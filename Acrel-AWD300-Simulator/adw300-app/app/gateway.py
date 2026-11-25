"""
Nucleo do gateway ADW300 -> AWS IoT Core.

Le o medidor Acrel ADW300 por Modbus-RTU (via RS485) ou gera dados em modo
simulador, monta o payload JSON de 73 campos (identico ao MQTT nativo do
medidor) e publica no AWS IoT Core por MQTT/TLS usando os certificados X.509.

Transportes de leitura:
  - simulator : gera valores realistas (nao precisa de hardware nem ponte)
  - serial    : abre a porta COM diretamente (execucao nativa no Windows)
  - tcp       : fala Modbus-RTU sobre TCP com a ponte serial (uso em Docker)
"""
import json
import os
import random
import ssl
import threading
import time
from collections import deque
from datetime import datetime, timezone

import yaml

import adw300_map as M

HERE = os.path.dirname(os.path.abspath(__file__))


# --------------------------------------------------------------------------
# Configuracao
# --------------------------------------------------------------------------
def load_config():
    """Precedencia: variavel de ambiente > config.yml > padrao embutido.

    Assim os .bat / docker-compose podem sobrescrever (ex.: TRANSPORT=serial no
    modo nativo), e o config.yml continua sendo o arquivo que o usuario edita.
    """
    path = os.environ.get("CONFIG_FILE", os.path.join(HERE, "..", "config.yml"))
    fcfg = {}
    if os.path.exists(path):
        with open(path, "r", encoding="utf-8") as fh:
            fcfg = yaml.safe_load(fh) or {}
    faws = fcfg.get("aws", {}) or {}

    def pick(env_key, cfg_key, default, cast=str):
        if env_key in os.environ:
            return cast(os.environ[env_key])
        if cfg_key in fcfg and fcfg[cfg_key] is not None:
            return cast(fcfg[cfg_key])
        return default

    def pick_aws(env_key, cfg_key, default, cast=str):
        if env_key in os.environ:
            return cast(os.environ[env_key])
        if cfg_key in faws and faws[cfg_key] is not None:
            return cast(faws[cfg_key])
        return default

    def as_bool(v):
        return str(v).lower() in ("1", "true", "yes", "on")

    cfg = {
        "mode": pick("MODE", "mode", "simulator"),
        "transport": pick("TRANSPORT", "transport", "tcp"),
        "serial_port": pick("SERIAL_PORT", "serial_port", "COM3"),
        "baud_rate": pick("BAUD_RATE", "baud_rate", M.DEFAULTS["baud_rate"], int),
        "parity": pick("PARITY", "parity", "N"),
        "stopbits": pick("STOPBITS", "stopbits", 1, int),
        "slave_id": pick("SLAVE_ID", "slave_id", M.DEFAULTS["slave_id"], int),
        "bridge_host": pick("BRIDGE_HOST", "bridge_host", "host.docker.internal"),
        "bridge_port": pick("BRIDGE_PORT", "bridge_port", 5020, int),
        "poll_interval": pick("POLL_INTERVAL", "poll_interval", 5, float),
        "publish_to_aws": pick("PUBLISH_TO_AWS", "publish_to_aws", True, as_bool),
        "subscribe_from_aws": pick("SUBSCRIBE_FROM_AWS", "subscribe_from_aws", True, as_bool),
        "device_id": pick("DEVICE_ID", "device_id", "20201998111433"),
        "iccid": pick("ICCID", "iccid", ""),
        "web_port": pick("WEB_PORT", "web_port", 8000, int),
        "aws": {
            "endpoint": pick_aws("IOT_ENDPOINT", "endpoint", "a13bm01k8tg2b8-ats.iot.us-east-1.amazonaws.com"),
            "port": pick_aws("IOT_PORT", "port", 8883, int),
            "client_id": pick_aws("CLIENT_ID", "client_id", "Kurc-Building-WebApp"),
            "publish_topic": pick_aws("PUBLISH_TOPIC", "publish_topic", "Kurc-Building-Central"),
            "subscribe_topic": pick_aws("SUBSCRIBE_TOPIC", "subscribe_topic", "Kurc-Building-Central"),
            "ca_file": pick_aws("CA_FILE", "ca_file", "certificates/AmazonRootCA1.pem"),
            "cert_file": pick_aws("CERT_FILE", "cert_file", "certificates/Web-Certs-certificate.pem.crt"),
            "key_file": pick_aws("KEY_FILE", "key_file", "certificates/Web-Certs-private.pem.key"),
        },
        "adw300": {
            "client_id": fcfg.get("adw300", {}).get("client_id", "Kurc-Building-Central"),
            "topic": fcfg.get("adw300", {}).get("topic", "Kurc-Building-Central"),
            "ca_file": fcfg.get("adw300", {}).get("ca_file", "certificates/AmazonRootCA1.pem"),
            "cert_file": fcfg.get("adw300", {}).get("cert_file", "certificates/ADW300-Certs-certificate.pem.crt"),
            "key_file": fcfg.get("adw300", {}).get("key_file", "certificates/ADW300-Certs-private.pem.key"),
        },
    }
    return cfg


