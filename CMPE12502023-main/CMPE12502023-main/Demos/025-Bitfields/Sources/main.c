/********************************************************************/
// HC12 Program:  BietFields
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here               
// Date:          Nov, 8th, 2023
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
  typedef struct SWL_Bitfields_Typedef__
  {
    unsigned int SwMid_BIT:1;
    unsigned int SwRight_BIT:1;
    unsigned int SwDown_BIT:1;
    unsigned int SwLeft_BIT:1;
    unsigned int SwUp_BIT:1;
    unsigned int GreenLed_BIT:1;
    unsigned int YellowLed_BIT:1;
    unsigned int RedLed_BIT:1;
  }SWL_Bitfields;

  SWL_Bitfields* port;
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
  port = (SWL_Bitfields*)&PT1AD1;
  while(1);
/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    if(port->SwLeft_BIT)
    {
      port->RedLed_BIT = 1;
    }
    else
    {
      port->RedLed_BIT = 0;
    }

    if(port->SwMid_BIT)
    {
      port->YellowLed_BIT = 1;
    }
    else
    {
      port->YellowLed_BIT = 0;
    }
    if(port->SwRight_BIT)
    {
      port->GreenLed_BIT = 1;
    }
    else
    {
      port->GreenLed_BIT = 0;
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/


/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
