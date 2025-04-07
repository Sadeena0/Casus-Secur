from database import *
from flask import Flask, request, abort
import threading
import psutil
import requests
import json

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
    threading.Timer(1, network_scan).start()
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
    add_records(log_entries)


def fetch_locations():
    threading.Timer(10, fetch_locations).start()
    missing = missing_location()[:100]
    url = "http://ip-api.com/batch?fields=status,country,countryCode,region,regionName,city,isp,org,query,lat,lon"
    data = json.dumps(missing)
    response = requests.post(url, data=data)
    update_locations(response.json())

@app.before_request
def limit_remote_addr():
    if request.remote_addr != '127.0.0.1':
        abort(403)
@app.route("/cleardb", methods=["POST"])
def clear_database_endpoint():
    clear_records()
    return "Database cleared.", 200

if __name__ == "__main__":
    network_scan()
    fetch_locations()
    app.run(host='0.0.0.0', port=5000)