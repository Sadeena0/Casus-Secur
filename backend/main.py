from database import *

match open_connection():
    case 0:
        pass
    case 1:
        print("Error connecting to database. Terminating service.")
        exit()
    case 2:
        print("Empty database detected. Initializing database.")
        intialise_database()