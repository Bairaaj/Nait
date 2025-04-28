from machine import Pin
from utime import sleep
import random

COL = 7
ROW = 6
PLAYER = [1,2]
CURRENTPLAYER = 0

## we are looping from the range of the col and row
## range() - https://www.datacamp.com/tutorial/python-range-function?utm_source=google&utm_medium=paid_search&utm_campaignid=19589720830&utm_adgroupid=157156377311&utm_device=c&utm_keyword=&utm_matchtype=&utm_network=s&utm_adpostion=&utm_creative=726015683898&utm_targetid=dsa-2218886984100&utm_loc_interest_ms=&utm_loc_physical_ms=9001397&utm_content=&utm_campaign=230119_1-sea~dsa~tofu_2-b2c_3-us_4-prc_5-na_6-na_7-le_8-pdsh-go_9-nb-e_10-na_11-na-jan25&gad_source=5&gclid=EAIaIQobChMIo92jpKWtiwMV-c3CBB3TiQndEAAYASAAEgLspfD_BwE
## we are looping from the given cal and row value to and
## creating a 2d board
board = [[0 for x in range(COL)] for y in range(ROW)]

## displaying the the board in the console 
## For debug purpose
def display_Board():
    for x in board:
        print(' '.join(map(str, x)))
    print('\n')

## checks if at the first line if the cols has a value of 0
def check_move(col):
    return board[0] == 0

## retriving all the available position
## save it as a list 
## random.choice will randomily picks one value from the list
def computer_choice_easy():
    available_spots = [_ for _ in range(COL) if check_move(_)]
    return random.choice(available_spots) if available_spots else -1
    

## most if the code inside this function was a start up code 
## added my be to test all the gpio to in a loop to check if my hardware is working
def gpio_tester():
    i = 0
    while i <= 28:
        print(f"GPIO: {i}")
        pin = Pin(i, Pin.OUT)
        try:
            pin.toggle()
            sleep(1) # sleep 1sec
        except:
            break
        pin.off()
        i = i + 1

## intial check for the hardware communication with the board
## as our infarred sensor is connected to the gpio and reading the pin assigned to it
def pinCheck():
    sensor = Pin(27, Pin.IN, Pin.PULL_UP)

    if(sensor.value() == 0):
        print('On')
    else:
        print('off')


## main Function
def __main_():
    ## print("Board GPIO Signal Tester")
    ## gpio_tester()

    CURRENTPLAYER = random.choice(PLAYER)

    while True:
        ##print('\nDisplaying the board')
        ##display_Board()

        ##col = int(input("Enter your move (0-6): "))

        ##if(check_move(col)):
        ##    print('valid move')
        ##else:
        ##    print('invalid move')
        pinCheck()
        sleep(1)


__main_()


