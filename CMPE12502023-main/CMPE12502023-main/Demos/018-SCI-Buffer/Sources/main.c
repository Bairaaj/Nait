/********************************************************************/
// HC12 Program:  SCI receiving
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here               
// Date:          Nov 1st-2023
// Revision History :
//  each revision will have a date + desc. of changes



/********************************************************************/
// Library includes
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

//Other system includes or your includes go here
//#include <stdlib.h>
//#include <stdio.h>  //for sprintf

#include "sw_led.h"
#include "clock.h"
#include "rti.h"
#include "sci.h"

#include <string.h> //for using memset and memcpy

/********************************************************************/
//Defines
/********************************************************************/
#define BUFFER_SIZE 64
/********************************************************************/
// Local Prototypes
/********************************************************************/


/********************************************************************/
// Global Variables
/********************************************************************/
char message[] ="Hello World";
char rxData = 0;
char rxArray[BUFFER_SIZE];
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
  //Any main local variables must be declared here

  // main entry point
  _DISABLE_COP();
  EnableInterrupts;
  Clock_Set20MHZ();
  RTI_Init();

/********************************************************************/
  // one-time initializations
/********************************************************************/
  SWL_Init();
//SCI Configuration
  (void)sci0_Init(115200, 1); //Init sci to 115,200 BR with interrupts


/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    RTI_Delay_ms(5000);
    if(process)
    {
      process = 0;
      sci0_txStr("You sent: ");
      sci0_txStr(rxArray);
      sci0_txStr("\r\n");
      //Clear Array and index
      memset(rxArray, 0,rxIndex);
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
  //Perform some action here
  ++rtiMasterCount;
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
      rxArray[rxIndex++] = rxData; //add received character to the buffer
    }
  }

}