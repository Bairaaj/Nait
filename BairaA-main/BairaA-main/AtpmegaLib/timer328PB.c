// Timer Library
// Simon Walker, NAIT

#include <avr/io.h>
#include "timer.h"

void Timer_Init2 (Timer_Prescale pre, unsigned int uiInitialOffset)
{
	//PRR1 = 0b00110100;

	TCCR3B = 0;		
	TCCR3B |= pre;	

	OCR3A = TCNT3 + uiInitialOffset;

	TIMSK3 = 0b00000010;
}

void Timer_Init (Timer_Prescale pre, unsigned int uiInitialOffset)
{
	// start code will power off all modules...
	PRR0 &= ~(1 << PRTIM1);

	// set prescale to requested rate
	TCCR1B = 0;		// noise canceler disabled, waveform generator normal
	TCCR1B |= pre;	// put back requested prescale bits
	
	// setup initial event for output compare 1 A
	OCR1A = TCNT1 + uiInitialOffset;

	// setup interrupt for output compare
	// timer/counter 1, output compare A match interrupt enable
	TIMSK1 = 0b00000010;
}
void Timer_F_PWM1 (Timer_PWM_Channel chan, Timer_PWM_ClockSel clksel, Timer_PWM_Pol pol, int iWantInterrupt)
{
	//PRR1 = 0b00110100;
	  if(chan == Timer_PWM_Channel_OC3B)
	  {
		  if(pol == Timer_PWM_Pol_NonInverting)
		  {
			  TCCR3A = 0b10000011;
		  }
		  else
		  {
			  TCCR3A = 0b11000011;
		  }
		  TCCR3B |= clksel; //THIS   
		  
		
		  OCR3A = 128;
		  PORTD |= 0b00000100;
		  DDRD |= 0b00000001;
		  
		  if(iWantInterrupt)
		  {
			  TIMSK3 |= 0b00000001;
		  }
	  }
	  
}
void Timer_F_PWM0 (Timer_PWM_Channel chan, Timer_PWM_ClockSel clksel, Timer_PWM_Pol pol, int iWantInterrupt)
{
  // setup fast PWM mode (closest to what we did in micro)
  // want 'negative polarity', so start low, go high on match, go low at end of period

  // start code will power off all modules...
  // ensure power is on : Timer 0
  // PRR on 328P, PRR0 on 328PB
  PRR0 &= ~(1 << PRTIM0);
  
  if (chan == Timer_PWM_Channel_OC0A) // 14.4
  {
    // (14.9.1) register, DDR comment
    if (pol == Timer_PWM_Pol_NonInverting)
    {
      TCCR0A = 0b10000011;  // fast pwm (mode 3), channel OC0A (14.7.3), non-inverting mode
      // non-inverting is like +'ve polarity on 9S12
    }
    else
    {
      TCCR0A = 0b11000011;  // fast pwm (mode 3), channel OC0A (14.7.3), inverting mode
      // inverting is like -'ve polarity on 9S12
    }
    
    TCCR0B = clksel;      // set the desired clock
    // start with 50% duty
    
    OCR0A = 0x7F;
    
    // pin must be marked as output
    // (14.9.1) register, DDR comment
    DDRD |= 0b01000000;
    
    // setup interrupts
    if (iWantInterrupt)
		  TIMSK0 |= 0b00000001;
  }
}