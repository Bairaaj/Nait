# ica03 -Collections, Doctest and Command Line parameters
# Adrian Baira
# Submission Code : 1242_2850_A03
import os.path
import random
import string
from collections import deque


import random
import string
from collections import deque


def make_big_queue(size):
    """
<<<<<<< Updated upstream
    Create a queue of random letters of length strSize
    :param size: required resultant queue length
    :return: queue of random letters
    >>> random.seed(0)
    >>> make_big_queue(7)
    deque(['y', 'W', 'A', 'c', 'q', 'G', 'F'])
    """
    letters = string.ascii_letters
    qlist = []
    for _ in range(size):
        qlist.append(random.choice(letters))
    queue = deque(qlist)

    #test = deque([random.choice(letters) for x in range(size)])
    return queue


def make_dict(queOfChars):
    """
    >>>random.seed(0)
    >>>make_dict(make_big_queue(3))
    {'y': 1, 'W': 1, 'A': 1}
    :param queOfChars: Queue of characters from make_big_queue
    :return: A dictionary
    """
    dictionary = {}
    for letter in queOfChars:
        if letter in dictionary:
            dictionary[letter] += 1
        else:
            dictionary[letter] = 1

    return dictionary


def show_dict(letterDictionary, sortFnc):

    for key, value in letterDictionary.items():
        squares = ''
        for _ in range(value):
            squares += chr(9608)
        print(f'{key} {value:<3d} : {squares}')


    keys = set(letterDictionary.keys())
    neverpicked = list(string.ascii_letters)
    for letter in keys:
        if letter in string.ascii_letters:
            neverpicked.remove(letter)

    print('Never selected: '+"".join(neverpicked))



def process_file(filename ='../'):
    try:
        if os.path.exists(filename):
            with open(filename, 'r') as file:
                contents = file.read()
                que = deque()
                for chars in contents:
                    que.append(chars)

                return que

    except FileExistsError:
        print(f"Error: File not found at '{filename}'")
        return None


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    print_hi('PyCharm')
    random.seed(0)
    test = make_big_queue(3)
    ok = make_dict(test)
    print(ok)
    show_dict(ok, 1)


=======
      Create a queue of random letters of length strSize
      :param size: required resultant queue length
      :return: queue of random letters
      >>> random.seed(0)
      >>> make_big_queue(7)
      deque(['y', 'W', 'A', 'c', 'q', 'G', 'F'])
      """
    letters = string.ascii_letters
    listofletters = deque(random.choice(letters) for x in range(size))

    return listofletters

if __name__ == "__main__":
    print(make_big_queue(40))




def make_dict(queueOfChars):
    """
    Create a dictionary of letter frequencies from a deque
    :param queueOfChars: deque of characters
    :return: dictionary of letter frequencies
    >>> make_dict(deque(['a', 'b', 'c', 'a', 'b', 'a']))
    {'a': 3, 'b': 2, 'c': 1}
    """
    freq_dict = {}
    while queueOfChars:
        char = queueOfChars.popleft()
        if char in freq_dict:
            freq_dict[char] += 1
        else:
            freq_dict[char] = 1
    return freq_dict

if __name__ == "__main__":
    queue = make_big_queue(40)
    letter_dict = make_dict(queue)
    print(letter_dict)
>>>>>>> Stashed changes
