//****************************************************************************
//Program: ICA10 Adrian
//Description: Sorting Quick sort and selection sort
//Date: Oct, 27, 2023
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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ICA10_AdrianBaira
{
    public partial class Form1 : Form
    {
        Random random = new Random(); //initalize a new random number
        List<int> generatedValues = new List<int>(); // a list for generated list
        public Form1()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_GenerateValues_Click(object sender, EventArgs e)
        //Purpose:          To check if user put in a value and check for numbers and characters 
        //Returns:          string - value to be used into the genertated list
        //*********************************************************************************************
        private void UI_Button_GenerateValues_Click(object sender, EventArgs e)
        {
            generatedValues.Clear(); //clears the list when button is pressed
            int numberofValue;      //to get the users input for values 
            int minValue;           //the min value user input
            int maxValue;           //the max value user input
            //To check if user put valid input
            if (int.TryParse(UI_TextBox_NumberofValues.Text, out numberofValue) && (int.TryParse(UI_TextBox_MinimumValues.Text, out minValue)) && (int.TryParse(UI_TextBox_MaximumValues.Text, out maxValue)))
            {
                if (numberofValue <= 10) //if the value is greater than 10
                {
                    MessageBox.Show("Invalid, You can not have a valuue less than 10"); //error message
                }
                if (minValue > maxValue) //if the min is less than max
                {
                    MessageBox.Show("Invalid, Minimum can not be higher than Maximum"); //error message
                }
                else if (numberofValue > 10)
                {
                    for (int i = 0; i < numberofValue; i++) //add generated values from
                    {
                        int value = random.Next(minValue, maxValue + 1);
                        generatedValues.Add(value); // Adds values into the list
                    }
                    UI_TextBox_GeneratedValues.Text = string.Join(" ", generatedValues); //displays the list into the textbox
                }
            }
            else if (!int.TryParse(UI_TextBox_NumberofValues.Text, out numberofValue) || (!int.TryParse(UI_TextBox_MinimumValues.Text, out minValue)) || (!int.TryParse(UI_TextBox_MaximumValues.Text, out maxValue)))
            {
                MessageBox.Show("Invalid"); //if user puts in a letter or word
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_SortValues_Click(object sender, EventArgs e)
        //Purpose:          To check if user put in a value and insert it into the listbox
        //Returns:          string - value to be used into list box
        //*********************************************************************************************
        private void UI_Button_SortValues_Click(object sender, EventArgs e)
        {
            var timer = new Stopwatch();    //to initalize a stop watch
            timer.Start(); //starts the timer
            List<int> copyvalues = new List<int>(generatedValues); //creates a copy of a the generated list
            if (UI_RadioButton_SelectionSort.Checked)
            {
                SelectionSort(copyvalues); // uses sorting method selected
            }
            if (UI_RadioButton_QuickSort.Checked)
            {
                quickSort(copyvalues, 0, copyvalues.Count - 1); //uses sorting method selected
            }
            timer.Stop(); //stop the timer  
            UI_TextBox_SortedValues.Text = string.Join(" ", copyvalues); //displays the new sorted values
            UI_TextBox_SortingTime.Text = $"{timer.ElapsedTicks}"; //displays the amount of ticks it took for the method
            timer.Reset();// resets the timer
        }
        //**********************************************************************************************
        //Method:           static private void SelectionSort(List<int> list)
        //Paramaters:       List<int> list - generated values
        //Purpose:          to sort the generated values
        //Returns:          sorted values
        //*********************************************************************************************
        static private void SelectionSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++) // amount of passes for the list   
            {
                int max = i; //the max position for the highest number
                for (int j = i + 1; j < list.Count; j++)
                {   
                    if(list[j] < list[max]) // if the highest number is higher in the next position "CAN CHANGE TO ORDER FROM HIGH TO LOW IF YOU SWITCH TO >"
                    {
                        max = j; //then the new highest number is replaced with max
                    }
                }
                Swap(list, max, i); //swaps the old number with helper method
            }
        }
        //**********************************************************************************************
        //Method:           static private int Partitioning(List<int> list, int low, int high)
        //Purpose:          To split the list into two
        //Returns:          Position of partition and low
        //*********************************************************************************************
        static private int Partitioning(List<int> list, int low, int high)
        {
            int pivot = list[high]; // partition point
            int i = (low - 1);      // to start before the list
            for(int j = low ;j <= high;j++)
            {
                if (list[j] < pivot) // if this condition is true then swap "CAN CHANGE TO ORDER FROM HIGH TO LOW IF YOU SWITCH TO >"
                {
                    i++;              //increment to move up the list
                    Swap(list, i, j); //helper method
                }
            }
            Swap(list, i + 1, high); // helper method
            return (i+1); // to move one line for partition
        }
        //**********************************************************************************************
        //Method:           static private void quickSort(List<int> list, int low, int high)
        //Paramaters:       List<int> list - genertated list
        //                  int low - end of the partition
        //                  int high - start of the partition
        //Purpose:          To sort the method recursively
        //Returns:          string - value to be used into list box
        //*********************************************************************************************
        static private void quickSort(List<int> list, int low, int high)
        {
            if (low < high) //method to stop the method **BASE CASE**
            {
                int partition = Partitioning(list, low, high); // makes a split in the method to create two "Arrays" and sort them and meet in the middle and 
                quickSort(list, low, partition - 1);  // to meet the lower of the paitition to meet in the middle of the int "Partition"
                quickSort(list, partition + 1, high);   //to meet the the upper half of the partition to meed in the middle
            }
        }
        //**********************************************************************************************
        //Method:           static private void Swap(List<int> list, int start, int end)
        //Paramaters:       List<int> - generated values list
        //                  int start - first number to be changed
        //                  int end - second number to be changed
        //Purpose:          To swap two values "Aka" helper method
        //Returns:          int start -swaped
        //                  int end - swaped
        //*********************************************************************************************
        static private void Swap(List<int> list, int start, int end)
        {
            int temp = list[start];  //Temp storage for first number
            list[start] = list[end];    //makes second number the first number
            list[end] = temp;        //uses temp storage to convert second number to the original first number 
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_ClearSorted_Click(object sender, EventArgs e)
        //Purpose:          to reset multi text line
        //Returns:          string - value to be used into generated values text
        //*********************************************************************************************
        private void UI_Button_ClearSorted_Click(object sender, EventArgs e)
        {
            UI_TextBox_SortedValues.Clear(); //clears the sorted values when button is clicked
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_ClearRaw_Click(object sender, EventArgs e)
        //Purpose:          to reset multi text line
        //Returns:          string - value to be used into generated values text
        //*********************************************************************************************
        private void UI_Button_ClearRaw_Click(object sender, EventArgs e)
        {
            UI_TextBox_GeneratedValues.Clear(); //clears the generated values when clicked
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_Redisplay_Click(object sender, EventArgs e)
        //Purpose:          to reset multi text line
        //Returns:          string - value to be used into generated values text
        //*********************************************************************************************
        private void UI_Button_Redisplay_Click(object sender, EventArgs e)
        {
            UI_TextBox_GeneratedValues.Text = string.Join(" ", generatedValues); // It will redisplay orginal unsorted values
        }
    }
}
