import os
import csv
from csv import DictReader


def get_file():
    files = []
    project_dir = os.getcwd()
    download_dir = os.path.join(os.path.expanduser('~'), 'Downloads')
    count = 0

    for x in os.listdir(project_dir):
        if x.endswith('.csv'):
            count += 1
            files.append((count, x, project_dir))

    for x in os.listdir(download_dir):
        if x.endswith('.csv'):
            count += 1
            files.append((count, x, project_dir))

    for x in files:
        print(f'[{x[0]}] {x[1]}')

    selection = None
    while True:
        userinput = input('\nSelect a .csv file: ')
        if userinput.isdigit():
            selection = int(userinput) - 1
            if selection < 0 or selection >= len(files):
                print(f'Invalid please select a number between 1 and {len(files)} Please Try Again. ')
            else:
                break
        else:
            print("Invalid Input. Please enter a number")

    selected_tuple = files[selection]
    full_path = selected_tuple[2] + '\\' + selected_tuple[1]
    print(full_path)
    return full_path



def read_csv(filepath):
    with open(filepath, 'r') as file:
        reader = DictReader(file)
        data = [row for row in reader]

    return data



