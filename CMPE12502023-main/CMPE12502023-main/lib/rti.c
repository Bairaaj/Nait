#include "derivative.h"
#include "rti.h"


extern volatile unsigned long rtiMasterCount;
extern volatile unsigned int delay;
//enable interupt with one ms
void RTI_Init(void)
{
    RTICTL = 0b10010111;
    CRGINT |= CRGINT_RTIE_MASK; 
}
//blocking delay
void RTI_Delay_ms(unsigned int ms)
{
    unsigned long past = rtiMasterCount + ms;
    while(rtiMasterCount < past);
}
//non blocking delay
int RTI_NonBlockingDelay_MS(unsigned int ms)
{
    if (ms == rtiMasterCount)
    {
        rtiMasterCount = 0;
        return 1;
    }
    return 0;
}

static void Throwawayfunction(void){}
static void (*Call) (void) = Throwawayfunction;
void RTI_InitCallback(void(*function)(void))
{
    RTI_Init();
    Call = function;
}
void RTI_InitCallbackMS(void(*function)(void), unsigned int ms)
{
    RTI_Init();
    Call = function;
    delay = ms;
}


interrupt VectorNumber_Vrti void Vrti_ISR(void)
{
    CRGFLG = CRGFLG_RTIF_MASK; // clear flag;
    rtiMasterCount++;
    if(delay > 0)
    {
        if(rtiMasterCount >= delay)
        {
            Call();
            rtiMasterCount = 0;
        }
    }
    else
    {
        Call();
    }

  
}