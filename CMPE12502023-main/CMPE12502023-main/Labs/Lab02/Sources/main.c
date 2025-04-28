/********************************************************************/
// HC12 Program:  Lab 2
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       A more detailed explanation of the program is entered here               
// Date:          Dec, 4th, 2023
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
#include "segs.h"

/********************************************************************/
// Constant Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/
void Send16HTop(unsigned int num);
void Send16HBot(unsigned int num);
/**************************;******************************************/
// Global Variables
/********************************************************************/
SwState upState, downState, leftsw, rightsw, centersw;
int count= 0;
int secondscount = 1;
int decimal = 4;
int hexcount = 0;
int deccount = 1;
/********************************************************************/
// Constants
/********************************************************************/

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  // main entry point
  _DISABLE_COP();
  //EnableInterrupts;
  /********************************************************************/
  // initializations
  /********************************************************************/
  Clock_Set20MHZ();
  SWL_Init();
  Segs_Init();
  PITMTLD1 = 200 - 1;   //Load register for MT0
  PITLD0 = 10000 - 1;  //Load register for CH0
  PIT_InitChannel(PIT_CH0, PIT_MT1, PIT_IDIS);
  Segs_16D(0, Segs_LineTop);
  SWL_TOG(SWL_GREEN);

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    Sw_Process(&upState, SWL_UP);
    Sw_Process(&leftsw, SWL_LEFT);
    Sw_Process(&downState, SWL_DOWN);
    Sw_Process(&rightsw, SWL_RIGHT);
    Sw_Process(&centersw, SWL_CTR);
    if(PITTF & PIT_CH0)
    {
      count++;
      if (count == 10)
      {
        count = 0;
        if(deccount)
        {
          Segs_16D(secondscount++, Segs_LineTop);
        }
        if (hexcount)
        {
          Segs_16H(secondscount++, Segs_LineTop);
        }
        
        if (secondscount > 9999)
        {
          secondscount = 0;
        }
        decimal = 4;
        Segs_ClearLine(Segs_LineBottom);
      }
      if (count == 2||count == 4||count == 6||count == 8)
      {
        Segs_Custom(decimal++, SEG_DP);
      }
      PITTF = PIT_CH0;   
    }
    if(upState == Pressed)
    {
      SWL_ON(SWL_YELLOW);
      SWL_OFF(SWL_GREEN);
      deccount = 0;
      hexcount = 1;

    }
    if(downState == Pressed)
    {
      SWL_OFF(SWL_YELLOW);
      SWL_ON(SWL_GREEN);
      deccount = 1;
      hexcount = 0;
    }
    if(centersw == Pressed)
    {
      secondscount = 0;
    }
   

  }                   
}

/********************************************************************/
// Functions
/********************************************************************/


/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
