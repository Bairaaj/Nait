using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web;

namespace text_files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename= openFileDialog1.FileName;
                // string[] lines = File.ReadAllLines(filename);
                string line;
                
                StreamReader reader = new StreamReader(filename);
                listBox1.Items.Clear();
                while ((line = reader.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                    System.Threading.Thread.Sleep(1000);
                    listBox1.Update();
                }
                //listBox1.Items.Clear();
               /// foreach (string line in lines) 
                //{
                    //listBox1.Items.Add(line);
                    //System.Threading.Thread.Sleep(100);
                //}
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
