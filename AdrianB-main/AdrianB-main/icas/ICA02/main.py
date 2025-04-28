# ica 02 Func-o-matic
# Adrian Baira
# Submission Code : 1242_2850_A02
import random
from contextlib import nullcontext


menuOption = [('g', 'Generate Letters'),('i','Inorder Shuffle Creation'), ('s', 'Stalin Sort')]
letters = []
def menu() -> str:
    """
    Menu Function To display Menu Items on to the command line
    :return: Letter User Selected
    """
    userinput = "INVALID"
    while userinput != "G" and userinput != "I" and userinput != "1" and userinput != "S":
        print("Menu:")
        for x in range(len(menuOption)):
            print( f'{menuOption[x][0]:3}: {menuOption[x][1]}')
        userinput = input("Enter Selection: ").capitalize()
    return userinput



def gen_letters(* stuff) -> str:
    """
    Generator to generate numbers using yield and *args
    Generate Letters From Start character to End Character till the limit is reached
    :param stuff:
            stuff[0] - Start Character
            stuff[1] - End Character
            stuff[2] - How many Letters To generate
    :return: Each character That is Generated
    """
    #Ord gets the Unicode of the character
    starts = ord(stuff[0])
    ends = ord(stuff[1])
    howmanys = stuff[2]
    icount = 0

    while icount < howmanys:
        icount += 1
        letter = random.randint(starts, ends)
        yield chr(letter)



shuffle_iterations = 0
def shuffle_letters(stuff : list[str]) -> str :
    """
    Shuffle Letters using fisher yates shuffle and return every time you shuffle one item
    :param stuff: List of Characters from Generate Lists
    :return: Character from the shuffle
    """
    global shuffle_iterations
    count = 0
    while count < len(stuff):
        rand = random.randint(count, len(stuff) - 1)
        #Swap
        temp = stuff[count]
        stuff[count] = stuff[rand]
        stuff[rand] = temp
        yield stuff[count]
        shuffle_iterations += 1
        count += 1


def inorder_shuffle(** stuff) -> (list[str], bool, int, int):
    """
    using Fisher-yates Shuffle_letters to shuffle in order within the max amount of tries
    if using the shuffle fails then give non-success code
    if shuffle is successful then show how many iterations and tries
    :param stuff:
            stuff['src'] - Source collection
            stuff['max_tries'] - Max tires to sort
    :return:(tuple of shuffledLetters, Success, Tries, Shuffle_iteration
    """

    #Checking if the Kwargs has the keys is 'max_tries' and 'src'
    #And Grabbing the values from the keys
    if 'max_tries' in stuff.keys() and 'src' in stuff.keys():
        source = stuff['src'].copy()
        attempts = int(stuff['max_tries'])
    else:
        return None

    #number Of iterations
    count = 0
    shuffle_iterations = 0
    success = True
    temp_lists = []
    while count < attempts:
        count += 1
        temp_lists = []
        success = True

        #got help from Adam W
        for index, letter in enumerate(shuffle_letters(source)):
            #add the letter to the temp list
            temp_lists.append(letter)
            shuffle_iterations += 1
            #if it's the first iteration then skip
            if index < 0:
                continue
            else:
                # if the letter is less than the previous letter then it failed
                if letter < temp_lists[index - 1]:
                    success = False
                    break
                else:
                    # gets the last letter in the list
                    if index == len(source) - 1:
                        return temp_lists, success, count, shuffle_iterations

    return temp_lists, success, count, shuffle_iterations


def stalin_sort(** stuff):
    """
    Sorting the Given list as a Stalin Sort
    :param stuff:
                key:        Value:
            stuff['src'] - source collection
    """
    #making sure the key is src and grab the list from the key
    if 'src' in stuff.keys():
        source = stuff['src'].copy()
    else:
        return nullcontext

    #count for the Stalin sort
    count = 0
    #Copy of the source
    sorted_raw = source.copy()

    sorted_pos = []
    #Biggest letter at the time
    letter = ''

    for index, value in enumerate(source):
        #Grab the first letter and continue as the first letter is currently the biggest
        if index == 0:
            letter = value
            sorted_pos.append(letter)
            continue
        else:
            #Compare the letter with the value
            if letter > value:
                sorted_pos.append(' ')
                sorted_raw.pop(index - count)
                count += 1
            #If the letter is less than change the max letter to the new max letter and add the l
            else:
                letter = value
                sorted_pos.append(letter)

    #Printing to the console
    print("Stalin Sort Raw".ljust(22) + ': ' + "".join(sorted_raw))
    print("Stalin Sort Original".ljust(22) + ': ' + "".join(source))
    print("Stalin Sort Position".ljust(22) + ': ' + "".join(sorted_pos))




while True:
    selection = menu()
    #Selection menu for generate letters
    if selection == 'G':

        #Loop until User input is valid for how many
        while True:
            howmany = input("Letters [40] : ").strip()
            if howmany == '':
                howmany = 40
                break
                #check if it is a digit and if the number is greater than 0
            if howmany.isdigit() and int(howmany) > 0:
                howmany = int(howmany)
                break

        while True:
            start = input('Start Letter [A]: ').strip()
            if start == '':
                start = 'A'
                break
            elif 'A' <= start <= 'Z':
                start = start[0]
                break

        while True:
            end = input('End Letter [H]: ')
            if end == '':
                end = 'H'
                break
            elif start <= end <= 'Z':
                end = end[0]
                break

        #Reset letter everytime generate number is made
        letters = []
        for i in gen_letters(start, end, howmany):
            letters.append(i)

        print("Letters: ", ',' .join(letters))

    #In Order Sort
    elif selection == 'I':
        if len(letters) == 0:
            print("\nGenerate Numbers First")
        else:
            #Error checking for if user input is a digit or empty
            while True:
                print(letters)
                tries = input("Number of shuffle attempts [100000]: ").strip()
                if tries == '':
                    tries = 100000
                    break
                elif tries.isdigit() and int(tries) > 0:
                    tries = int(tries)
                    break

            result = inorder_shuffle(src=letters, max_tries=tries)
            print("Gen: " + ''.join(letters))
            print(f"{result[1]} : Shuffle iterations {result[3]} : {result[2]} tries with {(result[3] / result[2]):.3f} iterations/try")



    #Selection of Stalin sort
    elif selection == 'S':
        if len(letters) == 0:
            print("\nGenerate Number First")
        else:
            stalin_sort(src= letters)
    elif selection == '1':
        exit()

