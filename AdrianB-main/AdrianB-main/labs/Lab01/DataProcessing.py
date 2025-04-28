import DataProcessing

toggle = False
def avaliable_courses(data):
    courses = []
    for x in data:
        courses.append(x['course'])

    return list(set(courses))

def student_distribution(data):

    y_axis = {}
    for rows in data:
        if rows['course'] in y_axis:
            y_axis[rows['course']] += 1
        else:
            y_axis[rows['course']] = 1
    lists = None
    x = None
    if toggle:
        lists = dict(sorted(y_axis.items()))
        x = sorted(avaliable_courses(data))
    else:
        lists = dict(y_axis.items())
        x = avaliable_courses(data)

    y = []
    for key, value in lists.items():
        y.append(value)

    return x,y

def assessments(data, course, ass_filter):
    x = []
    y = []
    count = 0
    for rows in data:
        if rows['course'] == course:
            count += 1
            grade = rows[ass_filter]
            x.append(count)
            y.append(int(grade))
    if toggle:
        y = sorted(y)

    return x,y

def course_averages(data, course, ass_filter):
    cases = ['Ica', 'Lab', 'Exam']
    match = ''
    for x in range(len(cases)):
        if ass_filter.capitalize() in cases[x]:
            match = cases[x]
            break
        else:
            print("No Evaluation Partial Matched")
            return

    evaluations = []
    for rows in data:
        for key in rows.keys():
            if key.startswith(match):
                evaluations.append(key)


    x = sorted(list(set(evaluations)))

    y = []
    for work in x:
        avg = 0
        count = 0
        for subject in data:
            if subject['course'] == course:
                count += 1
                avg += int(subject[work])
        y.append(round(avg / count, 2))

    print(f'CourseAverages : assessments {x}')
    print(f'CourseAverages : average grades {y}')

def student_averages(data, course):
    students_in_course = []
    All_of_Assessments = []
    for student in data:
        if student['course'] == course:
            students_in_course.append((student['last_name'], student['first_name']))

    for assess in data:
        for key in assess.keys():
            if key.startswith('Ica') or key.startswith('Lab') or key.startswith('Exam'):
                All_of_Assessments.append(key)
    list_of_Assessments = sorted(list(set(All_of_Assessments)))

    average = []
    for student in data:
        if student['course'] == course:
            avg = 0
            count = 0
            for assess in list_of_Assessments:
                count += 1
                avg += int(student[assess])
            average.append((round(avg / count, 2), f'{student['last_name']}, {student['first_name']}'))

    students = average
    if toggle:
        students = sorted(average, key=lambda x: x[1][0])


    x = [grades[0] for grades in students]
    y = [names[1] for names in students]
    return x,y
