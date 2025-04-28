/********************************************************************/
// HC12 Program:  LAB 01
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       SCI and timers
// Date:          Nov, 17, 2023
// Revision History :
//  each revision will have a date + desc. of changes

/********************************************************************/
// Library includes
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

// Other system includes or your includes go here
// #include <stdlib.h>
#include <stdio.h>
#include "sw_led.h"
#include "clock.h"
#include "sci.h"
#include "rti.h"
#include <string.h>
#include "segs.h"

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
SwState leftsw, centersw, rightsw, upsw, downsw;

unsigned int change = 0;
int parta = 0;
int partb = 1;
char rxData = 0;
char rxBuffer[BUFFER_SIZE];
char txBuffer[BUFFER_SIZE];
int rxIndex = 0;
char process = 0;
char sendSci = 0;

/********************************************************************/
// Constants
/********************************************************************/

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  // Any main local variables must be declared here
  change = 50;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;

  /********************************************************************/
  // one-time initializations
  /********************************************************************/
  Segs_Init();
  SWL_Init();
  Clock_Set20MHZ();
  RTI_Init();
  Segs_ClearLine(Segs_LineTop);
  Segs_ClearLine(Segs_LineBottom);
  (void)sci0_Init(115200, 1);
  // Clock_EnableOutput(ClockOutDiv1);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    Sw_Process(&upsw, SWL_UP);
    Sw_Process(&downsw, SWL_DOWN);
    Sw_Process(&leftsw, SWL_LEFT);
    Sw_Process(&centersw, SWL_CTR);
    Sw_Process(&rightsw, SWL_RIGHT);
    // Part A
    if(RTI_NonBlockingDelay_MS(change))
    {
      SWL_TOG(SWL_RED);
    }
    //part b
    if(upsw == Pressed)
    {
      change += 10;
      if(change > 100)
      {
        change = 100;
        rtiMasterCount = 0;
      }
       (void)sprintf(txBuffer, "RTI is set to: %d", change);
        sci0_txStr(txBuffer);
        sci0_txStr("\r\n");
    }
    if(downsw == Pressed)
    {
      change -= 10;
      if(change < 1)
      {
        change = change + 10;
        rtiMasterCount = 0;
      }
       (void)sprintf(txBuffer, "RTI is set to: %d", change);
        sci0_txStr(txBuffer);
        sci0_txStr("\r\n");
    }
    // part C
    if (process)
      {
        process = 0;
        sci0_txStr(rxBuffer);
        sci0_txStr("\r\n");
        // scans from the console and chagne the variable iwth the poninter &
        if (sscanf(rxBuffer, "%d", &change))
        {
          if (change < 1 || change > 100)
          {
            if (change < 1)
            {
              change = 10;
            }
            else if (change > 100)
            {
              change = 100;
            }
            sci0_txStr("Wrong setting, number must be between 10 and 100 inclusive");
            sci0_txStr("\r\n");
            (void)memset(rxBuffer, 0, rxIndex);
            rxIndex = 0;
          }
          (void)memset(rxBuffer, 0, rxIndex);
          rxIndex = 0;
        }
        else
        {
          // sent to the sci
          sci0_txStr("Input in the wrong format");
          // to go next line and the beginning
          sci0_txStr("\r\n");
          // clear array
          (void)memset(rxBuffer, 0, rxIndex);
          rxIndex = 0;
        }
        (void)sprintf(txBuffer, "RTI is set to: %d", change);
        sci0_txStr(txBuffer);
        sci0_txStr("\r\n");
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
  sendSci = 1;
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
      rxBuffer[rxIndex++] = rxData; // add received character to the buffer
    }
  }
}
