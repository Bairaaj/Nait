
namespace Lab03_AdrianBaira
{
    partial class HighScore
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
            this.UI_LBL_Playername = new System.Windows.Forms.Label();
            this.UI_TXTBox_Name = new System.Windows.Forms.TextBox();
            this.UI_BTN_OK = new System.Windows.Forms.Button();
            this.UI_BTN_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UI_LBL_Playername
            // 
            this.UI_LBL_Playername.AutoSize = true;
            this.UI_LBL_Playername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LBL_Playername.Location = new System.Drawing.Point(12, 34);
            this.UI_LBL_Playername.Name = "UI_LBL_Playername";
            this.UI_LBL_Playername.Size = new System.Drawing.Size(102, 20);
            this.UI_LBL_Playername.TabIndex = 0;
            this.UI_LBL_Playername.Text = "Player Name:";
            // 
            // UI_TXTBox_Name
            // 
            this.UI_TXTBox_Name.Location = new System.Drawing.Point(120, 34);
            this.UI_TXTBox_Name.Name = "UI_TXTBox_Name";
            this.UI_TXTBox_Name.Size = new System.Drawing.Size(222, 20);
            this.UI_TXTBox_Name.TabIndex = 1;
            // 
            // UI_BTN_OK
            // 
            this.UI_BTN_OK.Location = new System.Drawing.Point(16, 76);
            this.UI_BTN_OK.Name = "UI_BTN_OK";
            this.UI_BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.UI_BTN_OK.TabIndex = 2;
            this.UI_BTN_OK.Text = "OK";
            this.UI_BTN_OK.UseVisualStyleBackColor = true;
            this.UI_BTN_OK.Click += new System.EventHandler(this.UI_BTN_OK_Click);
            // 
            // UI_BTN_Cancel
            // 
            this.UI_BTN_Cancel.Location = new System.Drawing.Point(267, 76);
            this.UI_BTN_Cancel.Name = "UI_BTN_Cancel";
            this.UI_BTN_Cancel.Size = new System.Drawing.Size(75, 23);
            this.UI_BTN_Cancel.TabIndex = 3;
            this.UI_BTN_Cancel.Text = "Cancel";
            this.UI_BTN_Cancel.UseVisualStyleBackColor = true;
            this.UI_BTN_Cancel.Click += new System.EventHandler(this.UI_BTN_Cancel_Click);
            // 
            // HighScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 117);
            this.Controls.Add(this.UI_BTN_Cancel);
            this.Controls.Add(this.UI_BTN_OK);
            this.Controls.Add(this.UI_TXTBox_Name);
            this.Controls.Add(this.UI_LBL_Playername);
            this.Name = "HighScore";
            this.Text = "High Score";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UI_LBL_Playername;
        private System.Windows.Forms.TextBox UI_TXTBox_Name;
        private System.Windows.Forms.Button UI_BTN_OK;
        private System.Windows.Forms.Button UI_BTN_Cancel;
    }
}