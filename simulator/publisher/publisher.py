"""ADW300 energy-meter simulator that publishes to AWS IoT Core over MQTT/TLS.

Generates the two data frames documented in adw300-payload.pdf:
  frame 1: device id + instantaneous electrical data (point ids 0-35)
  frame 2: device id + per-phase energy, temperature and power-quality data (ids 36-72)
"""

import json
import logging
import os
import random
import ssl
import sys
import time

import threading

import paho.mqtt.client as mqtt

ENDPOINT = os.environ["IOT_ENDPOINT"]
TOPIC = os.environ["TOPIC"]
DEVICE_NAME = os.environ.get("DEVICE_NAME", TOPIC)
DEVICE_ID = os.environ.get("DEVICE_ID", "20201998111433")
ICCID = os.environ.get("ICCID", "898604510919C0479914")
CA_FILE = os.environ.get("CA_FILE", "/certs/AmazonRootCA1.pem")
CERT_FILE = os.environ["CERT_FILE"]
KEY_FILE = os.environ["KEY_FILE"]
INTERVAL = float(os.environ.get("PUBLISH_INTERVAL", "5"))

logging.basicConfig(
    level=logging.INFO,
    format=f"%(asctime)s [{DEVICE_NAME}] %(levelname)s %(message)s",
)
log = logging.getLogger(__name__)


def r(lo, hi, nd=2):
    return round(random.uniform(lo, hi), nd)


class Adw300Simulator:
    """Keeps cumulative energy counters so consecutive frames look like a real meter."""

    def __init__(self):
        # kWh / kvarh counters, seeded so the meter doesn't start from zero
        self.fwd_active = r(40.0, 60.0)
        self.rev_active = r(5.0, 15.0)
        self.fwd_reactive = r(4.0, 8.0)
        self.rev_reactive = r(0.5, 1.5)
        self.phase_fwd_active = [r(13.0, 17.0) for _ in range(3)]
        self.phase_rev_active = [r(3.0, 4.5) for _ in range(3)]
        self.phase_fwd_reactive = [r(1.8, 2.4) for _ in range(3)]
        self.phase_rev_reactive = [r(0.1, 0.7) for _ in range(3)]
        self.quadrant_reactive = [0.0, r(5.0, 8.0), 0.0, r(0.5, 1.5)]

    def sample(self):
        """Take one electrical snapshot and advance the energy counters."""
        # 120/208 V three-phase service
        v_phase = [r(118.0, 124.0, 1) for _ in range(3)]
        v_line = [r(206.0, 210.0, 1) for _ in range(3)]
        current = [r(2.0, 30.0) for _ in range(3)]
        pf = [r(0.90, 1.00) for _ in range(3)]

        active = [round(v * i * f / 1000.0, 3) for v, i, f in zip(v_phase, current, pf)]
        apparent = [round(v * i / 1000.0, 3) for v, i in zip(v_phase, current)]
        reactive = [round(max(s**2 - p**2, 0.0) ** 0.5, 3) for s, p in zip(apparent, active)]

        total_active = round(sum(active), 3)
        total_reactive = round(sum(reactive), 3)
        total_apparent = round(sum(apparent), 3)
        total_pf = round(total_active / total_apparent, 2) if total_apparent else 0

        # advance counters as if INTERVAL seconds of this load elapsed
        hours = INTERVAL / 3600.0
        self.fwd_active += total_active * hours
        self.fwd_reactive += total_reactive * hours
        for ph in range(3):
            self.phase_fwd_active[ph] += active[ph] * hours
            self.phase_fwd_reactive[ph] += reactive[ph] * hours
        self.quadrant_reactive[1] += total_reactive * hours

        self.snapshot = {
            "v_phase": v_phase,
            "v_line": v_line,
            "current": current,
            "active": active,
            "reactive": reactive,
            "apparent": apparent,
            "pf": pf,
            "total_active": total_active,
            "total_reactive": total_reactive,
            "total_apparent": total_apparent,
            "total_pf": total_pf,
        }
        return self.snapshot

    def frame1(self):
        """Instantaneous data frame, point ids 0-35."""
        s = self.sample()
        points = [{"id": 0, "val": DEVICE_ID}]
        vals = (
            s["v_phase"]                                   # 1-3   phase voltages (V)
            + s["v_line"]                                  # 4-6   line voltages (V)
            + s["current"]                                 # 7-9   phase currents (A)
            + s["active"] + [s["total_active"]]            # 10-13 active power (kW)
            + s["reactive"] + [s["total_reactive"]]        # 14-17 reactive power (kvar)
            + s["apparent"] + [s["total_apparent"]]        # 18-21 apparent power (kVA)
            + s["pf"] + [s["total_pf"]]                    # 22-25 power factors
            + [r(59.95, 60.05)]                            # 26    frequency (Hz)
            + [random.randint(15, 31)]                     # 27    signal (dBm)
            + [round(self.fwd_active, 2)]                  # 28    fwd active energy (kWh)
            + [round(self.rev_active, 2)]                  # 29    rev active energy (kWh)
            + [round(self.fwd_reactive, 2)]                # 30    fwd reactive energy (kvarh)
            + [round(self.rev_reactive, 2)]                # 31    rev reactive energy (kvarh)
            + [round(s["total_active"] * r(0.85, 1.0), 2)] # 32    current active demand (kW)
        )
        points += [{"id": i + 1, "val": v} for i, v in enumerate(vals)]
        points += [
            {"id": 33, "val": ICCID},
            {"id": 34, "val": 1},  # PT ratio
            {"id": 35, "val": 1},  # CT ratio
        ]
        return self._wrap(points)

    def frame2(self):
        """Energy/temperature/power-quality frame, point ids 36-72."""
        s = self.snapshot
        points = [{"id": 0, "val": DEVICE_ID}]
        vals = (
            [r(28.0, 42.0, 1) for _ in range(4)]           # 36-39 A/B/C/N temperature (C)
            + [r(0.0, 0.03, 3)]                            # 40    residual current (A)
            + [random.randint(0, 15)]                      # 41    DI mode bitmask
        )
        for ph in range(3):                                # 42-53 per-phase energies
            vals += [
                round(self.phase_fwd_active[ph], 2),
                round(self.phase_rev_active[ph], 2),
                round(self.phase_fwd_reactive[ph], 2),
                round(self.phase_rev_reactive[ph], 2),
            ]
        vals += (
            [r(0.5, 3.0) for _ in range(3)]                # 54-56 voltage distortion (%)
            + [r(1.0, 5.0) for _ in range(3)]              # 57-59 current distortion (%)
            + [0, round(s["total_reactive"] * r(0.85, 1.0), 2), 0]  # 60-62 demands
            + [r(0.0, 2.0), r(0.0, 3.0)]                   # 63-64 voltage/current imbalance (%)
            + [round(self.fwd_active * f, 2)               # 65-68 spike/peak/flat/valley energy
               for f in (0.1, 0.25, 0.4, 0.25)]
            + [round(q, 2) for q in self.quadrant_reactive]  # 69-72 quadrant reactive energy
        )
        points += [{"id": i + 36, "val": v} for i, v in enumerate(vals)]
        return self._wrap(points)

    @staticmethod
    def _wrap(points):
        return {"data": [{"tp": int(time.time() * 1000), "point": points}]}


