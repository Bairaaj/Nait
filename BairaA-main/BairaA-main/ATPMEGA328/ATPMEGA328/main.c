/*
 * ATPMEGA328.c
 *
 * Created: 2024-11-29 1:28:45 PM
 * Author : abaira1
 */ 

#define F_CPU 2E6 // with external xtal enabled, and clock div/8, bus == 2MHz
#include <avr/io.h>
#include <util/delay.h> // have to add, has delay implementation (requires F_CPU to be defined)
#include <avr/sleep.h>
#include <avr/interrupt.h>
#include <stdio.h>

#include "I2C.h"
#include "sci.h"
#include "timer.h"


const unsigned int _Timer_OC_Offset = 250; // 1 / (2000000 / 8 / 250) = 1ms (prescale 8)

volatile unsigned char _PWM_DutyVal = 0;


int main(void)
{
	SCI0_Init(F_CPU, 9600, 0);
	

	SCI0_TxString("\n328 Up! PWM!\n");
	
	//Timer_Init2(Timer_Prescale_8, _Timer_OC_Offset); // 1ms intervals
	Timer_Init(Timer_Prescale_8, _Timer_OC_Offset);
	// bring up pwm (debug)
	//Timer_F_PWM1(Timer_PWM_Channel_OC3B, Timer_PWM_ClockSel_Div64, Timer_PWM_Pol_NonInverting, 1);
	
	Timer_F_PWM0(Timer_PWM_Channel_OC0A, Timer_PWM_ClockSel_Div64, Timer_PWM_Pol_NonInverting, 1);
	
	
	
	sleep_enable();
	sei();
    /* Replace with your application code */

	DDRC &= (~0b00000001);
	
	DDRD |= 1 << PORTD3; // make portd pin 7 an output (PD7)
	DDRD |= 1 << PORTD4; // make portd pin 7 an output (PD7)
	
	PORTD |= (1 <<PORTD4);

    while (1)
	{
		if((PINC & (1 << PINC0)) == 0)
		{
			//Turn off LED
			PORTD &= ~(1 <<PORTD3);
			_PWM_DutyVal = 30;
		}
		else
		{
			//Turn on LED
			PORTD |= (1 <<PORTD3);
			_PWM_DutyVal = 70;
		}
    }
}

ISR(TIMER1_COMPA_vect)
{
	// rearm the output compare operation
	OCR1A += _Timer_OC_Offset; // 1ms intervals
}

ISR (TIMER0_OVF_vect)
{
	OCR0A = _PWM_DutyVal;
}
