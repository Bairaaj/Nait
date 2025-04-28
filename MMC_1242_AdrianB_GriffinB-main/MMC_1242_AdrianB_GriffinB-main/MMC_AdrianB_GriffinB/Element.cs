/*  Molar Mass Calculator 
 *  Element Class
 *  Written by Adrian B.
 *  
 *  Describes an element from the periodic table. Includes the
 *  name, atomic number, the symbol, and the atomic mass of the 
 *  element.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MMC_AdrianB_GriffinB
{
    internal class Element
    {
        #region properties
        //Atomic number from element for sorting
        public int _AtomicNumber { get; private set; }
        //Name of Element for sorting and searching
        public string _Name { get; private set; }  
        //Symbol of Element for sorting and searching
        public string _Symbol { get; private set; }
        //Mass of the Element for calulating molar mass
        public float _Mass { get; private set; }
        #endregion

        #region CTOR
        /// <summary>
        /// Getting the properties for each element
        /// for easier data manipulation like 
        /// sorting, searching and creating chemcial formulas
        /// </summary>
        /// <param name="element">CSV string from file</param>
        public Element(string element)
        {
            //Spliting each of the properties from the csv file line
            string[] properties = element.Split(',');

            //making the number from string to int for atomic number
            int.TryParse(properties[0], out int atomicnumber);
            _AtomicNumber = atomicnumber;
            //Grabbing the name of the element for sorting and searching
            _Name = properties[1];
            //Grabbing the symbol of the element for sorting and searching
            _Symbol = properties[2];

            //grabing the mass of the element for generating molar mass
            float.TryParse(properties[3], out float mass);
            _Mass = mass;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Helping error check if each element has a atomic number, name, symbol, and mass
        /// </summary>
        /// <returns>String showing each property of the element</returns>
        public override string ToString()
        {
            return $"Atomic Number : {_AtomicNumber} Name : {_Name} : Symbol : {_Symbol} Mass {_Mass}";
        }
        #endregion
    }
}
