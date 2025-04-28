//****************************************************************************
//Program: ICA09 Adrian
//Description: Sorting and binary search
//Date: Oct, 24, 2023
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

namespace ICA09_AdrianBaira
{
    public partial class Form1 : Form
    {
        //list of strings
        static public List<string> sortedlist = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_AddName_Click(object sender, EventArgs e)
        //Purpose:          To check if user put in a value and insert it into the listbox
        //Returns:          string - value to be used into list box
        //*********************************************************************************************
        private void UI_Button_AddName_Click(object sender, EventArgs e)
        {
            string name = UI_TextBox.Text; // to save user input
            if (UI_TextBox.Text != string.Empty ) // to check if the text box is empty
            {
                if (!UI_ListBox_ListOfNamesOrderOfEntry.Items.Contains(UI_TextBox.Text)) //checks if the same name is put in again
                {
                    UI_ListBox_ListOfNamesOrderOfEntry.Items.Add(name.Trim()); //adds the name and removes whitespace
                    sortedlist.Add(name.Trim()); //adds name
                    sortedlist.Sort(); //sorts the names in the list
                    UI_ListBox_ListOfNamesSorted.Items.Clear();//clears the name of the items
                    foreach (string list in sortedlist) //print all strings inputed from list
                    {
                        UI_ListBox_ListOfNamesSorted.Items.Add(list); //adds it into the listbox
                    }
                    UI_TextBox.Text = string.Empty; //resets the text box
                }
                UI_TextBox.Text = string.Empty; //resets the text box
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_Search_Click(object sender, EventArgs e)
        //Purpose:          To start the binary search
        //Returns:          string- a string to be put into the message box telling where the value is at
        //*********************************************************************************************
        private void UI_Button_Search_Click(object sender, EventArgs e)
        {
            string message = string.Empty; // shows the message of index 
            //int index = binartSearchtwo(sortedlist, UI_TextBox.Text, 0);
            int index = binarySearch(sortedlist, UI_TextBox.Text, 0, sortedlist.Count - 1); // call recursive method
            if (index != -1) 
            {
                MessageBox.Show(UI_TextBox.Text + " was found at index: " + index); //displays message box if it was found 
            }
            else
            {
                MessageBox.Show(UI_TextBox.Text + " was not found. "); //desplays message if not found
            }
        }
        //**********************************************************************************************
        //Method:           static private int binarySearch(List<string> namelist, string inputname, int low, int high)
        //Peramaters:       List<string> - namelist
        //                  string inputname - userinput
        //                  int low - start of index
        //                  int high - end of index
        //Purpose:          to search for the index of userinput
        //Returns:          int
        //*********************************************************************************************
        static private int binarySearch(List<string> namelist, string inputname, int low, int high)
        {
            if (low > high) //base case to leave method
            {
                return -1;
            }
            int mid = (low + high) / 2; //divides the array
            int result = string.Compare(namelist[mid], inputname); // the result of the compare
            if (result == 0)
            {
                return mid; //returns index if input is found
            }
            if (result < 0)
            {
                return binarySearch(namelist, inputname, mid + 1, high); //checks the upper array
            }
            else
            {  
                return binarySearch(namelist, inputname, low, mid - 1); //checks the lower array
            }
        }
    }
}

// Other recussion methods that work

//**********************************************************************************************
//Method:           static private int binarySearchtwo(List<string> namelist, string inputname, int indexOfName)
//Peramaters:       List<string> - namelist
//                  string inputname - userinput
//                  int indexOfName - index of the number
//Purpose:          to search for the index of userinput
//Returns:          int
//*********************************************************************************************
/*static private int binarySearchtwo(List<string> names, string inputName, int indexOfName)
{
    if (indexOfName < names.Count())
    {
        if (names[indexOfName] == inputName)
        {
            return indexOfName;
        }
        else
        {
            return binarySearchtwo(names, inputName, indexOfName + 1);
        }
    }
    else
    {
        return -1;
    }
}*/
//**********************************************************************************************
//Method:           static private int binarySearchthree(List<string> namelist, string inputname, int low, int high)
//Peramaters:       List<string> - namelist
//                  string inputname - userinput
//                  int low - start of index
//                  int high - end of index
//Purpose:          to search for the index of userinput
//Returns:          int
//*********************************************************************************************
/*static private int binarySearchthree(List<string> list, string input, int low, int high)
{
    if (high >= low)
    {
        if (list[low] == input)
        {
            return low;
        }
        bool result = string.Equals(list[low], input);
        if (!result)
        {
            return binarySearchthree(list, input, low +1, high);
        }
    }
    return -1;
}*/
