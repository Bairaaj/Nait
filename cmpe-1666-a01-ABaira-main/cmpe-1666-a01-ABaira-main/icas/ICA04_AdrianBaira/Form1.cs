//****************************************************************************
//Program: ICA04 Adrian
//Description: Conversion Calulator
//Date: Sept, 22, 2023
//Author: Adrian Baira
//Course: CMPE1666
//Class: CNTA01
//*************************************************************************************************
//  Test                            InputValue (Units)           Output m/s        Input Source (Cite)
//  Escape Velovity of Earth        25000            MPH         11175.68          https://letstalkscience.ca/educational-resources/stem-explained/escape-velocity 
//  Speed of sound                  761.2            MPH         340.28            https://www.livescience.com/37022-speed-of-sound-mach-1.html
//  Escape Velocity of Phobos       25               MPH         11.18             https://www.space.com/20346-phobos-moon.html
//  Speed of Light                  1079252848.7999  KPH         299792458.00      https://www.britannica.com/science/speed-of-light
//
//*************************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA04_AdrianBaira
{
    public partial class Form1 : Form
    {
        //variables to be able to use in any method
        const double miles = 2.237;
        const double kilo = 3.6;
        public Form1()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void UI_InputspeedTextBox_TextChanged(object sender, EventArgs e)
        //Peramaters:       to call Calulations method
        //                  to check if user put a valid number
        //Purpose:          to do event handling when radio buttons are clicked and if input is being changed
        //Returns:          to Display windows form 
        //**********************************************************************************************
        private void UI_InputspeedTextBox_TextChanged(object sender, EventArgs e)
        {
            //method
            //save use input
            double value;
            //checks input
            bool check;
            //changes value into a double and returns a true or false
            check = double.TryParse(UI_InputspeedTextBox.Text, out value);
            //if conditions aren't met then show invalid 
            if (!check || value < 0)
            {
                //to write in the output textbox
                UI_OutputspeedTextbox.Text = "Invalid Number";
            }
            //condition if button is checked
            else if (UI_MilesPerHourButton.Checked)
            {
                //to put calulation on to output window an call on calulation method
                UI_OutputspeedTextbox.Text = (Calulations(0, value));
            }
            //condition if button for kilo is checked
            else if (UI_Kilometerperhourbutton.Checked)
            {
                //to put calulation on to output window an call on calulation method
                UI_OutputspeedTextbox.Text = (Calulations(1, value));
            }
        }
        //**********************************************************************************************
        //Method:           private string Calulations()
        //Peramaters:       double - value to save user value
        //                  bool - check value if its a word
        //Purpose:          to do calulations for mph and kph
        //Returns:          to return calulations to text box event
        //**********************************************************************************************
        private string Calulations(int milesorkilo, double userinput)
        {
            string value = "";
            //if value is 1 then do calculation as kilometers
            if (milesorkilo == 1)
            {
                value = ($"{(userinput / kilo):F2}");
                //calculation to display and retuen decimal point to 2
            }
            //if value is 0 then do calulations as miles per hour
            if (milesorkilo == 0)
            {
                value = ($"{(userinput / miles):F2}");
            }
            //return to method
            return value;

        }
    }
}
