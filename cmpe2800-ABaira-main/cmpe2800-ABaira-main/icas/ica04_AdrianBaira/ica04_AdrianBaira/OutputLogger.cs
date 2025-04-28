//*************************************************************************************************
//Submission Code:  2800_1242_A04                  
//Program:          ica04_AdrianB
//Description:      VarCar OUTPUT LOGGER
//Date:             Feb. 1, 2025
//Author:           Adrian Baira
//Course:           CMPE2800
//Class:            CNTA03
//**************************************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ica04_AdrianBaira
{
    internal class OutputLogger
    {
        public string FileName { get; private set; }

        public OutputLogger(string filename)
        {
            FileName = filename;

            // let it fail, let it fail, let it fail
            using (File.CreateText(FileName))
            {

            }
        }

        public void Log(string message)
        {
            using (StreamWriter str = File.AppendText(FileName))
            {
                str.WriteLine(message);
            }
        }
    }
}
