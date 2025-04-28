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


/********************************************************************/
//Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/
#define LED_RED     0b10000000
#define LED_YELLOW  0b01000000
#define LED_GREEN   0b00100000


/********************************************************************/
// Global Variables
/********************************************************************/
unsigned int i;
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
  DDR1AD1 = 0b11100000;   //LEDs as output, SW as inputs
  //ATD1DIEN1 = 0b00011111; //enable switches


/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    /*Create a loop that iterates 50,000 times 
    and obtain the delay time*/
    i = 50000;  //value adjusted, after considering JSR cycles and other overhead
    while(--i);
    PT1AD1 ^= LED_RED;
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
