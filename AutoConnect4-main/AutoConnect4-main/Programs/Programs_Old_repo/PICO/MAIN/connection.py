import network
import socket
from utime import sleep

ssid = 'kishor'
password = 'kathmandu1'

def connect():
    wlan = network.WLAN(network.STA_IF)
    wlan.active(True)
    wlan.connect(ssid, password)

    while wlan.isconnected() == False:
        print('Waiting for connection...')
        sleep(1)
    
    ip = wlan.ifconfig()[0]
    print(f'Connected on {ip}')
    return ip
