#!/usr/bin/env bash
# Sobe o app ADW300 (macOS / Linux). Windows: use INICIAR-WINDOWS.bat
set -e
cd "$(dirname "$0")"

PORT="${WEB_PORT:-8000}"

if ! command -v docker >/dev/null 2>&1; then
  echo "ERRO: Docker nao encontrado. Instale o Docker Desktop (Mac) ou Docker Engine (Linux)."
  exit 1
fi
if ! docker info >/dev/null 2>&1; then
  echo "ERRO: o Docker nao esta rodando. Abra o Docker Desktop e espere ficar pronto."
  exit 1
fi

echo "[1/2] Subindo o container (na 1a vez pode demorar alguns minutos)..."
WEB_PORT="$PORT" docker compose up -d --build

echo "[2/2] Pronto. Interface em: http://localhost:${PORT}"
# abre o navegador (ignora erro se nao houver)
( command -v open >/dev/null 2>&1 && sleep 4 && open "http://localhost:${PORT}" ) >/dev/null 2>&1 &
( command -v xdg-open >/dev/null 2>&1 && sleep 4 && xdg-open "http://localhost:${PORT}" ) >/dev/null 2>&1 &
echo "Para parar: ./stop.sh"
