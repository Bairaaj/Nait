#include "clock.h"
#include "segs.h"
#include "derivative.h"
#include "pit.h"

void Segs_Init()
{
    // initalizing the segs 7
    DDRA |= PORTA_PA1_MASK | PORTA_PA0_MASK;
    DDRB = 0xFF;
    // Clear the display aswell before anything.
    Segs_Clear();
}

// show HEX decoding (changes all of display to HEX, w/wo dp)
/* Params: (address, data, dp) */
void Segs_Normal(unsigned char Addr, unsigned char Data, Segs_DPOption dp)
{
    // SET REGISTER
    PORTB = 0b01011000;
    PORTB |= (Addr & 0x7);
    // SET TO CONTROL MODE
    PORTA |= PORTA_PA1_MASK;
    // LATCH
    Latchanddelay();
    // sendig data first
    PORTB = Data;
    // IF THERE IS DEIMAL OR NO
    if (dp)
    {
        PORTB &= (~0x80);
    }
    else
    {
        PORTB |= 0x80;
    }
    // no decimal point
    
    // SEND
    // SET TO DATA MODE
    PORTA &= ~PORTA_PA1_MASK;
    // LATCH
    Latchanddelay();
}
// control segs manually
/* Params: (address, data) */
void Segs_Custom(unsigned char Addr, unsigned char Data)
{
    // SET REGISTER
    //      0b01111000
    //          ^ That one makes it able for you to control.
    PORTB = 0b01111000;
    PORTB |= (Addr & 0x7);
    // SET TO CONTROL MODE
    PORTA |= PORTA_PA1_MASK;
    // LATCH
    Latchanddelay();
    // SEND data to the segs  

    PORTB = Data; 
    // to have no decimal point REMOVE IF YOU WANT
    //PORTB |= 0x80;
    // SET TO DATA MODE
    PORTA &= ~PORTA_PA1_MASK;
    // LATCH
    Latchanddelay();
}

// clear the display
/* Params: (address) */
void Segs_ClearDigit(unsigned char Addr)
{
    Segs_Custom(Addr, 0x80);
    // PORTB = 0x80;
}

// clear the entire display
void Segs_Clear(void)
{
    int i;
    for (i = 0; i < 8; i++)
    {
        Segs_ClearDigit(i);
    }
}

// clear display  upper or lower line
/* Params: (line) */
void Segs_ClearLine(Segs_LineOption line)
{
    int i;
    // bottom line
    if (line)
    {
        for (i = 4; i <= 7; i++)
        {
            Segs_ClearDigit(i);
        }
    }
    // top line
    else
    {
        for (i = 0; i <= 3; i++)
        {
            Segs_ClearDigit(i);
        }
    }
}

