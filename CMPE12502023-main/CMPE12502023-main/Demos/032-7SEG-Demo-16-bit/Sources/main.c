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
#include <stdio.h> //for sscanf and sprintf
#include <string.h> //for memset and memcpy

#include "sw_led.h"
#include "clock.h"
#include "rti.h"
#include "sci.h"
#include "pit.h"
#include "segs.h"

/********************************************************************/
// Constant Defines
/********************************************************************/
#define BUFFER_SIZE 64
/********************************************************************/
// Local Prototypes
/********************************************************************/

/**************************;******************************************/
// Global Variables
/********************************************************************/
SwState upState, downState;
unsigned int number = 10;
unsigned int msCounter = 0;
char txFlag = 0;

char rxData = 0;
char rxBuffer[BUFFER_SIZE];
int rxIndex = 0;

char process = 0;
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
  sci0_Init(115200, 1);

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {

    if(Sw_ProcessD(&upState, SWL_UP) == Pressed)
    {
      Segs_16D(++number, Segs_LineTop);
    }
    else if (Sw_ProcessD(&downState, SWL_DOWN) == Pressed)
    {
      Segs_16D(--number, Segs_LineTop);
    }
    if(process)
    {
      process = 0;
      (void)sscanf(rxBuffer, "%d", &number);
      Segs_16D(number, Segs_LineTop);
      sci0_txStr("You sent: ");
      sci0_txStr(rxBuffer);
      //sci0_txStr("\r\n");
      //Clear Array and index
      memset(rxBuffer, 0,rxIndex);
      rxIndex = 0;
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

  if(++msCounter > 499)
  {
    msCounter = 0;
    txFlag = 1;
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