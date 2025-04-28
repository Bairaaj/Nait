/********************************************************************/
// HC12 Program:  PIT Demo1 (interrupts)
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here
                  
// Date:          Date Created
// Revision History :
//  each revision will have a date + desc. of changes

/********************************************************************/
// Constant Defines
/********************************************************************/

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/
// your includes go here
#include "sw_led.h"
#include "clock.h"
#include "pit.h"


/********************************************************************/
// Local Prototypes
/********************************************************************/

/********************************************************************/
// Global Variables
/********************************************************************/

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
  Clock_Set20MHZ(); //Set clock to 20MHz

  /*Set 10[ms] event
  20E6 * 10[ms] = 200,000 ticks = 20 * 10,000
  */
  PITMTLD0 = 20-1; //Micro timer load register 0
  PITLD1 = 10000-1; //PIT1 load register  
  PIT_InitChannel(PIT_CH1, PIT_MT0, PIT_IEN);

  /*Set 35[ms] event
  20E6 * 35[ms] = 700,000 ticks = 20 * 35,000
  */
  //PITMTLD0 = 20-1; //Micro timer load register 0
  PITLD2 = 35000-1; //PIT2 load register  
  //PITLD2 = 10000-1; //PIT1 load register, this is just for testing ISR priorities  
  PIT_InitChannel(PIT_CH2, PIT_MT0, PIT_IEN);
  PIT_Start();
  SWL_Init();
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  { 
    PIT_Sleep(PIT_CH3, 500);
    SWL_TOG(SWL_GREEN);
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/

/*This ISR gets called automatically when the PIT1 time-out
event occurs */
interrupt VectorNumber_Vpit1 void Vpit1_ISR(void)
{
  PITTF = PITTF_PTF1_MASK; //clear flag;
  SWL_TOG(SWL_RED);
}

/*This ISR gets called automatically when the PIT1 time-out
event occurs */
interrupt VectorNumber_Vpit2 void Vpit2_ISR(void)
{
  PITTF = PITTF_PTF2_MASK; //clear flag;
  SWL_TOG(SWL_YELLOW);
}