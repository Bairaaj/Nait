Project Proposal - MOTION ACTIVATED Activated Door

This project aims to design and build an automated door opener with a motion sensor and a servo motor. The door will automatically open when motion is detected and close afterward after some time. It can be used in homes, apartment buildings, and many more places that need a secure way to keep people from entering buildings. I will use a 1:10 scale model of a building door to show the functionality of the motion-activated door

Hardware

The ATmega328PB microcontroller will be the system's brain, controlling the servo motor and processing sensor signals. As a beginner with this chip, I must explore how to program and set it up, including choosing the correct programming tools and exploring more about this chip

I will use the PIR(MOTION) sensor from ADAFRUIT (https://www.adafruit.com/product/189) to allow people to access the door. It uses the 5-volt logic to open and close the door and will be able to run with 5v - 12v.

For opening and closing the door, I will use the S0025P servo motor I have experience using this Motor in the past. It runs on 667 hz and uses 3.3V to 5.0V, and this will serve as the door opener

PowerSupply: I would like to try to use a USB interface. I plan to have an onboard USB powered since it will be mounted on a wall on the 1:10 scale model of a building door.

(Revision)
Power supply: I have decided to use a 9 Volt battery instead to power my motor and motion sensor i will combine it with the LM7805 with capacitors to get a constant 5 volts.

I plan to house all components in a small form and factor using 3D printed parts, showcasing the housing and how it would be mounted to a door and wall.




Software

I will be using the provided libraries for the atmeta328 chip. This should help me start using the chip, but I will make my libraries for the RC552 as they are not provided. The ATmeta328 uses C or C++. I will probably use C more than C++ since I am more familiar with it; if needed, I might switch to C++ if it is easier to program the chip. The result would be sending a PWM signal through the chip that will activate the motor, allowing the door to close and causing a delay in when the door should be closed through the software side.


Research

I will see the limits to the ATMEGA328P chip, as this is my first time using it
I will do in-depth research on how to use the Motion sensor as it is my first time using it
For PWM for the motor, I will need to find its active range


Proof of Concept
This initial proof of concept will focus on using the servo motor and NFC Reader to open and close a miniature door. The motion sensor will detect motion and tell the micro to activate the servo motor, and after a little wait timer using software, it will close the door. For this, I will use the motion sensor by Adafruit, and combined with the Servo motor and atmega328p dip chip, it will allow me to show proof of life. Additionally, I will use the programmer to create code that recognizes the motion of a person and uses the logic to open the door.

Goals, if time permits
- Maybe add LCD or LED indicators to show if entry is permitted


Final Build
I will create a small-scale door model using 3D-printed parts to house all the electronics and simulate a 1:10 scale door that could be integrated into any door using more significant parts. 

Schedule
Week 1 - 3
- Finish Proposal
- Research and order parts

Week 3 - 6
- Design schematic
- Make proof of life
- Begin development of software

Week 6 - 8
- Design 3D simulation of a building door
- begin PCB design
- tinker and refine software implementation

Week 8 - 11
- Finish PCB design and get PCB made
- Continue 3d modeling and improving the software for easy installation when PCB comes

week 11 - 13
- Complete software
- Build and complete the Project and do further testing when all assembled
