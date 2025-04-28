/********************************************************************/
// HC12 Program:  SPI Intro
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       I2C Intro - DAC
                  
// Date:          March 22nd, 2023   
// Revision History : 
// Updated Dec 4th, 2023 

/********************************************************************/
// Constant Defines
/********************************************************************/
#define SPI_DAC_A 0b00010000
#define SPI_DAC_B 0b10010000
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
void SPI0_Init(void);
void SPI0_Write(char);
void SPI0_WriteDAC(unsigned char, unsigned int);
/********************************************************************/
// Global Variables
/********************************************************************/
int msCounter = 0;
char rtiUpdate = 0;

unsigned int value = 0;
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

  //SPI COnfiguration
  /*
  PS7 -> ~CS  (PIN 96) - Manual so it could be any PIN
  PS6 -> CLK  (PIN 95)
  PS5 -> MOSI (PIN 94)
  PS4 -> MISO (PIN 93)
  */  
  DDRS |= DDRS_DDRS7_MASK;  //Set PS7 as output (CS)
  

  SPI0_Init();
  SPI0_WriteDAC(SPI_DAC_B, 64);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(rtiUpdate)
    {
      rtiUpdate = 0; 
    }
    if(++value > 1023)
    {
      value = 0;
    }
    SPI0_WriteDAC(SPI_DAC_A, value);
  }
}

/********************************************************************/
// Functions
/********************************************************************/
void RTI_Callback()
{
  rtiUpdate = 1;
}

/// @brief 
/// @param  
void SPI0_Init(void)
{
    /*
    SPI -> Datasheet CHAPTER 12

    BR prescaler = (SPPR + 1) x 2 ^ (SPR + 1)

    Example:
    To get 5[MHz] clock @ 20[MHz] BUS speed we do:

    BR prescaler = (3 + 1) x 2 ^ 0 = 4    

    SPI0BR_SPPR2 = 0   
    SPI0BR_SPPR1 = 0
    SPI0BR_SPPR0 = 1

    SPI0BR_SPR2 = 0
    SPI0BR_SPR1 = 0
    SPI0BR_SPR0 = 0
    */
   
    SPI0BR = /*SPI0BR_SPPR1_MASK | */SPI0BR_SPPR0_MASK; //5[MHz] baud rate, clock divisor / 4
    
    //Stop SPI clock in wait mode - not strictly necessary
    SPI0CR2 = SPI0CR2_SPISWAI_MASK | SPI0CR2_BIDIROE_MASK;

    //SPI System Enable BIT,     Master Mode,Active low cllocks,  Sampling at even edges, LSB first Enable
    SPI0CR1 = SPI0CR1_SPE_MASK | SPI0CR1_MSTR_MASK | SPI0CR1_CPOL_MASK | SPI0CR1_CPHA_MASK /*| SPI0CR1_LSBFE_MASK*/;  
    
}

/// @brief We need to always write and read
/// @param data 
void SPI0_Write(char data)
{
  char temp;
  while(!SPI0SR_SPTEF);   //wait for transmit data register empty
  SPI0DR = data;
  while(!SPI0SR_SPIF);  //wait until data can be read
  temp = SPI0DR;
}

void SPI0_WriteDAC(unsigned char dac, unsigned int value)
{
  static char byte1, byte2;

  value &= 0x3FF;  //mask to 10-bit
  value <<= 2;    //bitshift

  byte1 =  dac;

  byte2 = (unsigned char)value;
  byte1 |= ((unsigned char)(value>>8) & 0x0F);


  PTS_PTS7 = 0;
  SPI0_Write(byte1);
  SPI0_Write(byte2);
  PTS_PTS7 = 1;   

}

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/