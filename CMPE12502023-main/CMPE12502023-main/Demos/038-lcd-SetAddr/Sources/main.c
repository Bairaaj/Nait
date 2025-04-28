/********************************************************************/
// HC12 Program:  LCD address demo
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

#define BUFFER_SIZE 64
/********************************************************************/
// Local Prototypes
/********************************************************************/
unsigned char  ReadData(unsigned char);
/**************************;******************************************/
// Global Variables
/********************************************************************/
unsigned int msCounter = 0;
char update = 0;

SwState ctrState, upState, downState, lefState, rightState;
unsigned int charIndex = CHAR_INDEX_MIN;

char rxData = 0;
char rxBuffer[BUFFER_SIZE];
int rxIndex = 0;

char process = 0;

unsigned char address = 0;
unsigned int readAddress = 0;


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
  lcd_DispControl(1,1);

  (void)sci0_Init(115200, 1); //Init sci to 115,200 BR with interrupts

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(update)
    {
      update = 0;
    }
    if(process)
    {
      process = 0;
      (void)sscanf(rxBuffer, "%d", &readAddress);
      
      sci0_txByte(ReadData((unsigned char)readAddress));

      //Clear Array and index
      memset(rxBuffer, 0,rxIndex);
      rxIndex = 0; 
    }

    if(Sw_ProcessD(&lefState, SWL_LEFT) == Pressed)
    {
      address = lcd_GetAddr();
      lcd_Addr(--address);
    }
    else if (Sw_ProcessD(&rightState, SWL_RIGHT) ==  Pressed)
    {
      address = lcd_GetAddr();
      lcd_Addr(++address);
    }

    if(Sw_ProcessD(&upState, SWL_UP) == Pressed)
    {
      if(--charIndex < CHAR_INDEX_MIN)
      {
        charIndex = CHAR_INDEX_MAX;
      }
      lcd_Data(charIndex);
      lcd_Addr(address);
    }
    else if (Sw_ProcessD(&downState, SWL_DOWN) ==  Pressed)
    {
      if(++charIndex > CHAR_INDEX_MAX)
      {
        charIndex = CHAR_INDEX_MIN;
      }
      lcd_Data(charIndex);
      lcd_Addr(address);
    }

  }                  
}

/********************************************************************/
// Functions
/********************************************************************/
unsigned char ReadData(unsigned char addr)
{
  unsigned char data = 0;

  lcd_Addr(addr);

  DDRH = 0x00;    //Configure port H as input
  PORTK_PK1 = 1;  //Read operation
  PORTK_PK2 = 1;  //Select Data register
  lcd_Latch;
  data = PTH;
  DDRH = 0xFF;    //Configure port H asback to putput

  return data;
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

interrupt VectorNumber_Vsci0 void sci0_ISR(void)
{
  if(sci0_rxByte(&rxData))
  {
    if(rxData == '\r')
    {//end of the message, process
      process = 1;
    }
    else if(rxIndex < BUFFER_SIZE)
    {
      rxBuffer[rxIndex++] = rxData; //add received character to the buffer
    }
  }

}


