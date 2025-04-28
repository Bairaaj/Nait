using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
namespace CompQuads_ICAPracticeAdrianBaira
{
    public partial class Form1 : Form
    {
        List<CBall> cball = new List<CBall>();
        int stop = 0;
        Random Random = new Random();
        public Form1()
        {
            InitializeComponent();
            Timer timer = new Timer();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cball.Clear();
            for (int i = 0; i < 10; i++)
            {
                cball.Add(new CBall(Random.Next(30), RandColor.GetColor()));
            }

            cball.Sort();
            foreach (CBall cball in cball)
            {
                Console.WriteLine(cball.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CBall.OKATTT = CBall.EsortType.test;

            cball.Sort(CBall.CompareRad);
            foreach (CBall cball in cball)
            {
                Console.WriteLine(cball.ToString());
            }
        }
    }
}
