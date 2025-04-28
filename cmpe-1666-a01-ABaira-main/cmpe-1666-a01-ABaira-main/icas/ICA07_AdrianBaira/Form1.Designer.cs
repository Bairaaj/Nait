
namespace ICA07AdrianBaira
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
            this.UI_Label_TestValue = new System.Windows.Forms.Label();
            this.UI_Label_TestValueResult = new System.Windows.Forms.Label();
            this.UI_Button_FindPalindrome = new System.Windows.Forms.Button();
            this.UI_Groupbox_CheckPalindrome = new System.Windows.Forms.GroupBox();
            this.UI_RadioButton_File = new System.Windows.Forms.RadioButton();
            this.UI_RadioButton_TextValue = new System.Windows.Forms.RadioButton();
            this.UI_ListBox = new System.Windows.Forms.ListBox();
            this.UI_TextBox_TestValueResult = new System.Windows.Forms.TextBox();
            this.UI_TextBox_TestValue = new System.Windows.Forms.TextBox();
            this.UI_TextBox_PalindromeCount = new System.Windows.Forms.TextBox();
            this.UI_TextBox_ExecutionTime = new System.Windows.Forms.TextBox();
            this.UI_Label_ExecutionTime = new System.Windows.Forms.Label();
            this.UI_Label_PalindromeCountFromFile = new System.Windows.Forms.Label();
            this.UI_Label_ListOfPalinDromesFromFile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.UI_Groupbox_CheckPalindrome.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_Label_TestValue
            // 
            this.UI_Label_TestValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Label_TestValue.AutoSize = true;
            this.UI_Label_TestValue.Location = new System.Drawing.Point(47, 84);
            this.UI_Label_TestValue.Name = "UI_Label_TestValue";
            this.UI_Label_TestValue.Size = new System.Drawing.Size(58, 13);
            this.UI_Label_TestValue.TabIndex = 0;
            this.UI_Label_TestValue.Text = "Test Value";
            // 
            // UI_Label_TestValueResult
            // 
            this.UI_Label_TestValueResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Label_TestValueResult.AutoSize = true;
            this.UI_Label_TestValueResult.Location = new System.Drawing.Point(14, 112);
            this.UI_Label_TestValueResult.Name = "UI_Label_TestValueResult";
            this.UI_Label_TestValueResult.Size = new System.Drawing.Size(91, 13);
            this.UI_Label_TestValueResult.TabIndex = 1;
            this.UI_Label_TestValueResult.Text = "Test Value Result";
            // 
            // UI_Button_FindPalindrome
            // 
            this.UI_Button_FindPalindrome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Button_FindPalindrome.Location = new System.Drawing.Point(111, 162);
            this.UI_Button_FindPalindrome.Name = "UI_Button_FindPalindrome";
            this.UI_Button_FindPalindrome.Size = new System.Drawing.Size(167, 48);
            this.UI_Button_FindPalindrome.TabIndex = 1;
            this.UI_Button_FindPalindrome.Text = "Find Palindrome(s)";
            this.UI_Button_FindPalindrome.UseVisualStyleBackColor = true;
            this.UI_Button_FindPalindrome.Click += new System.EventHandler(this.UI_Button_FindPalindrome_Click);
            // 
            // UI_Groupbox_CheckPalindrome
            // 
            this.UI_Groupbox_CheckPalindrome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Groupbox_CheckPalindrome.Controls.Add(this.UI_RadioButton_File);
            this.UI_Groupbox_CheckPalindrome.Controls.Add(this.UI_RadioButton_TextValue);
            this.UI_Groupbox_CheckPalindrome.Location = new System.Drawing.Point(417, 81);
            this.UI_Groupbox_CheckPalindrome.Name = "UI_Groupbox_CheckPalindrome";
            this.UI_Groupbox_CheckPalindrome.Size = new System.Drawing.Size(181, 111);
            this.UI_Groupbox_CheckPalindrome.TabIndex = 2;
            this.UI_Groupbox_CheckPalindrome.TabStop = false;
            this.UI_Groupbox_CheckPalindrome.Text = "Check Palindrome";
            // 
            // UI_RadioButton_File
            // 
            this.UI_RadioButton_File.AutoSize = true;
            this.UI_RadioButton_File.Location = new System.Drawing.Point(23, 63);
            this.UI_RadioButton_File.Name = "UI_RadioButton_File";
            this.UI_RadioButton_File.Size = new System.Drawing.Size(41, 17);
            this.UI_RadioButton_File.TabIndex = 1;
            this.UI_RadioButton_File.Text = "File";
            this.UI_RadioButton_File.UseVisualStyleBackColor = true;
            this.UI_RadioButton_File.CheckedChanged += new System.EventHandler(this.UI_RadioButton_File_CheckedChanged);
            // 
            // UI_RadioButton_TextValue
            // 
            this.UI_RadioButton_TextValue.AutoSize = true;
            this.UI_RadioButton_TextValue.Checked = true;
            this.UI_RadioButton_TextValue.Location = new System.Drawing.Point(23, 29);
            this.UI_RadioButton_TextValue.Name = "UI_RadioButton_TextValue";
            this.UI_RadioButton_TextValue.Size = new System.Drawing.Size(76, 17);
            this.UI_RadioButton_TextValue.TabIndex = 0;
            this.UI_RadioButton_TextValue.TabStop = true;
            this.UI_RadioButton_TextValue.Text = "Test Value";
            this.UI_RadioButton_TextValue.UseVisualStyleBackColor = true;
            this.UI_RadioButton_TextValue.CheckedChanged += new System.EventHandler(this.UI_RadioButton_TextValue_CheckedChanged);
            // 
            // UI_ListBox
            // 
            this.UI_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_ListBox.FormattingEnabled = true;
            this.UI_ListBox.Location = new System.Drawing.Point(394, 288);
            this.UI_ListBox.Name = "UI_ListBox";
            this.UI_ListBox.Size = new System.Drawing.Size(286, 160);
            this.UI_ListBox.TabIndex = 6;
            this.UI_ListBox.TabStop = false;
            this.UI_ListBox.Visible = false;
            // 
            // UI_TextBox_TestValueResult
            // 
            this.UI_TextBox_TestValueResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TextBox_TestValueResult.Location = new System.Drawing.Point(111, 109);
            this.UI_TextBox_TestValueResult.Name = "UI_TextBox_TestValueResult";
            this.UI_TextBox_TestValueResult.ReadOnly = true;
            this.UI_TextBox_TestValueResult.Size = new System.Drawing.Size(215, 20);
            this.UI_TextBox_TestValueResult.TabIndex = 1;
            this.UI_TextBox_TestValueResult.TabStop = false;
            // 
            // UI_TextBox_TestValue
            // 
            this.UI_TextBox_TestValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TextBox_TestValue.Location = new System.Drawing.Point(111, 81);
            this.UI_TextBox_TestValue.Name = "UI_TextBox_TestValue";
            this.UI_TextBox_TestValue.Size = new System.Drawing.Size(215, 20);
            this.UI_TextBox_TestValue.TabIndex = 0;
            // 
            // UI_TextBox_PalindromeCount
            // 
            this.UI_TextBox_PalindromeCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TextBox_PalindromeCount.Location = new System.Drawing.Point(153, 285);
            this.UI_TextBox_PalindromeCount.Name = "UI_TextBox_PalindromeCount";
            this.UI_TextBox_PalindromeCount.ReadOnly = true;
            this.UI_TextBox_PalindromeCount.Size = new System.Drawing.Size(210, 20);
            this.UI_TextBox_PalindromeCount.TabIndex = 3;
            this.UI_TextBox_PalindromeCount.TabStop = false;
            this.UI_TextBox_PalindromeCount.Visible = false;
            // 
            // UI_TextBox_ExecutionTime
            // 
            this.UI_TextBox_ExecutionTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TextBox_ExecutionTime.Location = new System.Drawing.Point(153, 313);
            this.UI_TextBox_ExecutionTime.Name = "UI_TextBox_ExecutionTime";
            this.UI_TextBox_ExecutionTime.ReadOnly = true;
            this.UI_TextBox_ExecutionTime.Size = new System.Drawing.Size(210, 20);
            this.UI_TextBox_ExecutionTime.TabIndex = 4;
            this.UI_TextBox_ExecutionTime.TabStop = false;
            this.UI_TextBox_ExecutionTime.Visible = false;
            // 
            // UI_Label_ExecutionTime
            // 
            this.UI_Label_ExecutionTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Label_ExecutionTime.AutoSize = true;
            this.UI_Label_ExecutionTime.Location = new System.Drawing.Point(45, 316);
            this.UI_Label_ExecutionTime.Name = "UI_Label_ExecutionTime";
            this.UI_Label_ExecutionTime.Size = new System.Drawing.Size(102, 13);
            this.UI_Label_ExecutionTime.TabIndex = 12;
            this.UI_Label_ExecutionTime.Text = "Execution Time (ms)";
            this.UI_Label_ExecutionTime.Visible = false;
            // 
            // UI_Label_PalindromeCountFromFile
            // 
            this.UI_Label_PalindromeCountFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Label_PalindromeCountFromFile.AutoSize = true;
            this.UI_Label_PalindromeCountFromFile.Location = new System.Drawing.Point(12, 288);
            this.UI_Label_PalindromeCountFromFile.Name = "UI_Label_PalindromeCountFromFile";
            this.UI_Label_PalindromeCountFromFile.Size = new System.Drawing.Size(135, 13);
            this.UI_Label_PalindromeCountFromFile.TabIndex = 11;
            this.UI_Label_PalindromeCountFromFile.Text = "Palindrome Count From File";
            this.UI_Label_PalindromeCountFromFile.Visible = false;
            // 
            // UI_Label_ListOfPalinDromesFromFile
            // 
            this.UI_Label_ListOfPalinDromesFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Label_ListOfPalinDromesFromFile.AutoSize = true;
            this.UI_Label_ListOfPalinDromesFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_Label_ListOfPalinDromesFromFile.Location = new System.Drawing.Point(390, 261);
            this.UI_Label_ListOfPalinDromesFromFile.Name = "UI_Label_ListOfPalinDromesFromFile";
            this.UI_Label_ListOfPalinDromesFromFile.Size = new System.Drawing.Size(282, 24);
            this.UI_Label_ListOfPalinDromesFromFile.TabIndex = 15;
            this.UI_Label_ListOfPalinDromesFromFile.Text = "List of Palindromes From File";
            this.UI_Label_ListOfPalinDromesFromFile.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 509);
            this.Controls.Add(this.UI_Label_ListOfPalinDromesFromFile);
            this.Controls.Add(this.UI_TextBox_PalindromeCount);
            this.Controls.Add(this.UI_TextBox_ExecutionTime);
            this.Controls.Add(this.UI_Label_ExecutionTime);
            this.Controls.Add(this.UI_Label_PalindromeCountFromFile);
            this.Controls.Add(this.UI_TextBox_TestValue);
            this.Controls.Add(this.UI_TextBox_TestValueResult);
            this.Controls.Add(this.UI_ListBox);
            this.Controls.Add(this.UI_Groupbox_CheckPalindrome);
            this.Controls.Add(this.UI_Button_FindPalindrome);
            this.Controls.Add(this.UI_Label_TestValueResult);
            this.Controls.Add(this.UI_Label_TestValue);
            this.Name = "Form1";
            this.Text = "Palindrome";
            this.UI_Groupbox_CheckPalindrome.ResumeLayout(false);
            this.UI_Groupbox_CheckPalindrome.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UI_Label_TestValue;
        private System.Windows.Forms.Label UI_Label_TestValueResult;
        private System.Windows.Forms.Button UI_Button_FindPalindrome;
        private System.Windows.Forms.GroupBox UI_Groupbox_CheckPalindrome;
        private System.Windows.Forms.RadioButton UI_RadioButton_File;
        private System.Windows.Forms.RadioButton UI_RadioButton_TextValue;
        private System.Windows.Forms.ListBox UI_ListBox;
        private System.Windows.Forms.TextBox UI_TextBox_TestValueResult;
        private System.Windows.Forms.TextBox UI_TextBox_TestValue;
        private System.Windows.Forms.TextBox UI_TextBox_PalindromeCount;
        private System.Windows.Forms.TextBox UI_TextBox_ExecutionTime;
        private System.Windows.Forms.Label UI_Label_ExecutionTime;
        private System.Windows.Forms.Label UI_Label_PalindromeCountFromFile;
        private System.Windows.Forms.Label UI_Label_ListOfPalinDromesFromFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

