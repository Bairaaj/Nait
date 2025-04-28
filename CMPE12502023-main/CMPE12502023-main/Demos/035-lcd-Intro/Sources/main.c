/********************************************************************/
// HC12 Program:  lcd intro demo
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
#include <stdio.h> //for sscanf and sprintf
#include <string.h> //for memset and memcpy

#include "sw_led.h"
#include "clock.h"
#include "rti.h"
#include "sci.h"
#include "pit.h"
#include "segs.h"
#include "lcd.h"

/********************************************************************/
// Constant Defines
/********************************************************************/
#define BUFFER_SIZE 64
/********************************************************************/
// Local Prototypes
/********************************************************************/

/**************************;******************************************/
// Global Variables
/********************************************************************/
unsigned int msCounter = 0;
char update = 0;

char rxData = 0;
char rxBuffer[BUFFER_SIZE];
int rxIndex = 0;
char process = 0;
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
  RTI_Init();
  SWL_Init();
  Segs_Init();
  sci0_Init(115200, 1);

  /*LCD Initialization Start***************************/
  //Port Initialization-------------------------------------------
    //PH7-PH0 -> D7 - D0 (data Lines)
    DDRH = 0xFF;
    //PK2-PK0 -> Control Lines (output)
    DDRK |= 0b00000111;
    //1st delay - Delay 40+ [ms]
    PIT_Sleep(PIT_CH2, 45);
    //Present Data on PTH
    PTH  = 0b00111000;  //Function Set
/*             ||||||_____(don't care)
               |||||______(don't care)
               ||||_______font:  5x8 matrix (LOW)
               |||________lines: 2 (HIGH)
               ||_________data:  8-bit (HIGH)
               |__________function set of commands
*/ 
    //Write Operation - Instruction Register
    //PK1->R/W->0  PK2->RS->0  
    PORTK_PK1 = 0;
    PORTK_PK2 = 0;

    //Latch Instruction
    PORTK_PK0 = 1;
    lcd_MicroDelay;
    PORTK_PK0 = 0;

    //2nd Delay, 4.1ms+   
    PIT_Sleep(PIT_CH2, 5);

    //Latch same Instruction again
    lcd_Latch;

    //third Delay  100uS+ 
    PIT_Delay_us(PIT_CH3, 150);//third Delay  100uS+ 

    //Latch same Instruction again
    lcd_Latch;



    /***************************************
    *At this point, we can use the busy flag
    ***************************************/
    //5x8 dots, 2 lines
    //lcd_Ins(0b00111000); 
    PIT_Sleep(PIT_CH3, 10);
    lcd_Latch;

    // lcd_Ins(0b00001110);   //display controls
/*                 ||||_____Blink:   LOW for off
                   |||______Cursor:  HIGH for on
                   ||_______Display: HIGH for on
                   |________Display Control commands    
*/
    PTH = 0b00001110;
    PIT_Sleep(PIT_CH3, 10);
    lcd_Latch;


    //lcd_Ins(0b00000001);   //clear display, home position
    PTH = 0b00000001;
    PIT_Sleep(PIT_CH3, 10);
    lcd_Latch;

    // lcd_Ins(0b00000110);   //mode controls
/*                  |||_____Shift:   LOW for no display shift
                    ||______Inc/Dec: HIGH for increment (to the left)
                    |_______Entry Mode commands
*/        
    PTH = 0b00000110;
    PIT_Sleep(PIT_CH3, 10);
    lcd_Latch;
    /*LCD Initialization END***************************/


  lcd_Data('Z');

  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(update)
    {
      update = 0;
    }
  }                  
}

/********************************************************************/
// Functions
/********************************************************************/
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
    update = 1;
  }
}

interrupt VectorNumber_Vsci0 void sci0_ISR(void)
{
  if(sci0_rxByte(&rxData))
  {
    if(rxData == '\r')
    {//end of the message, process
      process = 1;
    }
    else if(rxIndex < BUFFER_SIZE)
    {
      rxBuffer[rxIndex++] = rxData; //add received character to the buffer
    }
  }
}