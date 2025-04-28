/********************************************************************/
// HC12 Program:  #RTI review demo
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here               
// Date:          Nov-29-2023
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

/********************************************************************/
//Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/
void Delay_RTI_ms(unsigned int ms);
/********************************************************************/
// Global Variables
/********************************************************************/
unsigned int msCounter1 = 0;
char toggle = 0;
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
  EnableInterrupts;

/********************************************************************/
  // one-time initializations
/********************************************************************/
  Clock_Set20MHZ();
  RTI_Init();
  SWL_Init();
  sci0_Init(115200, 1);
/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    if(toggle)
    {
      toggle = 0;
      SWL_TOG(SWL_RED);
      Delay_RTI_ms(10);
      SWL_ON(SWL_GREEN);
      Delay_RTI_ms(25);
      SWL_OFF(SWL_GREEN);
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void Delay_RTI_ms(unsigned int ms)
{
  unsigned long tOut = rtiMasterCount + ms;
  while(rtiMasterCount < tOut);
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vrti void Vrti_ISR(void)
{
  CRGFLG = CRGFLG_RTIF_MASK; //clear flag;
  ++rtiMasterCount;
  if(++msCounter1 > 99)
  {//non-blocking event
    toggle = 1;
    msCounter1 = 0;
  }
}

