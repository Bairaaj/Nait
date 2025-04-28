namespace Lecture_10_Demo_3
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
            this.UI_Listbox = new System.Windows.Forms.ListBox();
            this.UI_BTN_CountClicks = new System.Windows.Forms.Button();
            this.UI_BTN_PerformComputation = new System.Windows.Forms.Button();
            this.UI_LBL_Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_Listbox
            // 
            this.UI_Listbox.FormattingEnabled = true;
            this.UI_Listbox.Location = new System.Drawing.Point(27, 61);
            this.UI_Listbox.Name = "UI_Listbox";
            this.UI_Listbox.Size = new System.Drawing.Size(193, 212);
            this.UI_Listbox.TabIndex = 0;
            this.UI_Listbox.SelectedIndexChanged += new System.EventHandler(this.UI_Lisbox_SelectedIndexChanged);
            // 
            // UI_BTN_CountClicks
            // 
            this.UI_BTN_CountClicks.Location = new System.Drawing.Point(291, 62);
            this.UI_BTN_CountClicks.Name = "UI_BTN_CountClicks";
            this.UI_BTN_CountClicks.Size = new System.Drawing.Size(350, 85);
            this.UI_BTN_CountClicks.TabIndex = 1;
            this.UI_BTN_CountClicks.Text = "Count Clicks";
            this.UI_BTN_CountClicks.UseVisualStyleBackColor = true;
            this.UI_BTN_CountClicks.Click += new System.EventHandler(this.UI_BTN_CountClicks_Click);
            // 
            // UI_BTN_PerformComputation
            // 
            this.UI_BTN_PerformComputation.Location = new System.Drawing.Point(291, 196);
            this.UI_BTN_PerformComputation.Name = "UI_BTN_PerformComputation";
            this.UI_BTN_PerformComputation.Size = new System.Drawing.Size(350, 77);
            this.UI_BTN_PerformComputation.TabIndex = 2;
            this.UI_BTN_PerformComputation.Text = "Perform Computation";
            this.UI_BTN_PerformComputation.UseVisualStyleBackColor = true;
            this.UI_BTN_PerformComputation.Click += new System.EventHandler(this.UI_BTN_PerformComputation_Click);
            // 
            // UI_LBL_Text
            // 
            this.UI_LBL_Text.AutoSize = true;
            this.UI_LBL_Text.Location = new System.Drawing.Point(368, 166);
            this.UI_LBL_Text.Name = "UI_LBL_Text";
            this.UI_LBL_Text.Size = new System.Drawing.Size(179, 13);
            this.UI_LBL_Text.TabIndex = 3;
            this.UI_LBL_Text.Text = "The button has been clicked 0 times";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UI_LBL_Text);
            this.Controls.Add(this.UI_BTN_PerformComputation);
            this.Controls.Add(this.UI_BTN_CountClicks);
            this.Controls.Add(this.UI_Listbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UI_Listbox;
        private System.Windows.Forms.Button UI_BTN_CountClicks;
        private System.Windows.Forms.Button UI_BTN_PerformComputation;
        private System.Windows.Forms.Label UI_LBL_Text;
    }
}

