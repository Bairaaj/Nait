
def view_student_distribution(plotting_data):
    print(f'StudentDistribution : Courses {plotting_data[0]}' )
    print(f'StudentDistribution : Students {plotting_data[1]}' )

def view_assessment(plotting_data):
    print(f'Assessment View : Students range(0, {len(plotting_data[0])})')  #{', '.join(map(str, plotting_data[0]))})')
    print(f'Assessment View : Grades {plotting_data[1]}')


def view_student_averages(plotting_data):
    print(f'StudentAverages : Students {plotting_data[1]}')
    print(f'StudentAverages : Grades {plotting_data[0]}')

import main