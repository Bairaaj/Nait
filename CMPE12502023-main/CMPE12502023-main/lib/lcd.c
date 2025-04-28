#include "lcd.h"
#include "derivative.h"
#include "pit.h"

void lcd_Init(void)
{
    DDRH = 0xFF;
    DDRK |= 0b00000111;
    PIT_Sleep(PIT_CH2, 45);
    // Present Data on PTH
    PTH = 0b00111000;
    PORTK_PK1 = 0;
    PORTK_PK2 = 0;
    lcd_Latch;
    PIT_Sleep(PIT_CH2, 5);
    // Latch same Instruction again
    lcd_Latch;
    // third Delay  100uS+
    PIT_Delay_us(PIT_CH3, 120); // third Delay  100uS+
    // Latch same Instruction again
    lcd_Latch;
    lcd_Ins(0b00111000);
    // DISPLAY CONTROL
    lcd_Ins(0b00001110);
    // Clear display
    lcd_Clear();
    // home position
    lcd_Home();
    // mode control
    lcd_Ins(0b00000110);
}
void lcd_Ins(unsigned char data)
{
    while (lcd_Busy());
    PTH = data;
    PORTK_PK1 = 0;
    PORTK_PK2 = 0;
    lcd_Latch;
}
char lcd_Busy(void)
{
    unsigned char value = 0;
    DDRH = 0x00;
    PORTK_PK1 = 1;
    PORTK_PK2 = 0;
    lcd_Latch
    value = (PTH & 0x80);
    DDRH = 0xFF;
    return value;

} // LCD_Inst
char lcd_GetAddr(void)
{
    char address = 0;
    DDRH = 0x00;              // Set port H as input
    PORTK_PK1 = 1;            // Read operation
    PORTK_PK2 = 0;            // Instruction register
    lcd_Latch                 // Latch intruction
    address = PTH & 0x7F; // get 7 least signifficant bits, BIT7 is busy flag
    DDRH = 0xFF;              // Set port H as putput;
    return address;
}
void lcd_Data(unsigned char val)
{
    while (lcd_Busy());
    PTH = val;
    PORTK_PK1 = 0;
    PORTK_PK2 = 1;
    lcd_Latch;
}

void lcd_Addr(unsigned char addr)
{
    addr |= 0b10000000;
    lcd_Ins(addr);
}
void lcd_AddrXY(unsigned char ix, unsigned char iy)
{
   if (iy > 3 || ix > 19)
   {
        lcd_Addr(0);
   }
   else
   {
        switch(iy)
        {
            case 0:
                lcd_Addr(ix + LCD_ROW0);
                break;
            case 1:
                lcd_Addr(ix + LCD_ROW1);
                break;
            case 2:
                lcd_Addr(ix + LCD_ROW2);
                break;
            case 3:
                lcd_Addr(ix + LCD_ROW3);
                break;
        }
   }
}
void lcd_String(char const *straddr)
{
    while (*straddr)
    {
        lcd_Data(*straddr++);
    }
}
void lcdSmartString(char const *straddr, unsigned int delay)
{
    while (*straddr)
    {
        lcd_Data(*straddr++);
        PIT_Sleep(PIT_CH0, delay);
    }
}
void lcdSmartStringXY(unsigned char ix, unsigned char iy, char const * const straddr, unsigned int delay)
{
    lcd_AddrXY(ix, iy);
    lcdSmartString(straddr , delay);
}

void lcd_StringXY(unsigned char ix, unsigned char iy, char const *const straddr)
{
    lcd_AddrXY(ix, iy);
    lcd_String(straddr);
}
//turns cursor off and or blink off USE 1 to turn off 
void lcd_DispControl(unsigned char curon, unsigned char blinkon)
{
    int send = 0b000001100;
    if(curon)
    {
        send |= 0b00000010;
    }
    if(blinkon)
    {
        send |= 0b00000001;
    }
    lcd_Ins(send);

}
void lcd_Clear(void)
{
    lcd_Ins(0b00000001);
}
void lcd_ClearLine(unsigned char pos)
{
    int i;
    for(i = 0 ; i < LCD_WIDTH - 1; ++i)
    {
        lcd_StringXY(i,pos," ");
    }
}
void lcd_Home(void)
{
    lcd_Ins(0b00000010);
}
void lcd_ShiftL(char left)
{
    lcd_Ins(0b00010100);
}
void lcd_ShiftR(char right)
{
    lcd_Ins(0b00010000);
}
void lcd_ShiftLe(void)
{
    lcd_Ins(0b00010000);
}
void lcd_ShiftRi(void)
{
    lcd_Ins(0b00010100);
    
}
void lcd_CGAddr (unsigned char addr)
{
    lcd_Ins(0b01000000 | addr);
}
void lcd_CGChar (unsigned char cgAddr, unsigned const char* cgData, int size)
{
    unsigned char line;    
    lcd_CGAddr(cgAddr);
    for (line = 0; line< size; line++)
    {
       lcd_Data(cgData[line]);
    }
    lcd_Ins(0b10000000);    //back to DDRAM, home location 0
}