/*  Molar Mass Calculator
 *  Adrian Baira, Griffin Bravo
 *  CMPE2800
 *  
 *  Elements up to 118 are displayed in the viewer. Users may sort by name, the symbol,
 *  or by the atomic number. A search bar allows the user to search for a specific element,
 *  showing results as relevant to the search criteria. Finally, users may input a chemical
 *  formula in the 'Chemical Formula' text bar. The input will be analyzed and the total
 *  molar mass of the formula will be calculated and displayed.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMC_AdrianB_GriffinB
{
    public partial class MMC : Form
    {
        //globals
        List<Element> Elements = new List<Element>();   //List containing elements from the loaded csv file
        public MMC()
        {
            InitializeComponent();
        }

        #region On Startup
        /// <summary>
        /// Load the Periodic table to the DataGrid view
        /// Creating a Element from the CSV file
        ///     -Atomic Number (int)
        ///     -Name   (string)
        ///     -Symbol (string)
        ///     -Mass   (float)
        ///  Saves it to master list of
        /// </summary>
        private void MMC_Load(object sender, EventArgs e)
        {
            //Folder path for the periodic table
            string filepath = @"..\..\Periodic_table\Table.csv";
            //Error if file is open or file naming is wrong
            try
            {
                //Checks if the data is from a .csv file
                if (Path.GetExtension(filepath) == ".csv")
                {
                    //reads each line in the csv file and saves each row into an array
                    string[] line = File.ReadAllLines(filepath);
                    //Skipps the headers and saves new element into a list of <Element>
                    foreach (var l in line.Skip(1))
                        Elements.Add(new Element(l));

                }
            }
            //Exception for error checking
            catch (Exception a)
            {
                throw a;
            }
            //After success the data will be displayed on to the datagrid
            UI_DataGrid.DataSource = Elements;

        }
        #endregion

        #region Sort By Buttons
        /// <summary>
        /// Sorting the each element by atomic value
        /// </summary>
        private void UI_BTN_SortByAtomic_Click(object sender, EventArgs e)
        {
            //Resetting DataSource Grid
            UI_DataGrid.DataSource = null;

            //Sort the data by the atomic number
           // Elements.Sort((x, y) => { return x._AtomicNumber.CompareTo(y._AtomicNumber); });
            var sortAtomic = (from element in Elements
                              orderby element._AtomicNumber
                              select element).ToList();

            //Add to the DataGrid
            UI_DataGrid.DataSource = sortAtomic;
        }
        /// <summary>
        /// Sorting the each element by name
        /// </summary>

        private void UI_BTN_SortByName_Click(object sender, EventArgs e)
        {
            //Resetting DataSource Grid
            UI_DataGrid.DataSource = null;

            //Sort the data by the element name
            //Elements.Sort((x, y) => { return x._Name.CompareTo(y._Name); });

            var sortbyname = (from element in Elements
                              orderby element._Name
                              select element).ToList();

            //Add to the DataGrid
            UI_DataGrid.DataSource = sortbyname;
        }
        /// <summary>
        /// Sorting to only show Elements with a symbol count of 1
        /// </summary>
        private void UI_BTN_SingleCharSymbols_Click(object sender, EventArgs e)
        {
            //Resetting DataSource Grid
            UI_DataGrid.DataSource = null;

            //Grab the Symbol which length of string is 1
            var single = (from element in Elements
                          orderby element._Symbol.Count() == 1 descending,
                          element._Symbol
                          select element).ToList();

            //Add to the DataGrid
            UI_DataGrid.DataSource = single;

        }
        #endregion

        #region Molar Mass Calculation/Chemical Formula Input
        /// <summary>
        /// Will calculate the total molar mass of an inputted chemical formula.
        /// Will only accept inputs that are made up of elements included in our
        /// periodic table.
        /// </summary>
        private void UI_TXT_ChemicalFormula_TextChanged(object sender, EventArgs e)
        {
            //clear data grid and remove any text in search bar, reset molar mass text box
            UI_DataGrid.DataSource = null;
            UI_TXT_Search.Text = string.Empty;
            UI_TxtBox_AproxMolarMass.ForeColor = Color.Black;
            UI_TxtBox_AproxMolarMass.Text = "Input a formula";

            //set variables
            //[][] first two char in range Aa-Zz, ? -second char doesn't need to exist
            //\d* includes any number after the first two chars
            //Accepts 'C' 'C0001' 'Cl23456'
            string pattern = @"[A-Z][a-z]?\d*";             //regex pattern for detecting chemical formulas
            string formula = UI_TXT_ChemicalFormula.Text;   //formula from text bar


            //create a collection of matches from text input
            MatchCollection matches = Regex.Matches(formula, pattern);
            //removing any matches from the formula leaving only that which does not belong
            //Ex. input = "aC4dl", leftovers = "adl"
            string leftovers = Regex.Replace(formula, pattern, "");
            //testing: Console.WriteLine("leftovers: " + leftovers);

            //check if any 'leftovers' exist. 
            if (leftovers.Length == 0)
            {
                //creating a dictionary which holds the element and the count
                var elementCount = ElementDictionaryMaker(matches);
                //testing:
                //foreach (var k in elementCount)
                //Console.WriteLine($"{k.Key} : {k.Value}");


                //update datagrid to show the element's Name, Count, the atomic mass, and the total mass
                //Join the dictionary on both Symbol since the Symbol is the key for the dicitonary they can join together and add to the list
                var search = (from elem in Elements
                              join dicSymbol in elementCount
                              on elem._Symbol equals dicSymbol.Key
                              select new
                              {
                                  //Create new Table for Data source Grid
                                  //The join will allow to use both values from the list and dictionary
                                  Element = elem._Name,
                                  Symbol = elem._Symbol,
                                  Count = dicSymbol.Value,
                                  Mass = elem._Mass,
                                  Total_Mass = elem._Mass * dicSymbol.Value
                              }
                              into project // save the new combined values into a collection
                              select project).ToList();
                UI_DataGrid.DataSource = search;


                //calculate molar mass
                float molarMass = 0;
                foreach (var k in elementCount)
                {
                    //This check is required because of how our regex is.
                    //Our regex allows for inputs such as 'A' and 'R' to be apart of the elementCount dictionary.
                    //checking if k is in the Elements list will discern whether it is valid or not.

                    //find the elements mass from the Elements list
                    var element = Elements.Find(i => i._Symbol == k.Key);

                    //if the element exists, display the calculation
                    if (element != null)
                    {
                        molarMass += (element._Mass * k.Value);
                        UI_TxtBox_AproxMolarMass.Text = $"{molarMass.ToString(): %.4f} g/mol";
                        UI_TxtBox_AproxMolarMass.ForeColor = Color.Green;
                    }
                    //display error message
                    else
                    {
                        UI_DataGrid.DataSource = null;
                        UI_TxtBox_AproxMolarMass.Text = "Invalid Formula!";
                        UI_TxtBox_AproxMolarMass.ForeColor = Color.Red;
                        break;
                    }
                }
            }
            //else display error message
            else
            {
                UI_DataGrid.DataSource = null;
                UI_TxtBox_AproxMolarMass.Text = "Invalid Formula!";
                UI_TxtBox_AproxMolarMass.ForeColor = Color.Red;
            }

        }
        #endregion

        #region Search Function
        private void UI_TXT_Search_TextChanged(object sender, EventArgs e)
        {
            //Resetting the datagrid
            UI_DataGrid.DataSource = null;
            //Making the chemical formula text empty
            UI_TXT_ChemicalFormula.Text = string.Empty;
            //Search in elements the name and check if the name contains the text in the Search box
           
            string input = UI_TXT_Search.Text.ToLower().Trim();

            //if user inputs anything other than letters then it will show a null table and return
            if (!Regex.IsMatch(input, @"^[A-Za-z]+$"))
            {
                if(input == string.Empty)
                    UI_DataGrid.DataSource = Elements;
                else 
                    UI_DataGrid.DataSource = null;
                return;
            }
            //Grab each element from the list and order by
            //the symbol that would equal the input
            //Then sort by the symbol that starts with the same letter
            //Then sort by the symbol that would best fit input
            //then sort by the name that is closest to the input
            //Then sort by name
            //and Lastly sort by symbol and make it to a list to add to the data grid view
            var search = (from element in Elements
                          orderby element._Symbol.ToLower() == input descending,
                          element._Symbol.ToLower().StartsWith(input) descending,
                          element._Symbol.ToLower().Contains(input) descending,
                          element._Name.ToLower().Contains(input) descending,       
                          element._Name,
                          element._Symbol
                          select element).ToList();


            //add the new list of searched items to the data source grid
            UI_DataGrid.DataSource = search;


        }

        #endregion 

        #region Helper Methods
        /// <summary>
        /// Create a Dictionary in which the element symbol will be the key
        /// and the value will be the number of occurences of that element in the formula.
        /// </summary>
        /// <param name="matches">MatchCollection from regex</param>
        /// <returns>Dictionary<string, int></string></returns>
        public Dictionary<string, int> ElementDictionaryMaker(MatchCollection matches)
        {
            //create new dictionary to return
            Dictionary<string, int> eCount = new Dictionary<string, int>();

            //fill the dictionary with the element symbol as the key
            //and the number that element appears in the formula as the value
            foreach (Match match in matches)
            {
                //Check if the match contains a number (Ex. C4 or Cl17)
                if (match.Value.Any(x => char.IsDigit(x)))
                {
                    //separate the element symbol and how many of the element is present
                    string symbol = match.Value.Remove(match.Value.IndexOf(match.Value.First(x => char.IsDigit(x))));
                    string eSubscript = match.Value.Substring(match.Value.IndexOf(symbol) + symbol.Length);

                    //Will catch an overflow exception in the case where the user tries 
                    //to input too high of an element count
                    try
                    {
                        int numOfElem = int.Parse(eSubscript);
                        Console.WriteLine($"symbol {symbol}");
                        Console.WriteLine($"esubscript {eSubscript}");
                        Console.WriteLine($"numofelem: {numOfElem}");
                        //will check to see if the element exists within dictionary
                        //and will increment based on the subscript number
                        //Ex. Cl3 -> {Cl = 3}
                        if (!eCount.ContainsKey(symbol))
                            eCount.Add(symbol, numOfElem);
                        else
                            eCount[symbol] += numOfElem;
                    }
                    //Returns an empty dictionary if exception is caught
                    catch (OverflowException)
                    {
                        UI_TxtBox_AproxMolarMass.Text = "Element Count is too high!";
                        UI_TxtBox_AproxMolarMass.ForeColor = Color.Red;
                        return new Dictionary<string, int>();
                    }

                }
                //If no number count is present
                //will increment based on how many times it is typed in the formula bar
                //Ex. CCCC -> {C : 4}
                else
                {
                    //creates a key of the symbol if does not exist already
                    if (!eCount.ContainsKey(match.Value))
                        eCount.Add(match.Value, 1);
                    else
                        eCount[match.Value]++;
                }
            }

            //return the dictionary
            return eCount;
        }
        #endregion
    }
}
