//*************************************************************************************************
//Program: ICA16 Adrian
//Description: Predicates & lamba expressions
//Date: Dec, 5, 2023
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
using System.Threading;
using System.IO;

namespace ICA16_AdrianBaira
{
    public delegate void Generate();
    public partial class ICA16 : Form
    {
        //struct for the sensor and temperature
        public struct Sensor
        {
            public int sensorid;
            public double temperature;
            public Sensor(int SensorID, double Temperature)
            {
                sensorid = SensorID;
                temperature = Temperature;
            }
            //puts the sensor id and temperature into a string
            public string toString()
            {
                return $"Sensor ID: {sensorid}. Temperature: {temperature:F1}";
            }
        }
        Generate generate = null; //delegate to null first
        public List<Sensor> sensorListOg = new List<Sensor>(); // lsit for the orginial sensors and temp
        public List<Sensor> sensorListNew; // new list for sorted and range vaues
        public List<int> UniqueId = new List<int>(); //new list to check for unique values
        public List<Thread> threadlist = new List<Thread>(); // thread list to save the threads
        double rangeval = 0; // range value for temperature range;
        public ICA16()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_GenerateSensors_Click(object sender, EventArgs e)
        //Purpose:          To generate the sensors and temperature
        //Returns:          values to be put into the list 
        //**********************************************************************************************
        private void UI_BTN_GenerateSensors_Click(object sender, EventArgs e)
        {
            UI_LISTBOX_RawData.Items.Clear(); //cleaar the list box
            generate = GenerateValues; //assign generate delegate to generate values
            Invoke(generate); //invoke the generate values
            Thread thread = new Thread(ShowListOG); // make a new thread and assign it to the method
            thread.IsBackground = true; //make the thread background thread
            threadlist.Add(thread); // add the thread into the list
            thread.Start(); //start the thread
        }
        //**********************************************************************************************
        //Method:           private void ShowListOG()
        //Purpose:          to put the values into the list box
        //Returns:          listbox values
        //**********************************************************************************************
        private void ShowListOG()
        {
            try
            {
                foreach (Sensor list in sensorListOg)
                {
                    UI_LISTBOX_RawData.Invoke(new Action(() => //invoke lamba expression
                    {
                        UI_LISTBOX_RawData.Items.Add(list.toString()); // add items into the list box
                    }));
                    Thread.Sleep(100); //Delay for the itterations
                }
            }
            catch
            {
                return;
            }
        }
        //**********************************************************************************************
        //Method:           private void GenerateValues()
        //Purpose:          Generate values to be put into a list
        //Returns:          Random Values to be put into a struct
        //**********************************************************************************************
        private void GenerateValues()
        {
            sensorListOg.Clear(); //clears the orignal list
            Random random = new Random(); //random value
            int inputvalue; //user input value
            bool check = int.TryParse(UI_TXTBOX_NumberOfSensors.Text, out inputvalue); //check if user input is valid
            if (check && inputvalue > 0)
            {
                for (int i = 0; i < inputvalue; i++)
                {
                    int sensor = random.Next(0, 5001); // makes the sensor between 0 and 5000
                    double temp = (random.Next(-400, 401) * 0.1); // to make the temperature be between -40 and 40
                    if (!UniqueId.Contains(sensor)) //made another list to check sensor id is unique
                    {
                        UniqueId.Add(sensor); //if the sensor id is unique it will show
                        sensorListOg.Add(new Sensor(sensor, temp)); // it will add it to the struct list
                    }
                    else { i--; } // if found the same it will go back one itteration
                }
            }
            sensorListNew = new List<Sensor>(sensorListOg);
        
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Redisplay_Click(object sender, EventArgs e)
        //Purpose:          To redisplay
        //Returns:          Saved values from the original list
        //**********************************************************************************************
        private void UI_BTN_Redisplay_Click(object sender, EventArgs e)
        {
            UI_LISTBOX_RawData.Items.Clear(); //to redisplay each time 
            Thread thread = new Thread(ShowListOG); //assign thread to a method
            thread.IsBackground = true; //is background for thread
            threadlist.Add(thread); // adds the thread to a list
            thread.Start(); //starts the thread
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_DisplaySorted_Click(object sender, EventArgs e)
        //Purpose:          To start a thread for the show list
        //Returns:          A new thread and sorting the list
        //**********************************************************************************************
        private void UI_BTN_DisplaySorted_Click(object sender, EventArgs e)
        {
            UI_LISTBOX_DataSortedOn.Items.Clear();
            Thread thread = new Thread(ShowListsSorted);
            thread.IsBackground = true;
            threadlist.Add(thread);
            thread.Start();
        }
        //**********************************************************************************************
        //Method:           private void ShowListsSorted()
        //Purpose:          To check the radio buttons
        //Returns:          Sorted list dependingo n the radio buttons
        //**********************************************************************************************
        private void ShowListsSorted()
        {
            try
            {
                if (UI_RAD_SensorId.Checked) // if the sensor id is check then sort the values using the helper method
                {
                    sensorListNew.Sort(CompareID); //use a predicate for the sort method
                }
                else if (UI_RAD_Temperature.Checked)
                {
                    sensorListNew.Sort(CompareTemp); //use a predicate for the sort method
                }
                foreach (Sensor list in sensorListNew)
                {
                    UI_LISTBOX_DataSortedOn.Invoke(new Action(() => // lamba expression to invoke
                    {
                        UI_LISTBOX_DataSortedOn.Items.Add(list.toString()); // to show the string into the listbox
                    }));
                    Thread.Sleep(100); //delay for each itteration
                }
            }
            catch
            {
                return;
            }
        }
        //**********************************************************************************************
        //Method:           private int CompareID(Sensor id1, Sensor id2)
        //Purpose:          helper method
        //Returns:          if the first id is check compared to the second id 
        //                  will give back the in value of one that is asc or desc
        //**********************************************************************************************
        private int CompareID(Sensor id1, Sensor id2)
        {
            if (UI_RAD_Ascending.Checked) // to see if asc is checked
            {
                return id1.sensorid.CompareTo(id2.sensorid); //compares the first number to the second number for asc
            }            
            return id2.sensorid.CompareTo(id1.sensorid);//comapres the second number to first number for desc

        }
        //**********************************************************************************************
        //Method:           private int CompareTemp(Sensor temp1, Sensor temp2)
        //Purpose:          helper method
        //Returns:          if the first Temperature is check compared to the seconds temperature 
        //                  will give back the in value of one that is asc or desc
        //**********************************************************************************************
        private int CompareTemp(Sensor temp1, Sensor temp2)
        {
            if (UI_RAD_Ascending.Checked) // if the radio button is checked
            {
                return temp1.temperature.CompareTo(temp2.temperature);
            } 
            return temp2.temperature.CompareTo(temp1.temperature); //comapres the second number to first number for desc
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_DisplaySelected_Click(object sender, EventArgs e)
        //Purpose:          to display and clear listbox
        //Returns:          new thread and listbox delegate
        //**********************************************************************************************
        private void UI_BTN_DisplaySelected_Click(object sender, EventArgs e)
        {
            UI_LISTBOX_SensorsWithTemp.Items.Clear(); //clear the listbox
            Thread thread = new Thread(ShowSelected); //assign the thread to a mthod
            thread.IsBackground = true; //set thread to background
            threadlist.Add(thread); // add thread to the list
            thread.Start(); //start the thread
        }
        //**********************************************************************************************
        //Method:           private void ShowSelected()
        //Purpose:          it will check to show the ones that are selected for the temperature range value to the ones that are in the list
        //Returns:          listbox item values to be put into the list box
        //**********************************************************************************************
        private void ShowSelected()
        {
            bool check = double.TryParse(UI_TXTBOX_TemperatureValue.Text, out rangeval); //to check if the value is valid or not and if it is then parse it out
            if(!check)
            {
                MessageBox.Show("Invalid"); // if the user puts in a invalid number
                return;
            }
            try
            {
                
                if (UI_RAD_GreaterthanEqual.Checked)
                {
                    sensorListNew = sensorListOg.FindAll(x => x.temperature >= rangeval); //lamba expression to check if the temperature it greater than the range value
                }
                else if (UI_RAD_LessthanEqual.Checked)
                {
                    sensorListNew = sensorListOg.FindAll(x => x.temperature <= rangeval); //lamba expression to check if the temperature is less than or equal to the range value
                }
                foreach (Sensor list in sensorListNew)
                {
                    UI_LISTBOX_SensorsWithTemp.Invoke(new Action(() => //invoking an action to prevent corss threading and that it will show the values in the list
                    {
                        UI_LISTBOX_SensorsWithTemp.Items.Add(list.toString());
                    }));
                    Thread.Sleep(100); //delay to show each iteration
                }
            }
            catch
            {
                return;
            }
        }

    }
}
