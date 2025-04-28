from machine import Pin
from time import sleep

# Define GPIO pins for ULN2003 driver
IN1 = Pin(4, Pin.OUT)
IN2 = Pin(2, Pin.OUT)
IN3 = Pin(0, Pin.OUT)
IN4 = Pin(15, Pin.OUT)

# Step sequence for 28BYJ-48 stepper motor (half-step mode for smoother motion)
step_sequence = [
    [1, 0, 0, 0],
    [1, 1, 0, 0],
    [0, 1, 0, 0],
    [0, 1, 1, 0],
    [0, 0, 1, 0],
    [0, 0, 1, 1],
    [0, 0, 0, 1],
    [1, 0, 0, 1]
]

# Function to move the stepper motor
def stepper_rotate(steps, delay=0.001):
    for _ in range(steps):
        for step in step_sequence:
            IN1.value(step[0])
            IN2.value(step[1])
            IN3.value(step[2])
            IN4.value(step[3])
            sleep(delay)  # Control speed

# while True:
#     # Run the stepper motor
#     print("Rotating stepper motor forward...")
#     stepper_rotate(512)  # One full rotation (28BYJ-48 has ~4096 steps per full rev)
#     sleep(1)
#     print("Rotating stepper motor backward...")
#     stepper_rotate(-512)  # Reverse direction
