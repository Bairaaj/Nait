/********************************************************************/
// HC12 Program:  Exam 1 Demo
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
//#include "clock.h"

/********************************************************************/
//Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/



/********************************************************************/
// Global Variables
/********************************************************************/
unsigned int timeON = 10, timeOFF = 15;
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
    if(SWCount()  == 2)
    {
      SWL_ON(SWL_GREEN);
      timeON = 15;
      timeOFF = 10;
    }
    else
    {
      SWL_OFF(SWL_GREEN);
      timeON = 10;
      timeOFF = 15;
    }
    SWL_ON(SWL_RED);
    Delay_ms(timeON);
    SWL_OFF(SWL_RED);
    Delay_ms(timeOFF);

  }                   
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
