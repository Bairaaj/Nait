def categorize(stuff: list[any]) -> dict[any, int] | str:
    """
    Categorize a list of any into key and count dictionary
    :param stuff: A list of any to categorize
    :return: A dictionary of any as key, and int as count/frequency
    >>> categorize([3,3,2,3,1,8])
    {3: 3, 2: 1, 1: 1, 8: 1}
    >>> categorize('tree')
    'Categorize : stuff must be a list'
    >>> categorize([])
    'Categorize : stuff must not be empty'
    """


    if not isinstance(stuff, list):
        return 'Categorize : stuff must be a list'
    if len(stuff) == 0:
        return 'Categorize : stuff must not be empty'

    dictionary = {}
    for x in stuff:
        if x in dictionary:
            dictionary[x] += 1
        else:
            dictionary[x] = 1

    return dictionary

if __name__ == '__main__':
    pass


