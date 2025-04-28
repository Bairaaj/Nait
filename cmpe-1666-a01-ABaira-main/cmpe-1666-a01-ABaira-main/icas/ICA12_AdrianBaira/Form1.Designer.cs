
namespace ICA_12_AdrianBaira
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
            this.UI_TXT_InputString = new System.Windows.Forms.TextBox();
            this.UI_TXT_Outputstring = new System.Windows.Forms.TextBox();
            this.UI_RAD_UpperCase = new System.Windows.Forms.RadioButton();
            this.UI_RAD_Lowercase = new System.Windows.Forms.RadioButton();
            this.UI_Rad_Flipcase = new System.Windows.Forms.RadioButton();
            this.UI_GroupBox_ModificationType = new System.Windows.Forms.GroupBox();
            this.UI_LBL_InputString = new System.Windows.Forms.Label();
            this.UI_LBL_OutputString = new System.Windows.Forms.Label();
            this.UI_GroupBox_ModificationType.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_TXT_InputString
            // 
            this.UI_TXT_InputString.Location = new System.Drawing.Point(74, 88);
            this.UI_TXT_InputString.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_TXT_InputString.Name = "UI_TXT_InputString";
            this.UI_TXT_InputString.Size = new System.Drawing.Size(594, 26);
            this.UI_TXT_InputString.TabIndex = 0;
            this.UI_TXT_InputString.TextChanged += new System.EventHandler(this.UI_TXT_InputString_TextChanged);
            // 
            // UI_TXT_Outputstring
            // 
            this.UI_TXT_Outputstring.Location = new System.Drawing.Point(74, 305);
            this.UI_TXT_Outputstring.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_TXT_Outputstring.Name = "UI_TXT_Outputstring";
            this.UI_TXT_Outputstring.ReadOnly = true;
            this.UI_TXT_Outputstring.Size = new System.Drawing.Size(594, 26);
            this.UI_TXT_Outputstring.TabIndex = 2;
            this.UI_TXT_Outputstring.TabStop = false;
            // 
            // UI_RAD_UpperCase
            // 
            this.UI_RAD_UpperCase.AutoSize = true;
            this.UI_RAD_UpperCase.Checked = true;
            this.UI_RAD_UpperCase.Location = new System.Drawing.Point(9, 34);
            this.UI_RAD_UpperCase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_UpperCase.Name = "UI_RAD_UpperCase";
            this.UI_RAD_UpperCase.Size = new System.Drawing.Size(112, 24);
            this.UI_RAD_UpperCase.TabIndex = 0;
            this.UI_RAD_UpperCase.TabStop = true;
            this.UI_RAD_UpperCase.Text = "Uppercase";
            this.UI_RAD_UpperCase.UseVisualStyleBackColor = true;
            this.UI_RAD_UpperCase.CheckedChanged += new System.EventHandler(this.UI_RAD_UpperCase_CheckedChanged);
            // 
            // UI_RAD_Lowercase
            // 
            this.UI_RAD_Lowercase.AutoSize = true;
            this.UI_RAD_Lowercase.Location = new System.Drawing.Point(225, 34);
            this.UI_RAD_Lowercase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_Lowercase.Name = "UI_RAD_Lowercase";
            this.UI_RAD_Lowercase.Size = new System.Drawing.Size(111, 24);
            this.UI_RAD_Lowercase.TabIndex = 1;
            this.UI_RAD_Lowercase.Text = "Lowercase";
            this.UI_RAD_Lowercase.UseVisualStyleBackColor = true;
            this.UI_RAD_Lowercase.CheckedChanged += new System.EventHandler(this.UI_RAD_UpperCase_CheckedChanged);
            // 
            // UI_Rad_Flipcase
            // 
            this.UI_Rad_Flipcase.AutoSize = true;
            this.UI_Rad_Flipcase.Location = new System.Drawing.Point(436, 34);
            this.UI_Rad_Flipcase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_Rad_Flipcase.Name = "UI_Rad_Flipcase";
            this.UI_Rad_Flipcase.Size = new System.Drawing.Size(93, 24);
            this.UI_Rad_Flipcase.TabIndex = 2;
            this.UI_Rad_Flipcase.Text = "Flipcase";
            this.UI_Rad_Flipcase.UseVisualStyleBackColor = true;
            this.UI_Rad_Flipcase.CheckedChanged += new System.EventHandler(this.UI_RAD_UpperCase_CheckedChanged);
            // 
            // UI_GroupBox_ModificationType
            // 
            this.UI_GroupBox_ModificationType.Controls.Add(this.UI_Rad_Flipcase);
            this.UI_GroupBox_ModificationType.Controls.Add(this.UI_RAD_Lowercase);
            this.UI_GroupBox_ModificationType.Controls.Add(this.UI_RAD_UpperCase);
            this.UI_GroupBox_ModificationType.Location = new System.Drawing.Point(74, 145);
            this.UI_GroupBox_ModificationType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_GroupBox_ModificationType.Name = "UI_GroupBox_ModificationType";
            this.UI_GroupBox_ModificationType.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_GroupBox_ModificationType.Size = new System.Drawing.Size(610, 86);
            this.UI_GroupBox_ModificationType.TabIndex = 1;
            this.UI_GroupBox_ModificationType.TabStop = false;
            this.UI_GroupBox_ModificationType.Text = "Modification Type";
            // 
            // UI_LBL_InputString
            // 
            this.UI_LBL_InputString.AutoSize = true;
            this.UI_LBL_InputString.Location = new System.Drawing.Point(78, 63);
            this.UI_LBL_InputString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_LBL_InputString.Name = "UI_LBL_InputString";
            this.UI_LBL_InputString.Size = new System.Drawing.Size(96, 20);
            this.UI_LBL_InputString.TabIndex = 6;
            this.UI_LBL_InputString.Text = "Input String:";
            // 
            // UI_LBL_OutputString
            // 
            this.UI_LBL_OutputString.AutoSize = true;
            this.UI_LBL_OutputString.Location = new System.Drawing.Point(78, 280);
            this.UI_LBL_OutputString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_LBL_OutputString.Name = "UI_LBL_OutputString";
            this.UI_LBL_OutputString.Size = new System.Drawing.Size(108, 20);
            this.UI_LBL_OutputString.TabIndex = 7;
            this.UI_LBL_OutputString.Text = "Output String:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 397);
            this.Controls.Add(this.UI_LBL_OutputString);
            this.Controls.Add(this.UI_LBL_InputString);
            this.Controls.Add(this.UI_GroupBox_ModificationType);
            this.Controls.Add(this.UI_TXT_Outputstring);
            this.Controls.Add(this.UI_TXT_InputString);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(793, 453);
            this.MinimumSize = new System.Drawing.Size(793, 453);
            this.Name = "Form1";
            this.Text = "ICA 12 Delegates";
            this.UI_GroupBox_ModificationType.ResumeLayout(false);
            this.UI_GroupBox_ModificationType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UI_TXT_InputString;
        private System.Windows.Forms.TextBox UI_TXT_Outputstring;
        private System.Windows.Forms.RadioButton UI_RAD_UpperCase;
        private System.Windows.Forms.RadioButton UI_RAD_Lowercase;
        private System.Windows.Forms.RadioButton UI_Rad_Flipcase;
        private System.Windows.Forms.GroupBox UI_GroupBox_ModificationType;
        private System.Windows.Forms.Label UI_LBL_InputString;
        private System.Windows.Forms.Label UI_LBL_OutputString;
    }
}

