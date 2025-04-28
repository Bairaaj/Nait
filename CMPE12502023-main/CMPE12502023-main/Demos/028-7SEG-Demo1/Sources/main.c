/********************************************************************/
// HC12 Program:  7-Seg display demo
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
//#include <stdio.h>
#include "sw_led.h"
#include "clock.h"
#include "rti.h"
#include "sci.h"
#include "pit.h"

/********************************************************************/
//Defines
/********************************************************************/
//#define COUNT
/********************************************************************/
// Local Prototypes
/********************************************************************/

/********************************************************************/
// Global Variables
/********************************************************************/
unsigned int msCounter = 0;
char txFlag = 0;

/********************************************************************/
// Constants
/********************************************************************/

/********************************************************************/
// Main Entry
/********************************************************************/
void main(void)
{
  unsigned char addr = 3;
  unsigned char number = 0;
  // main entry point
  _DISABLE_COP();
  EnableInterrupts;

/********************************************************************/
  // one-time initializations
/********************************************************************/
Clock_Set20MHZ();
RTI_Init();
SWL_Init();

 //PA0 and PA1 to outputs (DDR register)
  DDRA |= PORTA_PA1_MASK | PORTA_PA0_MASK; 
  //Set Entire port B to output
  DDRB = 0xFF;

  
  //CONTROL BYTE******************
  //Port B
  PORTB = 0b01011001;
/*          ||||||||_____Addr
            |||||________Bank A
            ||||_________Normal
            |||__________Decode  
            ||___________Decode as HEX
            |____________No Data coming
*/
  PORTB |= (addr &  0x7); //make addres only 3-lsb

  //Port A
  PORTA |= PORTA_PA1_MASK; //Set to Control Mode

  //LATCH
  PORTA &= ~PORTA_PA0_MASK;
  //Add delay for faster than 8MHZ
  PORTA |= PORTA_PA0_MASK;



  //Send DATA BYTE

  //Port B
  PORTB = 0x4;
  PORTB |= 0x80; //No decimal point


  //Port A
  PORTA &= ~PORTA_PA1_MASK; //Set to Data Mode

  //LATCH
  PORTA &= ~ PORTA_PA0_MASK;
  //Add delay for faster than 8MHZ
  PORTA |= PORTA_PA0_MASK;



  /********************************************************************/
  // main program loop
  /********************************************************************/

  for (;;)
  {
    if(txFlag)
    {
      txFlag = 0;
      if(++number > 15)
      {
        number = 0;
      }

    #ifdef COUNT
    //CONTROL BYTE******************
    //Port B
    PORTB = 0b01011001;
    /*          ||||||||_____Addr
              |||||________Bank A
              ||||_________Normal
              |||__________Decode  
              ||___________Decode as HEX
              |____________No Data coming
    */
    PORTB |= (addr &  0x7); //make addres only 3-lsb

    //Port A
    PORTA |= PORTA_PA1_MASK; //Set to Control Mode

    //LATCH
    PORTA &= ~PORTA_PA0_MASK;
    //Add delay for faster than 8MHZ
    PORTA |= PORTA_PA0_MASK;


    //DATA BYTE*********************
    PORTB = number;
    PORTB |= 0x80; //No decimal point

    //Port A
    PORTA &= ~PORTA_PA1_MASK; //Set to Data Mode

    //LATCH
    PORTA &= ~ PORTA_PA0_MASK;
    //Add delay for faster than 8MHZ
    PORTA |= PORTA_PA0_MASK;    
    #endif  
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