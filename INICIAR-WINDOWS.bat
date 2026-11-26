@echo off
setlocal
cd /d "%~dp0"
chcp 65001 >nul
echo ============================================================
echo    ADW300 - Prana IoT  :  INICIAR  (Windows)
echo ============================================================
echo.

echo [1/3] Subindo o container do aplicativo (na 1a vez pode demorar alguns minutos)...
docker compose up --build -d
if errorlevel 1 (
  echo.
  echo ERRO: o Docker nao respondeu. Abra o "Docker Desktop", espere ficar verde,
  echo        e rode este arquivo de novo.
  echo.
  pause
  exit /b 1
)

echo [2/3] (Opcional) Modo medidor real: iniciando a ponte serial...
echo        No modo "simulator" (padrao) voce pode fechar essa janela.
start "ADW300 Ponte Serial" cmd /k python "%~dp0app\bridge\serial_bridge.py"

echo [3/3] Abrindo o navegador em http://localhost:8000 ...
timeout /t 6 /nobreak >nul
start "" http://localhost:8000

echo.
echo ============================================================
echo    PRONTO. Interface em:  http://localhost:8000
echo    Para PARAR, rode:      PARAR-WINDOWS.bat
echo ============================================================
echo.
pause
