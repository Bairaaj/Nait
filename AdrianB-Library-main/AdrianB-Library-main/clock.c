#include "derivative.h"
#include "clock.h"

unsigned long ClockSpeed = DEF_BUS_CLOCK;

void Clock_EnableOutput(ClockOutDiv dividing)
{
    //dividing the bus speeed
    ECLKCTL &= ~ECLKCTL_NECLK_MASK; //Activate clock output 
    ECLKCTL |= ECLKCTL_EDIV1_MASK | dividing;   //clock divide by what user wants
}

void Clock_Set8MHZ(void)
{
    CLKSEL &= ~CLKSEL_PLLSEL_MASK;
    //ClockSpeed = DEF_BUS_CLOCK;
}

void Clock_Set20MHZ(void)
{
    Clock_SetSpeed(4,3);
    ClockSpeed = 20000000;
}

void Clock_Set24MHZ(void)
{
    Clock_SetSpeed(2,1);
    ClockSpeed = 24000000;
}

void Clock_Set40MHZ(void)
{
    Clock_SetSpeed(4,1);
    ClockSpeed = 40000000;
}

unsigned long Clock_GetBusSpeed(void)
{
    return ClockSpeed;
}

void Clock_SetSpeed(int synr,int refdv)
{
    SYNR = synr;
    REFDV = refdv;
    PLLCTL = PLLCTL_PLLON_MASK | PLLCTL_AUTO_MASK;//PLL ON and AUTO
    while(!(CRGFLG & CRGFLG_LOCK_MASK));//Wait for PLL to lock
    CLKSEL |= CLKSEL_PLLSEL_MASK; 
}
