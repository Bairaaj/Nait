#include "derivative.h"
#include "sci.h"
#include "clock.h"
#include <math.h>


extern unsigned long ClockSpeed;
//SCI0 - Normal mode: RDX0-> PS0 (PIN 89), TDX0-> PS1 (PIN 90)
// set baud, returns actual baud
unsigned long sci0_Init(unsigned long ulBaudRate, int iRDRF_Interrupt)
{
    unsigned long RoundedBR;
    unsigned long ReturnBR;
    SCI0CR1 = 0;

    SCI0CR2 = SCI0CR2_TE_MASK | SCI0CR2_RE_MASK;
    //enable RX, Enable TX
    if (iRDRF_Interrupt)
    {
        SCI0CR2_RIE = 1;
    }

    RoundedBR = floorf((Clock_GetBusSpeed() / (16.0 * ulBaudRate)) + 0.5);

    SCI0BD = RoundedBR;

    ReturnBR = (Clock_GetBusSpeed() / (16.0 * SCI0BD));

    return ReturnBR;

    // float floatingNumber;
    // unsigned long roundedNumber;
    // float returnBR;

    //SCI Configuration
    
    // floatingNumber = (Clock_GetBusSpeed() / (16.0 * ulBaudRate));
    //unsigned long roundedBR =  (ceil(BR * 2) / 2)
    
    // if ((floatingNumber - floor(floatingNumber)) >= 0.5) 
    // {
    //     roundedNumber = ceil(floatingNumber); // Round up
    // } 
    // else 
    // {
    //     roundedNumber = floor(floatingNumber); // Round down
    // }

    //Setting the Baud rate to the register
    // SCI0BD = roundedNumber; //math(ClockSpeed, ulBaudRate);

    
     //returnBR = (Clock_GetBusSpeed() / (16 * SCI0BD));
     //return returnBR;
}
unsigned char sci0_bread(void)
{
    
    //blocking delay
    while(!(SCI0SR1 & SCI0SR1_RDRF_MASK));//Wait till transmit data register is empty
    return SCI0DRL;

}

// read a byte, non-blocking
// returns 1 if byte read, 0 if not
unsigned char sci0_rxByte(unsigned char * pData)
{
    if(SCI0SR1 & SCI0SR1_RDRF_MASK) //Check if transmit data register is empty
    {
        *pData = SCI0DRL;
        return 1;
    } 
    return 0;
    
}

// send a byte over SCI
void sci0_txByte (unsigned char data)
{
    while(!(SCI0SR1_TDRE));//Wait till transmit data register is empty
    SCI0DRL = data;
}

// send a null-terminated string over SCI
//And sends things to the SCI 
//dont need interrupt for sending to the SCI
void sci0_txStr (char const * straddr)
{
    while(*straddr)
    {
        sci0_txByte(*straddr++);
    }

}