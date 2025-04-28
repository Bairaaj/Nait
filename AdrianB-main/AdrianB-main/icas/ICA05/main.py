import statistics
from statistics import mean
import ConnectDB
import mysql.connector

data = None
menuOption = [('c', 'Connect to the DB'),('f','Get Films by Category'), ('a', 'Get Films with Actors')]
def menu():
    userinput = None
    valid = [option[0] for option in menuOption]
    while userinput not in valid:
        print('\nMenu:')
        for key, value in menuOption:
            print(f'{key} : {value}')
        userinput = input("\nEnter Selection : ").lower().strip()
    return userinput


def get_films(DB):
    search = input("Enter Filter for title [car]: ") or "Car"
    try:

        cursor = DB.cursor(buffered=True)

        query = """
                select c.name, f.film_id, f.title, f.release_year, f.length 
                from film f 
                join film_category fc 
                on f.film_id = fc.film_id 
                join category c 
                on fc.category_id = c.category_id 
                where f.title like %s LIMIT 100
                """

        filter = "%"+ search + "%"

        cursor.execute(query, (filter,))
        if cursor.rowcount == 0:
            print("No films found with filter")
            return None

        column_names = cursor.column_names
        results = cursor.fetchall()

    except mysql.connector.Error as ex:
        print(f'Something went wrong: {ex}')
        results = None
        return None
    finally:
        cursor.close()

    print(column_names)
    runtime = []
    newest = []
    for x in results:
        print(f'>{x}')
        runtime.append(x[4])
        newest.append(x[3])


    length = statistics.mean(runtime)
    newest.sort(reverse=True)
    print(f"Average run time : {length:.2f} minutes")
    print(f"Newest Release : {newest[0]}")



def get_films_with_actors(DB):
    actors = int(input("Enter minimum actors [5] : ")) or 5

    try:
        cursor = DB.cursor(buffered=True)


        query = """
        select f.title, f.replacement_cost, Count(*) as actor_count
        from film f
        join film_actor fa
        on fa.film_id = f.film_id        
        group by f.title
        Having count(*) >= %s
        order by actor_count desc
        """

        filter = actors
        cursor.execute(query, (filter,))
        if cursor.rowcount == 0:
            print("No films found with filter")
            return None
        column_names = cursor.column_names
        results = cursor.fetchall()



    except mysql.connector.Error as ex:
        print(f"SQL Error {ex}")
    finally:
        cursor.close()

    for x in results:
        print(f'>{x}')







while True:
    selection = menu()
    if selection == 'c':
        password = input("Password for demo_user [demo_password] :") or 'demo_password'
        data = ConnectDB.ConnectToDB(password)
    elif selection == 'f':
        get_films(data)
    elif selection == 'a':
        get_films_with_actors(data)