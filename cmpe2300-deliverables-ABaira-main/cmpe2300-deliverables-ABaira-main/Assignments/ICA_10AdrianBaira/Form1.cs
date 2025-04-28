using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GDIDrawer;

namespace ICA_10AdrianBaira
{
    public partial class ICA10 : Form
    {
        static Random random = new Random();
        List<Point> listPoints = new List<Point>();
        LinkedList<Point> linkedPoints = new LinkedList<Point>();
        CDrawer canvas = new CDrawer();
        int divisor = 0;
        public ICA10()
        {
            InitializeComponent();
        }

        private void UI_BTN_MakeList_Click(object sender, EventArgs e)
        {
            listPoints.Clear();

            divisor = (int)UI_NumericUpDown.Value;

            for(int y = 0; y < canvas.ScaledHeight; y += divisor)
            {
                for(int x = 0; x < canvas.ScaledWidth; x += divisor)
                {
                    listPoints.Add(new Point(x, y));
                }
            }
            canvas?.Clear();
            Point first = listPoints.First();
            foreach(Point point in listPoints.Skip(1))
            {
                canvas?.AddLine(first.X, first.Y, point.X, point.Y, Color.Purple, 2);
                first = point;
            }
            canvas.Render();

            UI_BTN_MakeList.Text = $"Make list : Points {listPoints.Count} added";

        }

        private void UI_BTN_ShuffleIt_Click(object sender, EventArgs e)
        {

            listPoints = MyLibrary.FisherYates(listPoints);
            canvas?.Clear();
            Point first = listPoints.First();
            foreach (Point point in listPoints.Skip(1))
            {
                canvas?.AddLine(first.X, first.Y, point.X, point.Y, Color.Green, 2);
                first = point;
            }
            canvas.Render();
        }

        private void UI__BTN_PopulateLinked_Click(object sender, EventArgs e)
        {
            linkedPoints.Clear();

            foreach (Point point in listPoints)
            {
                if(linkedPoints.Count <= 0)
                {
                    linkedPoints.AddFirst(point);
                    continue;
                }
                else
                {
                    LinkedListNode<Point> node = linkedPoints.First;
                    while(node != null)
                    {
                        if (point.X * canvas.ScaledHeight + point.Y <= node.Value.X * canvas.ScaledHeight + node.Value.Y)
                        {
                            linkedPoints.AddBefore(node, point);
                            break;
                        }
                        node = node.Next;
                    }
                    if(node == null)
                    {
                        linkedPoints.AddLast(point);
                    }

                }
            }
            canvas?.Clear();


            for (LinkedListNode<Point> node = linkedPoints.First; node != linkedPoints.Last; node = node.Next)
            {
                canvas?.AddLine(node.Value.X, node.Value.Y, node.Next.Value.X, node.Next.Value.Y, Color.Yellow, 2);
            }
            //Point first = linkedPoints.First();
            //foreach(Point point in linkedPoints.Skip(1))
            //{
            //    canvas?.AddLine(first.X, first.Y, point.X, point.Y, Color.Yellow, 2);
            //    first = point;
            //}
            canvas.Render();
        }
        private void UI_BTN__FilterOrder_Click(object sender, EventArgs e)
        {
            IEnumerable<Point> newlinkedpoints = linkedPoints;

            newlinkedpoints = linkedPoints.Where(point =>
            {
                return (point.X + point.Y) / divisor % 2 != 0;
            }).OrderBy(point =>
            {
                return Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
            });
            canvas?.Clear();
            Point first = newlinkedpoints.First();
            foreach (Point point in newlinkedpoints.Skip(1))
            {
                canvas?.AddLine(first.X, first.Y, point.X, point.Y, Color.Blue, 2);
                first = point;
            }
            canvas.Render();
        }
    }
}
