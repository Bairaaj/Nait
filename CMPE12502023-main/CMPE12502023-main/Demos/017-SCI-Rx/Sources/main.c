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
char message[] ="Hello World";
char rxData = 0;
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
  SCI0CR1 = 0;

  //enable RX, Enable TX
  SCI0CR2 = SCI0CR2_TE_MASK | SCI0CR2_RE_MASK;
  /*
  BR = 20E6 / (16x115200) = 10.85 @20MHz
  */
  SCI0BD = 11; //set Baud Rate to 115200 @20MHz


/********************************************************************/
  // main program loop
/********************************************************************/

  for (;;)
  {
    //RX Data
    RTI_Delay_ms(000);
    /*The process of masking the flag and reading
    the byte, actually clears the flag itself*/
    if(SCI0SR1 & SCI0SR1_RDRF_MASK) 
    {//Sci just received a byte
      rxData = SCI0DRL;

      //Tx data back
      while(!(SCI0SR1 & SCI0SR1_TDRE_MASK));//Wait till transmit data register is empty
      SCI0DRL = rxData;
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