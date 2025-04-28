//****************************************************************************
//Program: ICA14 Adrian
//Description: Palindrome with threading and delegate
//Date: Nove, 17, 2023
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
using System.Threading;
using System.Timers;

namespace ICA14_AdrianBaira
{
    //delegate
    public delegate void DelPalindrome(List<string> text);
    public partial class Form1 : Form
    {
        //variables for the list, threading, and timer
        List<string> file = null;
        List<string> foundpal = null;
        Thread threading = null;
        Stopwatch timer = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private bool IsPalindrome(string text)
        //Peramaters:       String text           
        //Purpose:          To find the palindrome in the list
        //Returns:          True or false
        //**********************************************************************************************
        private bool IsPalindrome(string text)
        {
            //Condition to stop the recurrsion method
            if (text.Length <= 1)
            {
                return true; 
            }
            //will start at the first index of a character and will check if it does not equal to the last letter
            if (text[0] != text[text.Length - 1])
            {
                return false;
            }
            //it will change the text value for recussion again
            return IsPalindrome(text.Substring(1, text.Length - 2));
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_SimpleTest_Click(object sender, EventArgs e)          
        //Purpose:          Test in the text box if it is a palindrome
        //Returns:          Output Text
        //**********************************************************************************************
        private void UI_BTN_SimpleTest_Click(object sender, EventArgs e)
        {
            //to maek sure te text box is not null before running
            if (UI_TXT_SimpleTest.Text != null)
            {
                bool check = IsPalindrome(UI_TXT_SimpleTest.Text);
                //with method returns true then it will display true
                if (check == true)
                {
                    //if the word inputed was a palinome
                    UI_TXT_SimpleTest.Text = $"{UI_TXT_SimpleTest.Text} Is a Palindrome";
                }
                //if method returns false then will display false
                else
                {
                    //error message
                    UI_TXT_SimpleTest.Text = $"{UI_TXT_SimpleTest.Text} Is not a Palindrome";
                }
            }

        }
        //**********************************************************************************************
        //Method:           private void UI_TXT_SimpleTest_MouseClick(object sender, MouseEventArgs e)
        //Purpose:          to clear textbox
        //Returns:          clear text box
        //**********************************************************************************************
        private void UI_TXT_SimpleTest_MouseClick(object sender, MouseEventArgs e)
        {
            UI_TXT_SimpleTest.Clear(); //clears the text box when pressed
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_LoadFile_Click(object sender, EventArgs e)
        //Peramaters:       To open the file from openfile dialog              
        //Purpose:          to show the openfile dialog and allowing it to be set to a list
        //Returns:          text for the count of the list.
        //**********************************************************************************************
        private void UI_BTN_LoadFile_Click(object sender, EventArgs e)
        {
            //new openfile dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //adds the file from the openfile dialog and add it to the list
                file = new List<string>(File.ReadAllLines(openFileDialog.FileName));
                //shows the count for the list 
                UI_TXT_Palindromes.Text = ($"Loaded {file.Count} Words!");

            }
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Find_Click(object sender, EventArgs e)    
        //Purpose:          Assign a thread to a method 
        //Returns:          starts the thread to search from the file 
        //**********************************************************************************************
        private void UI_BTN_Find_Click(object sender, EventArgs e)
        {
            //assigning the CheckPaliFromFile method to a threadd
            threading = new Thread(CheckPaliFromFile);
            threading.IsBackground = true;
            //starts the thread
            threading.Start();
        }
        //**********************************************************************************************
        //Method:           private void CheckPaliFromFile()    
        //Purpose:          set the delegate to the method of list and add it to the new list of found palindrome
        //Returns:          The method to show the palindrome because of invoke
        //**********************************************************************************************
        private void CheckPaliFromFile()
        {
            //if the file is selected
            if (file != null)
            {
                //sets the delegate method to the list
                DelPalindrome palindrome = List;
                //makes a new list of the found palinomes
                foundpal = new List<string>();
                timer.Restart();
                //it will take the file and look at each line
                foreach (string line in file)
                {
                    //call upon recussion method and check which values are a Palindrome
                    if (IsPalindrome(line.ToLower()))
                    {
                        //will add items to the list to the new list that was created
                        foundpal.Add(line);
                    }
                }
                timer.Stop();
                //invokes the list method below
                Invoke(palindrome, foundpal);
            }
        }
        //**********************************************************************************************
        //Method:           private void List(List<string> foundpali)       
        //Purpose:          To add words to the textbox
        //Returns:          to print out the output text
        //**********************************************************************************************
        private void List(List<string> foundpali)
        {
            //clears the textbox
            UI_TXT_Palindromes.Clear();
            foreach (string line in foundpali)
            {
                //prints each word in the found palinome
                UI_TXT_Palindromes.Text += $"{line}, ";
            }
            //counts how many were added into the found palinomes list and shows the timer for how long it took in ms
            UI_TXT_Palindromes.Text += $"--- found {foundpal.Count} palindromes in {timer.ElapsedMilliseconds}ms!";
        }
        
                
    }
}
