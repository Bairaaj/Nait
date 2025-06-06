/********************************************************************/
// HC12 Program:  This is a program that is being put into a micro chip that makes a led blink.
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       Program coded for a blinking light in micro curciut              
// Date:          Sept, 8 2023
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


/********************************************************************/
//Defines
/********************************************************************/
#define RED_LED 0b10000000
#define INDEX_MAX 5
/********************************************************************/
// Local Prototypes
/********************************************************************/

/********************************************************************/
// Global Variables
/********************************************************************/
unsigned int counter, index;

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
PT1AD1 |= RED_LED;
DDR1AD1 |= RED_LED;
counter = 0;
index = 0;

/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    if(++counter == 0)
    {
      if (++index >= INDEX_MAX)
      {
        index = 0;
        PT1AD1 ^= RED_LED;
      }
    }

  }                   
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
