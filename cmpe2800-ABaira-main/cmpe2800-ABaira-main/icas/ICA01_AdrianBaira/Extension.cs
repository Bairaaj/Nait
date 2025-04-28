using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA01_AdrianBaira
{
    public static class Extension
    {
        /// <summary>
        /// Categorize Ints with a key and value and sort them by key value
        /// </summary>
        /// <returns>Categorized Dictionary ordered by Key value</returns>
        public static Dictionary<int, int> Categorize(this List<int> sourcelist)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();
            foreach (int i in sourcelist)
            {
                if (!temp.ContainsKey(i))
                    temp.Add(i, 1);
                else
                    temp[i]++;
            }

            return temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
        }

        /// <summary>
        /// Generic Extension method so that any List<T> can be used 
        /// </summary>
        /// <returns>Categorized Dictionary ordered by Key value</returns>
        public static Dictionary<T, int> CategorizeG<T>(this List<T> sourcelist)
        {

            Dictionary<T, int> temp = new Dictionary<T, int>();
            foreach (T i in sourcelist)
            {
                if (!temp.ContainsKey(i))
                    temp.Add(i, 1);
                else
                    temp[i]++;
            }

            return temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
        }

        /// <summary>
        /// Categorize any IEnumerable 
        /// </summary>
        /// <returns>Dictonary that is sorted and categorized</returns>
        public static Dictionary<T, int> CategorizeIE<T>(this IEnumerable<T> sourcelist)
        {

            Dictionary<T, int> temp = new Dictionary<T, int>();
            foreach (T i in sourcelist)
            {
                if (!temp.ContainsKey(i))
                    temp.Add(i, 1);
                else
                    temp[i]++;
            }

            return temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
        }





        public static IEnumerable<T> TheOdds<T>(this IEnumerable<T> sourcelist)
        {
            return sourcelist.Where((obj, index) => index % 2 != 0).OrderByDescending(item => item);
        }
        public static IEnumerable<T> Singles<T>(this IEnumerable<T> sourcelist)
        {
            if (sourcelist == null)
                return null;

   
            return sourcelist.GroupBy(x => x).Where(y => y.Count() == 1).Select(z => z.Key);

        }

        public static (int index, KeyValuePair<T, K> kvp) RandoDic<T, K>(this Dictionary<T, K> source)
        {
            if (source == null || source.Count == 0)
                throw new ArgumentException();
            Random rng = new Random();
            int index = rng.Next(source.Count + 1);
            KeyValuePair<T, K> kvp2 = source.ElementAt(rng.Next(source.Count));
            return (index, kvp2);
        }

        public static T FirstDup<T>(this IEnumerable<T> sourcelist) where T : class
        {
            if (sourcelist.Count() == 0)
                return default;

            List<T> list = sourcelist.ToList();

            for(int i = 0; i < sourcelist.Count(); i++)
            {
                for(int j = i + 1; j < sourcelist.Count(); j++)
                {
                    if (ReferenceEquals(list[i], list[j]))
                    {
                        return list[i];
                    }
                }
            }
            return default;
        }
    }
}
