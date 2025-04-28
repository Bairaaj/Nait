/********************************************************************/
// HC12 Program:  YourProg - PWM Demo Servo Motor using PWM2
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       SURPASS HOBBY S0025P 25g, 1520us, 333Hz working freq.
//                4.8V - 6V    
//                https://www.aliexpress.com/item/4001334951600.html              
// Date:          March 16, 2023
// Revision History :
//  Adapted Nov 8th, 2023


/********************************************************************/
// Constant Defines
/********************************************************************/


/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

#include <string.h>
#include "clock.h"
#include "sw_led.h"
#include "segs.h"
#include "sci.h"
#include "rti.h"


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
int index = 0;
SwState leftState, rightState;
unsigned char duty = 100;

unsigned int msCount = 0;
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
  RTI_InitCallback(RtiCallback);
  SWL_Init();
  (void)sci0_Init(115200,1);

  /*To work at approximately 333Hz, 3ms Period 
  @20MHZ, ticks are 50ns-> 3ms / 50ns = 60,000. we need to use Clock SB
  We can use 200 ticks, therefore we need to prescale by:  60,000 / 200 = 300

  */

  //PWM configuration - channel 2
  //Working @20[MHz], me use a prescale of 2 to get 100[ns] ticks

  /*Main prescaler = 2*/
  PWMPRCLK_PCKB2 = 0;
  PWMPRCLK_PCKB1 = 0;
  PWMPRCLK_PCKB0 = 1;

  PWMCLK_PCLK2 = 1; //Clock SB for channel 2

  /*  Formula:
      300 = 2 x 2 X 75
      PWMSCLB = 75
  */
  PWMSCLB = 75;

  //PWM positive polarity
  PWMPOL_PPOL2 = 1;  //PWM conf: High at the beginning of the period

  //set period 200 ticks = 3[ms]
  PWMPER2 = 200;

  //set Duty cycle 50%
  PWMDTY2 = duty;  //Define Pulse width
  
  PWME |= PWME_PWME2_MASK;  //Enable channel 2
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(update)
    {
      update = 0;
      if(SWL_Pushed(SWL_RIGHT))
      {   
        if(duty < 170)
        {
          duty += 1;
          PWMDTY2 = duty;
        }
      }
      if(SWL_Pushed(SWL_LEFT))
      {
        if(duty > 30)
        {
          duty -= 1;
          PWMDTY2 = duty;
        }
      }
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void RtiCallback(void)
{
  if(++msCount > 4)
  {
    msCount = 0;
    update = 1;
  }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/