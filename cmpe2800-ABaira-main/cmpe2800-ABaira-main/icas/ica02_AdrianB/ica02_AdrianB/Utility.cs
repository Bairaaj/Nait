//*************************************************************************************************
//Submission Code:  2800_1242_A02                  
//Program:          ica02_AdrianB
//Description:      IEnumerable, Iterator Methoids, Defferred Execution
//Date:             Jan. 20, 2025
//Author:           Adrian Baira
//Course:           CMPE2800
//Class:            CNTA03
//**************************************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ica02_AdrianB
{
    public static class Utility
    {
        public static Random _rng = new Random();       //Random variable
        /// <summary>
        /// Shuffles the collection and keeps giving back the current index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) 
        {
            if (source.Count() <= 0)
                throw new Exception("Invalid cannot shuffle with no elements");

            List<T> temp = source.ToList();

            for(int i = 0; i < temp.Count; i++)
            {
                Swap(i, _rng.Next(i, temp.Count));

                //keep returning until last element
                yield return temp[i];
            }

            //Swapping two values from the list 
            void Swap(int left, int right)
            {
                T hold = temp[left];
                temp[left] = temp[right];
                temp[right] = hold;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static IEnumerable<T> Selection<T>(this IEnumerable<T> source, int range)
        {
            List<T> values = new List<T>();
            values = source.Distinct().ToList();
            for (int i = 0; i < range; i++)
            {
                if (i > range)
                    yield break;
               
                else
                {
                    if (values.Count <= 0)
                        yield break;

                    int random = _rng.Next(0,values.Count());
                    T value = values.ElementAt(random);
                    values.RemoveAt(random);
                    yield return value;
                }
            }
        }
        /// <summary>
        /// Grabs random values in a list and return to the user need to use .take() to specify how many elements wanted
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns>values at index</returns>
        public static IEnumerable<T> Sample<T>(this IEnumerable<T> source)
        {
            if (source.Count() <= 0)
                throw new ArgumentException("Can't grab any values if list is empty");
            while (true)
                yield return source.ElementAt(_rng.Next(source.Count()));
            
        }
    }
}
