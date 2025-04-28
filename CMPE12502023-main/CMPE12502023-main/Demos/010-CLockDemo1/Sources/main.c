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
  //Any main local variables must be declared here
  
  // main entry point
  _DISABLE_COP();
  //EnableInterrupts;

/********************************************************************/
  // one-time initializations
/********************************************************************/
  
  //Clock Config.
  SYNR = 5; //0x5, set multiplier to: 5+1 = 6
  REFDV = 3; //0x3, set divider to: 3+1 = 4

  PLLCTL = PLLCTL_PLLON_MASK | PLLCTL_AUTO_MASK;//PLL ON and AUTO

  while(!(CRGFLG & CRGFLG_LOCK_MASK));//Wait for PLL to lock

  CLKSEL |= CLKSEL_PLLSEL_MASK; //Select PLL as clock source


  ECLKCTL = 0; //Enable clock outputs


  SWL_Init();


/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
   
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
