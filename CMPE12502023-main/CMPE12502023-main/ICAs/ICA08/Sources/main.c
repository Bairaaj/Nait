/********************************************************************/
// HC12 Program:  ICA08
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       Clock MHZ configure
// Date:          Oct 21, 2023
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
#include "sw_led.h"
#include "clock.h"
#include "sci.h"
#include "rti.h"
#include <string.h>

/********************************************************************/
// Defines
/********************************************************************/
#define BUFFER_SIZE 64

/********************************************************************/
// Local Prototypes
/********************************************************************/
/********************************************************************/
// Global Variables
/********************************************************************/
char rxData = 0;
char rxArray[BUFFER_SIZE];
char txBuffer[BUFFER_SIZE];
int rxIndex = 0;
char process = 0;
int partone = 1;
int parttwo = 0;
SwState leftsw, centersw, rightsw, upsw, downsw;

/********************************************************************/
// Constants
/********************************************************************/

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  // Any main local variables must be declared here

  // main entry point
  _DISABLE_COP();
  EnableInterrupts;

  /********************************************************************/
  // one-time initializations
  /********************************************************************/
  SWL_Init();
  //Clock_Set20MHZ();
  RTI_Init();
  (void)sci0_Init(19200, 1);
  // Clock_EnableOutput(ClockOutDiv1);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    // part 1
    Sw_Process(&upsw, SWL_UP);
    Sw_Process(&downsw, SWL_DOWN);
    if (upsw == Pressed)
    {
      partone = 1;
      parttwo = 0;
      sci0_txStr("Part one\r\n");
    }
    if (downsw == Pressed)
    {
      partone = 0;
      parttwo = 1;
      sci0_txStr("Part Two\r\n");
    }
    if (partone)
    {
      if (process)
      {
        process = 0;
        sci0_txStr(rxArray);
        sci0_txStr("\r\n");
        memset(rxArray, 0, rxIndex);
        rxIndex = 0;
      }
    }

    // part 2
    Sw_Process(&leftsw, SWL_LEFT);
    Sw_Process(&centersw, SWL_CTR);
    Sw_Process(&rightsw, SWL_RIGHT);
    if (parttwo)
    {
      if (leftsw == Pressed)
      {
        SWL_TOG(SWL_RED);
        process = 0;
        sci0_txStr("Left Pressed\r\n");
        rxIndex = 0;
      }
      if (leftsw == Released)
      {
        SWL_TOG(SWL_RED);
        process = 0;
        sci0_txStr("Left Released\r\n");
        rxIndex = 0;
      }
      if (centersw == Pressed)
      {
        SWL_TOG(SWL_YELLOW);
        process = 0;
        sci0_txStr("Center Pressed\r\n");
        rxIndex = 0;
      }
      if (centersw == Released)
      {
        SWL_TOG(SWL_YELLOW);
        process = 0;
        sci0_txStr("Center Released\r\n");
        rxIndex = 0;
      }
      if (rightsw == Pressed)
      {
        SWL_TOG(SWL_GREEN);
        process = 0;
        sci0_txStr("Right Pressed\r\n");
        rxIndex = 0;
      }
      if (rightsw == Released)
      {
        SWL_TOG(SWL_GREEN);
        process = 0;
        sci0_txStr("Right Released\r\n");
        rxIndex = 0;
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
  CRGFLG = CRGFLG_RTIF_MASK; // clear flag;
  // Perform some action here
  ++rtiMasterCount;
}
interrupt VectorNumber_Vsci0 void sci0_ISR(void)
{
  if (sci0_rxByte(&rxData))
  {
    if (rxData == '\r')
    { // end of the message, process
      process = 1;
    }
    else if (rxIndex < BUFFER_SIZE)
    {
      rxArray[rxIndex++] = rxData; // add received character to the buffer
    }
  }
}
