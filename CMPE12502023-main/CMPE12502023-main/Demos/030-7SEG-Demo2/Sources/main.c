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
//#include <stdio.h>
#include "sw_led.h"
#include "clock.h"
#include "rti.h"
#include "sci.h"
#include "pit.h"

/********************************************************************/
// Constant Defines
/********************************************************************/
#define DEGREE_SIGN SEG_A | SEG_B | SEG_F | SEG_G

#define SEG_A 0b01000000
#define SEG_B 0b00100000 
#define SEG_C 0b00010000 
#define SEG_E 0b00001000 
#define SEG_F 0b00000010 
#define SEG_G 0b00000100 
#define SEG_D 0b00000001 

/********************************************************************/
// Local Prototypes
/********************************************************************/
void WriteAddr0(unsigned char data);
void ClearAddr0(void);
/**************************;******************************************/
// Global Variables
/********************************************************************/
SwState upState, downState;
unsigned char number = 0;
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
  // main entry point
  _DISABLE_COP();
  //EnableInterrupts;
  /********************************************************************/
  // initializations
  /********************************************************************/
  Clock_Set20MHZ();
  SWL_Init();





  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {

    if(Sw_ProcessD(&upState, SWL_UP) == Pressed)
    {
      if(++number > 15)
      {
        number = 0;
      }
      WriteAddr0(number);
    }
    else if (Sw_ProcessD(&downState, SWL_DOWN) == Pressed)
    {
      ClearAddr0();
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void WriteAddr0(unsigned char data)
{
  unsigned char addr = 0;
 //PA0 and PA1 to outputs (DDR register)
  DDRA |= PORTA_PA1_MASK | PORTA_PA0_MASK; 
  //Set Entire port B to output
  DDRB = 0xFF;

  //CONTROL BYTE******************
  //Port B
  PORTB = 0b01011000;
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
  PORTB = data;
  PORTB |= 0x80; //No decimal point
  //Port A
  PORTA &= ~PORTA_PA1_MASK; //Set to Data Mode
  
  //LATCH
  PORTA &= ~ PORTA_PA0_MASK;
  //Add delay for faster than 8MHZ
  PORTA |= PORTA_PA0_MASK;
}

void ClearAddr0(void)
{
 unsigned char addr = 0;
 //PA0 and PA1 to outputs (DDR register)
  DDRA |= PORTA_PA1_MASK | PORTA_PA0_MASK; 
  //Set Entire port B to output
  DDRB = 0xFF;

  //CONTROL BYTE******************
  //Port B
  PORTB = 0b01111000;
/*          ||||||||_____Addr
            |||||________Bank A
            ||||_________Normal
            |||__________No Decode  
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
  PORTB = 0x80; //Clear digit
  //PORTB = DEGREE_SIGN; 
  //PORTB |= 0x80;  //NO D.P.
  //Port A
  PORTA &= ~PORTA_PA1_MASK; //Set to Data Mode
  
  //LATCH
  PORTA &= ~ PORTA_PA0_MASK;
  //Add delay for faster than 8MHZ
  PORTA |= PORTA_PA0_MASK;
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
    txFlag = 1;
  }
}