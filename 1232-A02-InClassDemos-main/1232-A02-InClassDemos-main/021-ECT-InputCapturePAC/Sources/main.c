/********************************************************************/
// HC12 Program:  YourProg - Input Capture using Pulse accumulator
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       Read a signal period based on tick counts
                  
// Date:          November 1st, 2023
// Revision History :
// 

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
#include <stdio.h>
#include "clock.h"
#include "rti.h"
#include "sw_led.h"
#include "segs.h"
#include "lcd.h"

/********************************************************************/
// Local Prototypes
/********************************************************************/
void RTI_Callback(void);
/********************************************************************/
// Global Variables
/********************************************************************/
int msCounter = 0;  //ms counter to be used with RTI callback
char update = 0; //Seg display update flag

unsigned int edgeCounter = 0;
char pacProcess = 0;


unsigned int lastCaptureTicks = 0, periodTicks = 0; //keep track of the last capture ticks and period in ticks

unsigned char lcdMessage[25];
float frequency = 0;
unsigned int edgeFrequency = 0;
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
  Segs_Init();
  
   /*
  ECT CONFIGURATION********************
  */

  /*1.1.1 Set Tick Time*/
  TSCR1_PRNT = 1;   //ECT Precision Timer 
  PTPSR = 20-1;        //No prescaler, 1[us] ticks

   /*1.1.2 Set CH1 as Input Capture*/
  TIOS_IOS1 = 0;    //Enable channel 1 (TC1) as input

  /*This is for PACA, maybe not needed*/
  TIOS_IOS7 = 0;    //Enable channel 1 (TC7) as input


  /*1.1.3 Configure the edge detection*/

  /*****************************************
  //Capture settings - TCTL3/TCTL4
  EDGxB   EDGxA
    0       0  Capture disabled
    0       1  Capture on rising edges only
    1       0  Capture on falling edges only
    1       1  Capture on any edge (rising or falling)
  *****************************************/

  //Capture TC1 in falling edge
  TCTL4_EDG1B = 1;
  TCTL4_EDG1A = 0;


  /*1.1.4 Enable interrupts*/
  TIE_C1I = 1;    //Enable interrupt for TC1

  /*1.1.7 Enable fast flag clear if interrupting and start timer*/
  TSCR1 |= TSCR1_TEN_MASK; //Fast flag clearing, enable timer


  //Pulse Acummulator B is connected to TC0
  //Pulse Acummulator A is connected to TC7

  /*
    DEFAULTS PACTL (7.3.2.15)
    - Event mode
    - Same prescaler
    - No edge interrupt
    - No OVF interrupt
  */

   /*
    DEFAULTS PBCTL (7.3.2.27)
    - Event mode
    - Same prescaler
    - No edge interrupt
    - No OVF interrupt
  */

  PACTL = PACTL_PAEN_MASK;    //Pulse accumulator A enable  
  //PBCTL = PBCTL_PBEN_MASK;    //Pulse accumulator B enable  

  lcd_Init();
  lcd_DispControl(0,0);

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(update)
    {
      update = 0;
      Segs_16D(periodTicks, Segs_LineTop);
      frequency =  1000000.0 / periodTicks;
      (void)sprintf(lcdMessage, "%.2f [Hz](calc)    ", frequency);
      lcd_StringXY(0, 0, lcdMessage);
    }
    if(pacProcess)
    {
      pacProcess = 0;
      (void)sprintf(lcdMessage, "%d[Hz](edgeCnt)    ", edgeFrequency);
      lcd_StringXY(0, 1, lcdMessage);
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void RTI_Callback(void)
{
  if(++msCounter > 99)
  {
    msCounter = 0;
    update = 1;
  }
  if(++edgeCounter > 999)
  {
    edgeFrequency = PACN32; //read PAC 16-bit counter
    PACN32 = 0;    
    edgeCounter = 0;
    pacProcess = 1;
  }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vtimch1  void Vtimch1_ISR(void)
{
  TFLG1 = TFLG1_C1F_MASK;                   //clears flag, not using fast flag clearing this time
  periodTicks = (TC1 - lastCaptureTicks);   //Calculate period in ticks
  lastCaptureTicks = TC1;                   //save capture for next subtraction
} 