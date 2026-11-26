# prana-iot-smart-city-40

POC that simulates two ACREL ADW300 energy meters and publishes their payloads to the
AWS IoT Core MQTT broker over mutual TLS. Each simulated device runs in its own Docker
container, connects with its own X.509 certificate, and publishes to its own topic:

| Device / MQTT client ID     | Topic                       | Device ID (payload id 0) |
|-----------------------------|-----------------------------|--------------------------|
| `Kurc-Building-Central`     | `Kurc-Building-Central`     | `20201998111433`         |
| `Kurc-Building-Secondary-1` | `Kurc-Building-Secondary-1` | `20201998111434`         |

AWS IoT endpoint: `a13bm01k8tg2b8-ats.iot.us-east-1.amazonaws.com` (account `970547334705`, us-east-1).

## Project layout

```
├── Dockerfile                  # python:3.12-slim + paho-mqtt
├── docker-compose.yml          # one service per simulated device
├── publisher/
│   ├── publisher.py            # ADW300 simulator + MQTT publisher
│   └── requirements.txt
└── certificates/               # device certs, private keys, Amazon Root CA (not in git)
```

> Datasheets e a especificação do payload ficam em `../reference/datasheets/`
> (ex.: `../reference/datasheets/adw300-payload.pdf`).

## The payload

The simulator reproduces the two JSON frames a real ADW300 sends
(see [../reference/datasheets/adw300-payload.pdf](../reference/datasheets/adw300-payload.pdf)):

- **Frame 1** — device id + instantaneous data (point ids `0-35`): phase/line voltages,
  currents, active/reactive/apparent power, power factors, frequency, signal strength,
  cumulative energy counters, demand, ICCID, PT/CT ratios.
- **Frame 2** — device id + extended data (ids `36-72`): per-phase temperatures, residual
  current, DI mode, per-phase energy counters, distortion rates, imbalance,
  spike/peak/flat/valley energy, quadrant reactive energy.

```json
{"data": [{"tp": 1784308721362, "point": [{"id": 0, "val": "20201998111433"}, {"id": 1, "val": 123.9}, ...]}]}
```

Values are random but physically consistent: ~120/208 V three-phase service, power
computed from V x I x PF, ~60 Hz, and cumulative energy counters (ids 28-31, 42-53,
65-72) that only grow over time, like a real meter. Both frames are published every
`PUBLISH_INTERVAL` seconds (default 5) with QoS 1.

## Prerequisites

1. **Docker Desktop** running.
2. **Certificates** in `certificates/` (already in place, registered and ACTIVE in IoT Core):
   - `AmazonRootCA1.pem`
   - `ADW300-Certs-certificate.pem.crt` / `-private.pem.key`
   - `Web-Certs-certificate.pem.crt` / `-private.pem.key`
3. **IoT policy attached to both certificates** (already done — see AWS setup below).

## Turn ON

From the repo root:

```bash
docker compose up -d --build
```

This builds the image and starts both containers (`kurc-building-central` and
`kurc-building-secondary-1`). They reconnect automatically (`restart: unless-stopped`),
so they also come back after a reboot of Docker/the machine.

Watch the payloads being published:

```bash
docker compose logs -f              # both devices
docker logs -f kurc-building-central    # one device
```

A healthy log shows `Connected to ... (reason: Success)` followed by
`Published to 'Kurc-Building-Central': {"data": ...}` lines every ~5 seconds.

### See the data arrive in AWS

AWS Console → **IoT Core** (us-east-1) → **MQTT test client** → Subscribe to:

```
Kurc-Building-#
```

(or subscribe to `Kurc-Building-Central` and `Kurc-Building-Secondary-1` individually).

## Turn OFF

```bash
docker compose stop     # stop containers, keep them for a quick restart
docker compose start    # ...and turn back on without rebuilding
```

or tear everything down (containers + network; image stays cached):

```bash
docker compose down
```

## Configuration

Everything is set via environment variables in [docker-compose.yml](docker-compose.yml):

| Variable           | Purpose                                    | Default              |
|--------------------|--------------------------------------------|----------------------|
| `IOT_ENDPOINT`     | AWS IoT ATS endpoint                       | (set per service)    |
| `TOPIC`            | MQTT topic to publish to                   | (set per service)    |
| `DEVICE_NAME`      | MQTT client ID                             | same as `TOPIC`      |
| `DEVICE_ID`        | Meter serial reported in payload id 0      | `20201998111433`     |
| `CERT_FILE` / `KEY_FILE` / `CA_FILE` | TLS credentials (mounted from `certificates/`) | `/certs/...` |
| `PUBLISH_INTERVAL` | Seconds between publish cycles             | `5`                  |

After changing `publisher/publisher.py` or the compose file, apply with:

```bash
docker compose up -d --build
```

## AWS setup (done once, kept for reference)

Local AWS access uses the named CLI profile **`prana-igor`** (IAM user `prana-igor`,
`AWSIoTFullAccess`). Always pass `--profile prana-igor` — there is no default profile.

Both device certificates are registered and **ACTIVE** in IoT Core and have the policy
**`Kurc-Building-POC-Policy`** attached:

```json
{
  "Version": "2012-10-17",
  "Statement": [
    { "Effect": "Allow", "Action": "iot:Connect",
      "Resource": "arn:aws:iot:us-east-1:970547334705:client/Kurc-Building-*" },
    { "Effect": "Allow", "Action": "iot:Publish",
      "Resource": "arn:aws:iot:us-east-1:970547334705:topic/Kurc-Building-*" }
  ]
}
```

Note: the policy allows **connect + publish only**. If you later build a consumer that
subscribes with these certificates, add `iot:Subscribe` (on `topicfilter/...`) and
`iot:Receive` (on `topic/...`) statements. The console MQTT test client uses your IAM
session, not these certs, so it works without that.

Useful checks:

```bash
aws sts get-caller-identity --profile prana-igor          # credentials OK?
aws iot list-certificates --profile prana-igor            # certs ACTIVE?
aws iot list-attached-policies --profile prana-igor \
  --target arn:aws:iot:us-east-1:970547334705:cert/<certificateId>
```

The certificate ID in AWS equals the SHA-256 fingerprint of the local cert file:

```bash
openssl x509 -in certificates/ADW300-Certs-certificate.pem.crt \
  -noout -fingerprint -sha256 | cut -d= -f2 | tr -d ':' | tr 'A-F' 'a-f'
```

## Troubleshooting

- **`Disconnected (reason: Unspecified error)` immediately after connecting, repeatedly**
  — AWS accepted the TLS handshake but rejected the MQTT connection. Check that the
  certificate is ACTIVE and that its attached policy allows `iot:Connect` for the client
  ID and `iot:Publish` on the topic. This exact symptom is what happens when no policy
  is attached.
- **TLS/handshake errors** — verify cert/key pair and Root CA:
  `openssl s_client -connect a13bm01k8tg2b8-ats.iot.us-east-1.amazonaws.com:8883 \
   -CAfile certificates/AmazonRootCA1.pem -cert <cert> -key <key>`
  should end with `Verify return code: 0 (ok)`.
- **Policy changes don't seem to apply** — attachment can take a few seconds to
  propagate, and the client backs off between retries (up to ~2 min). Force an
  immediate reconnect with `docker compose restart`.
- **Nothing in the MQTT test client** — confirm you're in **us-east-1** and subscribed
  to `Kurc-Building-#`, and that the container logs show `Published ...` lines.
