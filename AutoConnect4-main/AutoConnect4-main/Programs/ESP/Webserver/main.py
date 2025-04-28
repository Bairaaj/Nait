import network
import socket
import time
import json

# Connect to Wi-Fi
ssid = 'Olan'
password = 'November2001'

station = network.WLAN(network.STA_IF)
station.active(True)
station.connect(ssid, password)

while not station.isconnected():
    print('Connecting...')
    time.sleep(1)

print('Connection successful')
print(station.ifconfig())

# Read HTML, CSS, and JS content from files
with open('index.html', 'r') as file:
    html = file.read()

with open('style.css', 'r') as file:
    css = file.read()

with open('script.js', 'r') as file:
    js = file.read()

# Create a socket and listen for connections
addr = socket.getaddrinfo('0.0.0.0', 80)[0][-1]
s = socket.socket()
s.bind(addr)
s.listen(5)

print('Listening on', addr)

button_press_count = 0

while True:
    cl, addr = s.accept()
    print('Client connected from', addr)
    request = cl.recv(1024)
    request = str(request)
    
    if 'GET /style.css' in request:
        cl.send('HTTP/1.1 200 OK\n')
        cl.send('Content-Type: text/css\n')
        cl.send('Connection: close\n\n')
        cl.sendall(css)
    elif 'GET /script.js' in request:
        cl.send('HTTP/1.1 200 OK\n')
        cl.send('Content-Type: application/javascript\n')
        cl.send('Connection: close\n\n')
        cl.sendall(js)
    elif 'GET /button-pressed' in request:
        button_press_count += 1
        print(f'Button was pressed! Total count: {button_press_count}')
        cl.send('HTTP/1.1 200 OK\n')
        cl.send('Content-Type: text/plain\n')
        cl.send('Connection: close\n\n')
        cl.send(f'Button press received. Total count: {button_press_count}')
    elif 'GET /data' in request:
        data = {
            'button_press_count': button_press_count
        }
        cl.send('HTTP/1.1 200 OK\n')
        cl.send('Content-Type: application/json\n')
        cl.send('Connection: close\n\n')
        cl.send(json.dumps(data))
    else:
        cl.send('HTTP/1.1 200 OK\n')
        cl.send('Content-Type: text/html\n')
        cl.send('Connection: close\n\n')
        cl.sendall(html)
    
    cl.close()
