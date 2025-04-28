namespace ConnectDlg_ICA05_AdrianBaira
{
    partial class TestCases
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
            this.UI_BTN_BA = new System.Windows.Forms.Button();
            this.UI_BTN_GABP = new System.Windows.Forms.Button();
            this.UI_BTN_GAGP = new System.Windows.Forms.Button();
            this.UI_LBL_Result = new System.Windows.Forms.Label();
            this.UI_TXT_Results = new System.Windows.Forms.TextBox();
            this.UI_TXT_Socketinfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_BTN_BA
            // 
            this.UI_BTN_BA.Location = new System.Drawing.Point(12, 41);
            this.UI_BTN_BA.Name = "UI_BTN_BA";
            this.UI_BTN_BA.Size = new System.Drawing.Size(428, 23);
            this.UI_BTN_BA.TabIndex = 7;
            this.UI_BTN_BA.Text = "Bad Address";
            this.UI_BTN_BA.UseVisualStyleBackColor = true;
            this.UI_BTN_BA.Click += new System.EventHandler(this.UI_BTN_BA_Click);
            // 
            // UI_BTN_GABP
            // 
            this.UI_BTN_GABP.Location = new System.Drawing.Point(12, 12);
            this.UI_BTN_GABP.Name = "UI_BTN_GABP";
            this.UI_BTN_GABP.Size = new System.Drawing.Size(428, 23);
            this.UI_BTN_GABP.TabIndex = 6;
            this.UI_BTN_GABP.Text = "Good Address and Bad Port";
            this.UI_BTN_GABP.UseVisualStyleBackColor = true;
            this.UI_BTN_GABP.Click += new System.EventHandler(this.UI_BTN_GABP_Click);
            // 
            // UI_BTN_GAGP
            // 
            this.UI_BTN_GAGP.Location = new System.Drawing.Point(12, 70);
            this.UI_BTN_GAGP.Name = "UI_BTN_GAGP";
            this.UI_BTN_GAGP.Size = new System.Drawing.Size(428, 23);
            this.UI_BTN_GAGP.TabIndex = 5;
            this.UI_BTN_GAGP.Text = "Good Address And Port";
            this.UI_BTN_GAGP.UseVisualStyleBackColor = true;
            this.UI_BTN_GAGP.Click += new System.EventHandler(this.UI_BTN_GAGP_Click);
            // 
            // UI_LBL_Result
            // 
            this.UI_LBL_Result.AutoSize = true;
            this.UI_LBL_Result.Location = new System.Drawing.Point(14, 102);
            this.UI_LBL_Result.Name = "UI_LBL_Result";
            this.UI_LBL_Result.Size = new System.Drawing.Size(42, 13);
            this.UI_LBL_Result.TabIndex = 8;
            this.UI_LBL_Result.Text = "Results";
            // 
            // UI_TXT_Results
            // 
            this.UI_TXT_Results.Location = new System.Drawing.Point(62, 99);
            this.UI_TXT_Results.Name = "UI_TXT_Results";
            this.UI_TXT_Results.ReadOnly = true;
            this.UI_TXT_Results.Size = new System.Drawing.Size(378, 20);
            this.UI_TXT_Results.TabIndex = 9;
            // 
            // UI_TXT_Socketinfo
            // 
            this.UI_TXT_Socketinfo.Location = new System.Drawing.Point(81, 125);
            this.UI_TXT_Socketinfo.Name = "UI_TXT_Socketinfo";
            this.UI_TXT_Socketinfo.ReadOnly = true;
            this.UI_TXT_Socketinfo.Size = new System.Drawing.Size(359, 20);
            this.UI_TXT_Socketinfo.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Socket info";
            // 
            // TestCases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 156);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UI_TXT_Socketinfo);
            this.Controls.Add(this.UI_TXT_Results);
            this.Controls.Add(this.UI_LBL_Result);
            this.Controls.Add(this.UI_BTN_BA);
            this.Controls.Add(this.UI_BTN_GABP);
            this.Controls.Add(this.UI_BTN_GAGP);
            this.Name = "TestCases";
            this.Text = "TestCases";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_BA;
        private System.Windows.Forms.Button UI_BTN_GABP;
        private System.Windows.Forms.Button UI_BTN_GAGP;
        private System.Windows.Forms.Label UI_LBL_Result;
        private System.Windows.Forms.TextBox UI_TXT_Results;
        private System.Windows.Forms.TextBox UI_TXT_Socketinfo;
        private System.Windows.Forms.Label label1;
    }
}

