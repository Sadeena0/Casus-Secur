from collections import defaultdict
from scapy.sendrecv import sniff
from database import *
from datetime import datetime, timezone
from flask import Flask, request
from dotenv import load_dotenv
from pathlib import Path
from scapy.layers.inet import IP, TCP, UDP
import platform
import threading
import psutil
import requests
import json
import os
import re

bytes_sent = defaultdict(int)

load_dotenv()
API_KEY = os.getenv('API_KEY')
last_check = datetime.now(timezone.utc)

match open_connection():
    case 0:
        pass
    case 1:
        print("Error connecting to database. Terminating service.")
        exit()
    case 2:
        print("Empty database detected. Initializing database.")
        intialise_database()

app = Flask(__name__)

def network_scan():
    global last_check
    connections = psutil.net_connections(kind='inet')

    log_entries = []

    for conn in connections:
        if (conn.status == 'ESTABLISHED' and conn.raddr and
                conn.raddr[0] not in ["127.0.0.1", "::1"]
                and not conn.raddr[0].startswith("192.168")):
            pid = conn.pid
            if pid:
                try:
                    process = psutil.Process(pid)
                    app_name = process.name()
                except psutil.NoSuchProcess:
                    app_name = "Unknown"
            else:
                app_name = "System"

            sent = bytes_sent.get((conn.raddr[0], conn.raddr[1]), 0)
            log_entries.append((conn.raddr[0], conn.raddr[1], pid, app_name, sent))
    if platform.system() == "Linux":
        auth_log = Path("/var/log/auth.log")
        parsed_log = []
        if auth_log.is_file():
            with open(auth_log, "r") as f:
                for line in f:
                    if "sshd" not in line:
                        continue
                    try:
                        timestamp_str = line[:32]
                        timestamp = datetime.fromisoformat(timestamp_str)
                        if timestamp > last_check:
                            match = re.search(r"from (\d+\.\d+\.\d+\.\d+) port (\d+)", line.strip())
                            if match:
                                ip = match.group(1)
                                parsed_log.append(ip)
                    except Exception as e:
                        print(f"Error parsing line: {line.strip()}, {e}")
        if parsed_log:
            parsed_log = list(dict.fromkeys(parsed_log))
            for ip in parsed_log:
                log_entries.append((ip, -1,  -1, "SSH", 0))
    add_records(log_entries)
    last_check = datetime.now(timezone.utc)
    threading.Timer(1, network_scan).start()

def fetch_locations():
    missing = missing_location()[:100]
    if missing:
        url = "http://ip-api.com/batch?fields=status,country,countryCode,region,regionName,city,isp,org,query,lat,lon"
        data = json.dumps(missing)
        response = requests.post(url, data=data)
        update_locations(response.json())
    threading.Timer(10, fetch_locations).start()

@app.route("/getdb", methods=["GET"])
def get_database_endpoint():
    key = request.args.get("key")
    if key is None:
        return "No API key provided.", 400
    if key not in API_KEY:
        return "Invalid API key.", 401
    else:
        data = json.dumps(fetch_records())
        return data, 200

@app.route("/cleardb", methods=["POST"])
def clear_database_endpoint():
    key = request.args.get("key")
    if key is None:
        return "No API key provided.", 400
    if key not in API_KEY:
        return "Invalid API key.", 401
    else:
        clear_records()
        return "Database cleared.", 200

def packet_callback(packet):
    if IP in packet and (TCP in packet or UDP in packet):
        dst_ip = packet[IP].dst
        dst_port = packet[TCP].dport if TCP in packet else packet[UDP].dport
        size = len(packet)
        bytes_sent[(dst_ip, dst_port)] += size

def start_sniffing():
    try:
        sniff(filter="ip", prn=packet_callback, store=0)
    except Exception as e:
        print("No drivers detected. Byte analysis unavailable.")
        print(f"Error: {e}")

sniff_thread = threading.Thread(target=start_sniffing, daemon=True)
sniff_thread.start()

if __name__ == "__main__":
    network_scan()
    fetch_locations()
    app.run(host='0.0.0.0', port=5000, debug=True)