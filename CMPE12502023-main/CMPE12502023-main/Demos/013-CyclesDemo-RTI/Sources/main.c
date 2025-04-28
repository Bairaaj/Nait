/********************************************************************/
// HC12 Program:  Clock System demo
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here               
// Date:          Sept-27-2023
// Revision History :
//  each revision will have a date + desc. of changes



/********************************************************************/
// Library includes
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

//Other system includes or your includes go here
//#include <stdlib.h>
//#include <stdio.h>
#include "sw_led.h"
#include "clock.h"

/********************************************************************/
//Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/
void Delay_ms(unsigned int ms);

/********************************************************************/
// Global Variables
/********************************************************************/
volatile unsigned int counter;
/********************************************************************/
// Constants
/********************************************************************/

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  //Any main local variables must be declared here
  
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;

/********************************************************************/
  // one-time initializations
/********************************************************************/
  Clock_Set20MHZ();
  SWL_Init();

  //RTI enabling
  //Decimal, divider 2000, mod8 counter -> 1ms
  RTICTL = 0b10010111;
  CRGINT |= CRGINT_RTIE_MASK; //0b10000000, Enable RTI

/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    //Delay_ms(100);
    if(counter == 100)
    {
      counter = 0;
      SWL_TOG(SWL_RED);
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void Delay_ms(unsigned int ms)
{
    unsigned int i, loopCount;
    for (i = 0; i < ms; i++)
    {
      loopCount = 2659;  //value adjusted, after considering JSR cycles and other overhead
      while(--loopCount); 
    }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vrti void Vrti_ISR(void)
{
  CRGFLG = CRGFLG_RTIF_MASK; //clear flag;
  //Perform some action here
  SWL_TOG(SWL_GREEN);
  ++counter;
}