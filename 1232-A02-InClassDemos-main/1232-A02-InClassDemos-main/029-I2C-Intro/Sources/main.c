/********************************************************************/
// HC12 Program:  I2C DIntro
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       I2C Intro - DAC
                  
// Date:          April 4th, 2023   
// Revision History : 
// Updated Nov, 15th, 2023 

/********************************************************************/
// Constant Defines
/********************************************************************/

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/
// your includes go here
#include "clock.h"
#include "rti.h"
#include "sw_led.h"
#include "segs.h"
#include "lcd.h"
#include "sci.h"
#include "i2c.h"

/********************************************************************/
// Local Prototypes
/********************************************************************/
void RTI_Callback(void);
/********************************************************************/
// Global Variables
/********************************************************************/
int msCounter = 0;
char rtiUpdate = 0;
int test;
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
  RTI_InitCallback(RTI_Callback);
  SWL_Init();
  lcd_Init();
  lcd_DispControl(0,0);
  Segs_Init();

  I2C0_InitBus(I2CBus400); //for 400KHz

  /*

  DAC INPUT WORD (LTC2633-12)
  *****1ST DATA BYTE*****   ******2ND DATA BYTE******    ***3RD DATA BYTE***
  C3 C2 C1 C0 A3 A2 A1 A0   D11 D10 D9 D8 D7 D6 D5 D4    D3 D2 D1 D0 X X X X

  DAC FIRST BYTE**************
  For writing into the DAC we'll use command 0b0010 = 0x2 =>
  Write to Input Register n, Update (Power-Up) All
  This will be the most signifficant nibble. The following (least signifficant)
  nibble will be the Address code, which is according to the table:

  A3 A2 A1 A0
  0 0 0 0 DAC A
  0 0 0 1 DAC B
  1 1 1 1 All DACs

  DAC SECOND and THIRD BYTES*******************
  The following bytes contain the number to write, which is 12-bits
  left justified, which means the number to sned has to be shifted to 
  the left by 4 and the 4 least signifficant bits are don't care.

  */
  
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(rtiUpdate)
    {
      rtiUpdate = 0;
      test = I2C0_Addr(0x48, IIC0_WRITE, IIC0_NOWAIT); //Testing Address, NACK
      //test = I2C0_Addr(0x10, IIC0_WRITE, IIC0_NOWAIT); //Testing Address, ACK

      /*
      test = I2C0_Addr(0x10, IIC0_WRITE, IIC0_WAIT); //Testing Address, REAL ADDR-> DAC
      test = I2C0_WriteByte(DAC_ALL, IIC0_NOSTOP);
      test = I2C0_WriteByte(0x9C, IIC0_NOSTOP);
      test = I2C0_WriteByte(0x40, IIC0_STOP);
      */
      
    }
  }
}

/********************************************************************/
// Functions
/********************************************************************/
void RTI_Callback()
{
  if(++msCounter > 99)
  {
    msCounter = 0;
    rtiUpdate = 1;
  }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/