// show a 16-bit value on the upper or lower display
/* Params: (value, line) */
void Segs_16H(unsigned int value, Segs_LineOption line)
{
    int i;
    // bottom line
    if (line)
    {
        for (i = 7; i > 3; i--)
        {
            
            Segs_Normal(i, (unsigned char)(value % 16), Segs_DP_OFF);
            value /=16;
        }
    }
    // top
    else
    {
        for (i = 3; i >= 0; i--)
        {
            Segs_Normal(i, (unsigned char)(value % 16), Segs_DP_OFF);
            value /= 16;
        }
    }
}
// show a decimal value on the first or second line of the 7-segs
/* Params: (value, line) */
void Segs_16D(unsigned int value, Segs_LineOption line)
{
    int i;
    // bottom line
    
    if (line)
    {
        for (i = 7; i > 3; i--)
        {
            
            Segs_Normal(i, (unsigned char)(value % 10), Segs_DP_OFF);
            value /= 10;
            
        }
    }
    // top line
    else
    {
        for (i = 3; i >= 0; i--)
        {
            Segs_Normal(i, (unsigned char)(value % 10), Segs_DP_OFF);
            value /= 10;
        }
    }
}
void Segs_16H_DP (unsigned int value, Segs_LineOption line, char dpIndex)
{
    unsigned char i, offset;
    unsigned int cDisplay;

    if(line == Segs_LineTop)
    {
        offset = 0;
    }
    else if(line == Segs_LineBottom)
    {
        offset = 4;
    }

    for (i = 0; i < 4; i++)
    {
        cDisplay = (value >> (unsigned char)((3 - i) * 4)) & 0xF;
        if(i == dpIndex)
        {
          Segs_Normal(offset + i, (unsigned char)cDisplay, Segs_DP_ON); 
        }
        else
        {
          Segs_Normal(offset + i, (unsigned char)cDisplay, Segs_DP_OFF);
        }
 
    }  
   
}
void Segs_16D_DP (unsigned int value, Segs_LineOption line, unsigned char dpIndex)
{
    unsigned char i, offset;
    unsigned int cDisplay;

    if(line == Segs_LineTop)
    {
        offset = 0;
    }
    else if(line == Segs_LineBottom)
    {
        offset = 4;
    }

    for (i = 0; i < 4; i++)
    {
        if(i == dpIndex)
        {
           Segs_Normal(offset + i, (unsigned char)(value % 10), Segs_DP_ON);
          value /=10;
        }
        else
        {
           Segs_Normal(offset + i, (unsigned char)(value % 10), Segs_DP_OFF);
          value /=10;
        }
 
    }  
}
// show the 8-bit value starting on the digit as addr (0-6)
/* Params: (addr, value) */
void Segs_8H(unsigned char Addr, unsigned char Value)
{
    int lower = Value & 0x0F;
    int upper = (Value /= 16); 
    Addr = Addr % 8;
    Segs_Normal(Addr, upper,Segs_DP_OFF);
    Segs_Normal((Addr + 1) % 8, lower, Segs_DP_OFF);
    
}

// say Err on the appropriate line
/* Params: (line) */
void Segs_SayErr(Segs_LineOption line)
{
    int i;
    int val;
    // for the bottom line
    if (line)
    {
        for (i = 7; i > 3; i--)
        {
            // o_o face :)
            //  if(i == 7)
            //  {
            //      val = oup;
            //  }
            //  if (i == 6)
            //  {
            //      val = linebottom;
            //  }
            //  if (i == 5)
            //  {
            //      val = linebottom;
            //  }
            //  if (i == 4)
            //  {
            //      val = oup;
            //  }
            if (i == 7)
            {
                val = odown;
            }
            if (i == 6)
            {
                val = r;
            }
            if (i == 5)
            {
                val = r;
            }
            if (i == 4)
            {
                val = E;
            }
            Segs_Custom(i, val);
        }
    }
    // for the top of the Line
    else
    {
        Segs_Custom(3, odown);
        Segs_Custom(1, r);
        Segs_Custom(2, r);
        Segs_Custom(0, E);
    }
}
// Latch and a delay
void Latchanddelay()
{
    int delaysmall = 10;
    // to open the latch
    PORTA &= ~PORTA_PA0_MASK;
    // if the bus speed is greater than 8MHZ it will mess mup a bit so make a delay
    if (Clock_GetBusSpeed() > 80000000)
    {
        while (--delaysmall);
    }
    // close the latch
    PORTA |= PORTA_PA0_MASK;
}
unsigned int i = 0;
void Loadingsymbol(unsigned char addr)
{
    int val;
    
    if (i > 6)
    {
        i = 1;
    }
    PIT_Sleep(PIT_CH1, 100);
    if (i == 6)
    {
        val = linebottom;
    }
    if (i == 5)
    {
        val = linerightb;
    }
    if (i == 4)
    {
        val = linerightt;
    }
    if (i == 3)
    {
        val = linetop;
    }
    if (i == 2)
    {
        val = lineleftt;
    }
    if (i == 1)
    {
        val = lineleftb;
    }
    i++;
    Segs_Custom(addr, val);

    // for the top of the Line
}
void NibbleUpdate(Seg16Typedef* num, char addr, char inc_dec)
{
  switch (addr)
  {
    case 0:
      num->Nibble.Nibble3 += inc_dec;
    break;

    case 1:
      num->Nibble.Nibble2 += inc_dec;
    break;
      
    case 2:
      num->Nibble.Nibble1 += inc_dec;
    break;

    case 3:
      num->Nibble.Nibble0 += inc_dec;
    break;
  
    default:
      break;
  }
}