using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question2Practice
{
    public partial class Form1 : Form
    {
        List<Isummy> isummies = new List<Isummy>();
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ints ints = new Ints(10);
            label1.Text = ints.GetSum().ToString();
            ShowInts showInts = new ShowInts(10);
            label2.Text = $"{showInts}";

            for(int i = 0; i < 100; i++)
            {
                switch(random.Next(0,2))
                {
                    case 0:
                        isummies.Add(new Ints(10));
                        break;

                    case 1:
                        isummies.Add(new ShowInts(10));
                        break;
                }
            }
            string Test = "";
            Console.WriteLine(string.Join("\r\n", isummies));

            
        }
    }
    interface Isummy
    {
        object GetSum();
    }
    class Ints: Isummy
    {
        static Random _rng = new Random();
        public List<int> _list = new List<int>();

        public Ints(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _list.Add(_rng.Next(100));
            }
        }
        public object GetSum()
        {
            return _list.Sum();
        }
        public override string ToString()
        {
            return $"[{GetSum()}]";
        }
    }
    class ShowInts : Ints
    {
        public ShowInts(int count) : base(count) { }

        public override string ToString()
        {
            string sum = $"[{base.GetSum()}] : ";

            _list.ForEach(x => sum += $"{x}, ");

            return sum;
        }
    }
}
