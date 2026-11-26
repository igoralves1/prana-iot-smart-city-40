# app/ — Aplicação ADW300 (setup + teste)

App web local (FastAPI + Vue 3 + d3) para **configurar** e **testar** o medidor Acrel
ADW300 4G que publica no AWS IoT Core. **O arranque é feito pela raiz do repositório**
(`docker compose up -d --build` → http://localhost:8000) — veja o `README.md` da raiz.

## Estrutura

| Caminho | O que é |
|---|---|
| `server/` | Código da aplicação e **contexto de build do Docker** (sem segredos): `web.py` (API/SPA), `gateway.py` (leitura Modbus + cliente AWS MQTT), `adw300_map.py` (mapa de registradores), `static/` (SPA Vue + d3 + telas). |
| `config.yml` | Configuração que você edita (modo, AWS on/off, porta serial, tópicos). Montado no container; `docker compose restart` após editar. |
| `certificates/` | Certificados/chaves AWS. **Fora do Git** — ver `certificates/README.md`. Vazio ⇒ app roda local/simulador. |
| `bridge/serial_bridge.py` | Ponte COM↔TCP para o **modo medidor real** (o Docker não vê a porta serial do host). Desnecessária no simulador. |
| `RODAR-SEM-DOCKER-WINDOWS.bat` | Alternativa sem Docker (Python do Windows). |

## Rodar sem Docker (dev)

```bash
cd server
pip install -r requirements.txt
uvicorn web:app --reload --port 8000
```
O `config.yml` e `certificates/` são lidos da pasta `app/` (um nível acima de `server/`).
