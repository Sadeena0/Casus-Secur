from database import *
import threading
import psutil
import time

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
        if conn.status == 'ESTABLISHED' and conn.raddr:
            pid = conn.pid
            if pid:
                try:
                    process = psutil.Process(pid)
                    app_name = process.name()
                except psutil.NoSuchProcess:
                    app_name = "Unknown"
            else:
                app_name = "System"

            log_entries.append((conn.raddr[0], conn.raddr[1], pid, app_name, "Not Implemented"))
    add_records(log_entries)

network_scan()
time.sleep(3600)