def _abs(path):
    """Resolve caminho relativo a raiz do projeto (pasta do gateway)."""
    if os.path.isabs(path):
        return path
    return os.path.normpath(os.path.join(HERE, "..", path))


# --------------------------------------------------------------------------
# Leitura do medidor
# --------------------------------------------------------------------------
class MeterReader:
    def __init__(self, cfg, log):
        self.cfg = cfg
        self.log = log
        self.client = None
        self._kind = None

    def _ensure_client(self):
        from pymodbus.client import ModbusTcpClient, ModbusSerialClient
        from pymodbus.transaction import ModbusRtuFramer

        if self.client is not None:
            return
        t = self.cfg["transport"]
        if t == "tcp":
            self.client = ModbusTcpClient(
                host=self.cfg["bridge_host"], port=self.cfg["bridge_port"],
                framer=ModbusRtuFramer, timeout=3,
            )
            self._kind = f"tcp {self.cfg['bridge_host']}:{self.cfg['bridge_port']}"
        else:  # serial
            self.client = ModbusSerialClient(
                port=self.cfg["serial_port"], baudrate=self.cfg["baud_rate"],
                parity=self.cfg["parity"], stopbits=self.cfg["stopbits"],
                bytesize=8, timeout=3,
            )
            self._kind = f"serial {self.cfg['serial_port']}@{self.cfg['baud_rate']}"
        self.client.connect()

    def read(self):
        """Le todos os blocos e devolve dict {id: valor}. Lanca excecao em falha."""
        self._ensure_client()
        slave = self.cfg["slave_id"]
        regmap = {}
        for start, count in M.BLOCKS:
            rr = self.client.read_holding_registers(start, count, slave=slave)
            if rr.isError():
                raise IOError(f"Modbus erro no bloco {start}/{count}: {rr}")
            for i, val in enumerate(rr.registers):
                regmap[start + i] = val
        data = M.decode(regmap)
        return data

    def read_regs(self, addr, count, slave=None):
        self._ensure_client()
        rr = self.client.read_holding_registers(addr, count, slave=slave or self.cfg["slave_id"])
        if rr.isError():
            raise IOError(f"Modbus leitura {addr}/{count}: {rr}")
        return list(rr.registers)

    def write_reg(self, addr, value):
        self._ensure_client()
        wr = self.client.write_register(addr, int(value) & 0xFFFF, slave=self.cfg["slave_id"])
        if wr.isError():
            raise IOError(f"Modbus escrita reg {addr}={value}: {wr}")
        return True

    def close(self):
        if self.client:
            try:
                self.client.close()
            except Exception:
                pass
            self.client = None


