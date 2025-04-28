namespace Server
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
            this.UI_ListBox = new System.Windows.Forms.ListBox();
            this.UI_LBL_Number = new System.Windows.Forms.Label();
            this.UI_LBL_Log = new System.Windows.Forms.Label();
            this.UI_CHK_Disconnect = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // UI_ListBox
            // 
            this.UI_ListBox.FormattingEnabled = true;
            this.UI_ListBox.Location = new System.Drawing.Point(12, 124);
            this.UI_ListBox.Name = "UI_ListBox";
            this.UI_ListBox.ScrollAlwaysVisible = true;
            this.UI_ListBox.Size = new System.Drawing.Size(343, 121);
            this.UI_ListBox.TabIndex = 0;
            // 
            // UI_LBL_Number
            // 
            this.UI_LBL_Number.AutoSize = true;
            this.UI_LBL_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LBL_Number.Location = new System.Drawing.Point(128, 51);
            this.UI_LBL_Number.Name = "UI_LBL_Number";
            this.UI_LBL_Number.Size = new System.Drawing.Size(39, 42);
            this.UI_LBL_Number.TabIndex = 1;
            this.UI_LBL_Number.Text = "0";
            // 
            // UI_LBL_Log
            // 
            this.UI_LBL_Log.AutoSize = true;
            this.UI_LBL_Log.Location = new System.Drawing.Point(12, 108);
            this.UI_LBL_Log.Name = "UI_LBL_Log";
            this.UI_LBL_Log.Size = new System.Drawing.Size(25, 13);
            this.UI_LBL_Log.TabIndex = 2;
            this.UI_LBL_Log.Text = "Log";
            // 
            // UI_CHK_Disconnect
            // 
            this.UI_CHK_Disconnect.AutoSize = true;
            this.UI_CHK_Disconnect.Location = new System.Drawing.Point(238, 51);
            this.UI_CHK_Disconnect.Name = "UI_CHK_Disconnect";
            this.UI_CHK_Disconnect.Size = new System.Drawing.Size(117, 17);
            this.UI_CHK_Disconnect.TabIndex = 3;
            this.UI_CHK_Disconnect.Text = "Disconnect on Win";
            this.UI_CHK_Disconnect.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 266);
            this.Controls.Add(this.UI_CHK_Disconnect);
            this.Controls.Add(this.UI_LBL_Log);
            this.Controls.Add(this.UI_LBL_Number);
            this.Controls.Add(this.UI_ListBox);
            this.Name = "Form1";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UI_ListBox;
        private System.Windows.Forms.Label UI_LBL_Number;
        private System.Windows.Forms.Label UI_LBL_Log;
        private System.Windows.Forms.CheckBox UI_CHK_Disconnect;
    }
}

