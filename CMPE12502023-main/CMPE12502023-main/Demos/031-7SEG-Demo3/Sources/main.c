/********************************************************************/
// HC12 Program:  7-Seg display demo 2
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here               
// Date:          Nov, 15th, 2023
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
SwState upState, downState;
unsigned int number = 10;
unsigned int msCounter = 0;
char txFlag = 0;
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


  Send16HTop(number);

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {

    if(Sw_ProcessD(&upState, SWL_UP) == Pressed)
    {
      Send16HTop(++number);
    }
    else if (Sw_ProcessD(&downState, SWL_DOWN) == Pressed)
    {
      Send16HTop(--number);
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void Send16HTop(unsigned int num)
{
  Segs_Normal(0, (unsigned char)(num >>12), Segs_DP_OFF);
  Segs_Normal(1, (unsigned char)(num >>8), Segs_DP_OFF);
  Segs_Normal(2, (unsigned char)(num >>4), Segs_DP_OFF);
  Segs_Normal(3, (unsigned char)(num >>0), Segs_DP_OFF);
}
void Send16HBot(unsigned int num)
{
  Segs_Normal(7, (unsigned char)(num % 16), Segs_DP_OFF);
  num /= 16;
  Segs_Normal(6, (unsigned char)(num % 16), Segs_DP_OFF);
  num /= 16;
  Segs_Normal(5, (unsigned char)(num % 16), Segs_DP_OFF);
  num /= 16;
  Segs_Normal(4, (unsigned char)(num % 16), Segs_DP_OFF);
}

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vrti void Vrti_ISR(void)
{
  CRGFLG = CRGFLG_RTIF_MASK; //clear flag;
  ++rtiMasterCount;

  if(++msCounter > 499)
  {
    msCounter = 0;
    txFlag = 1;
  }
}