connected = threading.Event()


def on_connect(client, userdata, flags, reason_code, properties):
    log.info("Connected to %s (reason: %s)", ENDPOINT, reason_code)
    connected.set()


def on_disconnect(client, userdata, flags, reason_code, properties):
    connected.clear()
    log.warning(
        "Disconnected (reason: %s) - if this repeats immediately after connecting, "
        "check that the certificate is ACTIVE and its IoT policy allows "
        "iot:Connect for client '%s' and iot:Publish on topic '%s'",
        reason_code, DEVICE_NAME, TOPIC,
    )


def main():
    client = mqtt.Client(
        mqtt.CallbackAPIVersion.VERSION2, client_id=DEVICE_NAME, protocol=mqtt.MQTTv311
    )
    client.tls_set(
        ca_certs=CA_FILE,
        certfile=CERT_FILE,
        keyfile=KEY_FILE,
        tls_version=ssl.PROTOCOL_TLS_CLIENT,
    )
    client.on_connect = on_connect
    client.on_disconnect = on_disconnect

    log.info("Connecting to %s:8883 as client '%s' ...", ENDPOINT, DEVICE_NAME)
    client.connect(ENDPOINT, 8883, keepalive=60)
    client.loop_start()

    sim = Adw300Simulator()
    try:
        while True:
            if not connected.wait(timeout=30):
                log.error("Still not connected, waiting for broker to accept us ...")
                continue
            for frame in (sim.frame1(), sim.frame2()):
                payload = json.dumps(frame)
                info = client.publish(TOPIC, payload, qos=1)
                try:
                    info.wait_for_publish(timeout=10)
                except RuntimeError as exc:
                    log.error("Publish to '%s' failed: %s", TOPIC, exc)
                    break
                if info.is_published():
                    log.info("Published to '%s': %s", TOPIC, payload)
                else:
                    log.error("Publish to '%s' NOT confirmed (rc=%s)", TOPIC, info.rc)
                time.sleep(1)
            time.sleep(INTERVAL)
    except KeyboardInterrupt:
        pass
    finally:
        client.loop_stop()
        client.disconnect()


if __name__ == "__main__":
    sys.exit(main())
