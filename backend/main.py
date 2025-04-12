import os
from datetime import datetime, timezone

from database import *
from flask import Flask, request, abort
from dotenv import load_dotenv
from pathlib import Path
import platform
import threading
import psutil
import requests
import json

load_dotenv()
API_KEY = os.getenv('API_KEY')
last_check = datetime.now(timezone.utc)
unflushed_log = []

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

            log_entries.append((conn.raddr[0], conn.raddr[1], pid, app_name))
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
                            parsed_log.append(line.strip())
                    except Exception as e:
                        print(f"Error parsing line: {line.strip()}, {e}")
        if parsed_log:
            parsed_log = list(dict.fromkeys(parsed_log))
            unflushed_log.extend(parsed_log)
    add_records(log_entries)
    last_check = datetime.now(timezone.utc)
    threading.Timer(1, network_scan).start()

def fetch_locations():
    threading.Timer(10, fetch_locations).start()
    missing = missing_location()[:100]
    url = "http://ip-api.com/batch?fields=status,country,countryCode,region,regionName,city,isp,org,query,lat,lon"
    data = json.dumps(missing)
    response = requests.post(url, data=data)
    update_locations(response.json())

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

@app.route("/getsshlog", methods=["GET"])
def get_sshlog_endpoint():
    global unflushed_log
    key = request.args.get("key")
    if key is None:
        return "No API key provided.", 400
    if key not in API_KEY:
        return "Invalid API key.", 401
    else:
        data = json.dumps(unflushed_log)
        unflushed_log = []
        return data, 200

if __name__ == "__main__":
    network_scan()
    fetch_locations()
    app.run(host='0.0.0.0', port=5000, debug=True)