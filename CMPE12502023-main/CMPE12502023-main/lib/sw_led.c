#include "derivative.h"
#include "sw_led.h"
#include "pit.h"

void SWL_Init (void) 
{
    DDR1AD1 = 0b11100000;
    ATD1DIEN1 = 0b00011111;
}
void SWL_ON (SWL_LEDColour led)
{
    PT1AD1 |= led;
}
void SWL_OFF (SWL_LEDColour led)
{
    PT1AD1 &= ~led;
}
void SWL_TOG (SWL_LEDColour led)
{
    PT1AD1 ^= led;
}
int SWL_Pushed (SWL_SwitchPos Position)
{
    if (PT1AD1 & Position)
    {
        return 1;
    }    
    return 0;
}
void Sw_Process(SwState* state, unsigned char mask)
{
    //the mask is the 1 is in the switch so like 01000000 
    if(PT1AD1 & mask)
    {
        if (*state == Idle)
        {
            *state = Pressed;
        }
        else
        {
            *state = Held;
        }
    }
    else
    {
        if(*state == Held)
        {
            *state = Released;
        }
        else
        {
            *state = Idle;
        }
    }
}

SwState Sw_ProcessD(SwState* state, SWL_SwitchPos pos) 
{
    if(SWL_PushedDeb(pos))
    {
        if (*state == Idle)
        {
            return *state = Pressed;
        }
        else
        {
            return *state = Held;
        }
    }
    else
    {
        if(*state == Held)
        {
            return *state = Released;
        }
        else
        {
            return *state = Idle;
        }
    }
}
int SWL_PushedDeb (SWL_SwitchPos pos)
{
    unsigned char sample1 = 1;
    unsigned char sample2 = 0;
    while(sample1 != sample2)
    {
        sample1 = PT1AD1 & 0b00011111;
        PIT_Sleep(PIT_CH3, 1);
        sample2 = PT1AD1 & 0b00011111;
    }
    if(sample1 & pos)
    {
        return 1;
    }
    return 0;
}
int SW_CountLED()
{
    int count=0;
    if(SWL_Pushed(SWL_GREEN))
    {
        count += 1;
    }     
    if(SWL_Pushed(SWL_RED))
    {
         count += 1;
    }
    if(SWL_Pushed(SWL_YELLOW))
    {
         count += 1;
    }
    return count;
}
int SW_Count()
{
    int count=0;
    if(SWL_Pushed(SWL_UP))
    {
        count++;
    }
    if(SWL_Pushed(SWL_DOWN))
    {
        count++;
    }
    if(SWL_Pushed(SWL_RIGHT))
    {
        count++;
    }
    if(SWL_Pushed(SWL_LEFT))
    {
        count++;
    }
    if(SWL_Pushed(SWL_CTR))
    {
        count++;
    }
    return count;
}
void Delay(unsigned int i)
{
    i = i * 2667;
    while(i--);
}
void DelayMs(unsigned int ms)
{
    unsigned int i, count;
    for (i = 0; i < ms; i++)
    {
        count = 2668;
        while(--count);
    }
    
}