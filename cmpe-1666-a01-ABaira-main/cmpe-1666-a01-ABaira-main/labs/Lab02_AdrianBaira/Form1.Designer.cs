namespace Lab02_AdrianBaira
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
            this.UI_PictureBox = new System.Windows.Forms.PictureBox();
            this.UI_Trackbar = new System.Windows.Forms.TrackBar();
            this.UI_BTN_LoadPicture = new System.Windows.Forms.Button();
            this.UI_GroupBox = new System.Windows.Forms.GroupBox();
            this.UI_RADIO_Noise = new System.Windows.Forms.RadioButton();
            this.UI_RADIO_BlackWhite = new System.Windows.Forms.RadioButton();
            this.UI_RADIO_Tint = new System.Windows.Forms.RadioButton();
            this.UI_RADIO_Contrast = new System.Windows.Forms.RadioButton();
            this.UI_LABEL_Left = new System.Windows.Forms.Label();
            this.UI_LoadBar = new System.Windows.Forms.ProgressBar();
            this.UI_BTN_Transform = new System.Windows.Forms.Button();
            this.UI_LABEL_Right = new System.Windows.Forms.Label();
            this.UI_LABEL_Middle = new System.Windows.Forms.Label();
            this.UI_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.UI_BTN_Revert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Trackbar)).BeginInit();
            this.UI_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_PictureBox
            // 
            this.UI_PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_PictureBox.Location = new System.Drawing.Point(12, 12);
            this.UI_PictureBox.Name = "UI_PictureBox";
            this.UI_PictureBox.Size = new System.Drawing.Size(812, 394);
            this.UI_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UI_PictureBox.TabIndex = 0;
            this.UI_PictureBox.TabStop = false;
            // 
            // UI_Trackbar
            // 
            this.UI_Trackbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Trackbar.Location = new System.Drawing.Point(354, 434);
            this.UI_Trackbar.Maximum = 100;
            this.UI_Trackbar.Name = "UI_Trackbar";
            this.UI_Trackbar.Size = new System.Drawing.Size(375, 45);
            this.UI_Trackbar.SmallChange = 5;
            this.UI_Trackbar.TabIndex = 3;
            this.UI_Trackbar.TickFrequency = 5;
            this.UI_Trackbar.Value = 50;
            this.UI_Trackbar.Scroll += new System.EventHandler(this.UI_Trackbar_Scroll);
            // 
            // UI_BTN_LoadPicture
            // 
            this.UI_BTN_LoadPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_BTN_LoadPicture.Location = new System.Drawing.Point(12, 434);
            this.UI_BTN_LoadPicture.Name = "UI_BTN_LoadPicture";
            this.UI_BTN_LoadPicture.Size = new System.Drawing.Size(89, 23);
            this.UI_BTN_LoadPicture.TabIndex = 0;
            this.UI_BTN_LoadPicture.Text = "Load Picture";
            this.UI_BTN_LoadPicture.UseVisualStyleBackColor = true;
            this.UI_BTN_LoadPicture.Click += new System.EventHandler(this.UI_BTN_LoadPicture_Click);
            // 
            // UI_GroupBox
            // 
            this.UI_GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_GroupBox.Controls.Add(this.UI_RADIO_Noise);
            this.UI_GroupBox.Controls.Add(this.UI_RADIO_BlackWhite);
            this.UI_GroupBox.Controls.Add(this.UI_RADIO_Tint);
            this.UI_GroupBox.Controls.Add(this.UI_RADIO_Contrast);
            this.UI_GroupBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.UI_GroupBox.Location = new System.Drawing.Point(107, 434);
            this.UI_GroupBox.Name = "UI_GroupBox";
            this.UI_GroupBox.Size = new System.Drawing.Size(241, 105);
            this.UI_GroupBox.TabIndex = 1;
            this.UI_GroupBox.TabStop = false;
            this.UI_GroupBox.Text = "Modification Type";
            // 
            // UI_RADIO_Noise
            // 
            this.UI_RADIO_Noise.AutoSize = true;
            this.UI_RADIO_Noise.Location = new System.Drawing.Point(141, 67);
            this.UI_RADIO_Noise.Name = "UI_RADIO_Noise";
            this.UI_RADIO_Noise.Size = new System.Drawing.Size(52, 17);
            this.UI_RADIO_Noise.TabIndex = 3;
            this.UI_RADIO_Noise.Text = "Noise";
            this.UI_RADIO_Noise.UseVisualStyleBackColor = true;
            this.UI_RADIO_Noise.CheckedChanged += new System.EventHandler(this.UI_RADIO_Noise_CheckedChanged);
            // 
            // UI_RADIO_BlackWhite
            // 
            this.UI_RADIO_BlackWhite.AutoSize = true;
            this.UI_RADIO_BlackWhite.Location = new System.Drawing.Point(21, 67);
            this.UI_RADIO_BlackWhite.Name = "UI_RADIO_BlackWhite";
            this.UI_RADIO_BlackWhite.Size = new System.Drawing.Size(92, 17);
            this.UI_RADIO_BlackWhite.TabIndex = 2;
            this.UI_RADIO_BlackWhite.Text = "Black & White";
            this.UI_RADIO_BlackWhite.UseMnemonic = false;
            this.UI_RADIO_BlackWhite.UseVisualStyleBackColor = true;
            this.UI_RADIO_BlackWhite.CheckedChanged += new System.EventHandler(this.UI_RADIO_BlackWhite_CheckedChanged);
            // 
            // UI_RADIO_Tint
            // 
            this.UI_RADIO_Tint.AutoSize = true;
            this.UI_RADIO_Tint.Location = new System.Drawing.Point(141, 28);
            this.UI_RADIO_Tint.Name = "UI_RADIO_Tint";
            this.UI_RADIO_Tint.Size = new System.Drawing.Size(43, 17);
            this.UI_RADIO_Tint.TabIndex = 1;
            this.UI_RADIO_Tint.Text = "Tint";
            this.UI_RADIO_Tint.UseVisualStyleBackColor = true;
            this.UI_RADIO_Tint.CheckedChanged += new System.EventHandler(this.UI_RADIO_Tint_CheckedChanged);
            // 
            // UI_RADIO_Contrast
            // 
            this.UI_RADIO_Contrast.AutoSize = true;
            this.UI_RADIO_Contrast.Checked = true;
            this.UI_RADIO_Contrast.Location = new System.Drawing.Point(21, 28);
            this.UI_RADIO_Contrast.Name = "UI_RADIO_Contrast";
            this.UI_RADIO_Contrast.Size = new System.Drawing.Size(64, 17);
            this.UI_RADIO_Contrast.TabIndex = 0;
            this.UI_RADIO_Contrast.TabStop = true;
            this.UI_RADIO_Contrast.Text = "Contrast";
            this.UI_RADIO_Contrast.UseVisualStyleBackColor = true;
            this.UI_RADIO_Contrast.CheckedChanged += new System.EventHandler(this.UI_RADIO_Contrast_CheckedChanged);
            // 
            // UI_LABEL_Left
            // 
            this.UI_LABEL_Left.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_LABEL_Left.AutoSize = true;
            this.UI_LABEL_Left.Location = new System.Drawing.Point(351, 482);
            this.UI_LABEL_Left.Name = "UI_LABEL_Left";
            this.UI_LABEL_Left.Size = new System.Drawing.Size(25, 13);
            this.UI_LABEL_Left.TabIndex = 5;
            this.UI_LABEL_Left.Text = "Left";
            // 
            // UI_LoadBar
            // 
            this.UI_LoadBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LoadBar.Location = new System.Drawing.Point(12, 412);
            this.UI_LoadBar.MarqueeAnimationSpeed = 1;
            this.UI_LoadBar.Maximum = 1000;
            this.UI_LoadBar.Name = "UI_LoadBar";
            this.UI_LoadBar.Size = new System.Drawing.Size(812, 16);
            this.UI_LoadBar.Step = 1;
            this.UI_LoadBar.TabIndex = 6;
            // 
            // UI_BTN_Transform
            // 
            this.UI_BTN_Transform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_Transform.Location = new System.Drawing.Point(735, 434);
            this.UI_BTN_Transform.Name = "UI_BTN_Transform";
            this.UI_BTN_Transform.Size = new System.Drawing.Size(89, 23);
            this.UI_BTN_Transform.TabIndex = 2;
            this.UI_BTN_Transform.Text = "Transform!";
            this.UI_BTN_Transform.UseVisualStyleBackColor = true;
            this.UI_BTN_Transform.Click += new System.EventHandler(this.UI_BTN_Transform_Click);
            // 
            // UI_LABEL_Right
            // 
            this.UI_LABEL_Right.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LABEL_Right.AutoSize = true;
            this.UI_LABEL_Right.Location = new System.Drawing.Point(694, 482);
            this.UI_LABEL_Right.Name = "UI_LABEL_Right";
            this.UI_LABEL_Right.Size = new System.Drawing.Size(32, 13);
            this.UI_LABEL_Right.TabIndex = 8;
            this.UI_LABEL_Right.Text = "Right";
            // 
            // UI_LABEL_Middle
            // 
            this.UI_LABEL_Middle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UI_LABEL_Middle.AutoSize = true;
            this.UI_LABEL_Middle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.UI_LABEL_Middle.Location = new System.Drawing.Point(531, 482);
            this.UI_LABEL_Middle.Name = "UI_LABEL_Middle";
            this.UI_LABEL_Middle.Size = new System.Drawing.Size(38, 13);
            this.UI_LABEL_Middle.TabIndex = 9;
            this.UI_LABEL_Middle.Text = "Middle";
            // 
            // UI_OpenFileDialog
            // 
            this.UI_OpenFileDialog.FileName = "openFileDialog1";
            // 
            // UI_BTN_Revert
            // 
            this.UI_BTN_Revert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_BTN_Revert.Location = new System.Drawing.Point(12, 511);
            this.UI_BTN_Revert.Name = "UI_BTN_Revert";
            this.UI_BTN_Revert.Size = new System.Drawing.Size(89, 23);
            this.UI_BTN_Revert.TabIndex = 4;
            this.UI_BTN_Revert.Text = "Revert!";
            this.UI_BTN_Revert.UseVisualStyleBackColor = true;
            this.UI_BTN_Revert.Click += new System.EventHandler(this.UI_BTN_Revert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 546);
            this.Controls.Add(this.UI_BTN_Revert);
            this.Controls.Add(this.UI_LABEL_Middle);
            this.Controls.Add(this.UI_LABEL_Right);
            this.Controls.Add(this.UI_BTN_Transform);
            this.Controls.Add(this.UI_LoadBar);
            this.Controls.Add(this.UI_LABEL_Left);
            this.Controls.Add(this.UI_GroupBox);
            this.Controls.Add(this.UI_BTN_LoadPicture);
            this.Controls.Add(this.UI_Trackbar);
            this.Controls.Add(this.UI_PictureBox);
            this.MinimumSize = new System.Drawing.Size(852, 585);
            this.Name = "Form1";
            this.Text = "PicBender";
            ((System.ComponentModel.ISupportInitialize)(this.UI_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Trackbar)).EndInit();
            this.UI_GroupBox.ResumeLayout(false);
            this.UI_GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UI_PictureBox;
        private System.Windows.Forms.TrackBar UI_Trackbar;
        private System.Windows.Forms.Button UI_BTN_LoadPicture;
        private System.Windows.Forms.GroupBox UI_GroupBox;
        private System.Windows.Forms.RadioButton UI_RADIO_Contrast;
        private System.Windows.Forms.Label UI_LABEL_Left;
        private System.Windows.Forms.ProgressBar UI_LoadBar;
        private System.Windows.Forms.Button UI_BTN_Transform;
        private System.Windows.Forms.RadioButton UI_RADIO_Noise;
        private System.Windows.Forms.RadioButton UI_RADIO_BlackWhite;
        private System.Windows.Forms.RadioButton UI_RADIO_Tint;
        private System.Windows.Forms.Label UI_LABEL_Right;
        private System.Windows.Forms.Label UI_LABEL_Middle;
        private System.Windows.Forms.OpenFileDialog UI_OpenFileDialog;
        private System.Windows.Forms.Button UI_BTN_Revert;
    }
}

