/********************************************************************/
// HC12 Program:  Lab 4
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       LCD Control Functions
// Date:          Dec, 4th, 2023
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
#include "sci.h"
#include "pit.h"
#include "segs.h"
#include "lcd.h"

/********************************************************************/
// Constant Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/
char GenerateRandomCapital();
/********************************************************************/
// Global Variables
/********************************************************************/
SwState upState, downState, leftsw, rightsw, centersw;
char count = 0;
char xcount = 0;
int updowncount = 0;
int address = 0;

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
  // EnableInterrupts;
  /********************************************************************/
  // initializations
  /********************************************************************/
  Clock_Set20MHZ();
  SWL_Init();
  Segs_Init();
  lcd_Init();
  Segs_16D(0, Segs_LineTop);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    Sw_Process(&upState, SWL_UP);
    Sw_Process(&leftsw, SWL_LEFT);
    Sw_Process(&downState, SWL_DOWN);
    Sw_Process(&rightsw, SWL_RIGHT);
    Sw_Process(&centersw, SWL_CTR);
    address = lcd_GetAddr();
    if (rightsw == Pressed )
    {
      xcount++;
      if(address == 19 ||address == 83 || address == 39|| address == 103)
      {
        SWL_ON(SWL_RED);
        PIT_Sleep(PIT_CH0, 50);
        SWL_OFF(SWL_RED);
        xcount = 19;
      }
      else
      {
        lcd_ShiftRi();
      }    
    }
    if (leftsw == Pressed)
    {
      xcount--;
      if(address == 0 ||address == 64 || address == 20|| address == 84)
      {
        SWL_ON(SWL_RED);
        PIT_Sleep(PIT_CH0, 50);
        SWL_OFF(SWL_RED);
        xcount = 0;
      }
      else
      {
        lcd_ShiftLe();
      }
    }
    if (upState == Pressed)
    {
      updowncount--;
      if(updowncount < 0)
      {
        updowncount = 0;
        SWL_ON(SWL_RED);
        PIT_Sleep(PIT_CH0, 50);
        SWL_OFF(SWL_RED);
      }
      else
      {
        lcd_AddrXY(xcount, updowncount);
      }
    }
    if (downState == Pressed)
    {
      updowncount++;
      if(updowncount > 3)
      {
        updowncount = 3;
        SWL_ON(SWL_RED);
        PIT_Sleep(PIT_CH0, 50);
        SWL_OFF(SWL_RED);
      }
      else
      {
        lcd_AddrXY(xcount, updowncount);
      }      
    }
    if(centersw == Pressed)
    {
      count++;
      Segs_ClearLine(Segs_LineTop);
      Segs_16D(count,Segs_LineTop);
      lcd_Data(GenerateRandomCapital());
      lcd_ShiftLe();
      if(count > 14)
      {
        updowncount = 0;
        xcount = 0;
        count = 0;
        Segs_ClearLine(Segs_LineTop);
        lcd_Clear();
        lcd_Home();
        Segs_16D(count,Segs_LineTop);
      }
    }
    
  }
}

/********************************************************************/
// Functions
/********************************************************************/
char GenerateRandomCapital()
{
  return (char)('A' + rand() % 26);
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
