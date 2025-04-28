/********************************************************************/
// HC12 Program:  YourProg - ECT Input Capture, ultrasonic sensor
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       Input capture, display period in us
//                Work @20MHz using precision prescaler
//                 Ultrasonic sensor SR04
                  
// Date:          March 9, 2023
// Revision History :
//  each revision will have a date + desc. of changes

/********************************************************************/
// Constant Defines
/********************************************************************/

/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */
#include "clock.h"
#include "sw_led.h"
#include "segs.h"
#include "rti.h"

/********************************************************************/
// Library includes
/********************************************************************/
// your includes go here


/********************************************************************/
// Local Prototypes
/********************************************************************/
void RtiCallback(void);
/********************************************************************/
// Global Variables
/********************************************************************/
unsigned int riseEdge, fallEdge, pulseWidth;
unsigned int msCounter = 0, cmDistance = 0;

char update = 0;
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
  RTI_InitCallback(RtiCallback);
  Clock_Set20MHZ();

  /*1.1.1 Set Tick Time*/
  TSCR1 |= TSCR1_PRNT_MASK; //Enable precision timer
  PTPSR = 20 - 1;  //Prescale by 20 - tick timer @1us;

  //OUTPUT COMPARE SECTION - TRIGGER PULSE****************************

  /*1.1.2 Set CH1(PIN10) and CH7(PIN18) as Output Compare*/
  TIOS_IOS7 = 1;  //enable channel 7 as output
  TIOS_IOS1 = 1;  //enable channel 1 as output

  /*1.1.3 Set timer ticks to compare against*/

  //CH7 - period
  TC7 = 25000; //25 ms period
  //CH1 - trigger pulse
  TC1 = TC7 + 12;     //12[us] pulse with for triggering

  /*1.1.4 Set pin action to TOGGLE*/
  //OUTPUT COMPARE ACTIONS
  /*****************************************
  Compare result Action - TCTL1/TCTL2
  OMx   OLx
  0     0  Timer Disconnected from pin
  0     1  Toggle OCx output line
  1     0  Clear OCx output lize to zero
  1     1  Set OCx output line to one
  *****************************************/

  //Set TC7 to toggle for testing only
  TCTL1_OM7 = 0; 
  TCTL1_OL7 = 1;

  //Set TC1 action to toggle
  TCTL2_OM1 = 0; 
  TCTL2_OL1 = 1;

  /*1.1.5 Decide if TC7 event affects other channels*/
  //OC7 transfer a "1" to OC1 on TC7 compare event

  OC7M |= OC7M_OC7M1_MASK;    //Mask OC7D0 and trasnfer to OC1 on CH7 compare
  OC7D |= OC7M_OC7M1_MASK;    //Transfer 1 to to OC1 if masked 
  
  
  /*1.1.6 Enable interrupts if necessary*/
  TIE_C7I = 1; //Enable interrupt for TC7
  TIE_C1I = 1; //Enable interrupt for TC1


  //INPUT CAPTURE SECTION - PULSE WIDTH****************************

  /*1.1.2 Set CH0 (PIN9) as Input Capture*/
  TIOS_IOS0 = 0;  //enable channel 0 as input


  /*1.1.3 Configure the edge detection*/

  //INPUT CAPTURE ACTIONS
  /*****************************************
  //Capture settings - TCTL3/TCTL4
  EDGxB   EDGxA
    0       0  Capture disabled
    0       1  Capture on rising edges only
    1       0  Capture on falling edges only
    1       1  Capture on any edge (rising or falling)
  *****************************************/
  
  //Capture in any edge
  TCTL4_EDG0B = 1;
  TCTL4_EDG0A = 1;
  
  /*1.1.4 Enable interrupts*/
  TIE_C0I = 1;    //enable interrupt for TC0


  //Timer Enable globally
  TSCR1 |= TSCR1_TEN_MASK;

  Segs_Init();
  SWL_Init();
  
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(update)
    {
      update = 0;
      cmDistance = pulseWidth / 58;
      Segs_16D(cmDistance, Segs_LineTop);
    }
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/
void RtiCallback(void)
{
  if(++msCounter > 499)
  {
    msCounter = 0; 
    update = 1;
  }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
interrupt VectorNumber_Vtimch7  void Vtimch7_ISR(void)
{
  TC7 += 25000;               //Re-arm TC7
  TFLG1 = TFLG1_C7F_MASK;      //clears flag, not using fast flag clearing this time
} 

interrupt VectorNumber_Vtimch1  void Vtimch1_ISR(void)
{
  TC1 += 25000;               //Re-arm TC1
  TFLG1 = TFLG1_C1F_MASK;      //clears flag, not using fast flag clearing this time
} 

interrupt VectorNumber_Vtimch0  void Vtimch0_ISR(void)
{
  if(PTT & PTT_PTT0_MASK)
  {//PIN is HIGH, it's a rising edge
    riseEdge = TC0;
  }
  else
  {//PIN is LOW, it's a falling edge
    fallEdge = TC0;
    pulseWidth = fallEdge - riseEdge; 
  }
  TFLG1 = TFLG1_C0F_MASK;   //clear flag;
} 