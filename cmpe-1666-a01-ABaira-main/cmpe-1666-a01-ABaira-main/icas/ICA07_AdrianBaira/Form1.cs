//****************************************************************************
//Program: ICA07 Adrian
//Description: Palindrome
//Date: OCt, 10, 2023
//Author: Adrian Baira
//Course: CMPE1666
//Class: CNTA01
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ICA07AdrianBaira
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_FindPalindrome_Click(object sender, EventArgs e)
        //Peramaters:       To send things into the Form                
        //Purpose:          To show Palindrome from palindrome method
        //Returns:          Output Text
        //**********************************************************************************************
        private void UI_Button_FindPalindrome_Click(object sender, EventArgs e)
        {
            //call the method and put it into a check
            bool check = IsPalindrome(UI_TextBox_TestValue.Text.ToLower());
            //with method returns true then it will display true
            if (check == true)
            {
                UI_TextBox_TestValueResult.Text = "True";
            }
            //if method returns false then will display false
            else
            {
                UI_TextBox_TestValueResult.Text = "False";
            }
            if (UI_RadioButton_File.Checked)
            {
                CheckPaliFromFile();
            }
        }
        //**********************************************************************************************
        //Method:           private bool IsPalindrome(string text)
        //Peramaters:       String text
        //Purpose:          Recussion method and will check if last index is the same as first index and keep going to check if it is a palindrome
        //Returns:          a Bool
        //**********************************************************************************************
        private bool IsPalindrome(string text)
        {
            //Condition to stop the recurrsion method
            if (text.Length <= 1)
            {
                return true;
            }
            //will start at the first index of a character and will check if it does not equal to the last latter
            if (text[0] != text[text.Length - 1])
            {
                return false;
            }
            //it will change the text value for recussion again
            return IsPalindrome(text.Substring(1, text.Length - 2));
        }
        //**********************************************************************************************
        //Method:           private void CheckPaliFromFile()
        //Peramaters:       SteamReader
        //Purpose:          To read from a text file and display its contents that are a palindrome
        //Returns:          returns listbox values
        //**********************************************************************************************
        private void CheckPaliFromFile()
        {
            //open file reader and allow user to pick a file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //sets file to a string 
                string filename = openFileDialog1.FileName;
                string line;
                int count = 0;
                //counter for miliseconds
                var timer = new Stopwatch();
                StreamReader reader = new StreamReader(filename);
                //clears the text box
                UI_ListBox.Items.Clear();
                //Starts the timer once user presses a file
                timer.Start();
                //will keep reading until it reads a empty space 
                while ((line = reader.ReadLine()) != null)
                {
                    //call upon recussion method and check which values are a Palindrome
                    if (IsPalindrome(line.ToLower()))
                    {               
                        //will add items to the list box
                        UI_ListBox.Items.Add(line);
                        UI_ListBox.Update();
                        count++;
                    }            
                }
                //stop the timer after it is done printing all text
                timer.Stop();
                //display output for Timer and count
                UI_TextBox_PalindromeCount.Text = count.ToString();
                UI_TextBox_ExecutionTime.Text = $"{timer.ElapsedMilliseconds}";
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_RadioButton_File_CheckedChanged(object sender, EventArgs e)
        //Peramaters:       To send things into the Form         
        //Purpose:          To change visual from windows form 
        //Returns:          Output Text and listbox 
        //**********************************************************************************************
        private void UI_RadioButton_File_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_RadioButton_File.Checked)
            {
                UI_TextBox_TestValue.Text = "";
                UI_TextBox_TestValueResult.Text = "";
                //To make invisible the items in form
                UI_Label_TestValue.Visible = false;
                UI_Label_TestValueResult.Visible = false;
                UI_TextBox_TestValue.Visible = false;
                UI_TextBox_TestValueResult.Visible = false;
                //To make visible the items in form
                UI_Label_ListOfPalinDromesFromFile.Visible = true;
                UI_Label_PalindromeCountFromFile.Visible = true;
                UI_TextBox_ExecutionTime.Visible = true;
                UI_TextBox_PalindromeCount.Visible = true;
                UI_Label_ListOfPalinDromesFromFile.Visible = true;
                UI_ListBox.Visible = true;
                UI_Label_ExecutionTime.Visible = true;
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_RadioButton_TextValue_CheckedChanged(object sender, EventArgs e)
        //Peramaters:       To send things into the Form         
        //Purpose:          To hide the items and show items in form
        //Returns:          visible items and invisible items
        //**********************************************************************************************
        private void UI_RadioButton_TextValue_CheckedChanged(object sender, EventArgs e)
        {
            if(UI_RadioButton_TextValue.Checked)
            {
                UI_ListBox.Items.Clear();
                UI_TextBox_ExecutionTime.Text = "";
                UI_TextBox_PalindromeCount.Text = "";
                //To make visible the items in form
                UI_Label_TestValue.Visible = true;
                UI_Label_TestValueResult.Visible = true;
                UI_TextBox_TestValue.Visible = true;
                UI_TextBox_TestValueResult.Visible = true;
                UI_Button_FindPalindrome.Visible = true;
                UI_Label_ExecutionTime.Visible = true;
                UI_ListBox.Visible = true;
                //To make invisible the items in form
                UI_Label_ListOfPalinDromesFromFile.Visible = false;
                UI_Label_PalindromeCountFromFile.Visible = false;
                UI_TextBox_ExecutionTime.Visible = false;
                UI_TextBox_PalindromeCount.Visible = false;
                UI_Label_ListOfPalinDromesFromFile.Visible = false;
                UI_Label_ExecutionTime.Visible = false;
                UI_ListBox.Visible = false;
            }
        }
    }
}
