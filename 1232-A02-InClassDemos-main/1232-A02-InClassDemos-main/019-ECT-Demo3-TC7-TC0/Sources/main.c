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


  //Counter reset enable
  TSCR2 |= TSCR2_TCRE_MASK;

  //Set Precision prescaler
  PTPSR = 20 - 1;

  //Set CH7 (PIN18) as output compare
  TIOS_IOS7 = 1;  //enable channel 7 as output
  TIOS_IOS0 = 1;  //enable channel 0 as output

  //Set event on TC7 at 1,000 ticks = 1,000 [us] = 1[ms]
  TC7 = 1000;

  TC0 = 400;
  /*****************************************
  Compare result Action - TCTL1/TCTL2
  OMx   OLx
  0     0  Timer Disconnected from pin
  0     1  Toggle OCx output line
  1     0  Clear OCx output lize to zero
  1     1  Set OCx output line to one
  *****************************************/
  TCTL1_OM7 = 0; //Set opration to toggle
  TCTL1_OL7 = 1; //Set opration to toggle

  TCTL2_OM0 = 0; //Set opration to toggle
  TCTL2_OL0 = 1; //Set opration to toggle


  //TC7 will send a HIGH(1) to TC0
  OC7M |= OC7M_OC7M0_MASK;   //connects to to TCO
  OC7D |= OC7M_OC7M0_MASK;    //send a "1"
  //OC7D &= ~OC7M_OC7M0_MASK;    //send a "0"



  TIE_C7I = 0;  //disable ISR for TC7
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
