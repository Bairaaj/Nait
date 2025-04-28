/********************************************************************/
// HC12 Program:  PIT Lib Demo
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here               
// Date:          Nov, 10th, 2023
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
unsigned int index = 0;
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
  sci0_Init(56000, 0); //no interrupts, just sending

  /*PIT1(CH1) Configuration to 100[ms] event
  20E6 * 100[ms] = 2,000,000 = 100 * 20,000
  connect to MT0
  */
 PITMTLD0 = 100 - 1;   //Load register for MT0
 PITLD1 = 20000 - 1;  //Load register for CH1
 PIT_InitChannel(PIT_CH1, PIT_MT0, PIT_IDIS);

 PIT_Start();


/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    PIT_Sleep(PIT_CH3, 200);
    if(PITTF & PIT_CH1)
    {
      PITTF = PIT_CH1;
      SWL_TOG(SWL_RED);
      if(++index > 9)
      {
        index = 0;
        sci0_txStr("Hello World \r\n");
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
