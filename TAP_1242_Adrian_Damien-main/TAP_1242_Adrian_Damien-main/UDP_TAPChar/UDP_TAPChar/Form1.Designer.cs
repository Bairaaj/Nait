namespace UDP_TAPChar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UI_TXT_CharText = new System.Windows.Forms.TextBox();
            this.UI_TXT_TargetAddress = new System.Windows.Forms.TextBox();
            this.UI_TXT_Nickname = new System.Windows.Forms.TextBox();
            this.UI_Datagridview = new System.Windows.Forms.DataGridView();
            this.UI_ListBox_KnownHosts = new System.Windows.Forms.ListBox();
            this.UI_BTN_Send = new System.Windows.Forms.Button();
            this.UI_ListBox = new System.Windows.Forms.ListBox();
            this.UI_TXT_Log = new System.Windows.Forms.Label();
            this.UI_BTN_Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chat Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target Address : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nickname : ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Known Hosts";
            // 
            // UI_TXT_CharText
            // 
            this.UI_TXT_CharText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TXT_CharText.Location = new System.Drawing.Point(65, 5);
            this.UI_TXT_CharText.Margin = new System.Windows.Forms.Padding(2);
            this.UI_TXT_CharText.Name = "UI_TXT_CharText";
            this.UI_TXT_CharText.Size = new System.Drawing.Size(667, 20);
            this.UI_TXT_CharText.TabIndex = 4;
            // 
            // UI_TXT_TargetAddress
            // 
            this.UI_TXT_TargetAddress.Location = new System.Drawing.Point(10, 54);
            this.UI_TXT_TargetAddress.Margin = new System.Windows.Forms.Padding(2);
            this.UI_TXT_TargetAddress.Name = "UI_TXT_TargetAddress";
            this.UI_TXT_TargetAddress.Size = new System.Drawing.Size(119, 20);
            this.UI_TXT_TargetAddress.TabIndex = 5;
            // 
            // UI_TXT_Nickname
            // 
            this.UI_TXT_Nickname.Location = new System.Drawing.Point(10, 99);
            this.UI_TXT_Nickname.Margin = new System.Windows.Forms.Padding(2);
            this.UI_TXT_Nickname.Name = "UI_TXT_Nickname";
            this.UI_TXT_Nickname.Size = new System.Drawing.Size(119, 20);
            this.UI_TXT_Nickname.TabIndex = 6;
            // 
            // UI_Datagridview
            // 
            this.UI_Datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UI_Datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_Datagridview.Location = new System.Drawing.Point(143, 40);
            this.UI_Datagridview.Margin = new System.Windows.Forms.Padding(2);
            this.UI_Datagridview.Name = "UI_Datagridview";
            this.UI_Datagridview.RowHeadersWidth = 62;
            this.UI_Datagridview.RowTemplate.Height = 28;
            this.UI_Datagridview.Size = new System.Drawing.Size(586, 381);
            this.UI_Datagridview.TabIndex = 8;
            // 
            // UI_ListBox_KnownHosts
            // 
            this.UI_ListBox_KnownHosts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_ListBox_KnownHosts.FormattingEnabled = true;
            this.UI_ListBox_KnownHosts.Location = new System.Drawing.Point(10, 164);
            this.UI_ListBox_KnownHosts.Margin = new System.Windows.Forms.Padding(2);
            this.UI_ListBox_KnownHosts.Name = "UI_ListBox_KnownHosts";
            this.UI_ListBox_KnownHosts.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.UI_ListBox_KnownHosts.Size = new System.Drawing.Size(129, 251);
            this.UI_ListBox_KnownHosts.TabIndex = 9;
            // 
            // UI_BTN_Send
            // 
            this.UI_BTN_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_Send.Location = new System.Drawing.Point(736, 5);
            this.UI_BTN_Send.Margin = new System.Windows.Forms.Padding(2);
            this.UI_BTN_Send.Name = "UI_BTN_Send";
            this.UI_BTN_Send.Size = new System.Drawing.Size(180, 23);
            this.UI_BTN_Send.TabIndex = 10;
            this.UI_BTN_Send.Text = "Send";
            this.UI_BTN_Send.UseVisualStyleBackColor = true;
            this.UI_BTN_Send.Click += new System.EventHandler(this.UI_BTN_Send_Click);
            // 
            // UI_ListBox
            // 
            this.UI_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_ListBox.FormattingEnabled = true;
            this.UI_ListBox.Location = new System.Drawing.Point(736, 66);
            this.UI_ListBox.Margin = new System.Windows.Forms.Padding(2);
            this.UI_ListBox.Name = "UI_ListBox";
            this.UI_ListBox.Size = new System.Drawing.Size(180, 355);
            this.UI_ListBox.TabIndex = 11;
            // 
            // UI_TXT_Log
            // 
            this.UI_TXT_Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TXT_Log.AutoSize = true;
            this.UI_TXT_Log.Location = new System.Drawing.Point(733, 44);
            this.UI_TXT_Log.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UI_TXT_Log.Name = "UI_TXT_Log";
            this.UI_TXT_Log.Size = new System.Drawing.Size(28, 13);
            this.UI_TXT_Log.TabIndex = 12;
            this.UI_TXT_Log.Text = "Log:";
            // 
            // UI_BTN_Clear
            // 
            this.UI_BTN_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_Clear.Location = new System.Drawing.Point(790, 39);
            this.UI_BTN_Clear.Margin = new System.Windows.Forms.Padding(2);
            this.UI_BTN_Clear.Name = "UI_BTN_Clear";
            this.UI_BTN_Clear.Size = new System.Drawing.Size(126, 23);
            this.UI_BTN_Clear.TabIndex = 13;
            this.UI_BTN_Clear.Text = "Clear Log";
            this.UI_BTN_Clear.UseVisualStyleBackColor = true;
            this.UI_BTN_Clear.Click += new System.EventHandler(this.UI_BTN_Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 436);
            this.Controls.Add(this.UI_BTN_Clear);
            this.Controls.Add(this.UI_TXT_Log);
            this.Controls.Add(this.UI_ListBox);
            this.Controls.Add(this.UI_BTN_Send);
            this.Controls.Add(this.UI_ListBox_KnownHosts);
            this.Controls.Add(this.UI_Datagridview);
            this.Controls.Add(this.UI_TXT_Nickname);
            this.Controls.Add(this.UI_TXT_TargetAddress);
            this.Controls.Add(this.UI_TXT_CharText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(946, 475);
            this.Name = "Form1";
            this.Text = "UDP_TAP";
            ((System.ComponentModel.ISupportInitialize)(this.UI_Datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UI_TXT_CharText;
        private System.Windows.Forms.TextBox UI_TXT_TargetAddress;
        private System.Windows.Forms.TextBox UI_TXT_Nickname;
        private System.Windows.Forms.DataGridView UI_Datagridview;
        private System.Windows.Forms.ListBox UI_ListBox_KnownHosts;
        private System.Windows.Forms.Button UI_BTN_Send;
        private System.Windows.Forms.ListBox UI_ListBox;
        private System.Windows.Forms.Label UI_TXT_Log;
        private System.Windows.Forms.Button UI_BTN_Clear;
    }
}

