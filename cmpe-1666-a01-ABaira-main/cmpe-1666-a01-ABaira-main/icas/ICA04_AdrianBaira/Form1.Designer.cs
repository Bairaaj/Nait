namespace ICA04_AdrianBaira
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
            this.UI_MilesPerHourButton = new System.Windows.Forms.RadioButton();
            this.UI_Kilometerperhourbutton = new System.Windows.Forms.RadioButton();
            this.UI_InputspeedTextBox = new System.Windows.Forms.TextBox();
            this.UI_OutputspeedTextbox = new System.Windows.Forms.TextBox();
            this.UI_InputSpeedLabel = new System.Windows.Forms.Label();
            this.UI_OnputSpeedLabel = new System.Windows.Forms.Label();
            this.UI_GroupBox = new System.Windows.Forms.GroupBox();
            this.UI_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_MilesPerHourButton
            // 
            this.UI_MilesPerHourButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_MilesPerHourButton.AutoSize = true;
            this.UI_MilesPerHourButton.Location = new System.Drawing.Point(6, 20);
            this.UI_MilesPerHourButton.Name = "UI_MilesPerHourButton";
            this.UI_MilesPerHourButton.Size = new System.Drawing.Size(123, 17);
            this.UI_MilesPerHourButton.TabIndex = 0;
            this.UI_MilesPerHourButton.Text = "Miles Per Hour (mph)";
            this.UI_MilesPerHourButton.UseVisualStyleBackColor = true;
            this.UI_MilesPerHourButton.Click += new System.EventHandler(this.UI_InputspeedTextBox_TextChanged);
            // 
            // UI_Kilometerperhourbutton
            // 
            this.UI_Kilometerperhourbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Kilometerperhourbutton.AutoSize = true;
            this.UI_Kilometerperhourbutton.Checked = true;
            this.UI_Kilometerperhourbutton.Location = new System.Drawing.Point(6, 43);
            this.UI_Kilometerperhourbutton.Name = "UI_Kilometerperhourbutton";
            this.UI_Kilometerperhourbutton.Size = new System.Drawing.Size(145, 17);
            this.UI_Kilometerperhourbutton.TabIndex = 0;
            this.UI_Kilometerperhourbutton.TabStop = true;
            this.UI_Kilometerperhourbutton.Text = "Kilometers Per Hour (kph)";
            this.UI_Kilometerperhourbutton.UseVisualStyleBackColor = true;
            this.UI_Kilometerperhourbutton.Click += new System.EventHandler(this.UI_InputspeedTextBox_TextChanged);
            // 
            // UI_InputspeedTextBox
            // 
            this.UI_InputspeedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_InputspeedTextBox.Location = new System.Drawing.Point(18, 121);
            this.UI_InputspeedTextBox.Name = "UI_InputspeedTextBox";
            this.UI_InputspeedTextBox.Size = new System.Drawing.Size(231, 20);
            this.UI_InputspeedTextBox.TabIndex = 0;
            this.UI_InputspeedTextBox.Text = "0";
            this.UI_InputspeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UI_InputspeedTextBox.TextChanged += new System.EventHandler(this.UI_InputspeedTextBox_TextChanged);
            // 
            // UI_OutputspeedTextbox
            // 
            this.UI_OutputspeedTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_OutputspeedTextbox.Location = new System.Drawing.Point(18, 170);
            this.UI_OutputspeedTextbox.Name = "UI_OutputspeedTextbox";
            this.UI_OutputspeedTextbox.ReadOnly = true;
            this.UI_OutputspeedTextbox.Size = new System.Drawing.Size(231, 20);
            this.UI_OutputspeedTextbox.TabIndex = 3;
            this.UI_OutputspeedTextbox.TabStop = false;
            this.UI_OutputspeedTextbox.Text = "0";
            this.UI_OutputspeedTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UI_InputSpeedLabel
            // 
            this.UI_InputSpeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_InputSpeedLabel.AutoSize = true;
            this.UI_InputSpeedLabel.Location = new System.Drawing.Point(18, 105);
            this.UI_InputSpeedLabel.Name = "UI_InputSpeedLabel";
            this.UI_InputSpeedLabel.Size = new System.Drawing.Size(68, 13);
            this.UI_InputSpeedLabel.TabIndex = 4;
            this.UI_InputSpeedLabel.Text = "Input Speed:";
            // 
            // UI_OnputSpeedLabel
            // 
            this.UI_OnputSpeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_OnputSpeedLabel.AutoSize = true;
            this.UI_OnputSpeedLabel.Location = new System.Drawing.Point(18, 154);
            this.UI_OnputSpeedLabel.Name = "UI_OnputSpeedLabel";
            this.UI_OnputSpeedLabel.Size = new System.Drawing.Size(76, 13);
            this.UI_OnputSpeedLabel.TabIndex = 5;
            this.UI_OnputSpeedLabel.Text = "Output Speed:";
            // 
            // UI_GroupBox
            // 
            this.UI_GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_GroupBox.Controls.Add(this.UI_MilesPerHourButton);
            this.UI_GroupBox.Controls.Add(this.UI_Kilometerperhourbutton);
            this.UI_GroupBox.Location = new System.Drawing.Point(12, 12);
            this.UI_GroupBox.Name = "UI_GroupBox";
            this.UI_GroupBox.Size = new System.Drawing.Size(231, 74);
            this.UI_GroupBox.TabIndex = 1;
            this.UI_GroupBox.TabStop = false;
            this.UI_GroupBox.Text = "Input Units";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 230);
            this.Controls.Add(this.UI_GroupBox);
            this.Controls.Add(this.UI_OnputSpeedLabel);
            this.Controls.Add(this.UI_InputSpeedLabel);
            this.Controls.Add(this.UI_OutputspeedTextbox);
            this.Controls.Add(this.UI_InputspeedTextBox);
            this.MinimumSize = new System.Drawing.Size(286, 269);
            this.Name = "Form1";
            this.Text = "Speed Conversion";
            this.UI_GroupBox.ResumeLayout(false);
            this.UI_GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton UI_MilesPerHourButton;
        private System.Windows.Forms.RadioButton UI_Kilometerperhourbutton;
        private System.Windows.Forms.TextBox UI_InputspeedTextBox;
        private System.Windows.Forms.TextBox UI_OutputspeedTextbox;
        private System.Windows.Forms.Label UI_InputSpeedLabel;
        private System.Windows.Forms.Label UI_OnputSpeedLabel;
        private System.Windows.Forms.GroupBox UI_GroupBox;
    }
}

