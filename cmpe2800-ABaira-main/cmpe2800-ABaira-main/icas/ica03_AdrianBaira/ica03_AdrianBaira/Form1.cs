//*************************************************************************************************
//Submission Code:  2800_1242_A03                  
//Program:          ica03_AdrianB
//Description:      VarCar
//Date:             Jan. 27, 2025
//Author:           Adrian Baira
//Course:           CMPE2800
//Class:            CNTA03
//**************************************************************************************************
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
using System.Xml.Schema;
namespace ica03_AdrianBaira
{
    public partial class Form1 : Form
    {
        List<Car> cars = new List<Car>();   //List of cars from .csv files
        public Form1()
        {
            InitializeComponent();  
        }
        /// <summary>
        /// Drag drop file into label to process
        /// </summary>
        private void UI_LBL_DropFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        /// <summary>
        /// Get file and check if file is a .csv file and process into a note pad 
        /// containing
        ///     -Total number of vehicles loaded
        ///     -Number of Unique Makes
        ///     -All makes categorized by first letter and ordered
        ///     -Show all styles from all cars
        ///     -Show all makes that offer all known styles
        ///     -Show all vehicles that have been made for more than 27 years
        /// </summary>
        private void UI_LBL_DropFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] filepath = (string[])e.Data.GetData(DataFormats.FileDrop, false);      //getting the file path from drag and drop event
            string[] files = Directory.GetFiles(filepath[0]);                               //Getting the directory of the file if it is in a folder
            Console.WriteLine(files[1]);
            //Foreach file in the folder only grab the .csv file
            try
            {
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".csv")
                    {
                        Console.WriteLine(file);
                        var lines = File.ReadAllLines(file).ToList();
                        foreach (var newline in lines.Skip(1))  //skip the header of the csv file
                        {
                            cars.Add(new Car(newline));
                        }
                    }
                }
            }
            catch(Exception)
            {
                throw new Exception("Something went wrong");
            }
            
            //Getting the total numbers of vehicles loaded
            var count = cars.Count;
            Console.WriteLine(count);

            //Number of Unique makes that were loaded
            var uniquecount = cars.Select(x => x._Make).Distinct().Count();
            Console.WriteLine(uniquecount);
          
            //makes categorized by there first letter 
            var categorize = cars.Select(x => x._Make).Distinct().GroupBy(x => x.ToUpper().First()).OrderBy(x => x.Key);
            foreach (var car in categorize)
            {
                var list = car.OrderBy(x => x);
                Console.WriteLine($"{car.Key}: {string.Join(", " , list)}");
            }
           

            //All known styles from all makes
            var allstyles = cars.SelectMany(x => x.Styles).Distinct().ToList();
            Console.WriteLine(string.Join(", ", allstyles));

            //All makes that have all the styles
            var compallstyles = cars.GroupBy(allbrands => allbrands._Make).Where(onebrand => allstyles.All(styles => onebrand.SelectMany(a => a.Styles).Contains(styles))).Select(c => c.Key).OrderBy(z =>z);
            Console.WriteLine(string.Join (", ", compallstyles));



            //The make/model for vehicles that have been manufactured for more than 27 years
            //var Years = cars.GroupBy(car => new { car._Make, car._Model }).Where(x=> x.Count() == 31).OrderBy(x => x.Key._Make);
            for(int i = 31; i > 27; i--)
            {
                var year = cars.GroupBy(car => new { car._Make, car._Model }).Where(x => x.Count() == i).OrderBy(x => x.Key._Make);
                Console.WriteLine(i);
                foreach(var t in year)
                {
                    Console.WriteLine($"{t.Key._Make}-{t.Key._Model} ({t.First()._Year}-{t.Last()._Year})");
                }
            }


            //Displaying to notepad
            var logger = new OutputLogger("txt");
            //Count of how many rows in folder of csv
            logger.Log($"Loaded data for {count} vehicles\n");

            //all different makes
            logger.Log($"There are {uniquecount} different makes\n");

            //categorized all by First charater
            foreach (var car in categorize)
            {
                var list = car.OrderBy(x => x);
                logger.Log($"{car.Key}: {string.Join(", ", list)}");
            }

            //all known styles across all makes
            logger.Log($"All known styles : {string.Join(", ", allstyles)}\n");

            //all brands that makes these styles
            logger.Log($"Makes that make all styles: " + string.Join(", ", compallstyles));

            //all makes / models that have been made for more than 27 - 31 years
            //Got help from Griffin Bravo
            for (int i = 31; i > 27; i--)
            {
                var year = cars.GroupBy(car => new { car._Make, car._Model }).Where(x => x.Count() == i).OrderBy(x => x.Key._Make);
                logger.Log($"\n{i} Years:");
                logger.Log("----------");
                foreach (var t in year)
                {
                    logger.Log($"{t.Key._Make}-{t.Key._Model} ({t.First()._Year}-{t.Last()._Year})");
                }
            }
            System.Diagnostics.Process.Start("notepad.exe", logger.FileName);

        }
    }
}
