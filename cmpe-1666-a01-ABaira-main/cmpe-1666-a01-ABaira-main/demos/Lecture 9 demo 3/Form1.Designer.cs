namespace Lecture_9_demo_3
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
            this.UI_ShowDialog_Cbx = new System.Windows.Forms.CheckBox();
            this.UI_DialogText_Lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_ShowDialog_Cbx
            // 
            this.UI_ShowDialog_Cbx.AutoSize = true;
            this.UI_ShowDialog_Cbx.Location = new System.Drawing.Point(66, 31);
            this.UI_ShowDialog_Cbx.Name = "UI_ShowDialog_Cbx";
            this.UI_ShowDialog_Cbx.Size = new System.Drawing.Size(86, 17);
            this.UI_ShowDialog_Cbx.TabIndex = 0;
            this.UI_ShowDialog_Cbx.Text = "Show Dialog";
            this.UI_ShowDialog_Cbx.UseVisualStyleBackColor = true;
            this.UI_ShowDialog_Cbx.CheckedChanged += new System.EventHandler(this.UI_ShowDialog_Cbx_CheckedChanged);
            // 
            // UI_DialogText_Lbl
            // 
            this.UI_DialogText_Lbl.AutoSize = true;
            this.UI_DialogText_Lbl.Location = new System.Drawing.Point(63, 104);
            this.UI_DialogText_Lbl.Name = "UI_DialogText_Lbl";
            this.UI_DialogText_Lbl.Size = new System.Drawing.Size(51, 13);
            this.UI_DialogText_Lbl.TabIndex = 1;
            this.UI_DialogText_Lbl.Text = "Initial text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 200);
            this.Controls.Add(this.UI_DialogText_Lbl);
            this.Controls.Add(this.UI_ShowDialog_Cbx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox UI_ShowDialog_Cbx;
        private System.Windows.Forms.Label UI_DialogText_Lbl;
    }
}

