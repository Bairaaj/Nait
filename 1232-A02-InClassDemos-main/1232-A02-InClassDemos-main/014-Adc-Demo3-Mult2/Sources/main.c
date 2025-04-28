/********************************************************************/
// HC12 Program:  ADC multiple channels demo
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       2 channels, continuous conversion AN4, AN5
                  
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
char rxData;
unsigned int msCounter = 0;

char update = 0;

unsigned int ch4Value, ch5Value;
char line1[25];
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
  sci0_Init(115200, 1);


  //ADC Settings


  //Power up - Fast flag clear - Interrupt enable
  ATD0CTL2 = ATD0CTL2_ADPU_MASK | ATD0CTL2_AFFC_MASK | ATD0CTL2_ASCIE_MASK;

  //Number of conversion per sequence (2)
  ATD0CTL3 = ATD0CTL3_S2C_MASK;

  //20MHz, divide by 20, ADC to 1MHz
  //10-bit resolution, 4 A/D coversion clock periods, prescaler to 20 -> 1MHZ ADC-Clock
  ATD0CTL4 = ATD0CTL4_SMP0 | ATD0CTL4_PRS3_MASK | ATD0CTL4_PRS0_MASK;


  ATD0CTL0 = ATD0CTL0_WRAP2_MASK | ATD0CTL0_WRAP0_MASK ; //wrap around channel 5

  //Right justified, multi channel, Continuos conversion, start at channel 4
  ATD0CTL5 = ATD0CTL5_DJM_MASK | ATD0CTL5_MULT_MASK | ATD0CTL5_SCAN_MASK | ATD0CTL5_CC_MASK;


  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  { 
    if(update)
    {
      update = 0;
      Segs_16D(ch4Value*5, Segs_LineTop);   
      Segs_16D(ch5Value*5, Segs_LineBottom);  
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void RTI_Callback(void)
{
  if(++msCounter > 199)
  {
    msCounter = 0;
    update = 1;
  }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vsci0 void Vsci0_ISR(void)
{
  if(SCI0SR1 & SCI0SR1_RDRF_MASK)
  {
    rxData = SCI0DRL; //read character  
  }
}

interrupt VectorNumber_Vatd0 void Vatd0_ISR(void)
{
  //ATD0STAT0 = ATD0STAT0_SCF_MASK; //flag clearing, not necessary here
  ch4Value = ATD0DR0; //It contains the first conversion, not neccessarily ch0 
  ch5Value = ATD0DR1; //It contains the first conversion, not neccessarily ch1  
  SWL_TOG(SWL_RED);
}
