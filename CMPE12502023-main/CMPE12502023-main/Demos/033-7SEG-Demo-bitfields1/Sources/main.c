/********************************************************************/
// HC12 Program:  7-Seg display bitfields demo 1
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


char rxData = 0;
char rxBuffer[BUFFER_SIZE];
int rxIndex = 0;

char process = 0, update = 0;
SwState upState, downState, leftsw, rightsw, centersw;
char autoCount = 0;
unsigned int msCounter = 0;

Seg16Typedef myCounter;
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
  sci0_Init(115200, 1);


  Segs_8H(7, 0xAB);
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
    if(centersw ==  Pressed)
    {
      autoCount ^= 1;
    }
    if(leftsw ==  Pressed)
    {
      myCounter.Nibble.Nibble3++;
      Segs_16H(myCounter.Word, Segs_LineBottom);
    }
    if(rightsw ==  Pressed)
    {
      myCounter.Nibble.Nibble0++;
      Segs_16H(myCounter.Word, Segs_LineBottom);
    }
    
    if(update)
    {
      update = 0;
      if(autoCount)
      {
        Segs_16H(myCounter.Word++, Segs_LineBottom);
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