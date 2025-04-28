/********************************************************************/
// HC12 Program:  Scoping single shot demo
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
#include <stdio.h> //for sscanf and sprintf
#include <string.h> //for memset and memcpy

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
void Segs_16H_DP (unsigned int, Segs_LineOption, char);
/**************************;******************************************/
// Global Variables
/********************************************************************/
unsigned int msCounter = 0;
char update = 0, run = 0;


SwState upState, downState, leftsw, rightsw, centersw;

char index = 0;


unsigned int number = 0X4530;
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
  RTI_Init();
  SWL_Init();
  Segs_Init();
  lcd_Init();
  lcd_DispControl(0,0); //Cursor OFF - No blinking

  Segs_16H(number, Segs_LineTop);
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
    if(rightsw == Pressed)
    {
      if(++index > 3)
      {
        index = 3;
      }
      Segs_16H_DP(number, Segs_LineTop, index);
    }
    else if(leftsw == Pressed)
    {
      if(--index < 0)
      {
        index = 0;
      }
      Segs_16H_DP(number, Segs_LineTop, index);
    }
    if(update)
    {

      update = 0;     
    }
  }                  
}

/********************************************************************/
// Functions
/********************************************************************/
void Segs_16H_DP (unsigned int value, Segs_LineOption line, char dpIndex)
{
    unsigned char i, offset;
    unsigned int cDisplay;

    if(line == Segs_LineTop)
    {
        offset = 0;
    }
    else if(line == Segs_LineBottom)
    {
        offset = 4;
    }

    for (i = 0; i < 4; i++)
    {
        cDisplay = (value >> (unsigned char)((3 - i) * 4)) & 0xF;
        if(i == dpIndex)
        {
          Segs_Normal(offset + i, (unsigned char)cDisplay, Segs_DP_ON); 
        }
        else
        {
          Segs_Normal(offset + i, (unsigned char)cDisplay, Segs_DP_OFF);
        }
 
    }  
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vrti void Vrti_ISR(void)
{
  CRGFLG = CRGFLG_RTIF_MASK; //clear flag;
  ++rtiMasterCount;

  if(++msCounter > 199)
  {
    msCounter = 0;
    update = 1;
  }
}



