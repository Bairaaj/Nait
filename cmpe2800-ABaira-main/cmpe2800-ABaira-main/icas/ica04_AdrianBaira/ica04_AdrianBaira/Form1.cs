//*************************************************************************************************
//Submission Code:  2800_1242_A04                  
//Program:          ica04_AdrianB
//Description:      VarCar
//Date:             Feb. 1, 2025
//Author:           Adrian Baira
//Course:           CMPE2800
//Class:            CNTA03
//**************************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ica04_AdrianBaira
{
    public partial class ICA04 : Form
    {
        public ICA04()
        {
            InitializeComponent();
        }

        /// /// <summary>
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
            var cars = new List<Car>();
            string[] filepath = (string[])e.Data.GetData(DataFormats.FileDrop, false);      //getting the file path from drag and drop event
            Console.WriteLine(filepath[0]);
            string[] files = Directory.GetFiles(filepath[0]);                               //Getting the directory of the file if it is in a folder
            //Foreach file in the folder only grab the .csv file
            try
            {
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".csv")
                    {
                        var lines = File.ReadAllLines(file).ToList();
                        foreach (var newline in lines.Skip(1))  //skip the header of the csv file
                        {
                            cars.Add(new Car(newline));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong");
            }

            //Getting the total numbers of vehicles loaded
            var count = (from car in cars
                         select car).Count();
            Console.WriteLine(count);

            //Number of Unique makes that were loaded
            var numOfUnique = (from car in cars
                               select car._Make)
                              .Distinct()
                              .Count();
            Console.WriteLine(numOfUnique);

            //makes categorized by there first letter 
            var categorize = from makes in
                                    (from car in cars
                                     select car._Make).Distinct()
                             group makes by makes.ToUpper().First()
                             into groups
                             orderby groups.Key
                             select groups;


            foreach (var car in categorize)
            {
                var list = from brands in car
                           orderby brands
                           select brands;
                            
                Console.WriteLine($"{car.Key}: {string.Join(", ", list)}");
            }

            //All known styles from all makes
            var allstyles = (from car in cars
                             from style in car.Styles
                             select style).Distinct();
            Console.WriteLine(string.Join(", ", allstyles));

            //All makes that have all the styles
            //var compallstyles = cars.GroupBy(allbrands => allbrands._Make).Where(onebrand => allstyles.All(styles => onebrand.SelectMany(a => a.Styles).Contains(styles))).Select(c => c.Key).OrderBy(z => z);
            //var compallstyles = from makes in cars
            //                    select makes._Model;

            //Gotten Help from Adam W
            var compallstyles = from onebrand in
                                     (from car in cars
                                      group car by car._Make)
                                where allstyles.All(styles =>
                                    (from a in onebrand from x in a.Styles select x)
                                    .Contains(styles))
                                orderby onebrand.Key
                                select onebrand.Key;



            Console.WriteLine(string.Join(", ", compallstyles));


            //Console.WriteLine(string.Join(", ", compallstyles));


            //The make/model for vehicles that have been manufactured for more than 27 years
            for (int i = 31; i > 27; i--)
            {
                var year = from car in cars
                           group car by new { car._Make, car._Model }
                           into grouped
                           where grouped.Count() == i
                           orderby grouped.Key._Make
                           select new
                           {
                               Make = grouped.Key._Make,
                               Model = grouped.Key._Model,
                               min = grouped.Min(x => x._Year),
                               max = grouped.Max(x => x._Year),
                           };
                Console.WriteLine(i);
                foreach (var t in year)
                {
                    Console.WriteLine($"{t.Make}-{t.Model} ({t.min}-{t.max})");
                }
            }



            //Displaying to notepad
            var logger = new OutputLogger("txt");
            //Count of how many rows in folder of csv
            logger.Log($"Loaded data for {count} vehicles\n");

            //all different makes
            logger.Log($"There are {numOfUnique} different makes\n");

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
    }
}
