/********************************************************************/
// HC12 Program:  State machine example
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
volatile unsigned int msCounter = 0;
unsigned int counter_ms = 0;
int seconds = 0;

//data variables
unsigned char rxData = 0;
unsigned char rxDataBuffer[128];
int rxDataIndex = 0;
char receiving = 0;
unsigned int tOutCount = 0;
char process = 0;

char update = 0;
char countSeconds = 0;
//States
typedef enum StatesTypedef
{
  Stop=0,
  Counter=1,
  LED=2,
}States;

States mainState;
States prevState;

SwState upState, downState;
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

  /*
    Port J initializations  
  */
  //Set PJ0 and PJ1 as inputs
  DDRJ &= ~(DDRJ_DDRJ1_MASK | DDRJ_DDRJ0_MASK);
  //DDRJ_DDRJ1 = 0;
  //DDRJ_DDRJ0 = 0;

  //Set edges for PJ0 and PJ1
  PPSJ |= PPSJ_PPSJ1_MASK | PPSJ_PPSJ0_MASK;   //both rising edge
 
  //Enable Interrupts for PJ1 and PJ0
  PIEJ |= PIEJ_PIEJ1_MASK | PIEJ_PIEJ0_MASK;
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  { 
    switch (mainState)
    {

    case Stop:
      /* Increment count manually */
      if(Sw_ProcessD(&upState, SWL_UP) == Pressed)
      {
        if(++seconds > 9999)
        {
          seconds = 0;
        }
        Segs_16D(seconds, Segs_LineTop);
      }
      if(Sw_ProcessD(&downState, SWL_DOWN) == Pressed)
      {
        if(--seconds < 0)
        {
          seconds = 9999;
        }
        Segs_16D(seconds, Segs_LineTop);
      }
      break;   

    case Counter:
      /* Autoincrement */
      if(countSeconds)
      {
        countSeconds = 0;
        Segs_16D(++seconds, Segs_LineTop);
      }
      break;

    case LED:
      if(update)
      {
        update = 0;
        SWL_TOG(SWL_ALL);
      }
      break;
    
    default:
      break;
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void RTI_Callback(void)
{
  if(receiving)
  {
    if(++tOutCount > 4)
    {
      process = 1;
      receiving = 0;
      tOutCount = 0;      
    }
  }
  if(++msCounter > 99)
  {
    msCounter = 0;
    update = 1;
  }
  if(++counter_ms > 999)
  {
    counter_ms = 0;
    countSeconds = 1;
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

interrupt VectorNumber_Vportj  void Vportj_ISR(void)
{
  if(PIFJ & PIFJ_PIFJ0_MASK)
  {//PJ0 detected an edge
    PIFJ = PIFJ_PIFJ0_MASK; //clear flag; 
    if(++mainState > 2)
    {
      mainState = 0;
    }
  }
  if(PIFJ & PIFJ_PIFJ1_MASK)
  {//PJ1 detected an edge
    PIFJ = PIFJ_PIFJ1_MASK; //clear flag;
    if(--mainState < 0)
    {
      mainState = 2;
    }
  } 

}