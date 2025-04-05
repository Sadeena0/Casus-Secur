from database import *
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

def network_scan():
    threading.Timer(1, network_scan).start()
    connections = psutil.net_connections(kind='inet')

    log_entries = []

    for conn in connections:
        if conn.status == 'ESTABLISHED' and conn.raddr and conn.raddr[0] != "127.0.0.1" and not conn.raddr[0].startswith("192.168"):
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
    missing = missing_location()[:100]
    url = "http://ip-api.com/batch?fields=status,country,countryCode,region,regionName,city,isp,org,query"
    data = json.dumps(missing)
    response = requests.post(url, data=data)
    update_locations(response.json())

network_scan()
fetch_locations()


