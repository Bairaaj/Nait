/********************************************************************/
// HC12 Program:  YourProg - PWM 16-bit (concatenation)
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       use 6-7 channels
//                                 
// Date:          March 21, 2023
// Revision History :
// Modified Nov 13, 2023


/********************************************************************/
// Constant Defines
/********************************************************************/

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

#include <string.h>
#include <stdio.h>

#include "clock.h"
#include "rti.h"
#include "sw_led.h"
#include "segs.h"
#include "sci.h"


/********************************************************************/
// Library includes
/********************************************************************/
// your includes go here


/********************************************************************/
// Local Prototypes
/********************************************************************/
void RtiCallback(void);
/********************************************************************/
// Global Variables
/********************************************************************/
unsigned int msCounter = 0, duty = 500;
char update = 0;
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
  // initializations
  /********************************************************************/
  Clock_Set20MHZ();
  SWL_Init();
  RTI_InitCallback(RtiCallback);

  //PWM configuration - channel 7
  //Working @20[MHz], 50[ns] ticks
  PWMPRCLK_PCKB0 = 0;
  PWMPRCLK_PCKB1 = 0;
  PWMPRCLK_PCKB2 = 0;

  //concatenate PWM6 and PWM7
  PWMCTL_CON67 = 1;

  //PWM positive polarity
  PWMPOL_PPOL7 = 1;  //PWM conf: High at the beginning of the period

  //set period 1000 ticks = 50[us]
  PWMPER67 = 1000;

  //set Duty cycle 50%
  PWMDTY67 = duty;
  
  PWME |= PWME_PWME7_MASK;  //Enable channel 7
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(update)
    {
      update = 0;
      if(SWL_Pushed(SWL_LEFT))
      {
        if(--duty < 10)
        {
          duty = 10;
        }
        PWMDTY67 = duty;
      }
      else if (SWL_Pushed(SWL_RIGHT))
      {
        if(++duty > 990)
        {
          duty = 990;
        }
        PWMDTY67 = duty;
      }
    }
  }
}

/********************************************************************/
// Functions
/********************************************************************/
void RtiCallback(void)
{
  if(++msCounter > 9)
  {
    msCounter = 0;
    update = 1;
  }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/