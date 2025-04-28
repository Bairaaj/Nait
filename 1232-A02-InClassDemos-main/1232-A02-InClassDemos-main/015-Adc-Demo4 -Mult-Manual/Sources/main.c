/********************************************************************/
// HC12 Program:  ADC demo
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       3 channels, manual conversion triggering (AN2, AN3, AN4)
                  
// Date:          Date Created
// Revision History :
//  each revision will have a date + desc. of changes

/********************************************************************/
// Constant Defines
/********************************************************************/

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
/********************************************************************/
// Library includes
/********************************************************************/
#include <stdio.h> //for sprintf
#include <string.h>//for memcpy, memset

// your includes go here
#include "clock.h"
#include "sw_led.h"
#include "segs.h"
#include "rti.h"
#include "lcd.h"
#include "sci.h"
#include "pit.h"

/********************************************************************/
// Local Prototypes
/********************************************************************/
void RTI_Callback(void);
/********************************************************************/
// Global Variables
/********************************************************************/

unsigned int msCounter = 0;

char convert = 0, update = 0;

unsigned int valueA = 0, valueB = 0, valueC = 0;

char message[25];
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
  Clock_Set20MHZ(); //Set clock to 20MHz
  SWL_Init();
  Segs_Init();
  lcd_Init();
  lcd_DispControl(0,0);
  RTI_InitCallback(RTI_Callback);

  //ADC Settings

  //Power up - Fast flag clear - ATD Power Down in wait mode
  ATD0CTL2 = ATD0CTL2_ADPU_MASK | ATD0CTL2_AFFC_MASK | ATD0CTL2_AWAI; 

  //Number of conversion per sequence (3), finish current conversion then freeze
  ATD0CTL3 = ATD0CTL3_S2C_MASK | ATD0CTL3_S1C_MASK | ATD0CTL3_FRZ1_MASK;
  //ATD0CTL3_S1C = 1;
  //ATD0CTL3_S2C = 1;
  //ATD0CTL3_FRZ1 = 1;

  //20MHz, divide by 20, ADC to 1MHz
  //10-bit resolution, 4 A/D coversion clock periods, prescaler to 20 -> 1MHZ ADC-Clock
  ATD0CTL4 = ATD0CTL4_SMP0 | ATD0CTL4_PRS3_MASK | ATD0CTL4_PRS0_MASK;

  ATD0CTL0 = ATD0CTL0_WRAP2_MASK; //Wrap around channel 4 (AN2, AN3, AN4)

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  { 
    if(convert)
    {
      convert = 0;
      //triggers conversion, starts from CH2 (AN2, AN3, AN4)
      //right-justified, start from AN2, MULT channels
      ATD0CTL5 = ATD0CTL5_DJM_MASK | ATD0CTL5_CB_MASK | ATD0CTL5_MULT_MASK;   
      while(!(ATD0STAT0 & ATD0STAT0_SCF_MASK)); // wait for conversion to complete
      valueA = ATD0DR0 * 5;   //read value, every step (LSB) is 5[mV], vREF = 5.115 /5.12 [V]
      valueB = ATD0DR1 * 5; 
      valueC = ATD0DR2 * 5; 
      Segs_16D(valueA, Segs_LineTop);   
      Segs_16D(valueB, Segs_LineBottom);  
      sprintf(message, "CH2:%04u", valueA);
      lcd_StringXY(0,0, message);
      sprintf(message, "CH3:%04u", valueB);
      lcd_StringXY(0,1, message); 
      sprintf(message, "CH4:%04u", valueC);
      lcd_StringXY(0,2, message);
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void RTI_Callback(void)
{
  if(++msCounter > 9)
  {
    msCounter = 0;
    convert = 1;
  }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
