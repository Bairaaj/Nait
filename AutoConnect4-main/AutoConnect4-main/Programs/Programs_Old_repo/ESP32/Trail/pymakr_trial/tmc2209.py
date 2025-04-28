from machine import Pin
import utime

step_pin = None
dir_pin = None
enable_pin = None

def tmc_init (step_p : int, dir_p : int, enable_p : int) :
    global step_pin, dir_pin, enable_pin

    step_pin = Pin(step_p, Pin.OUT)   # STEP
    dir_pin = Pin(dir_p, Pin.OUT)    # DIR
    enable_pin = Pin(enable_p, Pin.OUT) # EN

    enable_pin.value(0)

def step_motor(steps, direction, delay_ms=2):
    
    global step_pin, dir_pin, enable_pin

    dir_pin.value(direction)  # 0 or 1 to set direction

    for _ in range(steps):
        step_pin.value(1)     # Pulse high
        utime.sleep_ms(delay_ms // 2)  # Half delay
        step_pin.value(0)     # Pulse low
        utime.sleep_ms(delay_ms // 2)  # Half delay