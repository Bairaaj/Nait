# ica01
# Adrian Baira
# Submission Code : 1242_2850_A01

import random
import os
menuOption = [('c', 'Card Shuffler'),('d','Die Distribution'), ('f', 'File Read')]


# Menu Function To show the menus selection
## User Inputs a Letter and will keep looping until user inputs a correct letter
def menu():
    userInput = "INVALID"
    while userInput != "C" and userInput != "D" and userInput != "1" and userInput != "F":
        print("Menu:")
        for x in range(len(menuOption)):
            print( f'{menuOption[x][0]:3}: {menuOption[x][1]}')
        userInput = input("Enter Selection: ").capitalize()
    return userInput


## Card Shuffler
# Gets the middle of the cards and alternate putting into a new list from the end
def card_shuffler(deck_string):
    if(deck_string == ''):
        deck_string = '99990000JJJJQQQQKKKK'

    stringdeck = "Deck"
    print(f"{stringdeck:<10}: [{deck_string}]")

    # Cut the deck into two pieces and separate them into a list
    middle = int(len(deck_string) / 2)
    holdlist = ""
    firsthalf = list(deck_string[:middle])
    secondhalf = list(deck_string[middle:])

    #combine the last from each list and even
    while firsthalf or secondhalf:
        if len(firsthalf) != 0:
            holdlist += firsthalf.pop() + secondhalf.pop()
        else:
            holdlist += secondhalf.pop()

    ##The cut of the list
    stringdeck = 'Cut'
    print(f"{stringdeck:<10}: {holdlist}")
    cut = 1
    if(len(deck_string) > 2):
        cut = random.randint(0,len(deck_string) - 1)

    firsthalf = list(holdlist[:cut])
    secondhalf = list(holdlist[cut:])

    #Shuffled deck and showed to the main form
    firsthalf.reverse()
    secondhalf.reverse()
    shuffled = firsthalf + secondhalf
    shuffled.reverse()




    return shuffled


#Die Roller
def die_distribution(rolls, sides):
    #Create a dictionary for dice
    dicedictionary = {}

    #have the dictionary start at minimum 2
    for x in range((sides * 2) - 1) :
        dicedictionary[x + 2] = 0

    #Rolling x amount of times and adding two dices together
    for x in range(rolls):
        diceone = random.randrange(1, sides + 1)
        dicetwo = random.randint(1, sides)
        dicedictionary[dicetwo + diceone] += 1

    #Displaying onto the Console window
    for x in range((sides * 2) - 1):
        print(f"[{x + 2:>2}] = {dicedictionary[x + 2]:>8} generated = {dicedictionary[x+2] / rolls * 100.0 :>6.2f}%")



#Sorting the list (haven't implemented yet)
def insert_ascending(mainList, newItem):
    mainList.append(newItem)
    
    return mainList

#Open file and search for only unique characters and display them to the console
def file_chars(filename):
    #Open and read all lines in the list
    if(filename == ''):
        filename = 'main.py'
    os.path.exists(filename)
    contents = open(filename).read()
    contents.replace('\r\n', '')

    #Keep all lower, upper, other, and common letters
    lowercase = []
    uppercase = []
    other = []
    common = []

    #Check each letter in the file
    for char in contents:
        if char.islower():
            if char not in lowercase:
                lowercase = insert_ascending(lowercase, char)
        elif char.isupper():
            if char not in uppercase:
                uppercase = insert_ascending(uppercase, char)
        elif char not in('\r', '\n'):
            if char not in other:
                other = insert_ascending(other, char)

    #Copy of the uppercase
    copy = uppercase.copy()

    #changing all letters in the copy to be lower case
    for i in range(len(copy)):
        copy[i] = copy[i].lower()

    #Finding the common between both lists
    common = list(set(lowercase) & set(copy))

    print("Lower : ", ''.join(lowercase))
    print("Upper : ", ''.join(uppercase))
    print("Other : ", ''.join(other))
    print("Common: ", ''.join(common))





while True:
    userInput = menu()
    if userInput == "C":
        shuffled_deck = card_shuffler(input("Enter a deck [99990000JJJJQQQQKKKK]: "))
        stringdeck = 'Shuffled'
        print(f"{stringdeck:<10}:", ''.join(shuffled_deck))

    if userInput == "D":
        die_distribution(int(input("Rolls [1000]: ")), int(input("Sides [6]: ")))

    if userInput == "F":
        file_chars(input("Filename [main.py]: "))
    if userInput == "1":
        exit()
    userInput = ""