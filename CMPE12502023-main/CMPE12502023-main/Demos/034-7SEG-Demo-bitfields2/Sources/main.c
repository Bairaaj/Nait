/********************************************************************/
// HC12 Program:  7-Seg display bitfields demo 2
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
void NibbleUpdate(Seg16Typedef* num, char addr, char inc_dec);
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
char nibbleIndex = 0;
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


  myCounter.Word = 0;
  Segs_Custom(nibbleIndex, 0x0);

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
  if(leftsw ==  Pressed)
    {
      if(--nibbleIndex < 0)
      {
        nibbleIndex = 0;
      }
      Segs_ClearLine(Segs_LineTop);
      Segs_Custom(nibbleIndex, 0x0);
    }
    if(rightsw ==  Pressed)
    {
      if(++nibbleIndex > 3)
      {
        nibbleIndex = 3;
      }
      Segs_ClearLine(Segs_LineTop);
      Segs_Custom(nibbleIndex, 0x0);
    }
    if(upState ==  Pressed)
    {
      NibbleUpdate(&myCounter, nibbleIndex, 1);
      Segs_16H(myCounter.Word, Segs_LineBottom);
    }
    if(downState ==  Pressed)
    {
      NibbleUpdate(&myCounter, nibbleIndex,-1);
      Segs_16H(myCounter.Word, Segs_LineBottom);
    }
    

    //Stop / Resume counter
    if(centersw ==  Pressed)
    {
      autoCount ^= 1;
    }

    if(update)
    {
      update = 0;
      if(autoCount)
      {
        myCounter.Word++;
      }
      Segs_16H(myCounter.Word, Segs_LineBottom);
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
/*void NibbleUpdate(Seg16Typedef* num, char addr, char inc_dec)
{
  switch (addr)
  {
    case 0:
      num->Nibble.Nibble3 += inc_dec;
    break;

    case 1:
      num->Nibble.Nibble2 += inc_dec;
    break;
      
    case 2:
      num->Nibble.Nibble1 += inc_dec;
    break;

    case 3:
      num->Nibble.Nibble0 += inc_dec;
    break;
  
    default:
      break;
  }
}*/
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