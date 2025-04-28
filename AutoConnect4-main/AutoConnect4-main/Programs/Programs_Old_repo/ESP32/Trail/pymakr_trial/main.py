from machine import Pin
import utime
from connection import connect
# import mqtt

# connect()

broker = "172.20.10.9"
topic = "sensor"
move_val = 1342
rev = 3
run = False



step_pin = Pin(12, Pin.OUT)   # STEP
dir_pin = Pin(14, Pin.OUT)    # DIR
enable_pin = Pin(27, Pin.OUT) # EN

# Enable the driver (active low)
enable_pin.value(0)

# Function to step the motor
def step_motor(steps, direction, delay_ms=2):
    dir_pin.value(direction)  # 0 or 1 to set direction
    for _ in range(steps):
        step_pin.value(1)     # Pulse high
        utime.sleep_ms(delay_ms // 2)  # Half delay
        step_pin.value(0)     # Pulse low
        utime.sleep_ms(delay_ms // 2)  # Half delay

def callback(topic, msg):
    global rev
    print(f"Received: {msg}")
    rev = int(msg)
    print(f"Topic: {topic}")
    run = True

# client = mqtt.mqtt_sub_init(broker, topic, callback)
# print(f"Connected to broker at {broker}")
    

# step_motor(move_val, 0)


# utime.sleep(8) 

step_motor(move_val * rev, 0)
utime.sleep(8) 
step_motor(move_val * rev, 1)

#step_motor(800,0)




