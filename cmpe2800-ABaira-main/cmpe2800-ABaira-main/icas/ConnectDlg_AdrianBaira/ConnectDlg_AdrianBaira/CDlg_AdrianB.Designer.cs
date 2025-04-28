namespace ConnectDlg_AdrianBaira
{
    partial class CDlg_AdrianB
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
            this.UI_BTN_Cancel = new System.Windows.Forms.Button();
            this.UI_BTN_Connect = new System.Windows.Forms.Button();
            this.UI_TXT_IPAddress = new System.Windows.Forms.TextBox();
            this.UI_TXT_Port = new System.Windows.Forms.TextBox();
            this.UI_LBL_IPAdress = new System.Windows.Forms.Label();
            this.UI_LBL_Port = new System.Windows.Forms.Label();
            this.UI_LBL_Log = new System.Windows.Forms.Label();
            this.UI_TXT_Log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UI_BTN_Cancel
            // 
            this.UI_BTN_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_Cancel.Location = new System.Drawing.Point(14, 50);
            this.UI_BTN_Cancel.Name = "UI_BTN_Cancel";
            this.UI_BTN_Cancel.Size = new System.Drawing.Size(171, 23);
            this.UI_BTN_Cancel.TabIndex = 0;
            this.UI_BTN_Cancel.Text = "Cancel";
            this.UI_BTN_Cancel.UseVisualStyleBackColor = true;
            this.UI_BTN_Cancel.Click += new System.EventHandler(this.UI_BTN_Exit_Click);
            // 
            // UI_BTN_Connect
            // 
            this.UI_BTN_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_Connect.Location = new System.Drawing.Point(201, 50);
            this.UI_BTN_Connect.Name = "UI_BTN_Connect";
            this.UI_BTN_Connect.Size = new System.Drawing.Size(171, 23);
            this.UI_BTN_Connect.TabIndex = 1;
            this.UI_BTN_Connect.Text = "Connect";
            this.UI_BTN_Connect.UseVisualStyleBackColor = true;
            this.UI_BTN_Connect.Click += new System.EventHandler(this.UI_BTN_Connect_Click);
            // 
            // UI_TXT_IPAddress
            // 
            this.UI_TXT_IPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TXT_IPAddress.Location = new System.Drawing.Point(75, 12);
            this.UI_TXT_IPAddress.Name = "UI_TXT_IPAddress";
            this.UI_TXT_IPAddress.Size = new System.Drawing.Size(139, 20);
            this.UI_TXT_IPAddress.TabIndex = 7;
            // 
            // UI_TXT_Port
            // 
            this.UI_TXT_Port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TXT_Port.Location = new System.Drawing.Point(258, 12);
            this.UI_TXT_Port.Name = "UI_TXT_Port";
            this.UI_TXT_Port.Size = new System.Drawing.Size(114, 20);
            this.UI_TXT_Port.TabIndex = 8;
            // 
            // UI_LBL_IPAdress
            // 
            this.UI_LBL_IPAdress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_LBL_IPAdress.AutoSize = true;
            this.UI_LBL_IPAdress.Location = new System.Drawing.Point(11, 16);
            this.UI_LBL_IPAdress.Name = "UI_LBL_IPAdress";
            this.UI_LBL_IPAdress.Size = new System.Drawing.Size(63, 13);
            this.UI_LBL_IPAdress.TabIndex = 9;
            this.UI_LBL_IPAdress.Text = "IP Adresss: ";
            // 
            // UI_LBL_Port
            // 
            this.UI_LBL_Port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LBL_Port.AutoSize = true;
            this.UI_LBL_Port.Location = new System.Drawing.Point(220, 15);
            this.UI_LBL_Port.Name = "UI_LBL_Port";
            this.UI_LBL_Port.Size = new System.Drawing.Size(32, 13);
            this.UI_LBL_Port.TabIndex = 10;
            this.UI_LBL_Port.Text = "Port: ";
            // 
            // UI_LBL_Log
            // 
            this.UI_LBL_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_LBL_Log.AutoSize = true;
            this.UI_LBL_Log.Location = new System.Drawing.Point(7, 91);
            this.UI_LBL_Log.Name = "UI_LBL_Log";
            this.UI_LBL_Log.Size = new System.Drawing.Size(28, 13);
            this.UI_LBL_Log.TabIndex = 12;
            this.UI_LBL_Log.Text = "Log:";
            // 
            // UI_TXT_Log
            // 
            this.UI_TXT_Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TXT_Log.Location = new System.Drawing.Point(41, 88);
            this.UI_TXT_Log.Name = "UI_TXT_Log";
            this.UI_TXT_Log.ReadOnly = true;
            this.UI_TXT_Log.Size = new System.Drawing.Size(331, 20);
            this.UI_TXT_Log.TabIndex = 11;
            // 
            // CDlg_AdrianB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 120);
            this.Controls.Add(this.UI_LBL_Log);
            this.Controls.Add(this.UI_TXT_Log);
            this.Controls.Add(this.UI_LBL_Port);
            this.Controls.Add(this.UI_LBL_IPAdress);
            this.Controls.Add(this.UI_TXT_Port);
            this.Controls.Add(this.UI_TXT_IPAddress);
            this.Controls.Add(this.UI_BTN_Connect);
            this.Controls.Add(this.UI_BTN_Cancel);
            this.MinimumSize = new System.Drawing.Size(400, 159);
            this.Name = "CDlg_AdrianB";
            this.Text = "Connect Dialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CDlg_AdrianB_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_Cancel;
        private System.Windows.Forms.Button UI_BTN_Connect;
        private System.Windows.Forms.TextBox UI_TXT_IPAddress;
        private System.Windows.Forms.TextBox UI_TXT_Port;
        private System.Windows.Forms.Label UI_LBL_IPAdress;
        private System.Windows.Forms.Label UI_LBL_Port;
        private System.Windows.Forms.Label UI_LBL_Log;
        private System.Windows.Forms.TextBox UI_TXT_Log;
    }
}

