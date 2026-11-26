#!/usr/bin/env bash
# Para o app ADW300 (macOS / Linux). Windows: use PARAR-WINDOWS.bat
set -e
cd "$(dirname "$0")"
echo "Parando o container..."
docker compose down
echo "Pronto."
