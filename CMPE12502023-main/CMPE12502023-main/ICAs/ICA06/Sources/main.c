/********************************************************************/
// HC12 Program:  ICA06
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       Clock MHZ configure             
// Date:          Oct 21, 2023
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

/********************************************************************/
// Global Variables
/********************************************************************/
unsigned long int i;
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
    SWL_Init(); 
  
   //Clock_EnableOutput(ClockOutDiv1);
/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    i = Clock_GetBusSpeed();

    DelayMs(100);
    SWL_TOG(SWL_RED);
    
    if(SWL_Pushed(SWL_UP))
    {
      Clock_Set8MHZ();
    }

     if(SWL_Pushed(SWL_LEFT))
    {
      Clock_Set20MHZ();
    }

    if(SWL_Pushed(SWL_CTR))
    {
      Clock_Set24MHZ();
    }

    if(SWL_Pushed(SWL_RIGHT))
    {
      Clock_Set40MHZ();
    }
    

  }
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/


