from machine import Pin
from utime import sleep
import connection
import mqtt

pin = Pin(28, Pin.IN)

BROKER = "10.0.0.14" 
TOPIC = "test1"
topic = "test"
a = 0

def callback(topic, msg):
    print(f"Received: {msg}")
    print(f"Topic: {topic}")
    # mqtt.mqtt_pub_init(BROKER, topic, msg)

ip = connection.connect()
# client = mqtt.mqtt_sub_init(BROKER, TOPIC, callback)
# mqtt.mqtt_pub_init(BROKER, topic, 'Hello World')

while True:
    # client.wait_msg()
    if pin.value() == 0:
        mqtt.mqtt_pub_init(BROKER, topic, 'OFF')
    else:
        mqtt.mqtt_pub_init(BROKER, topic, 'ON')
