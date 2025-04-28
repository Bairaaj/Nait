# ica04 - WebAPI
# Adrian Baira
# Submission Code : 1242_2850_A04

from PartA import search, GSelection, parse_page, PSelection
import PartC

#Web page Options
menuOption = [('g', 'Web Search'),('p','Parse page'), ('s', 'Save')]
def menu() -> str:
    """
    Menu Function To display Menu Items on to the command line
    :return: Letter User Selected
    """
    userinput = "INVALID"
    #Check if user put valid inputs
    while userinput != "G" and userinput != "P" and userinput != "S" and userinput != "1":
        print("\nMenu:")
        for x in range(len(menuOption)):
            print( f'{menuOption[x][0]:3}: {menuOption[x][1]}')
        userinput = input("\nEnter Selection: ").capitalize()
    return userinput

result = None #saved Json object from web request
parsed = None #dictionary made from json object

print('ICA04 - Menu :')

#Infinite loop to keep program running
while True:
    selection = menu()
    if selection == 'G':
        result = GSelection()
    elif result is None and parsed is None:
        print('Error must request page first')
    elif selection == 'P' and result is not None:
        parsed = parse_page(result, search, PSelection() )
    elif selection == "S" and parsed is not None and result is not None:
        PartC.save(parsed, search, input("Please input filename [out.txt]: ") or 'out.txt')



