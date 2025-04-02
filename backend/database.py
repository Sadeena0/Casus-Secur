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
        cur.execute("CREATE TABLE ip_addresses(ip PRIMARY KEY, location, times int CHECK(times>0))")
