import sqlite3


def open_connection():
    try:
        connection = sqlite3.connect('connections.db')
        with connection as conn:
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
        cur.execute("CREATE TABLE ip_addresses(ip PRIMARY KEY, pid int, appname varchar(255),"
                    " location varchar(255), times int CHECK(times>0))")

def add_records(records):
    connection = sqlite3.connect('connections.db')
    with connection as conn:
        cur = conn.cursor()
        for record in records:
            res = cur.execute("SELECT ip FROM ip_addresses WHERE ip=?", (f"{record[0]}:{record[1]}",))
            if res.fetchone():
                cur.execute("SELECT times from ip_addresses WHERE ip=?", (f"{record[0]}:{record[1]}",))
                times = cur.fetchone()[0] + 1
                cur.execute("UPDATE ip_addresses SET times=? WHERE ip=?", (times, f"{record[0]}:{record[1]}",))
                pass
            else:
                cur.execute("INSERT INTO ip_addresses(ip,pid,appname,times) VALUES(?,?,?,?) "
                            , (f"{record[0]}:{record[1]}", record[2], record[3], 1))


