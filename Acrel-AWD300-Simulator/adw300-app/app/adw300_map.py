"""
Mapa de registradores Modbus do medidor Acrel ADW300 (4G).

Fonte autoritativa: manual oficial "ADW300 Manual" (Acrel, 28 paginas),
secao 6.2 MODBUS. Protocolo MODBUS-RTU, funcao 03H (leitura de holding
registers). Palavras de 32 bits sao big-endian (palavra alta primeiro).

Cada campo mapeia para o "id" do payload JSON do ADW300 (0..72), o mesmo
usado no MQTT nativo do medidor e no publisher.py deste projeto, de modo que
o dado publicado no AWS IoT Core fique identico ao do medidor real.

Formato de cada entrada:
    id: (endereco_decimal, n_palavras, com_sinal, divisor, unidade, nome_pt)

Regras de escala extraidas do manual:
  tensao  (20-25)  : /10    (1 casa decimal, V)
  corrente(26-28)  : /100   (2 casas, A)
  potencia(30-53)  : /1000  (3 casas, kW/kvar/kVA) - 32 bits, com sinal
  fator pot(54-57) : /1000  (com sinal)
  frequencia(59)   : /100   (Hz)
  energia (60-98)  : /100   (2 casas, kWh/kvarh) - 32 bits
  demanda (100,346+): /1000 (kW/kvar) - 32 bits, com sinal
  THD    (116-121) : /100   (%)
  desequilibrio(354-355): /100 (%)
  temperatura(16,356-358): /10 (0.1 C) - com sinal
  corrente residual(449): /1000 (A)
  sinal 4G(447)    : bruto (Int)
"""

# id -> (addr, words, signed, scale, unit, name)
REG = {
    1:  (20, 1, False, 10,   "V",     "Tensao fase A"),
    2:  (21, 1, False, 10,   "V",     "Tensao fase B"),
    3:  (22, 1, False, 10,   "V",     "Tensao fase C"),
    4:  (23, 1, False, 10,   "V",     "Tensao linha A-B"),
    5:  (24, 1, False, 10,   "V",     "Tensao linha B-C"),
    6:  (25, 1, False, 10,   "V",     "Tensao linha C-A"),
    7:  (26, 1, False, 100,  "A",     "Corrente fase A"),
    8:  (27, 1, False, 100,  "A",     "Corrente fase B"),
    9:  (28, 1, False, 100,  "A",     "Corrente fase C"),
    10: (30, 2, True,  1000, "kW",    "Potencia ativa A"),
    11: (32, 2, True,  1000, "kW",    "Potencia ativa B"),
    12: (34, 2, True,  1000, "kW",    "Potencia ativa C"),
    13: (36, 2, True,  1000, "kW",    "Potencia ativa total"),
    14: (38, 2, True,  1000, "kvar",  "Potencia reativa A"),
    15: (40, 2, True,  1000, "kvar",  "Potencia reativa B"),
    16: (42, 2, True,  1000, "kvar",  "Potencia reativa C"),
    17: (44, 2, True,  1000, "kvar",  "Potencia reativa total"),
    18: (46, 2, False, 1000, "kVA",   "Potencia aparente A"),
    19: (48, 2, False, 1000, "kVA",   "Potencia aparente B"),
    20: (50, 2, False, 1000, "kVA",   "Potencia aparente C"),
    21: (52, 2, False, 1000, "kVA",   "Potencia aparente total"),
    22: (54, 1, True,  1000, "",      "Fator de potencia A"),
    23: (55, 1, True,  1000, "",      "Fator de potencia B"),
    24: (56, 1, True,  1000, "",      "Fator de potencia C"),
    25: (57, 1, True,  1000, "",      "Fator de potencia total"),
    26: (59, 1, False, 100,  "Hz",    "Frequencia"),
    27: (447, 1, True, 1,    "dBm",   "Sinal 4G"),
    28: (62, 2, False, 100,  "kWh",   "Energia ativa direta"),
    29: (64, 2, False, 100,  "kWh",   "Energia ativa reversa"),
    30: (66, 2, False, 100,  "kvarh", "Energia reativa direta"),
    31: (68, 2, False, 100,  "kvarh", "Energia reativa reversa"),
    32: (346, 2, True, 1000, "kW",    "Demanda ativa atual"),
    34: (14, 1, False, 1,    "",      "PT (rel. tensao)"),
    35: (15, 1, False, 1,    "",      "CT (rel. corrente)"),
    36: (356, 1, True, 10,   "C",     "Temperatura fase A"),
    37: (357, 1, True, 10,   "C",     "Temperatura fase B"),
    38: (358, 1, True, 10,   "C",     "Temperatura fase C"),
    39: (16, 1, True,  10,   "C",     "Temperatura neutro N"),
    40: (449, 1, False, 1000, "A",    "Corrente residual (fuga)"),
    41: (58, 1, False, 1,    "",      "Estado das DI (bits)"),
    42: (72, 2, False, 100,  "kWh",   "Energia ativa direta - A"),
    43: (74, 2, False, 100,  "kWh",   "Energia ativa reversa - A"),
    44: (76, 2, False, 100,  "kvarh", "Energia reativa direta - A"),
    45: (78, 2, False, 100,  "kvarh", "Energia reativa reversa - A"),
    46: (82, 2, False, 100,  "kWh",   "Energia ativa direta - B"),
    47: (84, 2, False, 100,  "kWh",   "Energia ativa reversa - B"),
    48: (86, 2, False, 100,  "kvarh", "Energia reativa direta - B"),
    49: (88, 2, False, 100,  "kvarh", "Energia reativa reversa - B"),
    50: (92, 2, False, 100,  "kWh",   "Energia ativa direta - C"),
    51: (94, 2, False, 100,  "kWh",   "Energia ativa reversa - C"),
    52: (96, 2, False, 100,  "kvarh", "Energia reativa direta - C"),
    53: (98, 2, False, 100,  "kvarh", "Energia reativa reversa - C"),
    54: (116, 1, False, 100, "%",     "THD tensao A"),
    55: (117, 1, False, 100, "%",     "THD tensao B"),
    56: (118, 1, False, 100, "%",     "THD tensao C"),
    57: (119, 1, False, 100, "%",     "THD corrente A"),
    58: (120, 1, False, 100, "%",     "THD corrente B"),
    59: (121, 1, False, 100, "%",     "THD corrente C"),
    60: (348, 2, True, 1000, "kW",    "Demanda ativa reversa"),
    61: (350, 2, True, 1000, "kvar",  "Demanda reativa direta"),
    62: (352, 2, True, 1000, "kvar",  "Demanda reativa reversa"),
    63: (354, 1, False, 100, "%",     "Desequilibrio de tensao"),
    64: (355, 1, False, 100, "%",     "Desequilibrio de corrente"),
    65: (407, 2, False, 100, "kWh",   "Energia ativa - Ponta"),
    66: (409, 2, False, 100, "kWh",   "Energia ativa - Pico"),
    67: (411, 2, False, 100, "kWh",   "Energia ativa - Normal"),
    68: (413, 2, False, 100, "kWh",   "Energia ativa - Vale"),
}

