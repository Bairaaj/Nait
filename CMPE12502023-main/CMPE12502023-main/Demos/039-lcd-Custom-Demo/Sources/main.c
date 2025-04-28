/********************************************************************/
// HC12 Program:  LCD custom demo (CGRAM)
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

/**************************;******************************************/
// Global Variables
/********************************************************************/
unsigned int msCounter = 0;
char update = 0, run = 0;

unsigned char index = 0;

SwState ctrState;
/********************************************************************/
// Constants
/********************************************************************/
unsigned const char ASCII_0to7[64] = 
{//ASCII char 0
    0b00000000,
    0b00000000,
    0b00000000,
    0b00000000,
    0b00000000,
    0b00000000,
    0b00000000,
    0b00011111,  
 //ASCII char 1
    0b00000000,
    0b00000000,
    0b00000000,
    0b00000000,
    0b00000000,
    0b00000000,
    0b00011111,
    0b00011111,
 //ASCII char 2
    0b00000000,
    0b00000000,
    0b00000000,
    0b00000000,
    0b00000000,
    0b00011111,
    0b00011111,
    0b00011111, 
 //ASCII char 3
    0b00000000,
    0b00000000,
    0b00000000,
    0b00000000,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
 //ASCII char 4
    0b00000000,
    0b00000000,
    0b00000000,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
 //ASCII char 5
    0b00000000,
    0b00000000,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111, 
 //ASCII char 6
    0b00000000,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
 //ASCII char 7
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,
    0b00011111,                     
};
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
  lcd_CGChar(0, ASCII_0to7, 64); //storing data into CGRAM

  //printing data stored in CGRAM
  lcd_Data(0);
  lcd_Data(1);
  lcd_Data(2);
  lcd_Data(3);
  lcd_Data(4);
  lcd_Data(5);
  lcd_Data(6);
  lcd_Data(7);

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(Sw_ProcessD(&ctrState, SWL_CTR) == Pressed)
    {
      run ^= 1;
    }
    if(update)
    {
      update = 0;
      if(run)
      {
        if(++index > 7)
        {
          index = 0;
          lcd_Clear();
        }
        lcd_Data(index);
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



