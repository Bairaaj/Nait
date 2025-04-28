//*************************************************************************************************
//Submission Code:  2800_1242_A03                  
//Program:          ica03_AdrianB
//Description:      CLASS OUTPUTLOGGER
//Date:             Jan. 27, 2025
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

namespace ica03_AdrianBaira
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
