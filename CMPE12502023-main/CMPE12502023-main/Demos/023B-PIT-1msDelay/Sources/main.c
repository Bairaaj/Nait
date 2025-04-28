/********************************************************************/
// HC12 Program:  PIT Intro
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
#include "rti.h"
#include "sci.h"
#include "pit.h"

/********************************************************************/
//Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/

/********************************************************************/
// Global Variables
/********************************************************************/
unsigned int msDelay = 0;

/********************************************************************/
// Constants
/********************************************************************/

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  int i;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;

/********************************************************************/
  // one-time initializations
/********************************************************************/
  Clock_Set20MHZ();
  SWL_Init();

  /*PIT1(CH3) Configuration to 1[ms] event*/

  //PITMUX |= PITMUX_PMUX3_MASK; //Connect PIT3 to Micro Timer 1
  PITMUX |= PIT_CH3; //Connect PIT3 to Micro Timer 1
  /*
    1[ms] event
    20E6 * 1[ms] = 20,000 = 1 * 20,000
  */
  PITMTLD1 = 1 - 1;       //Micro Timer 1 : bypass

  //PITLD3 = 20000 - 1;     //20,000 ticks
  PITLD3 = Clock_GetBusSpeed() / 1000 - 1;

  //PITINTE &= ~PITINTE_PINTE3_MASK; //interrupt disabled
  PITINTE &= ~PIT_CH3; //interrupt disabled

  //PITCE |= PITCE_PCE3_MASK; //enable channel 3 (PIT3)
  PITCE |= PIT_CH3; //enable channel 3 (PIT3)

  PITCFLMT |= PITCFLMT_PITE_MASK; //Enable PIT Timer (Global)
/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    msDelay = 33;
    
    /*
    If the counter is already active, it could be at any point
    to start a new fresh count before we start looping, we force load
    the counter (reload to the maximum), an clear the flag in case it's 
    already active for some reason
    */

    //PITFLT |= PITFLT_PFLT3_MASK;     //Force load counter;
    PITFLT |= PIT_CH3;                //Force load counter;

    //PITTF = PITFLT_PFLT3_MASK;       //clear flag, in case already active
    PITTF = PIT_CH3;

    //Start looping the 1[ms] delay
    for (i = 0; i < msDelay; i++)
    {
      while(!(PITTF & PIT_CH3)); //wait for flag to become active
      PITTF = PIT_CH3;         //clear flag;      
    }
    SWL_TOG(SWL_RED);
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/


/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
