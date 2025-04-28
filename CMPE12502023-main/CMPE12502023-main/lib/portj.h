

typedef enum SwitchLR
{
    SWJ_LEFT = 0b00000010,
    SWJ_RIGHT = 0b00000001
}SwitchLR;

typedef enum PORTJ_InterruptTypedef_
{
    PORTJ_IEN = 1,
    PORJ_IDIS = 0
}PORTJ_Interrupt;


//void PSW_Init(SwitchLR leftsw, SwitchLR rightsw);
//Initalize both switches
void PORTJ_Init();

//set switch to be high (Rising Edge) PRESSED
void PORTJ_SetHigh(SwitchLR SW);

//Set switch to low (Falling Edge) RELEASED
void PORTJ_SetLow(SwitchLR SW);

// //Enable interrupt on a single switch
// void PORTJ_IENSW(SwitchLR SW);

// //Enable interrupt on all switches
// void PORTJ_IEN(void);
