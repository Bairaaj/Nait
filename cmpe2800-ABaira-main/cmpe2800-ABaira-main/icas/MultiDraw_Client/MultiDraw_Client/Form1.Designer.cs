namespace MultiDraw_Client
{
    partial class MDClient
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
            this.UI_BTN_ConnectDisconnect = new System.Windows.Forms.Button();
            this.UI_BTN_Color = new System.Windows.Forms.Button();
            this.UI_LBL_Fragments = new System.Windows.Forms.Label();
            this.UI_LBL_DestackAVG = new System.Windows.Forms.Label();
            this.UI_LBL_BytesRX = new System.Windows.Forms.Label();
            this.UI_LBL_Frames = new System.Windows.Forms.Label();
            this.UI_LBL_Thickness = new System.Windows.Forms.Label();
            this.UI_ColorDlg = new System.Windows.Forms.ColorDialog();
            this.UI_LBL_Color = new System.Windows.Forms.Label();
            this.UI_GroupBox = new System.Windows.Forms.GroupBox();
            this.UI_LBL_Aplha = new System.Windows.Forms.Label();
            this.UI_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_BTN_ConnectDisconnect
            // 
            this.UI_BTN_ConnectDisconnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_BTN_ConnectDisconnect.Location = new System.Drawing.Point(30, 16);
            this.UI_BTN_ConnectDisconnect.Name = "UI_BTN_ConnectDisconnect";
            this.UI_BTN_ConnectDisconnect.Size = new System.Drawing.Size(107, 23);
            this.UI_BTN_ConnectDisconnect.TabIndex = 0;
            this.UI_BTN_ConnectDisconnect.Text = "Connect";
            this.UI_BTN_ConnectDisconnect.UseVisualStyleBackColor = true;
            this.UI_BTN_ConnectDisconnect.Click += new System.EventHandler(this.UI_BTN_ConnectDisconnect_Click);
            // 
            // UI_BTN_Color
            // 
            this.UI_BTN_Color.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_BTN_Color.Location = new System.Drawing.Point(166, 16);
            this.UI_BTN_Color.Name = "UI_BTN_Color";
            this.UI_BTN_Color.Size = new System.Drawing.Size(107, 23);
            this.UI_BTN_Color.TabIndex = 2;
            this.UI_BTN_Color.Text = "Colour";
            this.UI_BTN_Color.UseVisualStyleBackColor = true;
            this.UI_BTN_Color.Click += new System.EventHandler(this.UI_BTN_Color_Click);
            // 
            // UI_LBL_Fragments
            // 
            this.UI_LBL_Fragments.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_LBL_Fragments.Location = new System.Drawing.Point(611, 16);
            this.UI_LBL_Fragments.Name = "UI_LBL_Fragments";
            this.UI_LBL_Fragments.Size = new System.Drawing.Size(100, 23);
            this.UI_LBL_Fragments.TabIndex = 3;
            this.UI_LBL_Fragments.Text = "Fragments: 0";
            this.UI_LBL_Fragments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_LBL_DestackAVG
            // 
            this.UI_LBL_DestackAVG.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_LBL_DestackAVG.Location = new System.Drawing.Point(741, 16);
            this.UI_LBL_DestackAVG.Name = "UI_LBL_DestackAVG";
            this.UI_LBL_DestackAVG.Size = new System.Drawing.Size(100, 23);
            this.UI_LBL_DestackAVG.TabIndex = 4;
            this.UI_LBL_DestackAVG.Text = "Destack Avg: 0";
            this.UI_LBL_DestackAVG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_LBL_BytesRX
            // 
            this.UI_LBL_BytesRX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_LBL_BytesRX.Location = new System.Drawing.Point(869, 16);
            this.UI_LBL_BytesRX.Name = "UI_LBL_BytesRX";
            this.UI_LBL_BytesRX.Size = new System.Drawing.Size(100, 23);
            this.UI_LBL_BytesRX.TabIndex = 5;
            this.UI_LBL_BytesRX.Text = "Bytes RX\'d: 0";
            this.UI_LBL_BytesRX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_LBL_Frames
            // 
            this.UI_LBL_Frames.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_LBL_Frames.Location = new System.Drawing.Point(505, 16);
            this.UI_LBL_Frames.Name = "UI_LBL_Frames";
            this.UI_LBL_Frames.Size = new System.Drawing.Size(100, 23);
            this.UI_LBL_Frames.TabIndex = 6;
            this.UI_LBL_Frames.Text = "Frames RX\'d: 0";
            this.UI_LBL_Frames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_LBL_Thickness
            // 
            this.UI_LBL_Thickness.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_LBL_Thickness.Location = new System.Drawing.Point(408, 16);
            this.UI_LBL_Thickness.Name = "UI_LBL_Thickness";
            this.UI_LBL_Thickness.Size = new System.Drawing.Size(100, 23);
            this.UI_LBL_Thickness.TabIndex = 7;
            this.UI_LBL_Thickness.Text = "Thickness: 1";
            this.UI_LBL_Thickness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_LBL_Color
            // 
            this.UI_LBL_Color.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_LBL_Color.BackColor = System.Drawing.Color.Blue;
            this.UI_LBL_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UI_LBL_Color.Location = new System.Drawing.Point(289, 16);
            this.UI_LBL_Color.Name = "UI_LBL_Color";
            this.UI_LBL_Color.Size = new System.Drawing.Size(25, 23);
            this.UI_LBL_Color.TabIndex = 8;
            this.UI_LBL_Color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_GroupBox
            // 
            this.UI_GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_GroupBox.BackColor = System.Drawing.SystemColors.Window;
            this.UI_GroupBox.Controls.Add(this.UI_LBL_Aplha);
            this.UI_GroupBox.Controls.Add(this.UI_LBL_BytesRX);
            this.UI_GroupBox.Controls.Add(this.UI_LBL_Color);
            this.UI_GroupBox.Controls.Add(this.UI_BTN_ConnectDisconnect);
            this.UI_GroupBox.Controls.Add(this.UI_LBL_Thickness);
            this.UI_GroupBox.Controls.Add(this.UI_BTN_Color);
            this.UI_GroupBox.Controls.Add(this.UI_LBL_Frames);
            this.UI_GroupBox.Controls.Add(this.UI_LBL_Fragments);
            this.UI_GroupBox.Controls.Add(this.UI_LBL_DestackAVG);
            this.UI_GroupBox.Location = new System.Drawing.Point(2, 510);
            this.UI_GroupBox.Name = "UI_GroupBox";
            this.UI_GroupBox.Size = new System.Drawing.Size(1007, 50);
            this.UI_GroupBox.TabIndex = 9;
            this.UI_GroupBox.TabStop = false;
            // 
            // UI_LBL_Aplha
            // 
            this.UI_LBL_Aplha.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_LBL_Aplha.Location = new System.Drawing.Point(320, 16);
            this.UI_LBL_Aplha.Name = "UI_LBL_Aplha";
            this.UI_LBL_Aplha.Size = new System.Drawing.Size(82, 23);
            this.UI_LBL_Aplha.TabIndex = 9;
            this.UI_LBL_Aplha.Text = "Alpha: 255";
            this.UI_LBL_Aplha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MDClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 561);
            this.Controls.Add(this.UI_GroupBox);
            this.Name = "MDClient";
            this.Text = "MultiDraw Client";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MDClient_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MDClient_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MDClient_MouseUp);
            this.UI_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_ConnectDisconnect;
        private System.Windows.Forms.Button UI_BTN_Color;
        private System.Windows.Forms.Label UI_LBL_Fragments;
        private System.Windows.Forms.Label UI_LBL_DestackAVG;
        private System.Windows.Forms.Label UI_LBL_BytesRX;
        private System.Windows.Forms.Label UI_LBL_Frames;
        private System.Windows.Forms.Label UI_LBL_Thickness;
        private System.Windows.Forms.ColorDialog UI_ColorDlg;
        private System.Windows.Forms.Label UI_LBL_Color;
        private System.Windows.Forms.GroupBox UI_GroupBox;
        private System.Windows.Forms.Label UI_LBL_Aplha;
    }
}

