/********************************************************************/
// HC12 Program:  ICA 11
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       7 segs
// Date:          Dec, 3rd, 2023
// Revision History :
//  each revision will have a date + desc. of changes

/********************************************************************/
// Library includes
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

// Other system includes or your includes go here
// #include <stdlib.h>
// #include <stdio.h>
#include <stdlib.h>
#include <stdio.h>  //for sprintf
#include <string.h> //for memset and memcpy
#include "sw_led.h"
#include "clock.h"
#include "rti.h"
#include "sci.h"
#include "pit.h"
#include "segs.h"
#include "lcd.h"
#include <string.h>

/********************************************************************/
// Constant Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/

/**************************;******************************************/
// Global Variables
/********************************************************************/
SwState upState, downState, leftsw, rightsw, ctrsw;
unsigned int counterup = 0;
unsigned int counterdown = 0;
int move = 0;
int movecount = 1;
int partb = 0;
int partc = 0;
int pass = 0;
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
  Segs_Init();
  Segs_8H(7, 228);
  Segs_Custom(1, SEG_A | SEG_F | SEG_E | SEG_DP);
  Segs_Custom(2, SEG_A | SEG_B | SEG_C | NO_DP);
  Segs_Custom(5, SEG_F | SEG_E | SEG_D | NO_DP);
  Segs_Custom(6, SEG_D | SEG_C | SEG_B | NO_DP);
  Segs_Normal(4, 3, Segs_DP_OFF);

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    Sw_Process(&upState, SWL_UP);
    Sw_Process(&downState, SWL_DOWN);
    Sw_Process(&leftsw, SWL_LEFT);
    Sw_Process(&rightsw, SWL_RIGHT);
    Sw_Process(&ctrsw, SWL_CTR);
    if(ctrsw == Held)
    {
      PIT_Sleep(PIT_CH1, 100);
      Segs_16D(counterup++, Segs_LineTop);
      Segs_16H(counterdown--, Segs_LineBottom);
      SWL_ON(SWL_YELLOW);
    }
    if (upState == Pressed)
    {
      partb = 1;
      partc = 0;
      SWL_OFF(SWL_YELLOW);
      SWL_OFF(SWL_GREEN);
      SWL_ON(SWL_RED);
    }
    if (downState == Pressed)
    {
      partb = 0;
      partc = 1;
      SWL_OFF(SWL_YELLOW);
      SWL_OFF(SWL_RED);
      SWL_ON(SWL_GREEN);
      
    }
    if (partb)
    {
      if (leftsw == Pressed)
      {
        if (--move < 0)
        {
          move = 0;
        }
        Segs_ClearLine(Segs_LineTop);
        Segs_16H(movecount++, Segs_LineBottom);
      }
      if (rightsw == Pressed)
      {
        if (++move > 3)
        {
          move = 3;
        }
        Segs_ClearLine(Segs_LineTop);
         Segs_16H(movecount++, Segs_LineBottom);
      }
      Loading(move);
    }
    if (partc)
    {
      if (leftsw == Held && pass == 10)
      {
        if (--move < 0)
        {
          move = 0;
        }
        
        Segs_ClearLine(Segs_LineTop);
         Segs_16H(movecount++, Segs_LineBottom);
      }
      if (rightsw == Held && pass == 10)
      {
        if (++move > 3)
        {
          move = 3;
        }
        Segs_ClearLine(Segs_LineTop);
        Segs_16H(movecount++, Segs_LineBottom);
      }
      Loading(move);
    }
    pass++;
    if(pass > 10)
    {
      pass = 0;
    }
  }
}

/********************************************************************/
// Functions
/********************************************************************/

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/