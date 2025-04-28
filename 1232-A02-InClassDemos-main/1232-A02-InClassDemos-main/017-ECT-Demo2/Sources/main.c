/********************************************************************/
// HC12 Program:  YourProg - Simple ECT Demo
// Processor:     MC9S12XDP512
// Bus Speed:     8 MHz
// Author:        This B. You
// Details:       A more detailed explanation of the program is entered here
                  
// Date:          March 1, 2023
// Revision History :
//  each revision will have a date + desc. of changes

/********************************************************************/
// Constant Defines
/********************************************************************/

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
#include "clock.h"
#include "sw_led.h"

/********************************************************************/
// Library includes
/********************************************************************/
// your includes go here


/********************************************************************/
// Local Prototypes
/********************************************************************/

/********************************************************************/
// Global Variables
/********************************************************************/
int counter = 0;
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
  Clock_Set20MHZ();
  
  /********************************************************************/
  // initializations
  /********************************************************************/

  //ECT Timer - Precision Mode
  TSCR1 |= TSCR1_PRNT_MASK;

  //Set Precision prescaler
  PTPSR = 20 - 1;

  //Set CH0 (PIN9) as output compare
  TIOS_IOS0 = 1;  //enable channel 0 as output

  //Set event on TCO at 2,000 ticks = 2,000 [us] = 2[ms]
  TC0 = 1000;

  /*****************************************
  Compare result Action - TCTL1/TCTL2
  OMx   OLx
  0     0  Timer Disconnected from pin
  0     1  Toggle OCx output line
  1     0  Clear OCx output lize to zero
  1     1  Set OCx output line to one
  *****************************************/
  TCTL2_OM0 = 0; //Set opration to toggle
  TCTL2_OL0 = 1; //Set opration to toggle

  //enable interrupt for CH0
  //TIE_C0I = 1;
  TIE_C0I = 0;  //disable ISR for TC0

  //Timer Enable, Fast Flag clear all (auto clear flag
  TSCR1 = TSCR1_TEN_MASK | TSCR1_TFFCA_MASK;

  SWL_Init();
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vtimch0 void Vtimch0_ISR(void)
{
  //TFLG1 = TFLG1_C0F_MASK; //clear flag, if not using fast flag clearing
  TC0 += 1000;    //this re-arms the timer and clear the flag
  SWL_TOG(SWL_RED);
}