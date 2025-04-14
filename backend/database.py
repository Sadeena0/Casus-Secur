import sqlite3


def open_connection():
    try:
        connection = sqlite3.connect('connections.db')
        with connection as conn:
            conn.execute("PRAGMA journal_mode = WAL")
            conn.execute("PRAGMA busy_timeout = 100")
            cur = conn.cursor()
            res = cur.execute("SELECT name FROM sqlite_master WHERE type='table' AND name='ip_addresses';")
            if res.fetchone():
                return 0  # No errors
            else:
                return 2  # Table not intialised
    except Exception as e:
        print(e)
        return 1  # Database error


def intialise_database():
    connection = sqlite3.connect('connections.db')
    with connection as conn:
        cur = conn.cursor()
        cur.execute("CREATE TABLE ip_addresses(ip varchar(255), port int, pid int, appname varchar(255),"
                    " location varchar(255), times int CHECK(times>0), lat float, lon float, sent int CHECK(sent>=0),"
                    " PRIMARY KEY(ip, port))")

def add_records(records):
    connection = sqlite3.connect('connections.db')
    with connection as conn:
        cur = conn.cursor()
        for record in records:
            res = cur.execute("SELECT ip FROM ip_addresses WHERE ip=? AND port=?", (record[0], record[1]))
            if res.fetchone():
                cur.execute("SELECT times, sent from ip_addresses WHERE ip=? AND port=?", (record[0], record[1]))
                result = cur.fetchone()
                times = result[0] + 1
                sent = result[1] + record[4]
                cur.execute("UPDATE ip_addresses SET times=?,sent=? WHERE ip=? AND port=?", (times, sent, record[0], record[1]))
                pass
            else:
                cur.execute("INSERT INTO ip_addresses(ip,port,pid,appname,times,sent) VALUES(?,?,?,?,?,?) "
                            , (record[0], record[1], record[2], record[3], 1, record[4]))

def fetch_records():
    connection = sqlite3.connect('connections.db')
    with connection as conn:
        cur = conn.cursor()
        res = cur.execute("SELECT * FROM ip_addresses ORDER BY times")
        records = res.fetchall()
        return records

def clear_records():
    connection = sqlite3.connect('connections.db')
    with connection as conn:
        cur = conn.cursor()
        cur.execute("DELETE FROM ip_addresses")

def missing_location():
    connection = sqlite3.connect('connections.db')
    with connection as conn:
        cur = conn.cursor()
        cur.execute("SELECT ip FROM ip_addresses WHERE location IS NULL")
        return list(map(lambda x: x[0], cur.fetchall()))

def update_locations(records):
    connection = sqlite3.connect('connections.db')
    with connection as conn:
        cur = conn.cursor()
        for record in records:
            if record["status"] == "success":
                cur.execute("UPDATE ip_addresses SET location=?, lat=?, lon=? WHERE ip=?",
                            (f"{record['regionName']}, {record['country']}", record['lat'], record['lon'], record['query']))


