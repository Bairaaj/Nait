using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_10AdrianBaira
{
    internal class MyLibrary
    {
        public static List<Point> FisherYates(List<Point> list)
        {
            List<Point> points = new List<Point>(list);

            Random random = new Random();

            for (int i = points.Count - 1; i > 0; i--)
            {
                int z = random.Next(i + 1);

                Point temp = points[i];
                points[i] = points[z];
                points[z] = temp;
            }
            return points;
        }
    }
}
