//*************************************************************************************************
//Program: ICA06 Adrian
//Description: Recurssions
//Date: OCT, 04, 2023
//Author: Adrian Baira
//Course: CMPE1666
//Class: CNTA01
//*************************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA06_AdrianBaira
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*---------------------------------Part A -----------------------------------*/
        //**********************************************************************************************
        //Method:           private void UI_StringRecusion_RECShow_Button_Click(object sender, EventArgs e)
        //Peramaters:       To send things into the Form
        //                  Changes UI string textbox
        //Purpose:          To show output from method
        //Returns:          Output Text
        //**********************************************************************************************
        private void UI_StringRecusion_RECShow_Button_Click(object sender, EventArgs e)
        {
            //to reset UI output box
            UI_StringRecusion_TextBox_Output.Text = "";
            //To save user input
            string text = UI_StringRecusion_TextBox_Input.Text;
            //to call upon method 
            Stringshow(text, 0, text.Length -1);
        }
        //**********************************************************************************************
        //Method:           private void Stringshow(string text, int position, int endposition)
        //Peramaters:       String text
        //                  Int Position
        //                  Int endposition
        //Purpose:          To call upon itself for it to look at the postion of letters
        //Returns:          Show string forwards
        //**********************************************************************************************
        private void Stringshow(string text, int position, int endposition)
        {
            //condition to stop calling apon itself
            if (position > endposition)
            {
                return;
            }
            else
            {
                //will add letter by letter into the output box from position
                UI_StringRecusion_TextBox_Output.Text += text[position];
                //will keep adding +1 to position until it reaches the end
                Stringshow(text, position + 1, endposition);
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_StringRecusion_RecReverse_Button_Click(object sender, EventArgs e)
        //Peramaters:       Reverse button click                
        //Purpose:          To call upon recussion method
        //Returns:          String backwards from method
        //**********************************************************************************************
        private void UI_StringRecusion_RecReverse_Button_Click(object sender, EventArgs e)
        {
            //to clear my output box
            UI_StringRecusion_TextBox_Output.Text = "";
            //to save user input
            string text = UI_StringRecusion_TextBox_Input.Text;
            //method to reverse 
            StringReverse(text, 0, text.Length - 1);
        }
        //**********************************************************************************************
        //Method:           private void StringReverse(string text, int position, int endposition)
        //Peramaters:       String text
        //                  Int Position
        //                  Int endposition
        //Purpose:          To call upon itself for it to look at the postion of letters
        //Returns:          Reversed string
        //**********************************************************************************************
        private void StringReverse(string text, int position, int endposition)
        {
            //condition to leave the loop
            if (position > endposition)
            {
                return;
            }
            else
            {
                //it will start from the end position then after will be able to count down
                StringReverse(text, position + 1, endposition);
                //starts at the end of the string to be able to count down
                UI_StringRecusion_TextBox_Output.Text += text[position];
            }
        }
        //----------------------------------------------Part B -------------------------------------------------//
        //**********************************************************************************************
        //Method:           private void UI_FactorFinder_FindFactors_Button_Click(object sender, EventArgs e)
        //Peramaters:       event handeler when button is pressed
        //Purpose:          To activate method when pressed
        //Returns:          Factors from method
        //**********************************************************************************************
        private void UI_FactorFinder_FindFactors_Button_Click(object sender, EventArgs e)
        {
            //save user value
            int value = (int)UI_NumericUpDown_Input.Value;
            //clear the output text
            UI_TextBox_FactorFinder_Output.Text = "";
            //method to find the factor
            FactorFinder(value, 1);
        }
        //**********************************************************************************************
        //Method:           private void FactorFinder(int value, int factors)
        //Peramaters:       int Value
        //                  int factors
        //Purpose:          To get the remainder for the factors of the numbers and call itself again
        //Returns:          Factors
        //**********************************************************************************************
        private void FactorFinder(int value, int factors)
        {
            //condition to end the loop
            if (factors > value) 
            {
                return;
            }
            //if my remainer is 0 that means it is a factor
            else if (value % factors == 0)
            {
                UI_TextBox_FactorFinder_Output.Text += $"{factors} ";
            }
            //go back into the method to add 1 until it reaches the condition to end the loop
            FactorFinder(value, factors + 1);

        }
        //---------------------------------------------Part C --------------------------------------------------//
        //**********************************************************************************************
        //Method:           private void UI_FindUppercase_Button_Click(object sender, EventArgs e)
        //Peramaters:       Eventhandler
        //Purpose:          To change text box when button is pressed
        //Returns:          changed texted from method and count
        //**********************************************************************************************
        private void UI_FindUppercase_Button_Click(object sender, EventArgs e)
        {
            //to Grab the text user input
            string value = UI_BinaryHunter_TextBox_Input.Text;
            //will save the count from method
            int count = CountUpperCase(value, 0, value.Length - 1);
            //display count in the box with promt given
            UI_BinarHunter_Textbox_OutPut.Text = $"There are {count} uppercase letters!";
        }
        //**********************************************************************************************
        //Method:           private int CountUpperCase(string input, int low, int high)
        //Peramaters:       string input
        //                  int low
        //                  int high
        //Purpose:          to search in the string which character is an uppercase
        //Returns:          Binary numbers that represent what it counted
        //**********************************************************************************************
        private int CountUpperCase(string input, int low, int high)
        {
            //this is my condition to start returning 1 or 0
            if (low == high)
            {
                if (char.IsUpper(input[high]))
                {
                    return 1;
                }
                else 
                {
                    return 0;
                }
            }           
            //it will keep iterrating until high goes to 0 so it can return to the first condition STEP 1
            int startOfInput = CountUpperCase(input, low,  high - 1);
            //now it will start from the beginning of the string and count up and check if its uppercase STEP 3
            int countingUpFromStart = CountUpperCase(input, high, high);
            //Will go from CountUpperCase and add it to counting from start so 1 STEP 2
            return startOfInput + countingUpFromStart;
            //METHOD STARTS FROM THE BEGINNING THEN COUNTS UP FROM THERE AND ADDS THE VALUES WHEN IT CALLS UPON ITSELF
        }
    }
}
