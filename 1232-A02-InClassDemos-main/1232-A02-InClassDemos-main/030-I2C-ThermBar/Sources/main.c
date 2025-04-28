/********************************************************************/
// HC12 Program:  I2C Thermometer / Barometer intro
// Processor:     MC9S12XDP512
// Bus Speed:     20 MHz
// Author:        Carlos Estay
// Details:       I2C Intro - DAC
                  
// Date:          April 4th, 2023   
// Revision History : 
// Updated Nov, 15th, 2023 

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
/********************************************************************/
// Global Variables
/********************************************************************/
int msCounter = 0;
char rtiUpdate = 0;
int test;

char readData = 0; 
char dataArray[5] = {0};
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
  lcd_Init();
  lcd_DispControl(0,0);
  Segs_Init();
  sci0_Init(115200, 1);

  I2C0_InitBus(I2CBus400); //for 400KHz

  //Initialize thermometer / barometer / temp sensor
  //CTRL_REG1(0x26) -> 0b00111000 - Barometer mode, 128 Over Sampling, verything else 0
  test = I2C0_RegWrite(MPL3115A2_ADD, CTRL_REG1, 0x38, IIC0_STOP);

  //PT_DATA_CFG(0x13) -> 0b00000111 - Data ready Event flag, Event or Pressure/Alt, Event on Temp
  test = I2C0_RegWrite(MPL3115A2_ADD, PT_DATA_CFG, 0x07, IIC0_STOP);

  //Activate device (out of stand-by mode)
  //CTRL_REG1(0x26) -> 0b00111001
  test = I2C0_RegWrite(MPL3115A2_ADD, CTRL_REG1, 0x39, IIC0_STOP);

   /*
  MPL3115A2 Registers to read:
  OUT_P_MSB (0x01) -> Pressure data out MSB
  OUT_P_CSB (0x02) -> Pressure data out CSB
  OUT_P_LSB (0x03) -> Pressure data out LSB
  OUT_T_MSB (0x04) -> Temperature data out MSB
  OUT_T_LSB (0x05) -> Temperature data out LSB
  */
  
  /********************************************************************/
  // main program loop
  /********************************************************************/
  for (;;)
  {
    if(rtiUpdate)
    {
      SWL_TOG(SWL_YELLOW);
      rtiUpdate = 0;
      test = I2C0_RegRead(&readData, MPL3115A2_ADD, DR_STATUS); 
      if(readData & DR_STATUS_PTDR_MASK)
      {
        SWL_ON(SWL_GREEN);
        SWL_OFF(SWL_RED);
        //Pressure Bytes
        test = I2C0_RegRead(dataArray, MPL3115A2_ADD, 0x01);
        test = I2C0_RegRead(dataArray+1, MPL3115A2_ADD, 0x02);
        test = I2C0_RegRead(dataArray+2, MPL3115A2_ADD, 0x03);
        //Temperature
        test = I2C0_RegRead(dataArray+3, MPL3115A2_ADD, 0x04);
        test = I2C0_RegRead(dataArray+4, MPL3115A2_ADD, 0x05); 
        sci0_txStr("READ successful!\r\n");
      }
      else
      {
        SWL_OFF(SWL_GREEN);
        SWL_ON(SWL_RED);
        sci0_txStr("NO READ\r\n");
      }
    }
  }
}

/********************************************************************/
// Functions
/********************************************************************/
void RTI_Callback()
{
  if(++msCounter > 249)
  {
    msCounter = 0;
    rtiUpdate = 1;
  }
}
/********************************************************************/
// Interrupt Service Routines
/********************************************************************/