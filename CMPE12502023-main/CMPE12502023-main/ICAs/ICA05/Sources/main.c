/********************************************************************/
// HC12 Program:  ICA05
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
int count;
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
    count = SW_CountLED();
    if (count < 2)
    {
      if (PT1AD1 & SWL_RIGHT) 
      {
        SWL_ON (SWL_GREEN);
      }
      if (PT1AD1 & SWL_CTR)
      {
        SWL_ON (SWL_YELLOW);
      }
      if (PT1AD1 & SWL_LEFT)
      {
        SWL_ON (SWL_RED);
      }
    }
    if(PT1AD1 & SWL_DOWN || PT1AD1 & SWL_UP)
    {
      SWL_OFF (SWL_ALL);
    }
    
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/

//T1
/*
for (;;)
  {
    if (PT1AD1 & SWL_RIGHT) 
    {
      SWL_ON (SWL_GREEN);
    }
    else
    {
      SWL_OFF(SWL_ALL);
    }
    if (PT1AD1 & SWL_CTR)
    {
      SWL_ON (SWL_YELLOW);
    }
    if (PT1AD1 & SWL_LEFT)
    {
      SWL_ON (SWL_RED);
    }

  }                   
}
*/
//T2
/*
for (;;)
  {
    if (PT1AD1 & SWL_RIGHT) 
    {
      SWL_ON (SWL_GREEN);
    }
    if (PT1AD1 & SWL_CTR)
    {
      SWL_ON (SWL_YELLOW);
    }
    if (PT1AD1 & SWL_LEFT)
    {
      SWL_ON (SWL_RED);
    }
    if(PT01AD1 & SWL_DOWN || PT01AD1 & SWL_UP)
    {
      SWL_OFF (SWL_ALL);
    }

  }              
  */
 //T3
 /*
    count = SW_CountLED();
    if (count < 2)
    {
      if (PT1AD1 & SWL_RIGHT) 
      {
        SWL_ON (SWL_GREEN);
      }
      if (PT1AD1 & SWL_CTR)
      {
        SWL_ON (SWL_YELLOW);
      }
      if (PT1AD1 & SWL_LEFT)
      {
        SWL_ON (SWL_RED);
      }
    }
    if(PT1AD1 & SWL_DOWN || PT1AD1 & SWL_UP)
    {
      SWL_OFF (SWL_ALL);
    }
    
    if(((((PT1AD1 & SWL_RED) >> 1) + (PT1AD1 & SWL_YELLOW) + ((PT1AD1 & SWL_GREEN) << 1)) >> 6) < 2) 
    {
      if (PT1AD1 & SWL_RIGHT) 
      {
        SWL_ON (SWL_GREEN);
      }
      if (PT1AD1 & SWL_CTR)
      {
        SWL_ON (SWL_YELLOW);
      }
      if (PT1AD1 & SWL_LEFT)
      {
        SWL_ON (SWL_RED);
      }
    }
    if(PT1AD1 & SWL_DOWN || PT1AD1 & SWL_UP)
    {
      SWL_OFF (SWL_ALL);
    }
    */