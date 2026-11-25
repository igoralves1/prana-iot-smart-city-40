@echo off
setlocal
cd /d "%~dp0"
chcp 65001 >nul
echo ============================================================
echo    ADW300 Gateway - Prana IoT  :  INICIAR
echo ============================================================
echo.

echo [1/4] Instalando dependencias da ponte serial (pyserial, pyyaml)...
python -m pip install --quiet --disable-pip-version-check pyserial==3.5 pyyaml==6.0.1
if errorlevel 1 (
  echo.
  echo ERRO: Python nao encontrado. Instale o "Python para Windows" em python.org
  echo        e marque a opcao "Add python.exe to PATH" na instalacao.
  echo.
  pause
  exit /b 1
)

echo [2/4] Iniciando a ponte serial em uma janela separada...
echo        (necessaria no modo "meter". No modo "simulator" pode ignora-la.)
start "ADW300 Ponte Serial" cmd /k python "%~dp0bridge\serial_bridge.py"

echo [3/4] Subindo o container do aplicativo (na 1a vez pode demorar alguns minutos)...
docker compose up --build -d
if errorlevel 1 (
  echo.
  echo ERRO: o Docker nao respondeu. Abra o "Docker Desktop", espere ficar verde,
  echo        e rode este arquivo de novo.
  echo.
  pause
  exit /b 1
)

echo [4/4] Abrindo o navegador em http://localhost:8000 ...
timeout /t 6 /nobreak >nul
start "" http://localhost:8000

echo.
echo ============================================================
echo    PRONTO. A interface esta em:  http://localhost:8000
echo    Para PARAR tudo, rode:        PARAR-WINDOWS.bat
echo ============================================================
echo.
pause
