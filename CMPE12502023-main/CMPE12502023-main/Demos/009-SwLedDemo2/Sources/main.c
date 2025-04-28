/********************************************************************/
// HC12 Program:  Demo Cycles and time.
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
unsigned int i;
SwState centerState = Idle;
//SwState *pCenterState = &centerState;
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
  SWL_Init();


/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    if(Sw_Process(&centerState, SWL_CTR) == Pressed)
    {
      SWL_TOG(SWL_RED);
    }

    // if(SWL_Pushed(SWL_CTR))
    // {//Switch is active
    //   if(centerState == Idle)
    //   {//First time switch was detected active
    //     centerState =  Pressed; //action here
    //     SWL_TOG(SWL_RED);
    //   }
    //   else
    //   {//switch was already active
    //     centerState = Held;
    //   }   
    // }
    // else
    // {//switch is inactive
    //   if(centerState == Held)
    //   {//switch was just released
    //     centerState = Released;
    //     //SWL_TOG(SWL_RED);
    //   }
    //   else
    //   {//switch was already released
    //     centerState = Idle;
    //   }
    // }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
