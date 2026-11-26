# Prana IoT — ADW300 → AWS IoT Core

Projeto da **Prana IoT** em torno do medidor de energia **Acrel ADW300 4G**, que publica
dados **direto no AWS IoT Core** pela rede celular (MQTT sobre TLS mútuo, X.509). O
repositório reúne: a **aplicação** de setup/teste, o **simulador**, a **engenharia reversa**
do software da Acrel, a **documentação do projeto** e o **material de referência** do fabricante.

---

## 🚀 Instalar e rodar (qualquer SO)

Pré-requisito único: **Docker**.
- Windows/macOS → **Docker Desktop** (https://www.docker.com/products/docker-desktop/), abra e espere ficar "Running".
- Linux → **Docker Engine + Compose** (https://docs.docker.com/engine/install/).

Na **raiz do repositório**:

```bash
git clone https://github.com/igoralves1/prana-iot-smart-city-40.git
cd prana-iot-smart-city-40
docker compose up -d --build
```

Abra **http://localhost:8000** ✅

- **Windows:** dê duplo-clique em `INICIAR-WINDOWS.bat` (parar: `PARAR-WINDOWS.bat`).
- **macOS/Linux:** `./start.sh` (parar: `./stop.sh`).
- **Porta 8000 ocupada?** `WEB_PORT=8099 docker compose up -d --build` → http://localhost:8099
  (Windows PowerShell: `$env:WEB_PORT=8099; docker compose up -d --build`).
- **Parar:** `docker compose down`.

> Sem medidor e sem certificados, o app sobe em **modo simulador** (dados fake) — ideal para
> conhecer a interface. Ninguém precisa de credenciais para clonar e rodar.

---

## 🗂️ Estrutura do repositório

```
prana-iot-smart-city-40/
├── README.md                 ← este documento (instalar / rodar / estrutura)
├── docker-compose.yml        ← ARRANQUE (raiz): docker compose up -d --build
├── INICIAR-WINDOWS.bat · PARAR-WINDOWS.bat   ← atalhos Windows
├── start.sh · stop.sh                        ← atalhos macOS/Linux
├── .gitignore
│
├── app/                      ← APLICAÇÃO (setup + teste do ADW300)
│   ├── server/               ← código (contexto Docker, sem segredos)
│   │   ├── web.py            ← API + SPA (FastAPI)
│   │   ├── gateway.py        ← leitura Modbus + cliente AWS MQTT
│   │   ├── adw300_map.py     ← mapa de registradores / payload
│   │   ├── static/           ← SPA Vue 3 + d3 + telas (screens/)
│   │   └── Dockerfile · requirements.txt
│   ├── bridge/               ← ponte serial COM↔TCP (modo medidor real)
│   ├── certificates/         ← certs AWS (fora do Git; só README)
│   └── config.yml            ← configuração editável
│
├── simulator/                ← SIMULADOR MQTT standalone (publisher + Docker próprio)
│
├── reverse-engineering/      ← ENGENHARIA REVERSA do software ACREL
│   ├── REGISTER-MAP.md       ← registradores Modbus (V1.49)
│   ├── CERTIFICATE-UPLOAD-T1.2.md  ← protocolo "ZSDR" de upload de certificados
│   ├── decompiled/           ← fonte descompilado V1.49
│   └── decompiled-T1.2/      ← fonte descompilado T1.2 (com import de certificados)
│
├── docs/                     ← DOCUMENTOS DO PROJETO
│   ├── business-plan-pcb-iot.*       pitch-deck-prana-iot.*
│   ├── requisitos-ped*.*             guia-adw300-aws.*
│   └── Monitoramento-Inteligente-Energia-Edificios-*.*
│
└── reference/                ← MATERIAL DE REFERÊNCIA (Acrel)
    ├── acrel-software/       ← softwares de ajuste (V1.49 e T1.2)
    ├── protocol-mqtt-4g/     ← protocolo MQTT/RS485 + telas + vídeo
    ├── datasheets/           ← manuais, payload, CTs, catálogos
    └── cases/                ← casos de aplicação (hospitalar CSE)
```

| Pasta | Grupo | O que é |
|---|---|---|
| **`app/`** | Aplicação | App web (FastAPI + Vue 3 + d3) de **setup e teste** do ADW300. `server/` = código (contexto Docker), `bridge/` = ponte serial (modo medidor real), `certificates/` = certificados AWS (fora do Git), `config.yml` = configuração. |
| **`simulator/`** | Simulação | Publicador MQTT **standalone** que emula o payload do ADW300 no AWS IoT Core (Docker próprio). |
| **`reverse-engineering/`** | Engenharia reversa | Código descompilado do software da Acrel (`decompiled/` V1.49 e `decompiled-T1.2/`), o **mapa de registradores Modbus** (`REGISTER-MAP.md`) e o **protocolo de upload de certificados** (`CERTIFICATE-UPLOAD-T1.2.md`). |
| **`docs/`** | Documentos | Entregáveis do projeto: plano de negócios, pitch deck, requisitos de P&D, guia ADW300→AWS e o estudo de monitoramento. |
| **`reference/`** | Referência Acrel | `acrel-software/` (softwares de ajuste), `protocol-mqtt-4g/` (protocolo MQTT/RS485), `datasheets/` (manuais e catálogos), `cases/` (casos de aplicação). |
| raiz | Arranque | `docker-compose.yml` + `start/stop.sh` + `*.bat` — subir o sistema. |

---

## ⚙️ Modos de uso

| Objetivo | Como |
|---|---|
| **Ver a interface** (padrão) | `docker compose up -d` → simulador, sem AWS. |
| **Publicar/receber no AWS IoT Core** | Coloque os 5 arquivos em `app/certificates/` (ver `app/certificates/README.md`) e em `app/config.yml` ligue `publish_to_aws`/`subscribe_from_aws`. |
| **Ler um ADW300 real** (USB-RS485) | `app/config.yml`: `mode: meter` + `serial_port`. No Windows, rode a ponte serial (`app/bridge/serial_bridge.py`). |
| **Configurar a placa p/ o AWS** | Aba **Setup** do app: gera os `.bin`, mostra o passo a passo (telas reais do software ACREL) e a engenharia reversa do upload de certificados. |

---

## 🔒 Segurança

Certificados e chaves X.509 **nunca** vão para o Git (ver `.gitignore`): são ignorados por
extensão em todo o repositório. As pastas `certificates/` ficam versionadas só com um README.

## 📡 Arquitetura (resumo)

```
ADW300 4G ──(MQTT/TLS mútuo via 4G)──▶ AWS IoT Core        ← produção
    ▲
    └──(USB-RS485, só no setup/teste)── Laptop (este app em Docker)
```
Em produção o medidor publica sozinho pela 4G; o laptop e o app são usados apenas para
**configurar** (endpoint, tópico, QoS, certificados) e **testar**.
