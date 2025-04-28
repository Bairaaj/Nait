namespace ICA_09AdrianBaira
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
            this.UI_Timer = new System.Windows.Forms.Timer(this.components);
            this.UI_BTN_Simulate = new System.Windows.Forms.Button();
            this.UI_LBL_CartsLeft = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_Timer
            // 
            this.UI_Timer.Enabled = true;
            this.UI_Timer.Interval = 20;
            this.UI_Timer.Tick += new System.EventHandler(this.UI_Timer_Tick);
            // 
            // UI_BTN_Simulate
            // 
            this.UI_BTN_Simulate.Location = new System.Drawing.Point(8, 15);
            this.UI_BTN_Simulate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UI_BTN_Simulate.Name = "UI_BTN_Simulate";
            this.UI_BTN_Simulate.Size = new System.Drawing.Size(113, 46);
            this.UI_BTN_Simulate.TabIndex = 0;
            this.UI_BTN_Simulate.Text = "Simulate[1]";
            this.UI_BTN_Simulate.UseVisualStyleBackColor = true;
            this.UI_BTN_Simulate.Click += new System.EventHandler(this.UI_BTN_Simulate_Click);
            // 
            // UI_LBL_CartsLeft
            // 
            this.UI_LBL_CartsLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UI_LBL_CartsLeft.Location = new System.Drawing.Point(144, 15);
            this.UI_LBL_CartsLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UI_LBL_CartsLeft.Name = "UI_LBL_CartsLeft";
            this.UI_LBL_CartsLeft.Size = new System.Drawing.Size(259, 46);
            this.UI_LBL_CartsLeft.TabIndex = 1;
            this.UI_LBL_CartsLeft.Text = "0 left";
            this.UI_LBL_CartsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 77);
            this.Controls.Add(this.UI_LBL_CartsLeft);
            this.Controls.Add(this.UI_BTN_Simulate);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Items Processed: 0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UI_Timer;
        private System.Windows.Forms.Button UI_BTN_Simulate;
        private System.Windows.Forms.Label UI_LBL_CartsLeft;
    }
}

