import csv
import  statistics
from warnings import catch_warnings

import matplotlib
from matplotlib import pyplot as plt

import CSVProcessing
from CSVProcessing import get_file, read_csv

import DataProcessing
from DataProcessing import avaliable_courses, student_distribution, assessments, course_averages

import Plotting
from Plotting import view_student_distribution

menuOption = [('o', 'Open a file for loading'),('s','Student Distribution View'), ('a', 'Assessment View'),('c', 'Course Average View'), ('v', 'Student Averages View'), ('z', 'Sort toggle')]
def menu():
    userinput = None
    valid = [option[0] for option in menuOption]
    while userinput not in valid:
        print('\nMenu:')
        for key, value in menuOption:
            print(f'{key} : {value}')
        print(f'Sort is {"ON" if DataProcessing.toggle else "OFF"}')
        userinput = input("\nEnter Selection : ").lower().strip()
    return userinput


file = None
data = None
while True:
    selection = menu()

    if selection == 'o':
        file = get_file()
        data = read_csv(file)
    elif file is None:
        print("Error need to select o first")

    elif selection == 's' and file is not None:
        Plotting.view_student_averages(student_distribution(data))

    elif selection == 'a' and file is not None:
        course = input('Course : [cmpe2400] : ') or 'cmpe2400'
        assignment = input('Assessment Filter [Ica08] : ') or 'Ica08'

        Plotting.view_assessment(assessments(data, course, assignment))

    elif selection == 'c' and file is not None:
        course = input('Course : [cmpe2400] : ') or 'cmpe2400'
        evaluation = input('Evaluation Filter [Ica] : ') or 'Ica'
        try:
            course_averages(data, course, evaluation)
        except ValueError and ZeroDivisionError:
            print("Invalid evaluation filter")

    elif selection == 'v' and file is not None:
        course = input('Course : [cmpe2400] : ') or 'cmpe2400'
        Plotting.view_student_averages(DataProcessing.student_averages(data, course))

    elif selection == 'z' and file is not None:
        DataProcessing.toggle = not DataProcessing.toggle








