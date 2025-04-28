/********************************************************************/
// HC12 Program:  SCI demo w/timeout
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       A more detailed explanation of the program is entered here
                  
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

/********************************************************************/
// Local Prototypes
/********************************************************************/
void RTI_Callback(void);
/********************************************************************/
// Global Variables
/********************************************************************/
volatile unsigned int msCounter;
unsigned char line1[25];
unsigned char line2[25];

//data variables
unsigned char rxData = 0;
unsigned char rxDataBuffer[128];
int rxDataIndex = 0;

//flags
char process = 0, receiving = 0;
char update = 0;

unsigned int tOutCount = 0;

//lcd
unsigned char message[25];

typedef struct DateTimeStruct_Tepedef
{
    uint Year;
    uint Month;
    uint MonthDay;
    uint Day;
    byte Hours;
    byte Minutes;
    byte Seconds;
    byte HuSeconds; //hundreths of seconds (10ms)
}DateTimeStruct;

DateTimeStruct dateTime;
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
  RTI_InitCallback(RTI_Callback);
  sci0_Init(115200, 1);

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  { 
    if(process)
    {
      memcpy(&dateTime, rxDataBuffer, rxDataIndex);
      
      //clear buffer
      memset(rxDataBuffer, 0, rxDataIndex);
      rxDataIndex = 0;
      process = 0;
    }

    if(update)
    {
      update = 0;
      if(++(dateTime.HuSeconds) > 99)
      {
        dateTime.HuSeconds = 0;
        if(++(dateTime.Seconds) > 59)
        {
          dateTime.Seconds = 0;
          if(++(dateTime.Minutes) > 59)
          {
            dateTime.Minutes = 0;
            if(++(dateTime.Hours) > 23)
            {
              dateTime.Hours = 0;
            }
          }
        }
      }
      Segs_16D(dateTime.HuSeconds, Segs_LineTop);
      (void)sprintf(line2, "%02d:%02d:%02d", dateTime.Hours, dateTime.Minutes, dateTime.Seconds);
      lcd_StringXY(0,1, line2);
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void RTI_Callback(void)
{
  SWL_TOG(SWL_RED);
  if(receiving)
  {
    if(++tOutCount > 4)
    {
      process = 1;
      receiving = 0;
      tOutCount = 0;      
    }
  }
  if(++msCounter > 9)
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
    rxDataBuffer[rxDataIndex++] = rxData; //add character to the buffer
  }
  receiving = 1;
  tOutCount = 0;
}