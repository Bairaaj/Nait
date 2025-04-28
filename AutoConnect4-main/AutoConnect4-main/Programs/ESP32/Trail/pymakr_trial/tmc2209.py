from machine import Pin
import utime

step_pin = Pin(22, Pin.OUT)   # STEP
dir_pin = Pin(1, Pin.OUT)    # DIR
enable_pin = Pin(23, Pin.OUT) # EN

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