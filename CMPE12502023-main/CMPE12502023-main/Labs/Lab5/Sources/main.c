/********************************************************************/
// HC12 Program:  Lab 5
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       Lab 5 hex lcd decimal lcd
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
#include <stdio.h>
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
#define BUFFER_SIZE 64
/********************************************************************/
// Local Prototypes
/********************************************************************/
void Bits(void);
void Binvalues(void);
/********************************************************************/
// Global Variables
/********************************************************************/
SwState upState, downState, leftsw, rightsw, centersw;
float count = 0.0;
unsigned char Counter[BUFFER_SIZE];
unsigned char Decval[BUFFER_SIZE];
unsigned char Hexval[BUFFER_SIZE];
unsigned char binary[16];
unsigned int binarybits[16];
unsigned int cursorpos = 2;
unsigned int binarynumber = 0;
unsigned int forloop = 0;
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
  SWL_Init();
  lcd_Init();
  lcd_StringXY(0, 1, "DEC: 00000");
  lcd_StringXY(0, 2, "HEX: 0000");
  lcd_StringXY(2, 3, "0000000000000000");
  lcd_DispControl(1, 1);
  PITMTLD0 = 200 - 1;
  PITLD0 = 10000 - 1;
  PIT_InitChannel(PIT_CH0, PIT_MT0, PIT_IDIS);
  Bits(); // filling the bits for the lcd
  Binvalues(); // putting the bin bits in an array

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
    if (PITTF & PIT_CH0)
    {
      count += 0.1;
      (void)sprintf(Counter, "Count: %07.1f", count);
      lcd_StringXY(0, 0, &Counter);
      PITTF = PIT_CH0;
      PIT_Sleep(PIT_CH1, 10);
    }
    lcd_AddrXY(cursorpos, 3);
    if (rightsw == Pressed)
    {
      if (++cursorpos > 17)
      {
        cursorpos = 17;
      }
      else
      {
        lcd_ShiftRi();
      }
    }
    if (leftsw == Pressed)
    {
      if (--cursorpos < 2)
      {
        cursorpos = 2;
      }
      else
      {
        lcd_ShiftLe();
      }
    }
    if (centersw == Pressed)
    {
      if (binary[cursorpos - 2] == 49)
      {
        binary[cursorpos - 2] = 48;
      }
      else
      {
        binary[cursorpos - 2] = 49;
      }
      binarynumber = 0;
      for (forloop = 0; forloop < 16; forloop++)
      {
        if (binary[forloop] == 49) 
        {
          binarynumber += binarybits[forloop];
        }
      }
      (void)sprintf(Decval, "DEC: %05u", binarynumber);
      (void)sprintf(Hexval, "HEX: %04X", binarynumber);
      lcd_StringXY(0, 1, &Decval);
      lcd_StringXY(0, 2, &Hexval);
      lcd_StringXY(2, 3, &binary);
    }
  }
}

/********************************************************************/
// Functions
/********************************************************************/
void Bits()
{
  int i;
  for (i = 0; i < 16; i++)
  {
    binary[i] = 48;
  }
}
void Binvalues()
{
  int i;
  for (i = 0; i < 16; i++)
  {
    binarybits[i] = 1 << (15 - i);
  }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
