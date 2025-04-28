/********************************************************************/
// HC12 Program:  SCI0 Demo1
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here               
// Date:          Oct-25-2023
// Revision History :
//  each revision will have a date + desc. of changes



/********************************************************************/
// Library includes
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

//Other system includes or your includes go here
//#include <stdlib.h>
//#include <stdio.h>
#include "sw_led.h"
#include "clock.h"
#include "rti.h"

/********************************************************************/
//Defines
/********************************************************************/

/********************************************************************/
// Local Prototypes
/********************************************************************/

/********************************************************************/
// Global Variables
/********************************************************************/
volatile unsigned int counter;
char send = 0;
char message[] = "Hello World\r";
int i = 0;
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

/********************************************************************/
  // one-time initializations
/********************************************************************/
  Clock_Set20MHZ();
  RTI_Init();
  SWL_Init();


  //SCI Configuration
  SCI0CR1 = 0;

  //enable RX, Enable TX
  SCI0CR2 = SCI0CR2_TE_MASK | SCI0CR2_RE_MASK;

  //SCI0BD = 130; //set Baud Rate to 9600
  /*
  BR = 20E6 / (16x115200) = 10.85 @20MHz
  BR = 8E6 / (16x115200) = 4.34 @8MHz
  */

  //SCI0BD = 130; //set Baud Rate to 9600
  //SCI0BD = 4; //set Baud Rate to 115200 @8MHz
  SCI0BD = 11; //set Baud Rate to 115200 @20MHz


/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    if(send)
    {
      send = 0;
      //send a string
      i = 0;
      while(message[i] != 0)
      {
        while(!(SCI0SR1 & SCI0SR1_TDRE_MASK));//Wait till transmit data register is empty
        SCI0DRL = message[i++];
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
  //Perform some action here
  if(++counter > 999)
  {
    counter = 0;
    send = 1;
  }
}