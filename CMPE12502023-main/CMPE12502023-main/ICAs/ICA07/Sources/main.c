/********************************************************************/
// HC12 Program:  ICA07
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       RTI Configure
// Date:          Oct 21, 2023
// Revision History :
//  each revision will have a date + desc. of changes

/********************************************************************/
// Library includes
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

// Other system includes or your includes go here
#include <stdlib.h>
// #include <stdio.h>
#include "sw_led.h"
#include "clock.h"
#include "rti.h"

/********************************************************************/
// Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/

/********************************************************************/
// Global Variables
/********************************************************************/

/********************************************************************/
// Constants
/********************************************************************/
int count = 0;
/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  // Any main local variables must be declared here

  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  RTI_Init();
  SWL_Init();

  /********************************************************************/
  // one-time initializations
  /********************************************************************/

  /********************************************************************/
  // main program loop
  /********************************************************************/

  for (;;)
  {
    RTI_Delay_ms(1000);

    if (count == 0)
    {
      if (SWL_Pushed(SWL_LEFT))
      {
        count = 1;
      }
      SWL_TOG(SWL_GREEN);
      SWL_OFF(SWL_YELLOW);
    }

    if (count == 1)
    {
      if (SWL_Pushed(SWL_RIGHT))
      {
        count = 0;
      }
      SWL_TOG(SWL_YELLOW);
      SWL_OFF(SWL_GREEN);
    }
    
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vrti void Vrti_ISR(void)
{
  CRGFLG = CRGFLG_RTIF_MASK; // clear flag;
  SWL_TOG(SWL_RED);
  rtiMasterCount++;
}

// PART A
/*interrupt VectorNumber_Vrti void Vrti_ISR(void)
{
  CRGFLG = CRGFLG_RTIF_MASK; //clear flag;
  SWL_TOG(SWL_RED);
  rtiMasterCount++;
}*/
// PART B
/*interrupt VectorNumber_Vrti void Vrti_ISR(void)
{
  CRGFLG = CRGFLG_RTIF_MASK; //clear flag;
  SWL_TOG(SWL_RED);
  rtiMasterCount++;
  RTI_Delay_ms(100);
  SWL_TOG(SWL_GREEN);

}*/

// PART C
/*
if (count == 0)
      {
        if (RTI_Delay_ms(1000))
        {
          if(SWL_Pushed(SWL_LEFT))
          {
            count = 1;
          }
          SWL_TOG(SWL_GREEN);
          SWL_OFF(SWL_YELLOW);
        }
      }
      if (count == 1)
      {
        if (RTI_Delay_ms(1000))
        {
          if (SWL_Pushed(SWL_RIGHT))
          {
            count = 0;
          }
          SWL_TOG(SWL_YELLOW);
          SWL_OFF(SWL_GREEN);
      }

*/