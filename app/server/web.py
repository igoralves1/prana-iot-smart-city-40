"""
Backend (FastAPI) do app ADW300. Serve a SPA Vue 3 (pasta static/) e a API.
Abas: Home (pipeline/config), Monitor, Setup, Nuvem/AWS, Sobre.
"""
import os
import adw300_map as M
from fastapi import FastAPI, Request
from fastapi.responses import HTMLResponse, JSONResponse, Response
from fastapi.staticfiles import StaticFiles
from gateway import Gateway, load_config, _abs

HERE = os.path.dirname(os.path.abspath(__file__))
cfg = load_config()
gw = Gateway(cfg)
gw.start()

# Config 4G/MQTT do MEDIDOR (identidade ADW300-Certs)
setup4g = {
    "domain": cfg["aws"]["endpoint"], "port": cfg["aws"]["port"],
    "device_number": cfg["device_id"], "upload_interval": 5,
    "client_id": cfg["adw300"]["client_id"], "topic_data": cfg["adw300"]["topic"],
}
CERT_SRC = {
    "rootca": (cfg["adw300"]["ca_file"],   "AmazonRootCA1.bin"),
    "cert":   (cfg["adw300"]["cert_file"], "device-certificate.bin"),
    "key":    (cfg["adw300"]["key_file"],  "private-key.bin"),
}

# Nomes/unidades das 73 grandezas
NAMES = {pid: [M.field_name(pid), M.field_unit(pid)]
         for pid in range(0, 73) if pid in M.REG or pid in M.NOT_IN_MODBUS}

# Categorias do payload (para o donut da Home) -> (nome, qtd, cor)
PAYLOAD_CATEGORIES = [
    ["Energia (consumo/tarifa/quadrante)", 24, "#2f6fed"],
    ["Potencia, FP e Frequencia", 17, "#12a5a0"],
    ["Tensao", 6, "#4d8bf0"],
    ["Qualidade / Harmonicos", 8, "#f2a63b"],
    ["Status e Configuracao", 6, "#7d879c"],
    ["Demanda", 4, "#7a5cd0"],
    ["Termica (NTC)", 4, "#e08a3c"],
    ["Corrente", 3, "#33a06f"],
    ["Seguranca (corrente de fuga)", 1, "#e2574c"],
]

# Tabela de registradores Modbus (resumo) para a Home
REGISTER_TABLE = [
    ["Tensoes Ua/Ub/Uc e de linha", "0014H / 20..", "1", "/10", "V"],
    ["Correntes Ia/Ib/Ic", "001AH / 26..", "1", "/100", "A"],
    ["Potencia ativa A/B/C/total", "001EH / 30..", "2", "/1000", "kW"],
    ["Potencia reativa A/B/C/total", "0026H / 38..", "2", "/1000", "kvar"],
    ["Potencia aparente A/B/C/total", "002EH / 46..", "2", "/1000", "kVA"],
    ["Fator de potencia A/B/C/total", "0036H / 54..", "1", "/1000", "-"],
    ["Frequencia", "003BH / 59", "1", "/100", "Hz"],
    ["Energia ativa direta/reversa", "003EH / 62..", "2", "/100", "kWh"],
    ["Demanda ativa atual", "015AH / 346", "2", "/1000", "kW"],
    ["Temperaturas A/B/C ; N", "0164H/356 ; 0010H/16", "1", "/10", "°C"],
    ["Corrente residual (fuga)", "01C1H / 449", "1", "/1000", "A"],
    ["Sinal 4G", "01BFH / 447", "1", "-", "dBm"],
]

# Passos do pipeline (para a Home)
PIPELINE_STEPS = [
    ["1", "Preparar o AWS IoT Core", "Criar policy e thing, baixar certificados (device + chave + Root CA) e anotar o endpoint."],
    ["2", "Ligar o ADW300 ao laptop", "Conversor USB-RS485: borne 21 -> RS485+, borne 22 -> RS485-. Anotar a porta COM."],
    ["3", "Abrir este app (Docker)", "INICIAR-WINDOWS.bat sobe o container; o navegador abre em localhost:8000."],
    ["4", "Configurar o medidor", "No software ACREL: Domain 1 = endpoint AWS, MQTT = topico, SSL/TLS = 3 certificados .bin (baixados na aba Setup)."],
    ["5", "Verificar no AWS", "MQTT test client: assinar o topico e confirmar as mensagens. A aba Nuvem tambem mostra os dados recebidos."],
    ["6", "Desconectar o USB", "O medidor passa a enviar sozinho pela 4G; o PC e removido."],
]

