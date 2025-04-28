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
using System.Threading;

namespace Lab03_AdrianBaira
{
    public enum Difficulty { Easy = 3, Medium = 4, Hard = 5 }

    public partial class MainForm : Form
    {
        public SelectDifficultydialog selectDifficultydialog = new SelectDifficultydialog();
        static public int width = 800;
        static public int height = 600;
        public int ballsize = 50;
        CDrawer canvas = new CDrawer(width, height);
       
        //show dialog
        Score scoredlg = null;
        AnimationSpeed animationspeeddlg = null;
        public int animationspeed;
        public enum BallState{ Dead = 0, Alive = 1}
        public BallState state = BallState.Alive;
        public Difficulty difficulty = Difficulty.Easy;
        public Color[,] color = new Color[16, 12];
        public int[,] alivedead = new int[16, 12];

        public MainForm()
        {
            InitializeComponent();
        }
    
        private void UI_BTN_Play_Click(object sender, EventArgs e)
        {
           
            if (selectDifficultydialog.ShowDialog() == DialogResult.OK)
            {
                difficulty = (Difficulty)selectDifficultydialog.difficulty;
                UI_BTN_Play.Enabled = false;
                label1.Text = $"{difficulty}";
                Randomize();
                Display();

            }
            
            
        }
        private void Randomize()
        {
            int numofcolors = (int)selectDifficultydialog.difficulty;
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Purple };
            Random random = new Random();

            for(int x = 0; x < color.GetLength(0); x++) 
            {
                for (int y = 0; y < color.GetLength(1); y++)
                {
                    color[x, y] = colors[random.Next(0, (int)difficulty)];
                }
            }
            for (int x = 0; x < alivedead.GetLength(0); x++)
            {
                for (int y = 0; y < alivedead.GetLength(1); y++)
                {
                    alivedead[x, y] = (int)BallState.Alive;
                }
            }

        }
        private void Display()
        {
            canvas.Clear();
            for(int x = 0; x < alivedead.GetLength(0); x++)
            {
                for (int y = 0; y < alivedead.GetLength(1); y++)
                {                   
                    canvas.AddEllipse(x * 50, y * 50, ballsize, ballsize, color[x, y]);
                }
            }
        }
        private void floodfill(int x, int y, Color oldColor, Color newColor)
        {
            if (color[x, y] != oldColor)
            {
                return;
            }
            color[x, y] = newColor;
            //This can make it slow or fast
            floodfill(x + 1, y, oldColor, newColor);
            floodfill(x - 1, y, oldColor, newColor);
            floodfill(x, y + 1, oldColor, newColor);
            floodfill(x, y - 1, oldColor, newColor);
        }
        private void UI_CHKBOX_ShowScore_CheckedChanged(object sender, EventArgs e)
        {
           
            if (UI_CHKBOX_ShowScore.Checked)
            {
                if (scoredlg == null)
                {
                    scoredlg = new Score();
                    scoredlg._dFormClosing = CallbackFormClosingScore;
                }
                scoredlg.Show();
            }
            else
            {
                scoredlg.Hide();
            }
        }
        private void UI_CHKBOX_ShowAnimationSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_CHKBOX_ShowAnimationSpeed.Checked)
            {
                if (animationspeeddlg == null)
                {
                    animationspeeddlg = new AnimationSpeed();
                    animationspeeddlg._dFormClosing = CallbackFormClosingAnimation;
                    animationspeeddlg._dSpeed = getAniSpeed;
                }
                animationspeeddlg.Show();
            }
            else
            {
                animationspeeddlg.Hide();
            }
        }
        private void getAniSpeed(int speed)
        {
            animationspeed = speed;
            label1.Text = $"{speed}";
        }
        private void CallbackFormClosingScore()
        {
            UI_CHKBOX_ShowScore.Checked = false;
        }
        private void CallbackFormClosingAnimation()
        {
            UI_CHKBOX_ShowAnimationSpeed.Checked = false;
        }

    }
}
