/********************************************************************/
// HC12 Program:  PIT [us] delay
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here               
// Date:          Nove, 8th, 2023
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

unsigned int usDelays[] = {200, 100, 50};
int usIndex = 0;
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
  Clock_Set24MHZ();
  SWL_Init();

  /*PIT1(CH3) Configuration to 1[ms] event*/

  //PITMUX |= PITMUX_PMUX3_MASK; //Connect PIT3 to Micro Timer 1
  PITMUX |= PIT_CH3; //Connect PIT3 to Micro Timer 1
  /*
    x[xs] event
    20E6 * 1[ms] = 20,000 = 1 * 20,000
  */
  PITMTLD1 = 1 - 1;       //Micro Timer 1 : bypass

  PITINTE &= ~PIT_CH3; //interrupt disabled

  //PITCE |= PITCE_PCE3_MASK; //enable channel 3 (PIT3)
  PITCE |= PIT_CH3; //enable channel 3 (PIT3)

  PITCFLMT |= PITCFLMT_PITE_MASK; //Enable PIT Timer (Global)
/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    if(SWL_Pushed(SWL_LEFT))
    {
      usIndex = 0;
    }
    else if (SWL_Pushed(SWL_CTR))
    {
      usIndex = 1;
    }
    else if (SWL_Pushed(SWL_RIGHT))
    {
      usIndex = 2;
    }
    //set the number of ticks base on the [us]
    PITLD3 = Clock_GetBusSpeed() / 1000000 * usDelays[usIndex];

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

    while(!(PITTF & PIT_CH3)); //wait for flag to become active
    PITTF = PIT_CH3;         //clear flag;      
    SWL_TOG(SWL_RED);
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/


/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
