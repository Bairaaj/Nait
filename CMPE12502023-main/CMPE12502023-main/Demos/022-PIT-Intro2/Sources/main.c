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

/********************************************************************/
//Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/

/********************************************************************/
// Global Variables
/********************************************************************/


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
  // one-time initializations
/********************************************************************/
  Clock_Set20MHZ();
  SWL_Init();

  /*PIT Configuration*/
  PITMUX &= ~PITMUX_PMUX1_MASK; //Connect PIT1 to Micro Timer 0
  /*
    200[ms] event
    20E6 * 200[ms] = 4,000,000 = 100 * 40,000
  */
  PITMTLD0 = 100 - 1; 
  PITLD1 = 40000 - 1;

  PITINTE &= ~PITINTE_PINTE1_MASK; //interrupt disabled

  PITCE |= PITCE_PCE1_MASK; //enable channel 1 (PIT1)

  PITCFLMT |= PITCFLMT_PITE_MASK; //Enable PIT Timer (Global)
/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    if(PITTF & PITTF_PTF1_MASK)
    {
      PITTF = PITTF_PTF1_MASK;
      SWL_TOG(SWL_GREEN);
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/


/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
