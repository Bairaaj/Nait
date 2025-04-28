using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question02
{
    public partial class Form1 : Form
    {
        private static Random _rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ints myInts01 = new Ints(10);
            Console.WriteLine ($"{myInts01.GetSum()}");

            ShowInts myInts02 = new ShowInts(10);
            Console.WriteLine($"{myInts02}");

            List<ISummy> summies = new List<ISummy>();
            while (summies.Count < 100)
            {
                if (_rnd.NextDouble() < 0.5)
                    summies.Add(new Ints(10));
                else
                    summies.Add(new ShowInts(10));
            }

            Console.WriteLine (string.Join("\r\n", summies));
        }
    }
    public interface ISummy
    {
        object GetSum();
    }

    public class Ints : ISummy
    {
        private static Random _rnd = new Random();
        protected List<int> _vals = new List<int>();

        public Ints(int iCount)
        {
            for (int i = 0; i < iCount; i++)
            {
                _vals.Add(_rnd.Next(0, 100));
            }
        }

        public override string ToString()
        {
            return $"[{GetSum()}]";
        }

        public object GetSum ()
        {
            return _vals.Sum();
        }
    }

    public class ShowInts : Ints, ISummy
    {
        public ShowInts (int iCount)
            : base (iCount)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()} : {string.Join(", ", _vals)}";
        }
    }
}
