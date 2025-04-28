namespace ICA_03_AdrianBaira
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
            this.components = new System.ComponentModel.Container();
            this.UI_Start_Button = new System.Windows.Forms.Button();
            this.UI_ResetButton = new System.Windows.Forms.Button();
            this.UI_StopButton = new System.Windows.Forms.Button();
            this.UI_SplitButton = new System.Windows.Forms.Button();
            this.UI_LabelBox = new System.Windows.Forms.ListBox();
            this.UI_Label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_Start_Button
            // 
            this.UI_Start_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UI_Start_Button.Location = new System.Drawing.Point(230, 98);
            this.UI_Start_Button.Name = "UI_Start_Button";
            this.UI_Start_Button.Size = new System.Drawing.Size(75, 23);
            this.UI_Start_Button.TabIndex = 0;
            this.UI_Start_Button.Text = "Start";
            this.UI_Start_Button.UseVisualStyleBackColor = true;
            this.UI_Start_Button.Click += new System.EventHandler(this.UI_Start_Button_Click);
            // 
            // UI_ResetButton
            // 
            this.UI_ResetButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UI_ResetButton.Location = new System.Drawing.Point(230, 156);
            this.UI_ResetButton.Name = "UI_ResetButton";
            this.UI_ResetButton.Size = new System.Drawing.Size(75, 23);
            this.UI_ResetButton.TabIndex = 3;
            this.UI_ResetButton.Text = "Reset";
            this.UI_ResetButton.UseVisualStyleBackColor = true;
            this.UI_ResetButton.Click += new System.EventHandler(this.UI_ResetButton_Click);
            // 
            // UI_StopButton
            // 
            this.UI_StopButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UI_StopButton.Location = new System.Drawing.Point(230, 127);
            this.UI_StopButton.Name = "UI_StopButton";
            this.UI_StopButton.Size = new System.Drawing.Size(75, 23);
            this.UI_StopButton.TabIndex = 2;
            this.UI_StopButton.Text = "Stop";
            this.UI_StopButton.UseVisualStyleBackColor = true;
            this.UI_StopButton.Click += new System.EventHandler(this.UI_StopButton_Click);
            // 
            // UI_SplitButton
            // 
            this.UI_SplitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_SplitButton.Location = new System.Drawing.Point(230, 391);
            this.UI_SplitButton.Name = "UI_SplitButton";
            this.UI_SplitButton.Size = new System.Drawing.Size(75, 23);
            this.UI_SplitButton.TabIndex = 1;
            this.UI_SplitButton.Text = "Split";
            this.UI_SplitButton.UseVisualStyleBackColor = true;
            this.UI_SplitButton.Click += new System.EventHandler(this.UI_SplitButton_Click);
            // 
            // UI_LabelBox
            // 
            this.UI_LabelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LabelBox.FormattingEnabled = true;
            this.UI_LabelBox.Location = new System.Drawing.Point(12, 98);
            this.UI_LabelBox.Name = "UI_LabelBox";
            this.UI_LabelBox.Size = new System.Drawing.Size(212, 316);
            this.UI_LabelBox.TabIndex = 5;
            this.UI_LabelBox.TabStop = false;
            // 
            // UI_Label
            // 
            this.UI_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UI_Label.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_Label.Location = new System.Drawing.Point(12, 25);
            this.UI_Label.Name = "UI_Label";
            this.UI_Label.Size = new System.Drawing.Size(293, 41);
            this.UI_Label.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 457);
            this.Controls.Add(this.UI_Label);
            this.Controls.Add(this.UI_LabelBox);
            this.Controls.Add(this.UI_SplitButton);
            this.Controls.Add(this.UI_StopButton);
            this.Controls.Add(this.UI_ResetButton);
            this.Controls.Add(this.UI_Start_Button);
            this.Name = "Form1";
            this.Text = "Timers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_Start_Button;
        private System.Windows.Forms.Button UI_ResetButton;
        private System.Windows.Forms.Button UI_StopButton;
        private System.Windows.Forms.Button UI_SplitButton;
        private System.Windows.Forms.ListBox UI_LabelBox;
        private System.Windows.Forms.Label UI_Label;
        private System.Windows.Forms.Timer timer1;
    }
}