app = FastAPI(title="ADW300 App")
app.mount("/static", StaticFiles(directory=os.path.join(HERE, "static")), name="static")


@app.get("/", response_class=HTMLResponse)
def index():
    return SHELL


@app.get("/api/info")
def info():
    return {
        "endpoint": cfg["aws"]["endpoint"], "port": cfg["aws"]["port"],
        "device_id": cfg["device_id"],
        "adw300": {"client_id": cfg["adw300"]["client_id"], "topic": cfg["adw300"]["topic"]},
        "web": {"client_id": cfg["aws"]["client_id"],
                "publish_topic": cfg["aws"]["publish_topic"],
                "subscribe_topic": cfg["aws"]["subscribe_topic"]},
        "names": NAMES, "categories": PAYLOAD_CATEGORIES,
        "register_table": REGISTER_TABLE, "pipeline": PIPELINE_STEPS,
        "aws_fields": M.AWS_FIELDS, "setup4g": setup4g,
    }


@app.get("/api/snapshot")
def snapshot():
    return JSONResponse(gw.snapshot())


@app.post("/api/publish")
def set_publish(on: bool = True):
    gw.set_publishing(on)
    return {"publishing": on}


@app.get("/api/setup/cert/{which}")
def get_cert_bin(which: str):
    if which not in CERT_SRC:
        return JSONResponse({"error": "certificado desconhecido"}, status_code=404)
    src, outname = CERT_SRC[which]
    path = _abs(src)
    if not os.path.exists(path):
        return JSONResponse({"error": f"arquivo nao encontrado: {src}"}, status_code=404)
    with open(path, "rb") as fh:
        data = fh.read()
    return Response(content=data, media_type="application/octet-stream",
                    headers={"Content-Disposition": f'attachment; filename="{outname}"'})


@app.get("/api/setup/4g")
def get_4g():
    return {"config": setup4g, "fields": M.AWS_FIELDS}


@app.post("/api/setup/4g")
async def post_4g(request: Request):
    body = await request.json()
    for k in setup4g:
        if k in body:
            setup4g[k] = body[k]
    return {"config": setup4g, "ok": True}


@app.post("/api/setup/read")
def setup_read():
    try:
        return {"ok": True, "config": gw.admin_read_config()}
    except Exception as exc:
        return JSONResponse({"ok": False, "error": str(exc)}, status_code=200)


@app.post("/api/setup/write")
async def setup_write(request: Request):
    try:
        body = await request.json()
        return {"ok": True, "applied": gw.admin_write_config(body)}
    except Exception as exc:
        return JSONResponse({"ok": False, "error": str(exc)}, status_code=200)


@app.post("/api/setup/raw")
async def setup_raw(request: Request):
    try:
        body = await request.json()
        res = gw.admin_raw(body.get("addr"), body.get("count", 1), body.get("write"))
        return {"ok": True, "result": res}
    except Exception as exc:
        return JSONResponse({"ok": False, "error": str(exc)}, status_code=200)


@app.post("/api/diag")
def diag():
    try:
        return {"ok": True, "diag": gw.diagnose()}
    except Exception as exc:
        return JSONResponse({"ok": False, "error": str(exc)}, status_code=200)


@app.on_event("shutdown")
def _shutdown():
    gw.stop()


import time as _t
_V = str(int(_t.time()))   # cache-busting: muda a cada start do app

SHELL = """<!doctype html><html lang="pt-br"><head>
<meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1">
<title>ADW300 · Prana IoT</title>
<link rel="stylesheet" href="/static/style.css?v=__V__">
</head><body>
<div id="app"></div>
<script src="/static/vue.global.prod.js"></script>
<script src="/static/d3.v7.min.js"></script>
<script src="/static/app.js?v=__V__"></script>
</body></html>""".replace("__V__", _V)