# --------------------------------------------------------------------------
# Simulador (nao requer hardware) - espelha o publisher.py do projeto
# --------------------------------------------------------------------------
class Simulator:
    def __init__(self, interval):
        self.interval = interval
        self.fwd_active = round(random.uniform(40, 60), 2)
        self.rev_active = round(random.uniform(5, 15), 2)
        self.fwd_reactive = round(random.uniform(4, 8), 2)
        self.rev_reactive = round(random.uniform(0.5, 1.5), 2)
        self.ph_fa = [round(random.uniform(13, 17), 2) for _ in range(3)]
        self.ph_fr = [round(random.uniform(1.8, 2.4), 2) for _ in range(3)]

    def read(self):
        r = lambda a, b, n=2: round(random.uniform(a, b), n)
        vph = [r(118, 124, 1) for _ in range(3)]
        vln = [r(206, 210, 1) for _ in range(3)]
        cur = [r(2, 30) for _ in range(3)]
        pf = [r(0.90, 1.00) for _ in range(3)]
        act = [round(v * i * f / 1000, 3) for v, i, f in zip(vph, cur, pf)]
        app = [round(v * i / 1000, 3) for v, i in zip(vph, cur)]
        rea = [round(max(s * s - p * p, 0) ** 0.5, 3) for s, p in zip(app, act)]
        ta, tr, tp = round(sum(act), 3), round(sum(rea), 3), round(sum(app), 3)
        tpf = round(ta / tp, 2) if tp else 0
        h = self.interval / 3600.0
        self.fwd_active += ta * h
        self.fwd_reactive += tr * h
        for i in range(3):
            self.ph_fa[i] += act[i] * h
            self.ph_fr[i] += rea[i] * h
        d = {}
        d[1], d[2], d[3] = vph
        d[4], d[5], d[6] = vln
        d[7], d[8], d[9] = cur
        d[10], d[11], d[12], d[13] = act[0], act[1], act[2], ta
        d[14], d[15], d[16], d[17] = rea[0], rea[1], rea[2], tr
        d[18], d[19], d[20], d[21] = app[0], app[1], app[2], tp
        d[22], d[23], d[24], d[25] = pf[0], pf[1], pf[2], tpf
        d[26] = r(59.95, 60.05)
        d[27] = random.randint(15, 31)
        d[28] = round(self.fwd_active, 2)
        d[29] = round(self.rev_active, 2)
        d[30] = round(self.fwd_reactive, 2)
        d[31] = round(self.rev_reactive, 2)
        d[32] = round(ta * r(0.85, 1.0), 2)
        d[34], d[35] = 1, 1
        d[36], d[37], d[38], d[39] = (r(28, 42, 1) for _ in range(4))
        d[40] = r(0.0, 0.03, 3)
        d[41] = random.randint(0, 15)
        for ph in range(3):
            base = 42 + ph * 4
            d[base] = round(self.ph_fa[ph], 2)
            d[base + 1] = round(random.uniform(3, 4.5), 2)
            d[base + 2] = round(self.ph_fr[ph], 2)
            d[base + 3] = round(random.uniform(0.1, 0.7), 2)
        d[54], d[55], d[56] = (r(0.5, 3.0) for _ in range(3))
        d[57], d[58], d[59] = (r(1.0, 5.0) for _ in range(3))
        d[60], d[61], d[62] = 0, round(tr * r(0.85, 1.0), 2), 0
        d[63], d[64] = r(0, 2), r(0, 3)
        for i, f in zip(range(65, 69), (0.1, 0.25, 0.4, 0.25)):
            d[i] = round(self.fwd_active * f, 2)
        return d


