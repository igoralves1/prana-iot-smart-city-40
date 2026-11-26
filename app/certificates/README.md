# certificates/ — certificados do AWS IoT Core

Esta pasta é **versionada vazia** (só este README). Os certificados e chaves
**não vão para o Git** (são segredos) — ver `.gitignore` na raiz do repositório.

O app **roda sem nada aqui**: fica em modo **local/simulador** (sem AWS). Para
ligar a publicação/assinatura no AWS IoT Core, coloque aqui os **5 arquivos**:

| Arquivo | O que é |
|---|---|
| `AmazonRootCA1.pem` | Amazon Root CA (baixe em https://www.amazontrust.com/repository/AmazonRootCA1.pem) |
| `Web-Certs-certificate.pem.crt` | certificado do app/laptop (identidade `Web-Certs`) |
| `Web-Certs-private.pem.key` | chave privada do app/laptop |
| `ADW300-Certs-certificate.pem.crt` | certificado do medidor (identidade `ADW300-Certs`) |
| `ADW300-Certs-private.pem.key` | chave privada do medidor |

Como obter (AWS IoT Core): crie 2 *things* (ou use certificados já criados), baixe
o *device certificate* + *private key* de cada um e anexe uma IoT Policy que permita
`Connect/Publish/Subscribe/Receive` nos tópicos usados (ex.: `Kurc-Building-*`).

Depois, no `config.yml`, troque `publish_to_aws` e `subscribe_from_aws` para `true`.

> Os nomes acima são os padrão do `config.yml`. Se usar outros nomes, ajuste os
> campos `ca_file` / `cert_file` / `key_file` no `config.yml`.
