/********************************************************************/
// HC12 Program:  Lab 3
// Processor:     MC9S12XDP512
// Bus Speed:     MHz
// Author:        Adrian Baira
// Details:       A more detailed explanation of the program is entered here               
// Date:          Dec, 4th, 2023
// Revision History :
//  each revision will have a date + desc. of changes



/********************************************************************/
// Library includes
/********************************************************************/
#include <hidef.h>      /* common defines and macros */
#include "derivative.h" /* derivative-specific definitions */

//Other system includes or your includes go here
//#include <stdlib.h>
//#include <stdio.h>
#include "sw_led.h"
#include "clock.h"
#include "rti.h"
#include "sci.h"
#include "pit.h"
#include "segs.h"

/********************************************************************/
// Constant Defines
/********************************************************************/
#define size 4
/********************************************************************/
// Local Prototypes
/********************************************************************/
/********************************************************************/
// Global Variables
/********************************************************************/
SwState upState, downState, leftsw, rightsw, centersw;
char index = 0;
unsigned int nibblepos = 0;
unsigned int valuearray[size] = {0,0,0,0};
unsigned int dec =0;
unsigned int hex = 0;
Seg16Typedef Decimalsave;
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
  //EnableInterrupts;
  /********************************************************************/
  // initializations
  /********************************************************************/
  Clock_Set20MHZ();
  SWL_Init();
  Segs_Init();
  Segs_16D(0,Segs_LineBottom);
  Segs_16H(0,Segs_LineTop);
  Segs_Normal(0,0,Segs_DP_ON);
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    Sw_Process(&upState, SWL_UP);
    Sw_Process(&leftsw, SWL_LEFT);
    Sw_Process(&downState, SWL_DOWN);
    Sw_Process(&rightsw, SWL_RIGHT);
    Sw_Process(&centersw, SWL_CTR);
    if(leftsw ==  Pressed)
    {
      if(--index < 0)
      {
        index = 0;
      }
    }
    if(rightsw ==  Pressed)
    {
      if(++index > 3)
      {
        index = 3;
      }
    }
    if(upState ==  Pressed)
    {

      if(valuearray[index] >= 9)
      {
        valuearray[index] = 0;
      }
      else
      {
        valuearray[index] += 1;
      }
  
    }
    if(downState ==  Pressed)
    {
      if(valuearray[index] < 1)
      {
        valuearray[index] = 9;
      }
      else
      {
        valuearray[index] -= 1;
      }
       
    }
    hex = (valuearray[0] * 1000 + valuearray[1] * 100 + valuearray[2] * 10 + valuearray[3] * 1);
    dec = (valuearray[3] * 1000 + valuearray[2] * 100 + valuearray[1] * 10 + valuearray[0] * 1);
    Segs_16D_DP(dec, Segs_LineTop, index);
    Segs_16H(hex, Segs_LineBottom);
  }                   
}

/********************************************************************/
// Functions
/********************************************************************/


/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
