//*************************************************************************************************
//Program: ICA12 Adrian
//Description: Delegates
//Date: NOV, 11, 2023
//Author: Adrian Baka
//Course: CMPE1666
//Class: CNTA01
//*************************************************************************************************
using System;
using System.Windows.Forms;

namespace ICA_12_AdrianBaira
{
    public delegate string StringModiferDelegate(string input); //initialize delegate 
    public partial class Form1 : Form
    {
        public StringModiferDelegate stringModiferDelegate = null; //to set the delegate to null first
        public Form1()
        {
            InitializeComponent();
            stringModiferDelegate = UpperCase;
        }
        //**********************************************************************************************
        //Method:           private void UI_RAD_UpperCase_CheckedChanged(object sender, EventArgs e)
        //Purpose:          To check which radiobuttons are checked
        //Returns:          the output string
        //**********************************************************************************************
        private void UI_RAD_UpperCase_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_RAD_UpperCase.Checked)
            {
                stringModiferDelegate = UpperCase; //assign delegate to a method
            }
            else if (UI_RAD_Lowercase.Checked)
            {
                stringModiferDelegate = Lowercase; //assign delegate to a method
            }
            else if (UI_Rad_Flipcase.Checked)
            {
                stringModiferDelegate = FlipCase; //assign delegate to a method
            }
            UpdateOut(); //to update the output text box
        }
        //**********************************************************************************************
        //Method:           private string Uppercase(string input)
        //Peramaters:       String input - the input from textbox
        //Purpose:          to change all characters to UpperCase
        //Returns:          Uppercase string
        //**********************************************************************************************
        private string UpperCase(string input)
        {
            return input.ToUpper(); //changes string to lowercase
        }
        //**********************************************************************************************
        //Method:           private string Lowercase(string input)
        //Peramaters:       String input - the input from textbox
        //Purpose:          to change all characters to lowercase
        //Returns:          lowercase string
        //**********************************************************************************************
        private string Lowercase(string input)
        {
            return input.ToLower(); //changes string to uppercase
        }
        //**********************************************************************************************
        //Method:           private string FlipCase(string input)
        //Peramaters:       String input - the input from textbox
        //Purpose:          to change Upper case to lower and the other way around too
        //Returns:          a new string from chararray
        //**********************************************************************************************
        private string FlipCase(string input)
        {
            char[] chararray = input.ToCharArray(); //makes input into a char array
            for (int i = 0; i < chararray.Length; i++)
            {
                if (char.IsUpper(chararray[i])) //checks though if a letter is uppercase
                {
                    chararray[i] = char.ToLower(chararray[i]); //changes uppercase to lowercase
                }
                else if (char.IsLower(chararray[i])) //checks if a letter to lowercase
                {
                    chararray[i] = char.ToUpper(chararray[i]); //changes lowercase to uppercase
                }
            }
            return new string(chararray); //return the string array as a string
        }
        //**********************************************************************************************
        //Method:           private void UpdateOut()
        //Purpose:          To check if delegate is not null
        //Returns:          The output text from delegate method assigned to it
        //**********************************************************************************************
        private void UpdateOut()
        {
            if (stringModiferDelegate != null) //wont update the outputtext until it is assigned a method from delegate
            {
                UI_TXT_Outputstring.Text = stringModiferDelegate(UI_TXT_InputString.Text); //display output text from delgate method
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_TXT_InputString_TextChanged(object sender, EventArgs e)
        //Purpose:          To update output text
        //Returns:          The string input when changed
        //**********************************************************************************************
        private void UI_TXT_InputString_TextChanged(object sender, EventArgs e)
        {
            UpdateOut(); //To give the value to the output
        }
    }
}
