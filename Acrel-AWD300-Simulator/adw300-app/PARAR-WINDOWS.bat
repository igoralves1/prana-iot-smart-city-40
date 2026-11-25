@echo off
cd /d "%~dp0"
chcp 65001 >nul
echo Parando o container do aplicativo...
docker compose down
echo.
echo Feche tambem a janela "ADW300 Ponte Serial" (se ainda estiver aberta).
echo Pronto.
pause
