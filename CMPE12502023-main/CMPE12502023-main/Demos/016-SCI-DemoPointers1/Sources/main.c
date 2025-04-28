/********************************************************************/
// HC12 Program:  Pointers Demo
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here               
// Date:          Oct-25-2023
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

/********************************************************************/
//Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/
void IncrementBy2(int*);

/********************************************************************/
// Global Variables
/********************************************************************/
char message[] ="Hello World";
/********************************************************************/
// Constants
/********************************************************************/

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  //Any main local variables must be declared here
  int counter = 0;
  int* pCounter = &counter;
  char test = *(message+6);  //message[6]
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;

/********************************************************************/
  // one-time initializations
/********************************************************************/
  SWL_Init();



/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    IncrementBy2(pCounter);  //using pointer variable
    IncrementBy2(&counter);  //using variable address
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void IncrementBy2(int* pValue)
{
  *pValue +=2;
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/