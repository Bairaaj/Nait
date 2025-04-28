namespace ICA08_AdrianBaira
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UI_Button_Generate = new System.Windows.Forms.Button();
            this.UI_Button_FillColor = new System.Windows.Forms.Button();
            this.UI_Button_Fill = new System.Windows.Forms.Button();
            this.UI_TextBox_FillColor = new System.Windows.Forms.TextBox();
            this.UI_ColorDialog = new System.Windows.Forms.ColorDialog();
            this.UI_TrackBar = new System.Windows.Forms.TrackBar();
            this.UI_Label_Fillcolor = new System.Windows.Forms.Label();
            this.UI_Label_NumberOfBlocks = new System.Windows.Forms.Label();
            this.UI_Label_100 = new System.Windows.Forms.Label();
            this.UI_Label_3000 = new System.Windows.Forms.Label();
            this.UI_Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_Button_Generate
            // 
            this.UI_Button_Generate.Location = new System.Drawing.Point(96, 165);
            this.UI_Button_Generate.Name = "UI_Button_Generate";
            this.UI_Button_Generate.Size = new System.Drawing.Size(105, 44);
            this.UI_Button_Generate.TabIndex = 0;
            this.UI_Button_Generate.Text = "Generate";
            this.UI_Button_Generate.UseVisualStyleBackColor = true;
            this.UI_Button_Generate.Click += new System.EventHandler(this.UI_Button_Generate_Click);
            // 
            // UI_Button_FillColor
            // 
            this.UI_Button_FillColor.Location = new System.Drawing.Point(218, 165);
            this.UI_Button_FillColor.Name = "UI_Button_FillColor";
            this.UI_Button_FillColor.Size = new System.Drawing.Size(105, 44);
            this.UI_Button_FillColor.TabIndex = 1;
            this.UI_Button_FillColor.Text = "Fill Color";
            this.UI_Button_FillColor.UseVisualStyleBackColor = true;
            this.UI_Button_FillColor.Click += new System.EventHandler(this.UI_Button_FillColor_Click);
            // 
            // UI_Button_Fill
            // 
            this.UI_Button_Fill.Location = new System.Drawing.Point(345, 165);
            this.UI_Button_Fill.Name = "UI_Button_Fill";
            this.UI_Button_Fill.Size = new System.Drawing.Size(105, 44);
            this.UI_Button_Fill.TabIndex = 2;
            this.UI_Button_Fill.Text = "Fill";
            this.UI_Button_Fill.UseVisualStyleBackColor = true;
            this.UI_Button_Fill.Click += new System.EventHandler(this.UI_Button_Fill_Click);
            // 
            // UI_TextBox_FillColor
            // 
            this.UI_TextBox_FillColor.Location = new System.Drawing.Point(255, 128);
            this.UI_TextBox_FillColor.Name = "UI_TextBox_FillColor";
            this.UI_TextBox_FillColor.ReadOnly = true;
            this.UI_TextBox_FillColor.Size = new System.Drawing.Size(27, 20);
            this.UI_TextBox_FillColor.TabIndex = 3;
            // 
            // UI_TrackBar
            // 
            this.UI_TrackBar.Location = new System.Drawing.Point(96, 57);
            this.UI_TrackBar.Maximum = 3000;
            this.UI_TrackBar.Minimum = 100;
            this.UI_TrackBar.Name = "UI_TrackBar";
            this.UI_TrackBar.Size = new System.Drawing.Size(354, 45);
            this.UI_TrackBar.SmallChange = 10;
            this.UI_TrackBar.TabIndex = 4;
            this.UI_TrackBar.TickFrequency = 100;
            this.UI_TrackBar.Value = 100;
            this.UI_TrackBar.Scroll += new System.EventHandler(this.UI_TrackBar_Scroll);
            // 
            // UI_Label_Fillcolor
            // 
            this.UI_Label_Fillcolor.AutoSize = true;
            this.UI_Label_Fillcolor.Location = new System.Drawing.Point(203, 131);
            this.UI_Label_Fillcolor.Name = "UI_Label_Fillcolor";
            this.UI_Label_Fillcolor.Size = new System.Drawing.Size(46, 13);
            this.UI_Label_Fillcolor.TabIndex = 5;
            this.UI_Label_Fillcolor.Text = "Fill Color";
            // 
            // UI_Label_NumberOfBlocks
            // 
            this.UI_Label_NumberOfBlocks.AutoSize = true;
            this.UI_Label_NumberOfBlocks.Location = new System.Drawing.Point(230, 41);
            this.UI_Label_NumberOfBlocks.Name = "UI_Label_NumberOfBlocks";
            this.UI_Label_NumberOfBlocks.Size = new System.Drawing.Size(93, 13);
            this.UI_Label_NumberOfBlocks.TabIndex = 6;
            this.UI_Label_NumberOfBlocks.Text = "Number Of Blocks";
            // 
            // UI_Label_100
            // 
            this.UI_Label_100.AutoSize = true;
            this.UI_Label_100.Location = new System.Drawing.Point(84, 89);
            this.UI_Label_100.Name = "UI_Label_100";
            this.UI_Label_100.Size = new System.Drawing.Size(25, 13);
            this.UI_Label_100.TabIndex = 7;
            this.UI_Label_100.Text = "100";
            // 
            // UI_Label_3000
            // 
            this.UI_Label_3000.AutoSize = true;
            this.UI_Label_3000.Location = new System.Drawing.Point(436, 89);
            this.UI_Label_3000.Name = "UI_Label_3000";
            this.UI_Label_3000.Size = new System.Drawing.Size(31, 13);
            this.UI_Label_3000.TabIndex = 8;
            this.UI_Label_3000.Text = "3000";
            // 
            // UI_Timer
            // 
            this.UI_Timer.Enabled = true;
            this.UI_Timer.Tick += new System.EventHandler(this.UI_Timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 267);
            this.Controls.Add(this.UI_Label_3000);
            this.Controls.Add(this.UI_Label_100);
            this.Controls.Add(this.UI_Label_NumberOfBlocks);
            this.Controls.Add(this.UI_Label_Fillcolor);
            this.Controls.Add(this.UI_TrackBar);
            this.Controls.Add(this.UI_TextBox_FillColor);
            this.Controls.Add(this.UI_Button_Fill);
            this.Controls.Add(this.UI_Button_FillColor);
            this.Controls.Add(this.UI_Button_Generate);
            this.Name = "Form1";
            this.Text = "ICA 08";
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_Button_Generate;
        private System.Windows.Forms.Button UI_Button_FillColor;
        private System.Windows.Forms.Button UI_Button_Fill;
        private System.Windows.Forms.TextBox UI_TextBox_FillColor;
        private System.Windows.Forms.ColorDialog UI_ColorDialog;
        private System.Windows.Forms.TrackBar UI_TrackBar;
        private System.Windows.Forms.Label UI_Label_Fillcolor;
        private System.Windows.Forms.Label UI_Label_NumberOfBlocks;
        private System.Windows.Forms.Label UI_Label_100;
        private System.Windows.Forms.Label UI_Label_3000;
        private System.Windows.Forms.Timer UI_Timer;
    }
}

