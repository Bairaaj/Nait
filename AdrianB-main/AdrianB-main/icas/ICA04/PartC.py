# ica04 - WebAPI
# Adrian Baira
# Submission Code : 1242_2850_A04
# Part C
import os
from datetime import datetime
def save(data, measures, filename='out.txt'):
    '''
    Saving data from parsing function to save into a Txt file sorting the states in the file
    :param data: dictionary
    :param measures: what they wanted to search for
    :param filename: File name of wanted txt
    '''

    #if the file doesn't have .txt then add for easier file making
    if not filename.endswith('.txt'):
        filename += '.txt'

    #Split the name into name and .txt
    split_tup = os.path.splitext(filename)

    #split name and .txt
    file_name = split_tup[0]
    file_extension = split_tup[1]

    #Tries for how many times you can make one with the same name
    tries = 99
    for i  in range(tries):
        if os.path.exists(filename):
            filename = f'{file_name}_{i + 1}{file_extension}'
        else:
            break

    #file and write to it
    with open(filename, 'w') as file:
        #get the Current time
        time = datetime.now()

        #Write to the file with what they searched on and the time user asked for
        file.write(f'{measures} information as of : {time}\n')

        sort = sorted(data.items(), key=lambda x: x[0][0])

        #sorting data on
        for x, y in sort:
            y.sort()
            file.write(f'Range {x} : {', '.join(y)}\n')

    #Saved show that the data was saved
    print(f'{filename} saved')
