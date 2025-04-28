/********************************************************************/
// HC12 Program:  LCD idemo using library
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
#define CHAR_INDEX_MIN 65
#define CHAR_INDEX_MAX 90 
/********************************************************************/
// Local Prototypes
/********************************************************************/
char GetAddr(void);
/**************************;******************************************/
// Global Variables
/********************************************************************/
unsigned int msCounter = 0;
char update = 0;

SwState ctrState;
unsigned int charIndex = CHAR_INDEX_MIN;
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

  Segs_16D(GetAddr(), Segs_LineTop);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(Sw_ProcessD(&ctrState, SWL_CTR) == Pressed)
    {     
      lcd_Data(charIndex);
      Segs_16D(lcd_GetAddr(), Segs_LineTop);
      if(++charIndex > CHAR_INDEX_MAX)
      {
        charIndex = CHAR_INDEX_MIN;
      }
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


char GetAddr(void)
{
  char address = 0;
  DDRH = 0x00;  //Set port H as input

  PORTK_PK1 = 1; //Read operation
  PORTK_PK2 = 0; //Instruction register

  lcd_Latch   //Latch intruction

  address = PTH & 0x7F;  //get 7 least signifficant bits, BIT7 is busy flag

  DDRH = 0xFF;  //Set port H as putput;

  return address;
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
    update = 1;
  }
}


