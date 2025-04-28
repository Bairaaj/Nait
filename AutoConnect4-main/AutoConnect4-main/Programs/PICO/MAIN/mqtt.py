from simple import MQTTClient
from utime import sleep


def mqtt_sub_init(broker, topic, func):
    client = MQTTClient("pico", broker)
    client.set_callback(func)
    client.connect()
    client.subscribe(topic)
    return client

def mqtt_pub_init(broker, topic, message):
    client = MQTTClient("pico", broker)
    client.connect()
    client.publish(topic, message)
    sleep(1)
    client.disconnect()
