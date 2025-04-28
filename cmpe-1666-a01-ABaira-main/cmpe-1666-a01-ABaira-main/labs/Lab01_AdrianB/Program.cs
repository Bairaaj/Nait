//****************************************************************************************************************************
//Program:          LAB01_AdrianB
//Description:      Money Calculator and converter
//Date:             Sept. 14/2023
//Author:           Adrian Baira
//Course:           CMPE1666
//Class:            CNTA01
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Lab01_AdrianB
{
    class Program
    {
        static void Main(string[] args)
        {
            //loop to loop the program
            do
            {
                //clears my console and resets my variables
                Console.Clear();                
                double money = 0; //Userinput for money
                double moneyRounded;    //Userinput Rounded to canadian currency system
                double[] division = new double[9] { 50, 20, 10, 5, 2, 1, 0.25, 0.10, 0.05 };        //Array for my Dividing
                string[] nameofmoney = new string[9] { "Fifty", "Twenty", "Ten", "Five", "Toonie", "Loonie", "Qurter", "Dime", "Nickel" }; //string array for the names of currency
                double[] billCount = new double[9]; //array to save my bills

                GetValue("How much money do you wish to convert? ", out money); //method to collect user input
                moneyRounded = (Math.Round(money * 20) / 20); //rounding

                Console.WriteLine($"User entry of {money} interpreted and rounded to {moneyRounded}"); //display user input and rounded user input

                Bills(moneyRounded, division, out billCount); //method to divide and put user input into bills 
                //will display how much money in bills from user input
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine($"{nameofmoney[i]} x {billCount[i]}");
                }
                //method to draw money
                GDIDrawer(moneyRounded, billCount);
              //condition to loop              
            } while (YesNo("Would you like to try again? " ) == "yes");
           
        }
        //**********************************************************************************************
        //Method:           static void GetValue(string promt, out double money)                                
        //Purpose:          To check for a valid user input and give a proper value to be user
        //Peramaters:       String promt - promt to give to the user
        //Returns:          out double money - value accepted by method
        //*********************************************************************************************
        static void GetValue(string promt, out double money)
        {
            bool check;         //condition to leave the loop
            int counter;        //counts the amount of decimals are in the string
            money = 0;          //sets the value for money to save to
            string userValue;   //userinput
            //repeat
            do
            {
                //to leave loop 
                check = false;
                try
                {
                    //user display
                    Console.Write(promt);
                    userValue = Console.ReadLine().Trim();
                    counter = 0;
                    //checks if user put in a $ sign and trim it accordingly to be accepted as a double
                    if (userValue.Contains('$'))
                    {
                        userValue = userValue.Substring(1);
                    }
                    //parse value is accepted and will leave the loop
                    double.TryParse(userValue, out money);
                    //if value is not accepted will loop again
                    if (!double.TryParse(userValue, out money)) 
                    {                        
                        throw new Exception(); // it will throw an exception to the catch
                    }
                    if (money < 0) //when it is a (-) number 
                    {
                        throw new Exception();// it will throw an exception to the catch
                    }
                }
                catch (Exception)
                {
                    //error message
                    Console.WriteLine("Invalid input, Press enter to go again.");
                    Console.ReadKey();
                    Console.Clear();
     
                    check = true;
                }
            } while (check);

        }
        //***************************************************************************************************
        //Method:           static void Bills (double roundedMoney, double[] division, out double[] bills)            
        //Purpose:          To do calulations and divide accordingly
        //Peramaters:       double money - user input
        //                  double[] - division being used
        //Returns:          out double bills - returns the bills in an array 
        //****************************************************************************************************
        static void Bills(double roundedMoney, double[] division, out double[] bills) 
        {
           //array for the bills
            bills = new double[9];
            //will put values in the array 
            for (int i = 0; i < bills.Length; i++)
            {
                bills[i] = Math.Floor(roundedMoney / division[i]);
                roundedMoney = roundedMoney % division[i];
                roundedMoney = Math.Round(roundedMoney, 2);
            }
        }
        //***************************************************************************************************
        //Method:           static void GDIDrawer (double roundedMoney, double[] bills)            
        //Purpose:          to draw curreny in GDI
        //Peramaters:       double roundedmoney - user input
        //                  double[] bills - array of bills filled from "Bills" Method
        //Returns:          GDI drawer window
        //****************************************************************************************************
        static void GDIDrawer(double roundedMoney, double[] bills)
        {
            //postion to start drawing
            int xstart = 100;
            int ystart = 90;
            //create GDI window
            CDrawer canvas = new CDrawer(800, 650);
            //Add text for the ammount of money being shown in GDI
            canvas.AddText($"{roundedMoney:C}", 20, 200, 0, 400, 100, Color.Yellow);
            //String values to be put in to condese code to make it simipler also with colors
            string[] value = new string[] { "$50 x", "$20 x", "$10 x", "$5 x", "$2 x", "$1 x", "$0.25 x", "$0.10 x ", "$0.5 x" };
            Color[] color = new Color[9] {Color.Pink, Color.LightGreen, Color.AliceBlue, Color.LightBlue, Color.Beige, Color.Yellow, Color.Silver, Color.Silver, Color.Silver };
            //it will do the bills and will check if it is > than 1 and will draw bills accordingly
            for (int i = 0; i < 4; i++)
            {
                if (bills[i] > 0)
                {
                    canvas.AddRectangle(xstart, ystart, 200, 90, color[i], 3, Color.Gray);
                    canvas.AddText(value[i] + bills[i], 16, xstart + 20, ystart + 20, 160, 45, Color.Black);
                    ystart += 100;
                }
            }
            //if drawing reaches to the bottom of the screen it will move to the right side and contiune drawing accordingly
            if (ystart > 595)
            {
                xstart = 200;
                ystart = 80;
            }
            //to draw the coins and also be centered with the bills 
            for (int i = 4; i < 9; i++)
            {
                if(bills[i] > 0)
                {
                    canvas.AddEllipse(xstart + 50, ystart, 100, 100, color[i], 3, Color.Gray);
                    canvas.AddText(value[i] + bills[i], 16, xstart + 20, ystart + 25, 160, 45, Color.Gray);
                    ystart += 110;
                }
                //to draw the coins if space on the left is filled up
                if (ystart > 580)
                {
                    xstart = 500;
                    ystart = 80;
                }
            }
        }
        //***************************************************************************************************
        //Method:           static string Yesno (string yesNoPromt)            
        //Purpose:          A condition to restart program
        //Peramaters:       string yesNoPromt - gives user a promt
        //Returns:          string - containing yes and or no
        //****************************************************************************************************
        static string YesNo(string yesNoPromt)
        {
            //user input saved
            string input;
            //loop until condition is fufilled
            do
            {
                //will work even if use put in YES or yes
                Console.Write(yesNoPromt);
                input = Console.ReadLine().ToLower();
                if (input != "yes" && input != "no")
                {
                    Console.WriteLine("Invalid. please type yes or no ");
                }
                //if user types no it will close window
                if (input == "no")
                {
                    Environment.Exit(0);
                }
            } while (input != "yes" && input != "no");
            return input;
        }
    }
}
