#include "derivative.h"
#include "pit.h"
#include "clock.h"

/// @brief Configures a channel (ch0 - ch3)
/// @param ch The channel in question (PIT_CH0 - PIT_CH3)
/// @param mt The micro-timer to be connected to (MT1 or MT0(default))
/// @param ie Enables or disables interrupt for the channel
void PIT_InitChannel(PIT_Channel ch, PIT_MicroTimer mt, PIT_Interrupt ie)
{
    if (mt == PIT_MT1) // micro timer 1 default
    {
        // can do
        PITCE |= ch; //for both
        PITMUX |= ch;     // microtimer 1
        if (ie == PIT_IEN) // enable interupt
        {
            PITINTE |= ch;
        }
        if (ie == PIT_IDIS) // disable interupt
        {
            PITINTE &= ~ch;
        }
    }
    else if (mt == PIT_MT0) // microtimer 0 delays
    {
        PITMUX &= ~ch;      // microtimer 0
        
        // if (ch == PIT_CH0) // pit channel enable
        // {
        //     PITCE |= PIT_CH0;
        // }
        // else if (ch == PIT_CH1) // pit channel enable
        // {
        //     PITCE |= PIT_CH1;
        // }
        // else if (ch == PIT_CH2) // pit channel enable
        // {
        //     PITCE |= PIT_CH2;
        // }
        // else if (ch == PIT_CH3) // pit channel enable
        // {
        //     PITCE |= PIT_CH3;
        // }
        if (ie == PIT_IEN) // enable interupt
        {
            PITINTE |= ch;
        }
        if (ie == PIT_IDIS) // disable interupt
        {
            PITINTE &= ~ch;
        }
        PITCE |= ch;
    }
    PIT_Start();
}

/// @brief Configures the channel to a 1[ms] event, fix connection to micro-timer1
/// @param ch The channel to be configured
void PIT_Set1msDelay(PIT_Channel ch)
{
    unsigned long ticks;
    PITMUX |= ch;
    ticks = (Clock_GetBusSpeed() / 1000);
    PITMTLD1 = 1 - 1;
    if (ch == PIT_CH0)
    {
        PITLD0 = ticks - 1;
    }
    if (ch == PIT_CH1)
    {
        PITLD1 = ticks - 1;
    }
    if (ch == PIT_CH2)
    {
        PITLD2 = ticks - 1;
    }
    if (ch == PIT_CH3)
    {
        PITLD3 = ticks - 1;
    }
    PITINTE &= ~ch;
    PITCE |= ch;

}

/// @brief A blocking delay function in milliseconds
/// @param ch The channel to use with the delay
/// @param ms The number of milliseconds to delay
void PIT_Sleep(PIT_Channel ch, unsigned int ms)
{
    int i;
    PIT_Set1msDelay(ch);
    ForceLoad(ch);    
    PIT_Start(); // timer start   
    for (i = 0; i < ms; i++)
    {
        while (!(PITTF & ch));       // wait for flag to become active
        PITTF = ch; // clear flag;  
    }
}

/// @brief This enables the PIT. It is recommened to be called last.
///        Nothing will work if this is not called
void PIT_Start()
{
    if (!(PITCFLMT & PITCFLMT_PITE_MASK)) // it will check if timer is started if timer is not started then dont do anything
    {
         PITCFLMT |= PITCFLMT_PITE_MASK;
    }
   
}

/// @brief Optional. Reasonable for anything above 20us
/// @param ch The channel to use with the delay
/// @param us The number of microseconds to delay
void PIT_Delay_us(PIT_Channel ch, unsigned int us)
{
    short ticks;
    ticks = ((Clock_GetBusSpeed() / 1000000) * us);
    PITMUX |= ch;
    PITMTLD1 = 1 - 1;
    switch (ch)
    {
        case PIT_CH0:
            PITLD0 = ticks - 1;
            break;
        case PIT_CH1:
        PITLD1 = ticks - 1;
            break;
        case PIT_CH2:
        PITLD2 = ticks - 1;
            break;
        case PIT_CH3:
        PITLD3 = ticks - 1;
            break;
    }
    PITINTE &= ~ch;
    PITCE |= ch;
    ForceLoad(ch);
    PIT_Start(); // timer start   
    while(!(PITTF & ch));
    PITTF = ch;   
}
void ForceLoad(PIT_Channel ch)
{
    PITFLT |= ch;            
    PITTF = ch;
}