#include <hidef.h>      /* common defines and macros */
#include "derivative.h"      /* derivative-specific definitions */
#include <string.h>

unsigned int num1= 0xA1A2;
unsigned long num2 = 0xA1A2A3A4;

unsigned char data[5];




void main(void) {
  /* put your own code here */
  

	EnableInterrupts;


  memcpy(data, &num1, 2);
  memcpy(data, &num2, 4);


  for(;;) {
    _FEED_COP(); /* feeds the dog */
  } /* loop forever */
  /* please make sure that you never leave main */
}
