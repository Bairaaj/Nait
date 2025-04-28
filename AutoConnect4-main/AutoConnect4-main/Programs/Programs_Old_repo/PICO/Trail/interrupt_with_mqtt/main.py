from machine import Pin
from utime import sleep
import connection
import mqtt

connection.connect()


# sensor_pins = [Pin(x, Pin.IN) for x in range(16, 23)]
sensor_pins = [Pin(14, Pin.IN),
                Pin(15, Pin.IN)]


TOPIC = "sensor"
BROKER = "172.20.10.9" 
mqtt_message = ''
sent_message = False



def pin_handler(pin):
    global sent_message
    global mqtt_message
    sent_message = True
    if(pin == sensor_pins[0]):
        mqtt_message = f'1'
    else:
        mqtt_message = '0'
    print(f'interrupt: {pin}')

print('assigning interrupt')

for pin in sensor_pins:
    pin.irq(trigger=Pin.IRQ_FALLING, handler=pin_handler)



while True:
    if sent_message:
        sent_message = False
        print( 'Infinite Loop: ' + mqtt_message)
        mqtt.mqtt_pub_init(BROKER, topic, mqtt_message)


# from machine import Pin
# from utime import sleep
# import connection
# import mqtt

# # Connect to Wi-Fi
# connection.connect()

# # Create sensor pins (GPIO 16 to 22)
# sensor_pins = [Pin(x, Pin.IN) for x in range(16, 23)]

# # MQTT settings
# topic = "sensor/Num"
# BROKER = "10.0.0.14"  # Replace with your laptop’s IP if different
# mqtt_message = ''
# sent_message = False

# # Pin number mapping (since _pin_num() doesn’t exist)
# PIN_MAP = {Pin(x, Pin.IN): str(x-15) for x in range(16, 23)}

# def pin_handler(pin):
#     global sent_message, mqtt_message
#     mqtt_message = PIN_MAP.get(pin, "unknown")  # Get pin number from map
#     sent_message = True
#     print(f'interrupt: {pin}')

# # Set up interrupts for all pins
# for pin in sensor_pins:
#     pin.irq(trigger=Pin.IRQ_FALLING, handler=pin_handler)

# # Main loop
# while True:
#     if sent_message:
#         sent_message = False
#         print('Infinite Loop: ' + mqtt_message)
#         mqtt.mqtt_pub_init(BROKER, topic, mqtt_message)  # Publish the pin number
#     sleep(0.1)  # Small delay to avoid tight loop

# testing with input :

# sensor_pins = [Pin(x, Pin.OUT) for x in range(16, 23)]
# for i in sensor_pins:
#     print(i)
#     i.toggle()
#     sleep(1)


