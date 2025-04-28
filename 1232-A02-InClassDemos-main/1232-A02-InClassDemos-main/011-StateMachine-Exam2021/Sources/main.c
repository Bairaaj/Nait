/********************************************************************/
// HC12 Program:  CMPE2200 Exam #1 Solution
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       Exam #1 Fall 2021 for CMPE2200, C portion
                  
// Date:          Date Created
// Revision History :
//  each revision will have a date + desc. of changes

/********************************************************************/
// Constant Defines
/********************************************************************/
#define LOW_CIRCLE SEG_G | SEG_C | SEG_D | SEG_E
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
#include "lcd.h"

typedef enum SystemStateTypedef_
{
  Menu,
  Left,
  Center,
  Right,
  Counter
}SystemState;

/********************************************************************/
// Local Prototypes
/********************************************************************/
void RTI_Callback(void);
void ProcessInput(SystemState *pState);
void ExitToMenu(void);
/********************************************************************/
// Global Variables
/********************************************************************/
volatile unsigned int msCounter = 0;
int seconds = 0;
unsigned int secondsIndex = 0;

SystemState mainState;

unsigned char promptIndex = 0;
char updatePrompt = 0, updateCounter = 0, updateToggle = 0;


SwState leftState , rightState;
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

  Segs_16D(seconds, Segs_LineBottom);

  lcd_StringXY(0,0, "MENU    ");
  
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  { 
    switch (mainState)
    {
    case Menu:
      if(updatePrompt)
      {
        updatePrompt = 0;
        if(promptIndex == 0)
        {
          Segs_ClearLine(Segs_LineTop);
        }
        else 
        {
          Segs_Custom(promptIndex-1, 0);
        }
        if(++promptIndex > 4)
        {
          promptIndex = 0;
        }
      }
      ProcessInput(&mainState);
      break;

    case Left:
      if(updateToggle)
      {
        updateToggle = 0;
        SWL_TOG(SWL_RED);
      }
      if(SWL_Pushed(SWL_DOWN))
      {
        ExitToMenu();
      }
      break;

    case Center:
      if(updateToggle)
      {
        updateToggle = 0;
        SWL_TOG(SWL_YELLOW);
      }
      if(SWL_Pushed(SWL_DOWN))
      {
        ExitToMenu();
      }    
      break;

    case Right:
      if(updateToggle)
      {
        updateToggle = 0;
        SWL_TOG(SWL_GREEN);
      }
      if(SWL_Pushed(SWL_DOWN))
      {
        ExitToMenu();
      }    
      break;

    case Counter:
      if(SWL_Pushed(SWL_DOWN))
      {
        ExitToMenu();
      }  
      if(updateToggle)
      {
        updateToggle = 0;
        SWL_TOG(SWL_ALL);
      } 
      if(Sw_ProcessD(&rightState, SWL_RIGHT) ==  Released)
      {
        if(++seconds > 9999)
        {
          seconds = 0;        
        }
        Segs_16D(seconds, Segs_LineBottom);
      }  
      if(Sw_ProcessD(&leftState, SWL_LEFT) == Released)
      {
        if(--seconds < 0)
        {
          seconds = 9999;
        }
        Segs_16D(seconds, Segs_LineBottom);
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
  if(++msCounter > 199)
  {
    msCounter = 0; 
    updateToggle = 1; 
    if(mainState == Menu)
    {
      updatePrompt = 1;
      if(++secondsIndex > 4)
      {
        secondsIndex = 0;
        Segs_16D(++seconds, Segs_LineBottom);
      }
    }
  }    
}

void ProcessInput(SystemState *pState)
{
  if(SWL_Pushed(SWL_LEFT))
  {
    Segs_ClearLine(Segs_LineTop);
    lcd_StringXY(0,0, "LEFT    ");
    Segs_Custom(0, LOW_CIRCLE | NO_DP);
    SWL_OFF(SWL_ALL);
    SWL_ON(SWL_RED);
    *pState = Left;
  }
  else if (SWL_Pushed(SWL_CTR))
  {
    Segs_ClearLine(Segs_LineTop);
    lcd_StringXY(0,0, "CENTER  ");
    Segs_Custom(1, LOW_CIRCLE | NO_DP);
    SWL_OFF(SWL_ALL);
    SWL_ON(SWL_YELLOW);
    *pState = Center;
  }
  else if (SWL_Pushed(SWL_RIGHT))
  {
    Segs_ClearLine(Segs_LineTop);
    lcd_StringXY(0,0, "RIGHT   ");
    Segs_Custom(2, LOW_CIRCLE | NO_DP);
    SWL_OFF(SWL_ALL);
    SWL_ON(SWL_GREEN);
    *pState = Right;
  }
  else if (SWL_Pushed(SWL_UP))
  {
    Segs_ClearLine(Segs_LineTop);
    lcd_StringXY(0,0, "COUNTER ");
    Segs_Normal(3, 0xC, Segs_DP_OFF);
    SWL_ON(SWL_ALL);
    *pState = Counter;
  }
}

void ExitToMenu(void)
{
  Segs_ClearLine(Segs_LineTop);
  lcd_StringXY(0,0, "MENU    ");
  mainState = Menu;
}

/********************************************************************/
// Interrupt Service Routines
/********************************************************************/
