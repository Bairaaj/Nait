namespace Lecture_2_B_Demo
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
            this.UI_Change_Btn = new System.Windows.Forms.Button();
            this.UI_Display_lbl = new System.Windows.Forms.Label();
            this.UI_Name_Tbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UI_Change_Btn
            // 
            this.UI_Change_Btn.Location = new System.Drawing.Point(284, 188);
            this.UI_Change_Btn.Name = "UI_Change_Btn";
            this.UI_Change_Btn.Size = new System.Drawing.Size(183, 50);
            this.UI_Change_Btn.TabIndex = 1;
            this.UI_Change_Btn.Text = "Change Label Value";
            this.UI_Change_Btn.UseVisualStyleBackColor = true;
            this.UI_Change_Btn.Click += new System.EventHandler(this.UI_Change_Btn_Click);
            // 
            // UI_Display_lbl
            // 
            this.UI_Display_lbl.AutoSize = true;
            this.UI_Display_lbl.Location = new System.Drawing.Point(281, 172);
            this.UI_Display_lbl.Name = "UI_Display_lbl";
            this.UI_Display_lbl.Size = new System.Drawing.Size(88, 13);
            this.UI_Display_lbl.TabIndex = 2;
            this.UI_Display_lbl.Text = "Inital Label Value";
            this.UI_Display_lbl.Click += new System.EventHandler(this.UI_Display_lbl_Click);
            // 
            // UI_Name_Tbx
            // 
            this.UI_Name_Tbx.Location = new System.Drawing.Point(283, 122);
            this.UI_Name_Tbx.Name = "UI_Name_Tbx";
            this.UI_Name_Tbx.Size = new System.Drawing.Size(183, 20);
            this.UI_Name_Tbx.TabIndex = 3;
            this.UI_Name_Tbx.TextChanged += new System.EventHandler(this.UI_Name_Tbx_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UI_Name_Tbx);
            this.Controls.Add(this.UI_Display_lbl);
            this.Controls.Add(this.UI_Change_Btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button UI_Change_Btn;
        private System.Windows.Forms.Label UI_Display_lbl;
        private System.Windows.Forms.TextBox UI_Name_Tbx;
    }
}