# --------------------------------------------------------------------------
# Publicador AWS IoT Core (MQTT/TLS mutuo, igual ao publisher.py)
# --------------------------------------------------------------------------
class AwsClient:
    """Conecta ao AWS IoT Core com a identidade do LAPTOP (Web-Certs) e faz, na
    mesma conexao, PUBLICACAO (dados lidos/simulados) e ASSINATURA (recebe o que
    chega ao topico e mostra no app)."""

    def __init__(self, cfg, log):
        self.cfg = cfg
        self.log = log
        self.client = None
        self.connected = threading.Event()
        # estado da nuvem (dados RECEBIDOS por assinatura)
        self.cloud_values = {}            # {id: val}
        self.cloud_count = 0
        self.cloud_last = None            # ISO timestamp
        self.cloud_device = None          # device id (ponto 0) recebido
        self.cloud_log = deque(maxlen=60)

    def connect(self):
        import paho.mqtt.client as mqtt
        a = self.cfg["aws"]
        self.client = mqtt.Client(
            mqtt.CallbackAPIVersion.VERSION2,
            client_id=a["client_id"], protocol=mqtt.MQTTv311,
        )
        self.client.tls_set(
            ca_certs=_abs(a["ca_file"]), certfile=_abs(a["cert_file"]),
            keyfile=_abs(a["key_file"]), tls_version=ssl.PROTOCOL_TLS_CLIENT,
        )
        sub = self.cfg.get("subscribe_from_aws", True)
        topic_sub = a.get("subscribe_topic", a.get("topic"))

        def on_connect(c, u, f, rc, props):
            self.connected.set()
            self.log(f"AWS IoT conectado a {a['endpoint']} (rc={rc})")
            if sub and topic_sub:
                c.subscribe(topic_sub, qos=1)
                self.log(f"Assinando topico '{topic_sub}' (recebendo dados do AWS)")

        def on_disconnect(c, u, f, rc, props):
            self.connected.clear()
            self.log(f"AWS IoT desconectado (rc={rc})")

        def on_message(c, u, msg):
            try:
                self._ingest(json.loads(msg.payload.decode("utf-8")))
            except Exception as exc:
                self.log(f"Mensagem recebida ilegivel: {exc}")

        self.client.on_connect = on_connect
        self.client.on_disconnect = on_disconnect
        self.client.on_message = on_message
        self.log(f"Conectando ao AWS IoT {a['endpoint']}:{a['port']} como '{a['client_id']}'...")
        self.client.connect(a["endpoint"], a["port"], keepalive=60)
        self.client.loop_start()

    def _ingest(self, obj):
        """Processa uma mensagem recebida (formato payload do ADW300)."""
        for blk in obj.get("data", []):
            for pt in blk.get("point", []):
                pid = pt.get("id")
                if pid == 0:
                    self.cloud_device = pt.get("val")
                elif isinstance(pid, int):
                    self.cloud_values[pid] = pt.get("val")
        self.cloud_count += 1
        self.cloud_last = datetime.now(timezone.utc).isoformat(timespec="seconds")
        self.cloud_log.append(f"{datetime.now().strftime('%H:%M:%S')}  recebido do AWS "
                              f"(dev {self.cloud_device}, {len(self.cloud_values)} grandezas)")

    def publish_frames(self, data, device_id, iccid):
        a = self.cfg["aws"]
        topic = a.get("publish_topic", a.get("topic"))
        ok = True
        for fr in self._build_frames(data, device_id, iccid):
            info = self.client.publish(topic, json.dumps(fr), qos=1)
            try:
                info.wait_for_publish(timeout=10)
            except Exception as exc:
                self.log(f"Falha ao publicar: {exc}")
                ok = False
                break
            if not info.is_published():
                ok = False
        return ok

    @staticmethod
    def _build_frames(data, device_id, iccid):
        f1 = [{"id": 0, "val": device_id}]
        for pid in range(1, 36):
            if pid in data:
                f1.append({"id": pid, "val": data[pid]})
        if iccid:
            f1.append({"id": 33, "val": iccid})
        f2 = [{"id": 0, "val": device_id}]
        for pid in range(36, 73):
            if pid in data:
                f2.append({"id": pid, "val": data[pid]})
        tp = int(time.time() * 1000)
        return [{"data": [{"tp": tp, "point": f1}]},
                {"data": [{"tp": tp, "point": f2}]}]

    def cloud_snapshot(self):
        return {"values": dict(self.cloud_values), "count": self.cloud_count,
                "last": self.cloud_last, "device": self.cloud_device,
                "topic": self.cfg["aws"].get("subscribe_topic"),
                "log": list(self.cloud_log)}

    def close(self):
        if self.client:
            try:
                self.client.loop_stop()
                self.client.disconnect()
            except Exception:
                pass