# Campos presentes no payload mas NAO lidos via Modbus RS485:
#   0  device ID  -> vem da configuracao (device_id, codigo de barras de 14 digitos)
#   33 ICCID      -> identidade do chip 4G (apenas no modulo celular)
#   69-72 energia reativa por quadrante -> calculada internamente pelo firmware
NOT_IN_MODBUS = {
    0:  ("",      "ID do dispositivo"),
    33: ("",      "ICCID (chip 4G)"),
    69: ("kvarh", "Energia reativa 1o quadrante"),
    70: ("kvarh", "Energia reativa 2o quadrante"),
    71: ("kvarh", "Energia reativa 3o quadrante"),
    72: ("kvarh", "Energia reativa 4o quadrante"),
}

# Blocos contiguos lidos por ciclo (start_addr, count) - funcao 03H.
# Cobrem todos os enderecos usados acima com poucas transacoes Modbus.
BLOCKS = [
    (14, 108),   # 14..121: PT/CT, tempN, tensoes, correntes, potencias, FP, freq, energias, THD
    (346, 13),   # 346..358: demandas, desequilibrios, temperaturas A/B/C
    (407, 8),    # 407..414: energias por posto tarifario (ponta/pico/normal/vale)
    (447, 3),    # 447..449: sinal 4G, corrente residual (fuga)
]


def _to_int(words, signed):
    """Combina 1 ou 2 palavras de 16 bits (big-endian) em inteiro."""
    if len(words) == 1:
        v = words[0]
        if signed and v >= 0x8000:
            v -= 0x10000
        return v
    v = (words[0] << 16) | words[1]
    if signed and v >= 0x80000000:
        v -= 0x100000000
    return v


