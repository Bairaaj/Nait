namespace ICA06_AdrianBaira
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
            this.UI_StringRecusion_RECShow_Button = new System.Windows.Forms.Button();
            this.UI_StringRecusion_TextBox_Output = new System.Windows.Forms.TextBox();
            this.UI_StringRecusion_TextBox_Input = new System.Windows.Forms.TextBox();
            this.UI_StringRecusion_RecReverse_Button = new System.Windows.Forms.Button();
            this.UI_GroupBox_String_Recusion = new System.Windows.Forms.GroupBox();
            this.UI_FactorFinder_GroupBox = new System.Windows.Forms.GroupBox();
            this.UI_NumericUpDown_Input = new System.Windows.Forms.NumericUpDown();
            this.UI_TextBox_FactorFinder_Output = new System.Windows.Forms.TextBox();
            this.UI_FactorFinder_FindFactors_Button = new System.Windows.Forms.Button();
            this.UI_BinaryHunter_GroupBox = new System.Windows.Forms.GroupBox();
            this.UI_BinarHunter_Textbox_OutPut = new System.Windows.Forms.TextBox();
            this.UI_FindUppercase_Button = new System.Windows.Forms.Button();
            this.UI_BinaryHunter_TextBox_Input = new System.Windows.Forms.TextBox();
            this.UI_GroupBox_String_Recusion.SuspendLayout();
            this.UI_FactorFinder_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_NumericUpDown_Input)).BeginInit();
            this.UI_BinaryHunter_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_StringRecusion_RECShow_Button
            // 
            this.UI_StringRecusion_RECShow_Button.Location = new System.Drawing.Point(6, 50);
            this.UI_StringRecusion_RECShow_Button.Name = "UI_StringRecusion_RECShow_Button";
            this.UI_StringRecusion_RECShow_Button.Size = new System.Drawing.Size(155, 23);
            this.UI_StringRecusion_RECShow_Button.TabIndex = 0;
            this.UI_StringRecusion_RECShow_Button.Text = "Rec Show";
            this.UI_StringRecusion_RECShow_Button.UseVisualStyleBackColor = true;
            this.UI_StringRecusion_RECShow_Button.Click += new System.EventHandler(this.UI_StringRecusion_RECShow_Button_Click);
            // 
            // UI_StringRecusion_TextBox_Output
            // 
            this.UI_StringRecusion_TextBox_Output.Location = new System.Drawing.Point(6, 79);
            this.UI_StringRecusion_TextBox_Output.Name = "UI_StringRecusion_TextBox_Output";
            this.UI_StringRecusion_TextBox_Output.ReadOnly = true;
            this.UI_StringRecusion_TextBox_Output.Size = new System.Drawing.Size(448, 20);
            this.UI_StringRecusion_TextBox_Output.TabIndex = 12;
            // 
            // UI_StringRecusion_TextBox_Input
            // 
            this.UI_StringRecusion_TextBox_Input.Location = new System.Drawing.Point(6, 24);
            this.UI_StringRecusion_TextBox_Input.Name = "UI_StringRecusion_TextBox_Input";
            this.UI_StringRecusion_TextBox_Input.Size = new System.Drawing.Size(448, 20);
            this.UI_StringRecusion_TextBox_Input.TabIndex = 13;
            // 
            // UI_StringRecusion_RecReverse_Button
            // 
            this.UI_StringRecusion_RecReverse_Button.Location = new System.Drawing.Point(167, 50);
            this.UI_StringRecusion_RecReverse_Button.Name = "UI_StringRecusion_RecReverse_Button";
            this.UI_StringRecusion_RecReverse_Button.Size = new System.Drawing.Size(155, 23);
            this.UI_StringRecusion_RecReverse_Button.TabIndex = 16;
            this.UI_StringRecusion_RecReverse_Button.Text = "Rec Reverse";
            this.UI_StringRecusion_RecReverse_Button.UseVisualStyleBackColor = true;
            this.UI_StringRecusion_RecReverse_Button.Click += new System.EventHandler(this.UI_StringRecusion_RecReverse_Button_Click);
            // 
            // UI_GroupBox_String_Recusion
            // 
            this.UI_GroupBox_String_Recusion.Controls.Add(this.UI_StringRecusion_TextBox_Output);
            this.UI_GroupBox_String_Recusion.Controls.Add(this.UI_StringRecusion_RECShow_Button);
            this.UI_GroupBox_String_Recusion.Controls.Add(this.UI_StringRecusion_TextBox_Input);
            this.UI_GroupBox_String_Recusion.Controls.Add(this.UI_StringRecusion_RecReverse_Button);
            this.UI_GroupBox_String_Recusion.Location = new System.Drawing.Point(12, 12);
            this.UI_GroupBox_String_Recusion.Name = "UI_GroupBox_String_Recusion";
            this.UI_GroupBox_String_Recusion.Size = new System.Drawing.Size(476, 115);
            this.UI_GroupBox_String_Recusion.TabIndex = 19;
            this.UI_GroupBox_String_Recusion.TabStop = false;
            this.UI_GroupBox_String_Recusion.Text = "String Recusion";
            // 
            // UI_FactorFinder_GroupBox
            // 
            this.UI_FactorFinder_GroupBox.Controls.Add(this.UI_NumericUpDown_Input);
            this.UI_FactorFinder_GroupBox.Controls.Add(this.UI_TextBox_FactorFinder_Output);
            this.UI_FactorFinder_GroupBox.Controls.Add(this.UI_FactorFinder_FindFactors_Button);
            this.UI_FactorFinder_GroupBox.Location = new System.Drawing.Point(12, 145);
            this.UI_FactorFinder_GroupBox.Name = "UI_FactorFinder_GroupBox";
            this.UI_FactorFinder_GroupBox.Size = new System.Drawing.Size(476, 110);
            this.UI_FactorFinder_GroupBox.TabIndex = 20;
            this.UI_FactorFinder_GroupBox.TabStop = false;
            this.UI_FactorFinder_GroupBox.Text = "Factor Finder";
            // 
            // UI_NumericUpDown_Input
            // 
            this.UI_NumericUpDown_Input.Location = new System.Drawing.Point(6, 19);
            this.UI_NumericUpDown_Input.Name = "UI_NumericUpDown_Input";
            this.UI_NumericUpDown_Input.Size = new System.Drawing.Size(106, 20);
            this.UI_NumericUpDown_Input.TabIndex = 13;
            // 
            // UI_TextBox_FactorFinder_Output
            // 
            this.UI_TextBox_FactorFinder_Output.Location = new System.Drawing.Point(6, 74);
            this.UI_TextBox_FactorFinder_Output.Name = "UI_TextBox_FactorFinder_Output";
            this.UI_TextBox_FactorFinder_Output.ReadOnly = true;
            this.UI_TextBox_FactorFinder_Output.Size = new System.Drawing.Size(448, 20);
            this.UI_TextBox_FactorFinder_Output.TabIndex = 12;
            // 
            // UI_FactorFinder_FindFactors_Button
            // 
            this.UI_FactorFinder_FindFactors_Button.Location = new System.Drawing.Point(6, 45);
            this.UI_FactorFinder_FindFactors_Button.Name = "UI_FactorFinder_FindFactors_Button";
            this.UI_FactorFinder_FindFactors_Button.Size = new System.Drawing.Size(155, 23);
            this.UI_FactorFinder_FindFactors_Button.TabIndex = 0;
            this.UI_FactorFinder_FindFactors_Button.Text = "Find Factors";
            this.UI_FactorFinder_FindFactors_Button.UseVisualStyleBackColor = true;
            this.UI_FactorFinder_FindFactors_Button.Click += new System.EventHandler(this.UI_FactorFinder_FindFactors_Button_Click);
            // 
            // UI_BinaryHunter_GroupBox
            // 
            this.UI_BinaryHunter_GroupBox.Controls.Add(this.UI_BinarHunter_Textbox_OutPut);
            this.UI_BinaryHunter_GroupBox.Controls.Add(this.UI_FindUppercase_Button);
            this.UI_BinaryHunter_GroupBox.Controls.Add(this.UI_BinaryHunter_TextBox_Input);
            this.UI_BinaryHunter_GroupBox.Location = new System.Drawing.Point(12, 274);
            this.UI_BinaryHunter_GroupBox.Name = "UI_BinaryHunter_GroupBox";
            this.UI_BinaryHunter_GroupBox.Size = new System.Drawing.Size(476, 114);
            this.UI_BinaryHunter_GroupBox.TabIndex = 20;
            this.UI_BinaryHunter_GroupBox.TabStop = false;
            this.UI_BinaryHunter_GroupBox.Text = "Binary Hunter";
            // 
            // UI_BinarHunter_Textbox_OutPut
            // 
            this.UI_BinarHunter_Textbox_OutPut.Location = new System.Drawing.Point(6, 78);
            this.UI_BinarHunter_Textbox_OutPut.Name = "UI_BinarHunter_Textbox_OutPut";
            this.UI_BinarHunter_Textbox_OutPut.ReadOnly = true;
            this.UI_BinarHunter_Textbox_OutPut.Size = new System.Drawing.Size(448, 20);
            this.UI_BinarHunter_Textbox_OutPut.TabIndex = 12;
            // 
            // UI_FindUppercase_Button
            // 
            this.UI_FindUppercase_Button.Location = new System.Drawing.Point(6, 49);
            this.UI_FindUppercase_Button.Name = "UI_FindUppercase_Button";
            this.UI_FindUppercase_Button.Size = new System.Drawing.Size(155, 23);
            this.UI_FindUppercase_Button.TabIndex = 0;
            this.UI_FindUppercase_Button.Text = "Find Uppercase";
            this.UI_FindUppercase_Button.UseVisualStyleBackColor = true;
            this.UI_FindUppercase_Button.Click += new System.EventHandler(this.UI_FindUppercase_Button_Click);
            // 
            // UI_BinaryHunter_TextBox_Input
            // 
            this.UI_BinaryHunter_TextBox_Input.Location = new System.Drawing.Point(6, 23);
            this.UI_BinaryHunter_TextBox_Input.Name = "UI_BinaryHunter_TextBox_Input";
            this.UI_BinaryHunter_TextBox_Input.Size = new System.Drawing.Size(448, 20);
            this.UI_BinaryHunter_TextBox_Input.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 414);
            this.Controls.Add(this.UI_FactorFinder_GroupBox);
            this.Controls.Add(this.UI_BinaryHunter_GroupBox);
            this.Controls.Add(this.UI_GroupBox_String_Recusion);
            this.Name = "Form1";
            this.Text = "Basic Recusion Sandbox";
            this.UI_GroupBox_String_Recusion.ResumeLayout(false);
            this.UI_GroupBox_String_Recusion.PerformLayout();
            this.UI_FactorFinder_GroupBox.ResumeLayout(false);
            this.UI_FactorFinder_GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_NumericUpDown_Input)).EndInit();
            this.UI_BinaryHunter_GroupBox.ResumeLayout(false);
            this.UI_BinaryHunter_GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_StringRecusion_RECShow_Button;
        private System.Windows.Forms.TextBox UI_StringRecusion_TextBox_Output;
        private System.Windows.Forms.TextBox UI_StringRecusion_TextBox_Input;
        private System.Windows.Forms.Button UI_StringRecusion_RecReverse_Button;
        private System.Windows.Forms.GroupBox UI_GroupBox_String_Recusion;
        private System.Windows.Forms.GroupBox UI_FactorFinder_GroupBox;
        private System.Windows.Forms.NumericUpDown UI_NumericUpDown_Input;
        private System.Windows.Forms.TextBox UI_TextBox_FactorFinder_Output;
        private System.Windows.Forms.Button UI_FactorFinder_FindFactors_Button;
        private System.Windows.Forms.GroupBox UI_BinaryHunter_GroupBox;
        private System.Windows.Forms.TextBox UI_BinarHunter_Textbox_OutPut;
        private System.Windows.Forms.Button UI_FindUppercase_Button;
        private System.Windows.Forms.TextBox UI_BinaryHunter_TextBox_Input;
    }
}

