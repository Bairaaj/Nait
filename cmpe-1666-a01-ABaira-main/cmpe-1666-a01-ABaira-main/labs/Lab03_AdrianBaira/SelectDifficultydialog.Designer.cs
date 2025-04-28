
namespace Lab03_AdrianBaira
{
    partial class SelectDifficultydialog
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
            this.UI_GroupBox_Difficulty = new System.Windows.Forms.GroupBox();
            this.UI_RADIO_Hard = new System.Windows.Forms.RadioButton();
            this.UI_RADIO_Medium = new System.Windows.Forms.RadioButton();
            this.UI_RADIO_Easy = new System.Windows.Forms.RadioButton();
            this.UI_BTN_OK = new System.Windows.Forms.Button();
            this.UI_BTN_Cancel = new System.Windows.Forms.Button();
            this.UI_GroupBox_Difficulty.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_GroupBox_Difficulty
            // 
            this.UI_GroupBox_Difficulty.Controls.Add(this.UI_RADIO_Hard);
            this.UI_GroupBox_Difficulty.Controls.Add(this.UI_RADIO_Medium);
            this.UI_GroupBox_Difficulty.Controls.Add(this.UI_RADIO_Easy);
            this.UI_GroupBox_Difficulty.Location = new System.Drawing.Point(12, 12);
            this.UI_GroupBox_Difficulty.Name = "UI_GroupBox_Difficulty";
            this.UI_GroupBox_Difficulty.Size = new System.Drawing.Size(210, 145);
            this.UI_GroupBox_Difficulty.TabIndex = 0;
            this.UI_GroupBox_Difficulty.TabStop = false;
            this.UI_GroupBox_Difficulty.Text = "Difficulty";
            // 
            // UI_RADIO_Hard
            // 
            this.UI_RADIO_Hard.AutoSize = true;
            this.UI_RADIO_Hard.Location = new System.Drawing.Point(25, 105);
            this.UI_RADIO_Hard.Name = "UI_RADIO_Hard";
            this.UI_RADIO_Hard.Size = new System.Drawing.Size(48, 17);
            this.UI_RADIO_Hard.TabIndex = 2;
            this.UI_RADIO_Hard.Text = "Hard";
            this.UI_RADIO_Hard.UseVisualStyleBackColor = true;
            this.UI_RADIO_Hard.CheckedChanged += new System.EventHandler(this.UI_RADIO_Easy_CheckedChanged);
            // 
            // UI_RADIO_Medium
            // 
            this.UI_RADIO_Medium.AutoSize = true;
            this.UI_RADIO_Medium.Location = new System.Drawing.Point(25, 70);
            this.UI_RADIO_Medium.Name = "UI_RADIO_Medium";
            this.UI_RADIO_Medium.Size = new System.Drawing.Size(62, 17);
            this.UI_RADIO_Medium.TabIndex = 1;
            this.UI_RADIO_Medium.Text = "Medium";
            this.UI_RADIO_Medium.UseVisualStyleBackColor = true;
            this.UI_RADIO_Medium.CheckedChanged += new System.EventHandler(this.UI_RADIO_Easy_CheckedChanged);
            // 
            // UI_RADIO_Easy
            // 
            this.UI_RADIO_Easy.AutoSize = true;
            this.UI_RADIO_Easy.Checked = true;
            this.UI_RADIO_Easy.Location = new System.Drawing.Point(25, 35);
            this.UI_RADIO_Easy.Name = "UI_RADIO_Easy";
            this.UI_RADIO_Easy.Size = new System.Drawing.Size(48, 17);
            this.UI_RADIO_Easy.TabIndex = 0;
            this.UI_RADIO_Easy.TabStop = true;
            this.UI_RADIO_Easy.Text = "Easy";
            this.UI_RADIO_Easy.UseVisualStyleBackColor = true;
            this.UI_RADIO_Easy.CheckedChanged += new System.EventHandler(this.UI_RADIO_Easy_CheckedChanged);
            // 
            // UI_BTN_OK
            // 
            this.UI_BTN_OK.Location = new System.Drawing.Point(12, 163);
            this.UI_BTN_OK.Name = "UI_BTN_OK";
            this.UI_BTN_OK.Size = new System.Drawing.Size(100, 25);
            this.UI_BTN_OK.TabIndex = 1;
            this.UI_BTN_OK.Text = "OK";
            this.UI_BTN_OK.UseVisualStyleBackColor = true;
            this.UI_BTN_OK.Click += new System.EventHandler(this.UI_BTN_OK_Click);
            // 
            // UI_BTN_Cancel
            // 
            this.UI_BTN_Cancel.Location = new System.Drawing.Point(122, 163);
            this.UI_BTN_Cancel.Name = "UI_BTN_Cancel";
            this.UI_BTN_Cancel.Size = new System.Drawing.Size(100, 25);
            this.UI_BTN_Cancel.TabIndex = 2;
            this.UI_BTN_Cancel.Text = "Cancel";
            this.UI_BTN_Cancel.UseVisualStyleBackColor = true;
            this.UI_BTN_Cancel.Click += new System.EventHandler(this.UI_BTN_Cancel_Click);
            // 
            // SelectDifficultydialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 201);
            this.Controls.Add(this.UI_BTN_Cancel);
            this.Controls.Add(this.UI_BTN_OK);
            this.Controls.Add(this.UI_GroupBox_Difficulty);
            this.MaximumSize = new System.Drawing.Size(275, 240);
            this.MinimumSize = new System.Drawing.Size(275, 240);
            this.Name = "SelectDifficultydialog";
            this.Text = "Select Difficulty ";
            this.UI_GroupBox_Difficulty.ResumeLayout(false);
            this.UI_GroupBox_Difficulty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UI_GroupBox_Difficulty;
        private System.Windows.Forms.RadioButton UI_RADIO_Easy;
        private System.Windows.Forms.RadioButton UI_RADIO_Hard;
        private System.Windows.Forms.RadioButton UI_RADIO_Medium;
        private System.Windows.Forms.Button UI_BTN_OK;
        private System.Windows.Forms.Button UI_BTN_Cancel;
    }
}