//*************************************************************************************************
//Submission Code:  2800_1242_A04                  
//Program:          ica04_AdrianB
//Description:      VarCar - CAR CLASS
//Date:             Feb. 1, 2025
//Author:           Adrian Baira
//Course:           CMPE2800
//Class:            CNTA03
//**************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ica04_AdrianBaira
{
    internal class Car
    {
        public string _Make { get; private set; }
        public string _Model { get; private set; }

        public UInt16 _Year { get; private set; }

        private List<string> _Styles = new List<string>();

        public IEnumerable<string> Styles
        {
            get { return new List<string>(_Styles); }
        }

        // You provide a CTOR that can take a line from the csv file,
        //  parse out the necessary items and populate a Car
        //  Throw a new ArgumentException if anything fails to parse
        public Car(string csv)
        {
            //
            csv = csv.Replace("\"", "");
            //Grab the index for styles between the brackets
            int left = csv.IndexOf('[');
            int right = csv.IndexOf(']');

            string styles = "";

            //Grab the styles between the two brackets
            if (left != -1 || right != -1)
                styles = csv.Substring(left + 1, right - left - 1);

            //Spliting the data from , to an array => year / make / model / styles
            string[] cars = csv.Split(',');

            //parse out the year into an UInt16
            if (!UInt16.TryParse(cars[0], out UInt16 Year))
                throw new ArgumentException("Year format is incorrect.");

            //assign them to the properties
            _Year = Year;
            _Make = cars[1];
            _Model = cars[2];

            // for the styles split each of them on the , and sanitize them into the list
            foreach (string style in styles.Split(','))
                _Styles.Add(style.Trim());


        }

        // You can test your load by iterating and verifying
        public override string ToString()
        {
            return $"Make: {_Make}, Model: {_Model}, Year: {_Year}, Styles: {string.Join(",", _Styles)}";
        }
    }
}
