/********************************************************************/
// HC12 Program:  Port J Demo
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
#include "clock.h"
#include "sw_led.h"
#include "segs.h"

/********************************************************************/
// Local Prototypes
/********************************************************************/
int counter = 0;
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
  SWL_Init();
  Segs_Init();

  /*
    Port J initializations  
  */
  //Set PJ0 and PJ1 as inputs
  DDRJ &= ~(DDRJ_DDRJ1_MASK | DDRJ_DDRJ0_MASK);
  //DDRJ_DDRJ1 = 0;
  //DDRJ_DDRJ0 = 0;

  //Set edges for PJ0 and PJ1
  PPSJ |= PPSJ_PPSJ1_MASK;   //rising edge, PRESS
  PPSJ &= ~PPSJ_PPSJ0_MASK;   //falling edge, RELEASE

  //Enable Interrupts for PJ1 and PJ0
  PIEJ |= PIEJ_PIEJ1_MASK | PIEJ_PIEJ0_MASK;


  Segs_16D(counter, Segs_LineTop);
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
interrupt VectorNumber_Vportj  void Vportj_ISR(void)
{
  if(PIFJ & PIFJ_PIFJ0_MASK)
  {//PJ0 detected an edge
    PIFJ = PIFJ_PIFJ0_MASK; //clear flag; 
    if(++counter > 9999)
    {
      counter = 0;
    }

  }
  if(PIFJ & PIFJ_PIFJ1_MASK)
  {//PJ1 detected an edge
    PIFJ = PIFJ_PIFJ1_MASK; //clear flag;
    if(--counter < 0)
    {
      counter = 9999;
    }
  } 
  Segs_16D(counter, Segs_LineTop);
}