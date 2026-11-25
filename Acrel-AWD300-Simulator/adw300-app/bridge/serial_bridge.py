"""
Ponte serial  <->  TCP  (executa NATIVAMENTE no Windows, fora do Docker).

Por que existe: o Docker Desktop no Windows (WSL2) nao enxerga portas COM/USB.
Esta ponte roda no Windows, abre a porta COM do conversor USB-RS485 e a
"espelha" numa porta TCP (padrao 5020). O container do aplicativo conecta nessa
porta TCP e fala Modbus-RTU com o medidor atraves dela.

Nao precisa editar este arquivo. Ele le a porta COM e a velocidade do
../config.yml. Se a porta configurada nao existir, tenta achar sozinho um
conversor CH340/CH343 (WCH).

Dependencias: pyserial, pyyaml  (o START-WINDOWS.bat instala automaticamente).
"""
import os
import socket
import sys
import threading
import time

import serial
import serial.tools.list_ports
import yaml

HERE = os.path.dirname(os.path.abspath(__file__))
CFG = os.path.normpath(os.path.join(HERE, "..", "config.yml"))


def load():
    with open(CFG, "r", encoding="utf-8") as fh:
        c = yaml.safe_load(fh) or {}
    return c


def autodetect():
    """Procura um conversor USB-RS485 conhecido (CH340/CH343/CP210x/FTDI)."""
    cands = []
    for p in serial.tools.list_ports.comports():
        desc = f"{p.description} {p.manufacturer or ''} {p.hwid or ''}".lower()
        if any(k in desc for k in ("ch340", "ch343", "ch34", "wch", "cp210", "ftdi", "usb-serial", "usb serial")):
            cands.append(p.device)
    return cands


def open_serial(cfg):
    port = str(cfg.get("serial_port", "COM3"))
    baud = int(cfg.get("baud_rate", 9600))
    parity = {"N": serial.PARITY_NONE, "E": serial.PARITY_EVEN,
              "O": serial.PARITY_ODD}.get(str(cfg.get("parity", "N")).upper(), serial.PARITY_NONE)
    stop = serial.STOPBITS_TWO if int(cfg.get("stopbits", 1)) == 2 else serial.STOPBITS_ONE
    available = [p.device for p in serial.tools.list_ports.comports()]
    if port.upper() == "AUTO" or port not in available:
        found = autodetect()
        if found:
            print(f"[ponte] porta '{port}' nao encontrada; usando detectada: {found[0]}")
            port = found[0]
        else:
            print(f"[ponte] AVISO: porta '{port}' nao encontrada e nenhum conversor detectado.")
            print(f"[ponte] portas disponiveis: {available or 'nenhuma'}")
    ser = serial.Serial(port=port, baudrate=baud, parity=parity, stopbits=stop,
                        bytesize=serial.EIGHTBITS, timeout=0.05)
    print(f"[ponte] COM aberta: {port} {baud} {cfg.get('parity','N')}{8}{int(cfg.get('stopbits',1))}")
    return ser


def pipe(src_read, dst_write, name, stop_evt):
    try:
        while not stop_evt.is_set():
            data = src_read()
            if data:
                dst_write(data)
    except Exception as exc:
        print(f"[ponte] fim do fluxo {name}: {exc}")
    finally:
        stop_evt.set()


def main():
    cfg = load()
    port_tcp = int(cfg.get("bridge_port", 5020))
    ser = open_serial(cfg)

    srv = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    srv.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    srv.bind(("0.0.0.0", port_tcp))
    srv.listen(1)
    print(f"[ponte] ouvindo em TCP 0.0.0.0:{port_tcp}  (o container vai conectar aqui)")
    print("[ponte] pronto. Deixe esta janela ABERTA enquanto usa o gateway.")

    while True:
        conn, addr = srv.accept()
        print(f"[ponte] container conectado: {addr}")
        conn.settimeout(0.05)
        stop_evt = threading.Event()

        def ser_to_tcp():
            def rd():
                return ser.read(256)
            pipe(rd, conn.sendall, "serial->tcp", stop_evt)

        def tcp_to_ser():
            def rd():
                try:
                    return conn.recv(256)
                except socket.timeout:
                    return b""
            pipe(rd, ser.write, "tcp->serial", stop_evt)

        t1 = threading.Thread(target=ser_to_tcp, daemon=True)
        t2 = threading.Thread(target=tcp_to_ser, daemon=True)
        t1.start(); t2.start()
        while not stop_evt.is_set():
            time.sleep(0.2)
        try:
            conn.close()
        except Exception:
            pass
        print("[ponte] container desconectado; aguardando nova conexao...")


if __name__ == "__main__":
    try:
        main()
    except KeyboardInterrupt:
        print("\n[ponte] encerrada.")
        sys.exit(0)
