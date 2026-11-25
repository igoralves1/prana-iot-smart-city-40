# Acrel ADW300 4G ↔ AWS IoT Core

Conjunto completo para colocar o medidor **Acrel ADW300 4G** enviando dados
**direto** para o **AWS IoT Core** pela rede 4G (MQTT com TLS mútuo, certificado
X.509), além de ferramentas para **configurar, testar e simular** esse fluxo.

> O ADW300 4G (sem Wi‑Fi) tem chip celular e publica sozinho na nuvem. A
> configuração é feita **uma vez** pelo USB‑RS485 (software ACREL); depois o
> cabo e o PC são removidos e o medidor continua enviando pela 4G.

## Conteúdo da pasta

| Subpasta | O que é | Quando usar |
|---|---|---|
| **`adw300-app/`** | Aplicativo local (navegador + Docker, **Vue.js + d3.js**) para **configurar** o medidor pelo USB‑RS485 e **testar/visualizar** o fluxo (lê por Modbus, publica e **recebe** do AWS). | No campo, para preparar o medidor e acompanhar os dados. Comece por `adw300-app/README.md` e pelo guia em `adw300-app/docs/`. |
| **`simulator/`** | **Simulador** do medidor: containers Python (`publisher.py`) que publicam o payload de 73 grandezas no AWS IoT Core, como se fossem medidores reais. | Para validar o pipeline no AWS (regras, armazenamento, dashboards) **antes** de ter o medidor físico. Veja `simulator/README.md`. |

## Começo rápido

- **Configurar/testar um medidor real** → abra **`adw300-app/`**, siga
  **`adw300-app/docs/Guia-ADW300-AWS.pdf`** (passo a passo para quem não programa:
  Docker + Python no Windows, USB‑RS485, navegador).
- **Só simular dados no AWS** → entre em **`simulator/`** e rode `docker compose up`.

## Identidades de certificado (X.509)

- **ADW300‑Certs** — vão **dentro do medidor** (importados como `.bin` no software
  ACREL). clientID `Kurc-Building-Central`.
- **Web‑Certs** — identidade do **app/laptop** (clientID `Kurc-Building-WebApp`),
  para publicar e assinar. ClientIDs diferentes permitem medidor e app no AWS em
  paralelo.

Endpoint AWS IoT Core: `a13bm01k8tg2b8-ats.iot.us-east-1.amazonaws.com` (porta 8883).
Os certificados dão acesso ao seu AWS IoT Core — trate‑os como senhas.

## Referências

- Vídeo oficial Acrel — *ADW300 IoT Energy Meter connect to AWS IoT Platform*:
  https://www.youtube.com/watch?v=X7fWoVNajRg
- Manual oficial ADW300 (Modbus): https://www.acrelenergy.com/uploads/file/adw300-manual.pdf
- Documentos de referência do fabricante: pasta `../ACREL-DOCS` (inclui o software
  de ajuste `ADW300调试软件_V1.49.exe`).
