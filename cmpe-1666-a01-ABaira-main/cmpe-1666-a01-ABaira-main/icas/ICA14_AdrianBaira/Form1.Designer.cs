
namespace ICA14_AdrianBaira
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
            this.UI_BTN_LoadFile = new System.Windows.Forms.Button();
            this.UI_TXT_SimpleTest = new System.Windows.Forms.TextBox();
            this.UI_BTN_Find = new System.Windows.Forms.Button();
            this.UI_BTN_SimpleTest = new System.Windows.Forms.Button();
            this.UI_TXT_Palindromes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UI_BTN_LoadFile
            // 
            this.UI_BTN_LoadFile.Location = new System.Drawing.Point(45, 35);
            this.UI_BTN_LoadFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_BTN_LoadFile.Name = "UI_BTN_LoadFile";
            this.UI_BTN_LoadFile.Size = new System.Drawing.Size(135, 35);
            this.UI_BTN_LoadFile.TabIndex = 0;
            this.UI_BTN_LoadFile.Text = "Load File";
            this.UI_BTN_LoadFile.UseVisualStyleBackColor = true;
            this.UI_BTN_LoadFile.Click += new System.EventHandler(this.UI_BTN_LoadFile_Click);
            // 
            // UI_TXT_SimpleTest
            // 
            this.UI_TXT_SimpleTest.Location = new System.Drawing.Point(357, 35);
            this.UI_TXT_SimpleTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_TXT_SimpleTest.Name = "UI_TXT_SimpleTest";
            this.UI_TXT_SimpleTest.Size = new System.Drawing.Size(571, 26);
            this.UI_TXT_SimpleTest.TabIndex = 2;
            this.UI_TXT_SimpleTest.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_TXT_SimpleTest_MouseClick);
            // 
            // UI_BTN_Find
            // 
            this.UI_BTN_Find.Location = new System.Drawing.Point(196, 35);
            this.UI_BTN_Find.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_BTN_Find.Name = "UI_BTN_Find";
            this.UI_BTN_Find.Size = new System.Drawing.Size(135, 35);
            this.UI_BTN_Find.TabIndex = 1;
            this.UI_BTN_Find.Text = "Find";
            this.UI_BTN_Find.UseVisualStyleBackColor = true;
            this.UI_BTN_Find.Click += new System.EventHandler(this.UI_BTN_Find_Click);
            // 
            // UI_BTN_SimpleTest
            // 
            this.UI_BTN_SimpleTest.Location = new System.Drawing.Point(982, 35);
            this.UI_BTN_SimpleTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_BTN_SimpleTest.Name = "UI_BTN_SimpleTest";
            this.UI_BTN_SimpleTest.Size = new System.Drawing.Size(135, 35);
            this.UI_BTN_SimpleTest.TabIndex = 3;
            this.UI_BTN_SimpleTest.Text = "Simple Test";
            this.UI_BTN_SimpleTest.UseVisualStyleBackColor = true;
            this.UI_BTN_SimpleTest.Click += new System.EventHandler(this.UI_BTN_SimpleTest_Click);
            // 
            // UI_TXT_Palindromes
            // 
            this.UI_TXT_Palindromes.Location = new System.Drawing.Point(45, 100);
            this.UI_TXT_Palindromes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_TXT_Palindromes.Multiline = true;
            this.UI_TXT_Palindromes.Name = "UI_TXT_Palindromes";
            this.UI_TXT_Palindromes.ReadOnly = true;
            this.UI_TXT_Palindromes.Size = new System.Drawing.Size(1070, 392);
            this.UI_TXT_Palindromes.TabIndex = 4;
            this.UI_TXT_Palindromes.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 552);
            this.Controls.Add(this.UI_TXT_Palindromes);
            this.Controls.Add(this.UI_BTN_SimpleTest);
            this.Controls.Add(this.UI_BTN_Find);
            this.Controls.Add(this.UI_TXT_SimpleTest);
            this.Controls.Add(this.UI_BTN_LoadFile);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1207, 608);
            this.MinimumSize = new System.Drawing.Size(1207, 608);
            this.Name = "Form1";
            this.Text = "Pally Hunter!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_LoadFile;
        private System.Windows.Forms.TextBox UI_TXT_SimpleTest;
        private System.Windows.Forms.Button UI_BTN_Find;
        private System.Windows.Forms.Button UI_BTN_SimpleTest;
        private System.Windows.Forms.TextBox UI_TXT_Palindromes;
    }
}

