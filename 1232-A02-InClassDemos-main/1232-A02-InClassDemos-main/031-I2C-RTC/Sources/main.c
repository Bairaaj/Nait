/********************************************************************/
// HC12 Program:  I2C RTC Demo
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       I2C Intro - DAC
                  
// Date:          April 4th, 2023   
// Revision History : 
// Updated Nov, 29th, 2023 

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
#include "rti.h"

/********************************************************************/
// Local Prototypes
/********************************************************************/
void RTI_Callback(void);
void ReadRtc(RTC_Read*);
void WriteRtc(RTC_Read);
void DisplayRtc(RTC_Read, char);
/********************************************************************/
// Global Variables
/********************************************************************/
int msCounter = 0;
char rtiUpdate = 0;
int test;

RTC_Read haltedTime, clockTime;
char readData, SecondsReg, AlarmHourReg;
/********************************************************************/
// Constants
/********************************************************************/
const unsigned char* DaysArray[] = 
{
    "NA", //0
    "Su", //1
    "Mo", //2
    "Tu", //3
    "We", //4   
    "Th", //5
    "Fr", //6
    "Sa", //7       
};

const unsigned char*  MonthsArray[] = 
{
    "NON", //0
    "Jan", //1
    "Feb", //2
    "Mar", //3
    "Apr", //4
    "May", //5   
    "Jun", //6
    "Jul", //7
    "Aug", //8     
    "Sep", //9   
    "Oct", //10
    "Nov", //11
    "Dec", //12         
};
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
  (void)sci0_Init(115200, 1);

  I2C0_InitBus(I2CBus400); //for 400KHz

  //Configuring the M41T81S: "RTC" *****************************

  //Check for STOP flag
  test = I2C0_RegRead(&SecondsReg, RTC_ADD, RTC_SECONDS);
  if(SecondsReg & RTC_SECONDS_ST)
  {
    SWL_ON(SWL_RED);
    SWL_OFF(SWL_GREEN);
    //I2C0_RegWrite(RTC_ADD, RTC_SECONDS, SecondsReg & ~RTC_SECONDS_ST, IIC0_STOP);  
  }
  else
  {
    SWL_ON(SWL_GREEN);
    SWL_OFF(SWL_RED);
  }

  //Check for HALT flag
  test = I2C0_RegRead(&AlarmHourReg, RTC_ADD, RTC_AL_HOUR);
  if(AlarmHourReg & RTC_AL_HOUR_HT)
  {
    SWL_ON(SWL_YELLOW); 
    //I2C0_RegWrite(RTC_ADD, RTC_AL_HOUR, AlarmHourReg & ~RTC_AL_HOUR_HT, IIC0_STOP);   
  }
  else
  {
    SWL_OFF(SWL_YELLOW); 
  }
  
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(rtiUpdate)
    {
      rtiUpdate = 0;
    }
  }
}

/********************************************************************/
// Functions
/********************************************************************/
void RTI_Callback()
{
  if(++msCounter > 499)
  {
    msCounter = 0;
    rtiUpdate = 1;
  }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/

