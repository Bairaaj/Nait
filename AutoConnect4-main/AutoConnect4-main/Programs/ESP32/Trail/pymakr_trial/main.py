from machine import Pin
import time
import connection
import mqtt
import tmc2209
import stepper_motor
boolean = False

BROKER = "10.0.0.14"
topic = "sensor/Num"

def callback(topic, msg):
    global boolean
    boolean = True
    print(f"Topic: {topic}")
    print(f"Received: {msg}")

#ip = connection.connect()
#client = mqtt.mqtt_sub_init(BROKER, topic, callback)
print(f"Connected to broker at {BROKER}")
    
while True:
    #client.wait_msg()
    stepper_motor.stepper_rotate(512)
    if boolean:
        boolean = False
        
