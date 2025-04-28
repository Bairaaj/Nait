import network
import socket

# Connect to Wi-Fi
ssid = 'your_SSID'
password = 'your_PASSWORD'

station = network.WLAN(network.STA_IF)
station.active(True)
station.connect(ssid, password)

while not station.isconnected():
    pass

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
    else:
        cl.send('HTTP/1.1 200 OK\n')
        cl.send('Content-Type: text/html\n')
        cl.send('Connection: close\n\n')
        cl.sendall(html)
    
    cl.close()
