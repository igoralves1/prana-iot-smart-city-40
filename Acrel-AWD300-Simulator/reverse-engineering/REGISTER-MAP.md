# Engenharia reversa do software ACREL `ADW300调试软件_V1.49.exe`

Descompilado com **ilspycmd** (ICSharpCode.Decompiler 11.2). É um app .NET/VB.NET
WinForms. O código‑fonte C# recuperado está em `decompiled/` (15 arquivos; os
relevantes: `mqtt_pro.cs`, `Form3.cs`, `Modbus.cs`, `Parameters.cs`).

Objetivo: descobrir **como o software grava os parâmetros 4G/MQTT no medidor**
pelo RS485, para automatizar isso no nosso app.

## Resultado: é Modbus padrão (03H ler / 10H escrever)

Todos os parâmetros são lidos/gravados por **Modbus‑RTU** (função **03H**/**10H**)
em blocos de registradores. Frame de escrita:
`[addr][0x10][regHi][regLo][0x00][qtd][byteCount][...dados...][CRClo][CRChi]`
(CRC16 Modbus). Strings são **ASCII**, preenchidas com `0x00` até o tamanho do campo.

### Bloco REDE / GPRS / 4G — base `0x6000` (`Form3.cs`)
| Registrador | Dec | Qtd | Campo |
|---|---|---|---|
| `0x6001` | 24577 | 1 | Intervalo de envio (min) — `上传间隔` |
| `0x600A` | 24586 | 2 | Endereço IP (4 octetos) — modo "IP地址" |
| `0x6010` | 24592 | 1 | **Porta** (16 bits) — `端口号` |
| `0x6013` | 24595 | 3 | Modo/região (`地域` IP×Domínio) + aux |
| `0x6016` | 24598 | ≤40 (80 B) | **Domain / endpoint** (ASCII) — `域名1` (modo "域名") |
| `0x60BB` | 24763 | 20 | WiFi SSID + senha (só variante WiFi) |

### Bloco MQTT — base `0x7000` (`mqtt_pro.cs`), strings ASCII de 60 B (30 reg) cada
| Registrador | Dec | Qtd | Campo (label na UI) |
|---|---|---|---|
| `0x7000` | 28672 | 30 | MQTT **username** |
| `0x701E` | 28702 | 30 | MQTT **password** |
| `0x703C` | 28732 | 30 | Tópico **"Alarm"** (theme‑1 / comando) |
| `0x705A` | 28762 | 30 | Tópico **"Data"** (theme‑2 / **upload dos dados**) |
| `0x7078` | 28792 | 30 | **ClientID** |
| `0x7096` | 28822 | 1 | **QoS** (0/1/2) |
| `0x7097` | 28823 | 30 | campo extra de 60 B (uso a confirmar) |

> Para o AWS por mTLS, `username`/`password` ficam vazios; o que importa é
> **Domain** (`0x6016`), **Porta** (`0x6010` = 8883), **Tópico Data** (`0x705A`) e
> **ClientID** (`0x7078`), com **QoS** (`0x7096`) = 1.

## Achado crítico: NÃO há import de certificado nesta versão

Busca por `证书`/`密钥`/`SSL`/`TLS`/`cert`/`.pem`/`.der`/`.crt` em **todos** os
arquivos descompilados retornou **zero**. Esta build (V1.49, 2024‑07) configura
rede/WiFi/MQTT por Modbus, mas **não tem a tela "SSL/TLS" de import de certificado**
que aparece no vídeo oficial da Acrel. Esse recurso está em **outra versão** do
software de ajuste (ou é feito por outro mecanismo/firmware).

## Consequência para o nosso app
- **Dá para automatizar no app** (via Modbus 10H, que já implementamos): Domain,
  Porta, Tópico de upload, ClientID, QoS e intervalo — com os endereços acima.
- **Não dá para automatizar o import dos certificados** com esta versão — ainda
  depende da versão do software ACREL que tem a aba SSL/TLS (a do vídeo). O app
  continua gerando os `.bin` prontos para esse import.

Ferramenta: `ilspycmd` (dotnet tool). Para reabrir o código: veja `decompiled/`.
