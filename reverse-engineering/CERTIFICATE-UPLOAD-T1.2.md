# Engenharia reversa — `ADW300 configuration software EN T1.2`

Descompilado com **ilspycmd** (ICSharpCode.Decompiler 11.2). App .NET/VB.NET WinForms.
Fonte em `decompiled-T1.2/` (15 arquivos). Esta é a versão **nova, internacional (overseas)**
do software de ajuste — muito mais rica que a V1.49 e, principalmente, é a que **envia os
certificados para a placa**.

## Telas (JPEGs `ADW300-Degub-1/2-VT1.2`)

- **Tela 1 (Basic para):** versão **2298**, abas: Basic para · Network para · Log print ·
  EIOT · Multi-rate · DIDO Setting · Alarm para1 · Harmonic · Special Registers · WIFI …
- **Tela 2 (SSL/TLS):** aba **SSL/TLS** com 3 botões **`import Certificate 1/2/3`** e uma
  área de log. Também aparecem as abas **MQTT para**, **SSL/TLS**, **LoRaWAN** e
  **Microsoft MQTT** (perfis de nuvem prontos — AWS/Azure).

> É exatamente a tela que **faltava** na V1.49 (lá o grep por `证书/SSL/TLS/cert` deu zero).
> Agora temos o software **e** o protocolo.

## Como os certificados são enviados — protocolo "ZSDR" (NÃO é Modbus)

`Form1.cs`, handlers `importCertificate1_Click` / `2` / `3` (linhas ~18787–18998).
Cada botão abre um `OpenFileDialog` (filtro `*.bin`), lê o arquivo com
`File.ReadAllBytes` e manda pela **mesma porta serial RS485** (`Modbus.sp.Write`) em
**duas escritas**, usando um **protocolo binário proprietário próprio** — e não a função
Modbus 03H/10H. Buffer máximo `byte[6000]` ⇒ cada certificado deve ter **< ~5998 bytes**
(certs/chaves AWS em PEM cabem: ~1,2–1,8 kB).

### 1ª escrita — cabeçalho (7 bytes)
```
[0x5A][0x53][0x44][0x52][idx][lenHi][lenLo]
  Z     S     D     R
```
- `5A 53 44 52` = ASCII **"ZSDR"** (preâmbulo/magic).
- `idx` = índice do certificado: **1**, **2** ou **3** (o byte que diferencia os 3 botões).
- `lenHi lenLo` = tamanho do arquivo em bytes, **big-endian 16 bits** (`len>>8`, `len&0xFF`).
- Enviado com `Modbus.sp.Write(buf,0,7)` + `Thread.Sleep(100)`.

### 2ª escrita — dados + CRC
```
[ ...bytes crus do arquivo .bin... ][CRClo][CRChi]
```
- Os bytes do arquivo seguidos do **CRC16 Modbus** (init 0xFFFF, tabela `aucCRCHi/Lo`)
  calculado sobre **todo** o conteúdo (`GetStrCRC(array, len)`), byte baixo primeiro.
- Enviado com `Modbus.sp.Write(buf,0,len+2)` + `Thread.Sleep(2000)`.

### Resposta (ACK)
Sucesso = 7 bytes **"ZSDRACK"**:
```
[0x5A][0x53][0x44][0x52][0x41][0x43][0x4B]
  Z     S     D     R     A     C     K
```
Se bater → *"import certificateN success!"*; senão → *"import certificateN failed, retry please!"*.

`PortFlashWrite()` apenas pisca o LED de TX na UI — **sem efeito no protocolo**.

### Os 3 slots
Os botões são genéricos (`import Certificate 1/2/3`). A ordem convencional da Acrel
(vídeo oficial + fluxo mTLS) é:
1. **Amazon Root CA** → `AmazonRootCA1.bin`
2. **Certificado do dispositivo** → `device-certificate.bin`
3. **Chave privada** → `private-key.bin`

> Confirmar a ordem na própria tela/doc antes de automatizar — o índice `idx` (1/2/3) é o
> único diferenciador no frame.

## Consequência para o nosso app

- **Agora dá para automatizar o upload dos certificados** no nosso app: é um protocolo
  serial simples (ZSDR + tamanho + CRC16 + ACK) sobre a mesma ponte RS485 que já usamos.
  Pseudocódigo por slot `idx` e arquivo `data`:
  ```
  header = b"ZSDR" + bytes([idx, len>>8 & 0xFF, len & 0xFF])
  write(header); sleep(0.1)
  write(data + crc16_modbus(data)); sleep(2.0)
  ok = read(7) == b"ZSDRACK"
  ```
- Os `.bin` que o app já gera (seção 4 do Setup) são exatamente o payload — **bytes crus**
  do Root CA / certificado / chave.
- Isso **corrige** a conclusão anterior (baseada só na V1.49) de que "não dá para automatizar
  o import": não dava *naquela versão*; com a T1.2 o mecanismo está claro e é reprodutível.

## Parâmetros de texto (MQTT/Rede) continuam por Modbus 10H
`MQTT_Pro.cs` ainda monta frames Modbus função **16 (0x10)** com base de registrador
`0x70xx` (mesma família da V1.49: bloco MQTT em `0x7000`, rede/GPRS em `0x6000`). Ou seja,
o `REGISTER-MAP.md` da V1.49 segue válido para Domain/porta/tópico/ClientID/QoS; o que a
T1.2 **adiciona** é o canal de certificados acima (e abas novas: LoRaWAN, Microsoft MQTT/Azure).

Ferramenta: `~/.dotnet/tools/ilspycmd` via `dotnet` (roll-forward p/ .NET 11).
