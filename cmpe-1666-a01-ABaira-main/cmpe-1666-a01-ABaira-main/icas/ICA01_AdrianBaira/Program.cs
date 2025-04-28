//****************************************************************************************************************************
//Program:          ICA01_AdrianB
//Description:      Create an array using the user input values using methods and search in the array for a number inputted
//Date:             Sept. 04/2023
//Author:           Adrian Baira
//Course:           CMPE1666
//Class:            CNTA01
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ICA01_AdrianB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = "CMPE 1666 - ICA01 Winter 2023 - Adrian Baira"; // title
            Console.WriteLine($"\t\t\t\t\t{title}\n"); // To center and display the title

            //Variables
            
            int minarray = 10;      //Min size of array
            int maxarray = 100;     //max size of array
            int sizeofarray = 0;    //size of the array
            int lowerlimit = 0;     //Lower limit for the number in array
            int upperlimit = 100;   //upper limit for the number in array        
            int lower;              //lower linits for the range of numbers to generate
            int upper;              //upper linits for the range of numbers to generate
            int[] array;            //Allows to give an array and set its value
            int userinput = 0;      //saves the users input for searching value
            int count;              //count the ammount of times the number shows up
            bool check = false;     //bool expression to end program

            //input the size of the array
            GetValue($"Input the size of the array to generate  ({minarray}-{maxarray}): ", minarray, maxarray, out sizeofarray);\
            //input the range of numbers that go inside of the array
            GetRange(lowerlimit, upperlimit, out lower, out upper);
            //generate the array and fill with random numbers
            array = GenerateArray(ref sizeofarray, ref lower, ref upper);
            //display the array in the console
            DisplayArray(array);
            Console.Write("\n");
            //repeat until user says n 
            do
            {
                Console.Write("\n");
                //Input value to be searched
                GetValue($"Enter value to be searched ({lower}-{upper}): ", lower, upper, out userinput);
                //count the occurrences
                count = CountOccurrences(array, ref userinput);
                //will display if there is a occurence
                if (count > 0)
                {
                    Console.WriteLine($"\nNumber of Occurences of {userinput} is {count} ");
                }
                //to end the program
                check = EndProgram("\nDo you want to search for another value? (Y/N, y/n): ");
            } while (check);

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
        }
        //**********************************************************************************************
        //Method:           static private void GetValue(string promt, int min, int max, out int value)                                
        //Purpose:          Inputs interger value with error and range checking
        //Peramaters:       String promt - promt to give to the user
        //                  int min - min values accepted
        //                  int max - max values accepted
        //Returns:          int - value accepted by the method  
        //*********************************************************************************************
        static private void GetValue(string promt, int min, int max, out int value)
        {
            bool check = false;
            //repeat until input is ok
            do
            {
                //input value
                Console.Write(promt);
                check = int.TryParse(Console.ReadLine(), out value);
                //check the value if valid
                if (!check)
                {
                    Console.WriteLine("\nInvalid int. Please try again.\n");
                }
                else if (value < min)
                {
                    Console.WriteLine($"\nYour number must be higher than {min}.\n");
                }
                else if (value > max)
                {
                    Console.WriteLine($"\nYour number must be lower than {max}.\n");
                }
              //leaves the loop when conditions are met
            } while (!check || value > max || value < min);    
        }
        //***************************************************************************************************
        //Method:           static private void GetRange(int min, int max, out int lower, out int upper)                 
        //Purpose:          To get the range of values to generate inside the set array by the user
        //Peramaters:       int min - minimum value accepted
        //                  int max - maximum value accepted               
        //Returns:          int out lower - sends lower value to main
        //                  int out upper - sends upper value to main
        //****************************************************************************************************
        static private void GetRange(int min, int max, out int lower, out int upper)
        {           
            int lowerlimit = 0;
            int upperlimit = 0;

            //input the lower and upper limit to generate
            GetValue("\nEnter the lower limit of the range of values to Generate (0-100): ", min, max, out lowerlimit);
            GetValue("\nEnter the upper limit of the range of value to generate (0-100): ", min, max, out upperlimit);
            // checks if lower limit is higher than the upperlimit
            if (lowerlimit >= upperlimit)
            {
                do
                {
                    if (lowerlimit > upperlimit)
                    {
                        Console.WriteLine("\nInvalid. The lower limit can not be higher than the upper limit please try again.\n");
                        GetValue($"Enter the upper limit of the range of value to generate ({lowerlimit}-100): ", min, max, out upperlimit);
                    }
                    Console.WriteLine("\nInvalid. The lower limit can not be the same as the upper limit please try again.\n");
                    GetValue($"Enter the upper limit of the range of value to generate ({lowerlimit + 1}-100): ", min, max, out upperlimit);
                } while (lowerlimit > upperlimit);
            }
            //returns values
            lower = lowerlimit;
            upper = upperlimit; 

        }
        //**************************************************************************************************************
        //Method:           static private int[] GenerateArray(ref int size, ref int lowerlimit, ref int upperlimit)        
        //Purpose:          To generate a array filled with random numbers given the paramaters given by user
        //Peramaters:       ref int size - size of the array given by the user
        //                  ref int lowerlimit - to give the range for the lower limit set by user
        //                  ref int upperlimit - to give the range for the upper limit set by user
        //                  Random random - creates random numbers
        //Returns:          int[] - returns array filled with random numbers
        //**************************************************************************************************************
        static private int[] GenerateArray(ref int size, ref int lowerlimit, ref int upperlimit)
        {
            //generate array size and random numbers
            int[] array = new int[size];
            Random random = new Random();
            //fill array with random numbers
            for(int i = 0; i < size; i++)
            {
                array[i] = random.Next(lowerlimit, upperlimit + 1);
            }
            return array;
            
        }
        //***************************************************************************************
        //Method:           static private void DisplayArray(int[] array)                 
        //Purpose:          Displays the array that was generated by the "Generate Array" Method
        //Peramaters:       string array to use the array to print on the screen   
        //Returns:          Console command to write out the array  
        //****************************************************************************************
        static private void DisplayArray(int[] array)
        {
            //displays values
            Console.Write("\nThe Generated values are: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}, ", array[i]);
            }
        }
        //********************************************************************************************
        //Method:         static private int CountOccurrences(int[] array, ref int numbertolookfor)
        //Purpose:        To count how many occurrences are in the current array
        //Peramaters:     int[] array - array to look into
        //                ref int numberToLookFor - references the users input to look for
        //Returns:        int - count of how many times a number occurrs
        //********************************************************************************************
        static private int CountOccurrences(int[] array, ref int numberToLookFor)
        {
            //counter
            int count = 0;          
            //checks in each section of array and adds to count
            foreach (int i in array)
            {
                if (numberToLookFor == i)
                {
                    count++;
                }  
            }
            //if count is 0 then give error message
            if (count == 0)
            {
                Console.WriteLine($"\n{numberToLookFor} was not found in array");
            }           
            return count;
        }
        //******************************************************************************
        //Method:           static private bool EndProgram(string promt)             
        //Purpose:          To give user a promt to end the program
        //Peramaters:       string - promt - promt to display to the user   
        //Returns:          bool - a true or false  
        //******************************************************************************
        static private bool EndProgram(string promt)
        {
            string yn = "";
            bool check = false;
            do
            {
                //gives user promt to leave program or continue 
                Console.Write(promt);
                yn = Console.ReadLine().ToLower();
                if (yn != "y" && yn != "n")
                {
                    Console.WriteLine("\nYou must respond with a Y/y or N/n.");
                }
            } while (yn != "y" && yn != "n");
            if (yn == "y")
            {
                check = true;
            }
            return check;
        }
    }
}
