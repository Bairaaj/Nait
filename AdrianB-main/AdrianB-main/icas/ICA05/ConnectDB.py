import mysql.connector


def ConnectToDB(userpassword):
    database = None
    passw = userpassword

    try:
        database = mysql.connector.connect(
            host="thor.cnt.sast.ca",
            user='demo_user',
            password=passw,
            database='demo_sakila'
        )
    except mysql.connector.Error as ex:
        print(f'Something went wrong {ex}')

    if database != None and database.is_connected():
        print(f"Connected : {database.get_server_info()}")

    return database
