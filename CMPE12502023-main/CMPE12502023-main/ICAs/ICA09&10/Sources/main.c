/********************************************************************/
// HC12 Program:  ICA 09
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       ICA            
// Date:          Nov 30th 2023
// Revision History :
//  each revision will have a date + desc. of changes



/********************************************************************/
// Library includes
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

//Other system includes or your includes go here
//#include <stdlib.h>
#include <stdio.h>  //for sprintf


#include "sw_led.h"
#include "clock.h"
#include "rti.h"
#include "sci.h"
#include "pit.h"

#include <string.h> //for using memset and memcpy

/********************************************************************/
//Defines
/********************************************************************/
#define BUFFER_SIZE 64
/********************************************************************/
// Local Prototypes
/********************************************************************/


/********************************************************************/
// Global Variables
/********************************************************************/
SwState leftsw, centersw, rightsw, upsw, downsw;
int enable = 1;
int disable = 0;
int us = 200;
int ticks = 0;
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
  Clock_Set20MHZ();
  
  /*
    for 50 ms delay for MT0 and PIT0
    20E6 * 50E-3 = 1000000 ticks
    1000000 / 200 = 5000
    so 200 - 1 for MT0
    and 5000 - 1 for PIT0
    for 20MHZ clockspeed
  */
  PITMTLD0 = 200 - 1;
  PITLD0 = 5000 - 1;  
  PIT_InitChannel(PIT_CH0, PIT_MT0, PIT_IDIS);
/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    Sw_Process(&upsw, SWL_UP);
    Sw_Process(&downsw, SWL_DOWN);
    Sw_Process(&leftsw, SWL_LEFT);
    Sw_Process(&centersw, SWL_CTR);
    Sw_Process(&rightsw, SWL_RIGHT);
  
    if (downsw == Pressed)
    {
      enable = 0;
      disable = 0;
    }
    if (upsw == Pressed)
    {
      enable = 1;
      disable = 0;
    }
    if (leftsw == Pressed)
    {
      disable = 1;
      enable = 2;
    }
    //Part A
    if (enable)
    {
      //non blocking pit
      if (PITTF & PIT_CH0)
      {
          SWL_TOG(SWL_RED);
          //blocking delay
          PIT_Sleep(PIT_CH1, 20);

          SWL_TOG(SWL_GREEN);
      }
    }
    //Part B
    if (!enable)
    {
      if (PITTF & PIT_CH0)
      {
          SWL_TOG(SWL_RED);
          PIT_Sleep(PIT_CH1, 60);
          SWL_TOG(SWL_GREEN);
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