def decode(regmap):
    """
    regmap: dict {endereco -> valor_bruto_16bits} com todos os enderecos dos BLOCKS.
    Retorna dict {id: valor_em_unidade_real}.
    """
    out = {}
    for pid, (addr, words, signed, scale, unit, name) in REG.items():
        try:
            raw = [regmap[addr + i] for i in range(words)]
        except KeyError:
            continue
        val = _to_int(raw, signed) / scale
        out[pid] = round(val, 3)
    return out


def field_name(pid):
    if pid in REG:
        return REG[pid][5]
    if pid in NOT_IN_MODBUS:
        return NOT_IN_MODBUS[pid][1]
    return f"id {pid}"


def field_unit(pid):
    if pid in REG:
        return REG[pid][4]
    if pid in NOT_IN_MODBUS:
        return NOT_IN_MODBUS[pid][0]
    return ""


# Parametros de comunicacao padrao (manual secao 6.2 / 6.1)
DEFAULTS = {
    "baud_rate": 9600,   # reg 0001H: 1=1200, 3=4800, 4=9600 (padrao de fabrica comum: 9600)
    "parity": "N",       # reg 0004H
    "stopbits": 1,
    "bytesize": 8,
    "slave_id": 1,       # reg 0000H: endereco 1..247 (padrao 1)
    "function": "03H",   # leitura de holding registers
}

# ---------------------------------------------------------------------------
# Registradores de CONFIGURACAO graváveis via RS485 (funcao 10H/06H).
# Verificados no manual oficial (secao 6.2). Sao os parametros de comunicacao
# serial e de transformacao que a aplicacao pode ler e escrever com seguranca.
# (endereco_decimal, n_palavras)
# ---------------------------------------------------------------------------
CONFIG_REG = {
    "slave_address": (0, 1),   # 0000H  endereco Modbus do medidor (1..247)
    "baud_code":     (1, 1),   # 0001H  codigo de velocidade (ver BAUD_CODE)
    "parity_stop":   (4, 1),   # 0004H  byte alto=paridade(0/1/2) byte baixo=stop(0:1,1:2)
    "current_spec":  (13, 1),  # 000DH  especificacao de corrente
    "pt":            (14, 1),  # 000EH  relacao de transformacao de tensao (PT)
    "ct":            (15, 1),  # 000FH  relacao de transformacao de corrente (CT)
}
BAUD_CODE = {1: 1200, 2: 2400, 3: 4800, 4: 9600}   # reg 0001H (manual lista 2 como ~2400/3400)
BAUD_CODE_INV = {v: k for k, v in BAUD_CODE.items()}

# COMO O ADW300 4G CONECTA DIRETO AO AWS IoT CORE (confirmado no video oficial
# da Acrel "ADW300 IoT Energy Meter connect to AWS IoT Platform"):
# O medidor fala MQTT sobre TLS MUTUO (mTLS) com os certificados X.509 - os
# MESMOS da pasta certificates/. A configuracao e feita UMA VEZ pelo software de
# ajuste ACREL (ADW300调试软件_V1.49.exe) via USB-RS485, em 3 telas:
#   Network 1 / Domain 1 : colar o ENDPOINT do AWS IoT Core (porta 8883)
#   MQTT                 : definir o TOPICO de upload dos dados
#   SSL / TLS            : importar 3 arquivos renomeados para .bin:
#                           1) Amazon Root CA   2) device certificate   3) private key
# Depois disso o ADW300 publica sozinho pela 4G; o USB e o PC sao removidos.
# NAO ha gateway local, NAO ha WiFi, NAO ha usuario/senha (a autenticacao e por
# certificado). Os campos de texto (domain, topico) e a importacao dos .bin nao
# estao no mapa Modbus publico: sao gravados pelo software ACREL. Esta aplicacao
# monta os valores, gera os .bin e verifica o link RS485 com o medidor.
AWS_FIELDS = [
    ("domain",         "Domain 1 / Endpoint AWS", "endpoint ATS do AWS IoT Core"),
    ("port",           "Porta",                   "8883 (MQTT sobre TLS)"),
    ("device_number",  "Numero do dispositivo (14 digitos)", "codigo de barras do medidor"),
    ("upload_interval","Intervalo de envio (min)","1 a 15 minutos (padrao 5)"),
    ("client_id",      "ClientID",                "nome do 'thing' / numero de 14 digitos"),
    ("topic_data",     "Topico de upload (MQTT)", "ex.: Kurc-Building-Central"),
]
