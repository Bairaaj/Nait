# ica04 - WebAPI
# Adrian Baira
# Submission Code : 1242_2850_A04
# Part A and B
import requests

#Part A
# Measures of what to search for
search = ''
def get_page(**kwargs):
    """
    Request information from BaseURL for data manipulation
    :param kwargs: drilldowns = State, Measures = Search On ex Population, year = 'year'
    :return: Request object
    """
    #Base Url website to grab from
    baseURL = "https://datausa.io/api/data"

    #Get request
    response = requests.get(baseURL, params=kwargs)
    print(f'Web Request : {response.request.url}')
    print(f"Request status code {response.status_code}")

    #if the response from server was good then return the Request object if it was not then return
    if response.status_code == 200:
        return response
    else:
        return

#Part A
def GSelection():
    '''
    Selection of Part A Gets the web response of from the given prompts and returns a Json object
    :return: json object
    '''

    # Search is what we are measuring
    global search
    # Options to chose from
    Measures = {0:'Population', 1:'Average Commute Time', 2:'Average Wage', 3:'Median Household Income'}
    print()
    #Display options
    for x, y in Measures.items():
        print(f"{x} : {y}")

    # keep looping until valid input
    while True:
        user = input("Search [0] : ") or "0"
        #check for digit
        if user.isdigit():
            user = int(user)
            if 0 <= user <= 3:
                break
            else:
                print("Invalid index. Please enter a number between 0 and 3.")
        else:
            print("Invalid input. Please enter a valid number.")

    #Gets the numbers associated with choice
    key = list(Measures.keys())[user]

    #Gets the value from the key
    search = Measures[key]

    #Year user inputs
    year = input("year [latest] : ") or 'latest'

    #Returns gets a Get Request with all the data
    return get_page(drilldowns="State", measures=search, year=year)




#Part B
def parse_page(webresponse, measure, divisor):
    """
    Convert web response to a dictionary and process the data
    into range and state
    :param webresponse: Webresponse from Part A
    :param measure: What we want to search On ex Population
    :param divisor: Help with the Min max Range values from data
    :return:
    """
    #if the web Response if empty then return don't do anything
    if webresponse is None:
        return

    #Attempt to get the webrequest as a json Object
    try:
        data_dict = webresponse.json()['data']
    except ValueError:
        print("Error: The response is not in JSON format.")
        return

    #Dictionary from data_dict
    returnedDict = {}
    for data in data_dict:

        #save the state and the measure that we are looking for
        state = data["State"]
        value = data[measure]

        #if the value or state is Null or 0 then do not add into dictionary and skip
        if value == 0 or value is None or state is None or state == '#null':
            continue

        #Minimum value
        range_min = (value // divisor) * divisor
        #max value
        range_max = range_min + divisor
        #range value
        range = (range_min, range_max)

        #If the range isn't in the list then create one
        if range not in returnedDict:
            returnedDict[range] = []
        #then add the state to the dictionary
        returnedDict[range].append(state)

    #Display how many entire there are
    print(f"Found [{len(data_dict)}] {measure} categories in {len(returnedDict)} dictionary")

    #Display on to console
    for key, value in returnedDict.items():
        print(f'Range : {key} : {value}')

    #return the data
    return returnedDict



#Selection if user Selects P
def PSelection():
    '''
    Helper function for Part B
    Only allows a positive number or a valid number
    :return: User Input
    '''
    while True:
        #default value if none give
        user = input("Divisor [5000] : ") or '5000'
        if user.isdigit():
            user = int(user)
            if user <= 0:
                print("Please enter a number greater than 0")
            else:
                break
        else:
            print("Invalid input. Please enter a valid number.")

    return user

