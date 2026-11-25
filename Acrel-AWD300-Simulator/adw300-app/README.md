# ADW300 4G → AWS IoT Core — ferramenta local de Setup & Teste

Aplicativo local (navegador + Docker) para **configurar** o medidor Acrel
**ADW300 4G** a enviar os dados **direto** para o **AWS IoT Core** pela rede 4G,
e para **testar/visualizar** o fluxo de dados.

> O ADW300 4G tem chip celular e publica MQTT por conta própria na nuvem (TLS
> mútuo, certificado X.509). Este app **não** fica entre o medidor e a nuvem em
> produção — ele serve ao **setup** (via USB‑RS485) e ao **teste**. Depois da
> configuração, o USB e o PC são removidos e o medidor segue enviando sozinho.

## Como usar (Windows)

1. Instale **Docker Desktop** e **Python para Windows** (marque *Add to PATH*).
2. Ligue o medidor ao PC com o conversor **USB‑RS485 (CH343G)**:
   borne **21 → RS485+**, borne **22 → RS485−**.
3. Edite **`config.yml`**: `serial_port` (sua COM) e `device_id` (14 dígitos).
4. Dê duplo clique em **`INICIAR-WINDOWS.bat`**. O navegador abre em
   **http://localhost:8000**.
5. Siga o guia: **`docs/Guia-ADW300-AWS.pdf`** (passo a passo completo).
6. Para parar: **`PARAR-WINDOWS.bat`**.

Sem Docker? Use **`RODAR-SEM-DOCKER-WINDOWS.bat`** (só Python).

## Frontend

SPA em **Vue.js 3** + **d3.js** (bibliotecas embarcadas em `app/static/`, sem
internet em runtime). Abas:

- **Home** — explica todo o pipeline e a configuração (diagrama, passos, donut d3
  das 73 grandezas, valores de config e mapa Modbus).
- **Monitor / Teste** — lê o medidor (RS485) ou simula, com **gauges d3** e gráfico
  ao vivo; pode publicar no AWS para validar o pipeline.
- **Setup do ADW300** — testa a conexão RS485, lê/grava a comunicação, mostra os
  valores 4G/MQTT e **baixa os 3 certificados `.bin`** para o software ACREL.
- **Nuvem / AWS** — o app **publica e assina** o tópico ao mesmo tempo e mostra, ao
  vivo, os dados recebidos do AWS IoT Core (inclusive os do medidor pela 4G).

## Duas identidades de certificado

- **ADW300-Certs** — vão **dentro do medidor** (importados como `.bin` no software
  ACREL). Identidade do ADW300 ao conectar direto pela 4G (clientID `Kurc-Building-Central`).
- **Web-Certs** — identidade deste **app/laptop** (clientID `Kurc-Building-WebApp`)
  para publicar e assinar. ClientIDs diferentes = os dois conectam ao AWS em paralelo.

## Configuração do medidor (resumo — detalhes no guia)

Pelo software **ACREL** (`ADW300调试软件_V1.49.exe`, pasta `ACREL-DOCS`), via USB‑RS485:

| Tela | Valor |
|---|---|
| Serial | COM, **9600 8N1**, *Broadcast read* |
| Domain 1 | `a13bm01k8tg2b8-ats.iot.us-east-1.amazonaws.com` (porta **8883**) |
| MQTT | tópico de upload = `Kurc-Building-Central` |
| SSL/TLS | `AmazonRootCA1.bin` + `device-certificate.bin` + `private-key.bin` |

## Estrutura

```
adw300-app/
├─ INICIAR-WINDOWS.bat / PARAR-WINDOWS.bat / RODAR-SEM-DOCKER-WINDOWS.bat
├─ config.yml                  # configuração (edite aqui)
├─ docker-compose.yml
├─ certificates/               # certificados AWS IoT Core (X.509)
├─ app/                        # aplicativo web (FastAPI + Modbus + MQTT)
│  ├─ web.py  gateway.py  adw300_map.py  requirements.txt  Dockerfile
├─ bridge/serial_bridge.py     # ponte COM↔TCP (Windows vê a porta COM)
└─ docs/Guia-ADW300-AWS.pdf/.docx
```

## Referências

- Vídeo oficial Acrel — *ADW300 IoT Energy Meter connect to AWS IoT Platform*:
  https://www.youtube.com/watch?v=X7fWoVNajRg
- Manual oficial ADW300 (Modbus): https://www.acrelenergy.com/uploads/file/adw300-manual.pdf

> Os certificados dão acesso ao seu AWS IoT Core — trate-os como senhas.
