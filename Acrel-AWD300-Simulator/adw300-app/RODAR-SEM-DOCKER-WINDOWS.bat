@echo off
REM ----------------------------------------------------------------------
REM  ALTERNATIVA sem Docker: roda tudo com o Python do Windows.
REM  Use se o Docker Desktop nao estiver disponivel. Le a porta COM direto.
REM ----------------------------------------------------------------------
setlocal
cd /d "%~dp0app"
chcp 65001 >nul
echo Instalando dependencias Python (1a vez pode demorar)...
python -m pip install --quiet --disable-pip-version-check -r requirements.txt
if errorlevel 1 (
  echo ERRO: Python nao encontrado. Instale o "Python para Windows" (python.org, "Add to PATH").
  pause
  exit /b 1
)
set TRANSPORT=serial
set CONFIG_FILE=%~dp0config.yml
echo Abrindo o navegador em http://localhost:8000 ...
start "" http://localhost:8000
echo Iniciando o aplicativo (feche esta janela para parar)...
python -m uvicorn web:app --host 127.0.0.1 --port 8000
pause
