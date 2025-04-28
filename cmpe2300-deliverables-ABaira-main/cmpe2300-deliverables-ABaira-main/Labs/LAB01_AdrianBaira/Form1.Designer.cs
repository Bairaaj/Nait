namespace LAB01_AdrianBaira
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
            this.UI_BTN_START = new System.Windows.Forms.Button();
            this.UI_LBL_Mazes = new System.Windows.Forms.Label();
            this.UI_TXTBOX = new System.Windows.Forms.TextBox();
            this.UI_LBL_Color = new System.Windows.Forms.Label();
            this.UI_LISTBOX = new System.Windows.Forms.ListBox();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.UI_TXT_SleepNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_BTN_START
            // 
            this.UI_BTN_START.Location = new System.Drawing.Point(131, 7);
            this.UI_BTN_START.Name = "UI_BTN_START";
            this.UI_BTN_START.Size = new System.Drawing.Size(113, 53);
            this.UI_BTN_START.TabIndex = 0;
            this.UI_BTN_START.Text = "Start";
            this.UI_BTN_START.UseVisualStyleBackColor = true;
            this.UI_BTN_START.Click += new System.EventHandler(this.UI_BTN_START_Click);
            // 
            // UI_LBL_Mazes
            // 
            this.UI_LBL_Mazes.AllowDrop = true;
            this.UI_LBL_Mazes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UI_LBL_Mazes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UI_LBL_Mazes.Location = new System.Drawing.Point(12, 9);
            this.UI_LBL_Mazes.Name = "UI_LBL_Mazes";
            this.UI_LBL_Mazes.Size = new System.Drawing.Size(113, 51);
            this.UI_LBL_Mazes.TabIndex = 1;
            this.UI_LBL_Mazes.Text = "Drop Mazes Here!";
            this.UI_LBL_Mazes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UI_LBL_Mazes.DragDrop += new System.Windows.Forms.DragEventHandler(this.UI_LBL_Mazes_DragDrop);
            this.UI_LBL_Mazes.DragEnter += new System.Windows.Forms.DragEventHandler(this.UI_LBL_Mazes_DragEnter);
            // 
            // UI_TXTBOX
            // 
            this.UI_TXTBOX.Enabled = false;
            this.UI_TXTBOX.Location = new System.Drawing.Point(12, 209);
            this.UI_TXTBOX.Name = "UI_TXTBOX";
            this.UI_TXTBOX.ReadOnly = true;
            this.UI_TXTBOX.Size = new System.Drawing.Size(113, 20);
            this.UI_TXTBOX.TabIndex = 2;
            this.UI_TXTBOX.Text = "0";
            this.UI_TXTBOX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_LBL_Color
            // 
            this.UI_LBL_Color.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.UI_LBL_Color.Location = new System.Drawing.Point(250, 8);
            this.UI_LBL_Color.Name = "UI_LBL_Color";
            this.UI_LBL_Color.Size = new System.Drawing.Size(117, 51);
            this.UI_LBL_Color.TabIndex = 3;
            this.UI_LBL_Color.Text = "Solve Color";
            this.UI_LBL_Color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UI_LBL_Color.Click += new System.EventHandler(this.UI_LBL_Color_Click);
            // 
            // UI_LISTBOX
            // 
            this.UI_LISTBOX.FormattingEnabled = true;
            this.UI_LISTBOX.Location = new System.Drawing.Point(12, 79);
            this.UI_LISTBOX.Name = "UI_LISTBOX";
            this.UI_LISTBOX.Size = new System.Drawing.Size(355, 108);
            this.UI_LISTBOX.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Steps:";
            // 
            // UI_TXT_SleepNum
            // 
            this.UI_TXT_SleepNum.Location = new System.Drawing.Point(266, 209);
            this.UI_TXT_SleepNum.Name = "UI_TXT_SleepNum";
            this.UI_TXT_SleepNum.ReadOnly = true;
            this.UI_TXT_SleepNum.Size = new System.Drawing.Size(100, 20);
            this.UI_TXT_SleepNum.TabIndex = 6;
            this.UI_TXT_SleepNum.TabStop = false;
            this.UI_TXT_SleepNum.Text = "0";
            this.UI_TXT_SleepNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Speed:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 246);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UI_TXT_SleepNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UI_LISTBOX);
            this.Controls.Add(this.UI_LBL_Color);
            this.Controls.Add(this.UI_TXTBOX);
            this.Controls.Add(this.UI_LBL_Mazes);
            this.Controls.Add(this.UI_BTN_START);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_START;
        private System.Windows.Forms.Label UI_LBL_Mazes;
        private System.Windows.Forms.TextBox UI_TXTBOX;
        private System.Windows.Forms.Label UI_LBL_Color;
        private System.Windows.Forms.ListBox UI_LISTBOX;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UI_TXT_SleepNum;
        private System.Windows.Forms.Label label2;
    }
}

