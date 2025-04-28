/********************************************************************/
// HC12 Program:  YourProg - PWM MOdule demo 1
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       Input capture, display period in us
//                Work @20MHz using precision prescaler
//                 Ultrasonic sensor SR04
                  
// Date:          March 9, 2023
// Revision History :
//  each revision will have a date + desc. of changes


/*
Ticks @16[us]
C4 -> 261.63[Hz] -> 3.83[ms] -> 239 ticks
D4 -> 293.66[Hz] -> 3.40[ms] -> 213 ticks
E4 -> 329.63[Hz] -> 3.03[ms] -> 190 ticks

*/
/********************************************************************/
// Constant Defines
/********************************************************************/
#define NUMBER_OF_FREQ 8
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
#include "clock.h"
#include "sw_led.h"
#include "segs.h"
#include "rti.h"

/********************************************************************/
// Library includes
/********************************************************************/
// your includes go here


/********************************************************************/
// Local Prototypes
/********************************************************************/

/********************************************************************/
// Global Variables
/********************************************************************/
/*
        Period ticks calculation:
        Ticks =  Peiord/TickTime
        For instance:
        -For A central 440Hz-> 2.27[ms]
        Ticks = 2.27[ms] / 16[us] = 142.045 ticks
*/
                                         /* Do - Re - Mi - Fa - Sol - La - Si - Do */
                                         /* C4 - D4 - E4 - F4 - G4 - A4 - B4 - C5 */
unsigned int CountsArray[NUMBER_OF_FREQ] = {239, 213, 190, 179, 159, 142, 127, 119};//Array of mod-down counts
int index = 0;
SwState leftState, rightState;
/********************************************************************/
// Constants
/********************************************************************/

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  
  /********************************************************************/
  // initializations
  /********************************************************************/
  SWL_Init();

  //PWM configuration - channel 6 (Speaker)
  //Working @8[MHz], me use a prescale of 128 to get 16[us] ticks
  PWMPRCLK |= PWMPRCLK_PCKB2_MASK | PWMPRCLK_PCKB1_MASK | PWMPRCLK_PCKB0_MASK;//Prescaler for B clock = 16[us] tick

  //Clock B for channel 6
  PWMCLK_PCLK6 = 0;

  //PWM positive polarity
  PWMPOL_PPOL6 = 1;  //PWM conf: High at the beginning of the period

  //set period
  PWMPER6 = CountsArray[index]; //Define Period

  //set Duty cycle 50%
  PWMDTY6 = PWMPER6 / 2;  //Define Pulse width
  
  PWME |= PWME_PWME6_MASK;  //Enable channel 6(speaker)
  
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(Sw_ProcessD(&rightState, SWL_RIGHT) ==  Pressed)
    {
      if(++index > NUMBER_OF_FREQ - 1)
      {
        index = 0;
      }
      PWMPER6 = CountsArray[index];
      PWMDTY6 = PWMPER6 / 2;      
    }
    if(Sw_ProcessD(&leftState, SWL_LEFT) ==  Pressed)
    {
      if(--index < 0)
      {
        index = NUMBER_OF_FREQ - 1;
      }
      PWMPER6 = CountsArray[index];
      PWMDTY6 = PWMPER6 / 2;      
    }
  }                   
}

/********************************************************************/
// Functions

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
