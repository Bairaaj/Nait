#include "derivative.h"
#include "portj.h"

void PORTJ_Init(PORTJ_Interrupt ie)
{
    DDRJ &= ~(DDRJ_DDRJ1_MASK | DDRJ_DDRJ0_MASK);
    if(ie)
    {
        PIEJ |= SWJ_LEFT | SWJ_RIGHT;
    }
}

void PORTJ_SetHigh(SwitchLR SW)
{
    // if(!(PPSJ | SW) )
    // {
    //     PPSJ |= SW;
    // }
     PPSJ |= SW;
}

void PORTJ_SetLow(SwitchLR SW)
{
    // if(!(PPSJ & SW) )
    // {
    //     PPSJ &= ~SW;
    // }
    PPSJ &= ~SW;
}

// void PORTJ_IENSW(SwitchLR SW)
// {
//     PIEJ |= SW;
// }
// void PORTJ_IEN()
// {
//     PIEJ |= SWJ_LEFT | SWJ_RIGHT;
// }