# --------------------------------------------------------------------------
# Gateway: laco principal + estado compartilhado para a UI
# --------------------------------------------------------------------------
class Gateway:
    def __init__(self, cfg):
        self.cfg = cfg
        self.logs = deque(maxlen=200)
        self.lock = threading.Lock()
        self.io_lock = threading.Lock()   # serializa acesso ao barramento Modbus
        self.latest = {}          # {id: val}
        self.status = {
            "mode": cfg["mode"],
            "transport": cfg["transport"],
            "meter_ok": False,
            "meter_detail": "",
            "aws_connected": False,
            "publishing": bool(cfg["publish_to_aws"]),
            "subscribing": bool(cfg.get("subscribe_from_aws")),
            "last_read": None,
            "last_publish": None,
            "read_count": 0,
            "publish_count": 0,
            "error": "",
        }
        self.reader = None
        self.sim = None
        self.aws = None
        self._stop = threading.Event()
        self._thread = None

    def log(self, msg):
        line = f"{datetime.now().strftime('%H:%M:%S')}  {msg}"
        with self.lock:
            self.logs.append(line)
        print(line, flush=True)

    def set_publishing(self, on):
        with self.lock:
            self.status["publishing"] = bool(on)
        self.log(f"Publicacao AWS {'LIGADA' if on else 'DESLIGADA'}")

    def snapshot(self):
        with self.lock:
            snap = {"status": dict(self.status),
                    "values": dict(self.latest),
                    "logs": list(self.logs)[-60:]}
        snap["cloud"] = self.aws.cloud_snapshot() if self.aws else {
            "values": {}, "count": 0, "last": None, "device": None,
            "topic": self.cfg["aws"].get("subscribe_topic"), "log": []}
        with self.lock:
            snap["status"]["subscribing"] = bool(
                self.cfg.get("subscribe_from_aws") and self.status["aws_connected"])
        return snap

    # ---- Administracao / Setup (leitura e escrita de registradores) ----
    def admin_available(self):
        return self.reader is not None

    def admin_read_config(self):
        """Le os registradores de comunicacao do medidor (confirma link RS485)."""
        if not self.reader:
            raise RuntimeError("Modo simulador: conecte o medidor real (mode: meter) para ler a configuracao.")
        with self.io_lock:
            addr = self.reader.read_regs(*M.CONFIG_REG["slave_address"])[0]
            baud_code = self.reader.read_regs(*M.CONFIG_REG["baud_code"])[0]
            parity_stop = self.reader.read_regs(*M.CONFIG_REG["parity_stop"])[0]
            pt = self.reader.read_regs(*M.CONFIG_REG["pt"])[0]
            ct = self.reader.read_regs(*M.CONFIG_REG["ct"])[0]
        par = {0: "N", 1: "E", 2: "O"}.get((parity_stop >> 8) & 0xFF, "N")
        stop = 2 if (parity_stop & 0xFF) == 1 else 1
        self.log(f"Setup: config lida do medidor (addr={addr}, baud={M.BAUD_CODE.get(baud_code, '?')}, {par}{8}{stop})")
        return {
            "slave_address": addr,
            "baud_code": baud_code,
            "baud_rate": M.BAUD_CODE.get(baud_code, None),
            "parity": par, "stopbits": stop,
            "pt": pt, "ct": ct,
        }

    def admin_write_config(self, changes):
        """Escreve parametros de comunicacao verificados. changes: dict de chaves
        em {slave_address, baud_rate, pt, ct}. Retorna lista do que foi aplicado."""
        if not self.reader:
            raise RuntimeError("Modo simulador: conecte o medidor real para gravar.")
        applied = []
        with self.io_lock:
            if "slave_address" in changes:
                v = int(changes["slave_address"])
                if not (1 <= v <= 247):
                    raise ValueError("Endereco Modbus deve ser 1..247")
                self.reader.write_reg(M.CONFIG_REG["slave_address"][0], v)
                applied.append(f"endereco Modbus = {v}")
            if "baud_rate" in changes:
                code = M.BAUD_CODE_INV.get(int(changes["baud_rate"]))
                if code is None:
                    raise ValueError("Baud invalido (use 1200/2400/4800/9600)")
                self.reader.write_reg(M.CONFIG_REG["baud_code"][0], code)
                applied.append(f"baud = {changes['baud_rate']}")
            if "pt" in changes:
                self.reader.write_reg(M.CONFIG_REG["pt"][0], int(changes["pt"]))
                applied.append(f"PT = {changes['pt']}")
            if "ct" in changes:
                self.reader.write_reg(M.CONFIG_REG["ct"][0], int(changes["ct"]))
                applied.append(f"CT = {changes['ct']}")
        self.log("Setup: gravado -> " + "; ".join(applied))
        return applied

    def admin_raw(self, addr, count=1, write=None):
        """Leitura/escrita avancada de registrador arbitrario (para quando o mapa
        de registradores 4G/MQTT for obtido com a ACREL)."""
        if not self.reader:
            raise RuntimeError("Modo simulador: conecte o medidor real.")
        with self.io_lock:
            if write is None:
                regs = self.reader.read_regs(int(addr), int(count))
                return {"addr": int(addr), "values": regs}
            self.reader.write_reg(int(addr), int(write))
            self.log(f"Setup(avancado): reg {addr} = {write}")
            return {"addr": int(addr), "written": int(write)}

    def diagnose(self, scan=True):
        """Diagnostica o link RS485: (1) a ponte/COM abriu? (2) o medidor responde?
        Faz varredura de endereco se nao responder no configurado. Usa um cliente
        proprio de timeout curto e libera o cliente do laco (a ponte aceita 1 conexao)."""
        from pymodbus.client import ModbusTcpClient, ModbusSerialClient
        from pymodbus.transaction import ModbusRtuFramer
        cfg = self.cfg
        res = {"mode": cfg["mode"], "transport": cfg["transport"],
               "serial_port": cfg.get("serial_port"), "baud": cfg.get("baud_rate"),
               "slave_id": cfg.get("slave_id"),
               "link": {"ok": False, "detail": ""},
               "modbus": {"ok": False, "detail": "", "address": None},
               "scan": [], "suggestions": [], "note": ""}
        if cfg["mode"] == "simulator":
            res["note"] = ("Modo SIMULADOR: nao ha RS485 fisico. Troque para mode: meter "
                           "no config.yml (e tenha o medidor + conversor ligados) para diagnosticar.")
            return res
        with self.io_lock:
            if self.reader:
                self.reader.close()          # libera a ponte (1 conexao por vez)
            if cfg["transport"] == "tcp":
                cli = ModbusTcpClient(host=cfg["bridge_host"], port=cfg["bridge_port"],
                                      framer=ModbusRtuFramer, timeout=0.7)
                kind = f"ponte serial {cfg['bridge_host']}:{cfg['bridge_port']}"
            else:
                cli = ModbusSerialClient(port=cfg["serial_port"], baudrate=cfg["baud_rate"],
                                         parity=cfg["parity"], stopbits=cfg["stopbits"],
                                         bytesize=8, timeout=0.7)
                kind = f"COM {cfg['serial_port']} @ {cfg['baud_rate']}"
            try:
                link = bool(cli.connect())
            except Exception as exc:
                link = False
                res["link"]["detail"] = str(exc)
            res["link"]["ok"] = link
            if not link:
                res["link"]["detail"] = res["link"]["detail"] or (kind + " nao abriu")
                if cfg["transport"] == "tcp":
                    res["suggestions"] = [
                        "A ponte serial (serial_bridge.py) nao esta rodando ou nao abriu a COM.",
                        "Abra/olhe a janela 'ADW300 Ponte Serial' e confirme que a COM abriu.",
                        "Confira a porta COM no Gerenciador de Dispositivos e em config.yml (serial_port).",
                        "Se a COM nao aparece, instale o driver CH343SER do conversor."]
                else:
                    res["suggestions"] = [
                        "A porta COM nao abriu. Confira serial_port no config.yml e o driver CH343SER.",
                        "Veja se outro programa (ex.: software ACREL) esta usando a COM."]
            else:
                res["link"]["detail"] = kind + " aberto"

                def tryread(a):
                    try:
                        rr = cli.read_holding_registers(0, 1, slave=a)
                        return (not rr.isError()), rr
                    except Exception:
                        return False, None

                ok, rr = tryread(cfg["slave_id"])
                if ok:
                    res["modbus"] = {"ok": True, "address": cfg["slave_id"],
                                     "detail": f"Medidor respondeu no endereco {cfg['slave_id']} (reg0={rr.registers[0]})."}
                elif scan:
                    found = []
                    for a in range(1, 17):
                        o, _ = tryread(a)
                        if o:
                            found.append(a)
                    res["scan"] = found
                    if found:
                        res["modbus"] = {"ok": True, "address": found[0],
                                         "detail": f"Medidor encontrado no endereco {found[0]} "
                                                   f"(diferente do configurado {cfg['slave_id']})."}
                        res["suggestions"] = [f"Ajuste slave_id para {found[0]} em config.yml e reinicie, "
                                              f"ou grave o endereco desejado na secao 2 (Setup)."]
                    else:
                        res["suggestions"] = [
                            "Cabo/COM OK, mas o medidor NAO respondeu em nenhum endereco (1-16).",
                            "Inverta os fios A/B (bornes 21 e 22) — par trocado e a causa mais comum.",
                            "Velocidade: o medidor pode estar em 1200 e nao 9600. Mude baud_rate em config.yml e reinicie.",
                            "Confirme que o medidor esta energizado (85-265 V).",
                            "Em linha longa, use resistor de terminacao de 120 ohm nas pontas."]
                try:
                    cli.close()
                except Exception:
                    pass
            if self.reader:
                self.reader.client = None     # forca reconexao no proximo ciclo do laco
        self.log("Diagnostico RS485 executado: "
                 + ("link OK" if res["link"]["ok"] else "link FALHOU")
                 + " / " + ("medidor OK" if res["modbus"]["ok"] else "medidor sem resposta"))
        return res

    def start(self):
        self._thread = threading.Thread(target=self._run, daemon=True)
        self._thread.start()

    def _run(self):
        cfg = self.cfg
        if cfg["mode"] == "simulator":
            self.sim = Simulator(cfg["poll_interval"])
            self.log("Modo SIMULADOR ativo (sem hardware).")
        else:
            self.reader = MeterReader(cfg, self.log)
            self.log("Modo MEDIDOR: leitura por Modbus-RTU/RS485.")

        if cfg["publish_to_aws"] or cfg.get("subscribe_from_aws"):
            self.aws = AwsClient(cfg, self.log)
            try:
                self.aws.connect()
            except Exception as exc:
                self.log(f"Erro iniciando AWS: {exc}")

        while not self._stop.is_set():
            # ---- leitura ----
            try:
                if self.sim:
                    data = self.sim.read()
                else:
                    with self.io_lock:
                        data = self.reader.read()
                with self.lock:
                    self.latest = data
                    self.status["meter_ok"] = True
                    self.status["meter_detail"] = (
                        "simulador" if self.sim else self.reader._kind)
                    self.status["last_read"] = datetime.now(timezone.utc).isoformat(timespec="seconds")
                    self.status["read_count"] += 1
                    self.status["error"] = ""
            except Exception as exc:
                with self.lock:
                    self.status["meter_ok"] = False
                    self.status["error"] = str(exc)
                self.log(f"Falha de leitura: {exc}")
                if self.reader:
                    self.reader.close()
                time.sleep(cfg["poll_interval"])
                continue

            # ---- publicacao ----
            with self.lock:
                publishing = self.status["publishing"]
                aws_up = self.aws.connected.is_set() if self.aws else False
                self.status["aws_connected"] = aws_up
            if publishing and self.aws and aws_up:
                ok = self.aws.publish_frames(self.latest, cfg["device_id"], cfg["iccid"])
                if ok:
                    with self.lock:
                        self.status["last_publish"] = datetime.now(timezone.utc).isoformat(timespec="seconds")
                        self.status["publish_count"] += 1

            time.sleep(cfg["poll_interval"])

    def stop(self):
        self._stop.set()
        if self.reader:
            self.reader.close()
        if self.aws:
            self.aws.close()
