namespace ICA09_AdrianBaira
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
            this.UI_Button_AddName = new System.Windows.Forms.Button();
            this.UI_Button_Search = new System.Windows.Forms.Button();
            this.UI_ListBox_ListOfNamesOrderOfEntry = new System.Windows.Forms.ListBox();
            this.UI_Label_ListOfNamesOrderOfEntry = new System.Windows.Forms.Label();
            this.UI_Label_ListOfNamesSorted = new System.Windows.Forms.Label();
            this.UI_Label_Name = new System.Windows.Forms.Label();
            this.UI_TextBox = new System.Windows.Forms.TextBox();
            this.UI_ListBox_ListOfNamesSorted = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // UI_Button_AddName
            // 
            this.UI_Button_AddName.Location = new System.Drawing.Point(458, 155);
            this.UI_Button_AddName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_Button_AddName.Name = "UI_Button_AddName";
            this.UI_Button_AddName.Size = new System.Drawing.Size(196, 75);
            this.UI_Button_AddName.TabIndex = 1;
            this.UI_Button_AddName.Text = "Add Name";
            this.UI_Button_AddName.UseVisualStyleBackColor = true;
            this.UI_Button_AddName.Click += new System.EventHandler(this.UI_Button_AddName_Click);
            // 
            // UI_Button_Search
            // 
            this.UI_Button_Search.Location = new System.Drawing.Point(458, 263);
            this.UI_Button_Search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_Button_Search.Name = "UI_Button_Search";
            this.UI_Button_Search.Size = new System.Drawing.Size(196, 75);
            this.UI_Button_Search.TabIndex = 2;
            this.UI_Button_Search.Text = "Search";
            this.UI_Button_Search.UseVisualStyleBackColor = true;
            this.UI_Button_Search.Click += new System.EventHandler(this.UI_Button_Search_Click);
            // 
            // UI_ListBox_ListOfNamesOrderOfEntry
            // 
            this.UI_ListBox_ListOfNamesOrderOfEntry.FormattingEnabled = true;
            this.UI_ListBox_ListOfNamesOrderOfEntry.ItemHeight = 20;
            this.UI_ListBox_ListOfNamesOrderOfEntry.Location = new System.Drawing.Point(54, 74);
            this.UI_ListBox_ListOfNamesOrderOfEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_ListBox_ListOfNamesOrderOfEntry.Name = "UI_ListBox_ListOfNamesOrderOfEntry";
            this.UI_ListBox_ListOfNamesOrderOfEntry.Size = new System.Drawing.Size(312, 344);
            this.UI_ListBox_ListOfNamesOrderOfEntry.TabIndex = 2;
            this.UI_ListBox_ListOfNamesOrderOfEntry.TabStop = false;
            // 
            // UI_Label_ListOfNamesOrderOfEntry
            // 
            this.UI_Label_ListOfNamesOrderOfEntry.AutoSize = true;
            this.UI_Label_ListOfNamesOrderOfEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_Label_ListOfNamesOrderOfEntry.Location = new System.Drawing.Point(50, 49);
            this.UI_Label_ListOfNamesOrderOfEntry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_Label_ListOfNamesOrderOfEntry.Name = "UI_Label_ListOfNamesOrderOfEntry";
            this.UI_Label_ListOfNamesOrderOfEntry.Size = new System.Drawing.Size(305, 25);
            this.UI_Label_ListOfNamesOrderOfEntry.TabIndex = 4;
            this.UI_Label_ListOfNamesOrderOfEntry.Text = "List Of Names (Order of Entry)";
            // 
            // UI_Label_ListOfNamesSorted
            // 
            this.UI_Label_ListOfNamesSorted.AutoSize = true;
            this.UI_Label_ListOfNamesSorted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_Label_ListOfNamesSorted.Location = new System.Drawing.Point(806, 49);
            this.UI_Label_ListOfNamesSorted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_Label_ListOfNamesSorted.Name = "UI_Label_ListOfNamesSorted";
            this.UI_Label_ListOfNamesSorted.Size = new System.Drawing.Size(229, 25);
            this.UI_Label_ListOfNamesSorted.TabIndex = 5;
            this.UI_Label_ListOfNamesSorted.Text = "List of Names (Sorted)";
            // 
            // UI_Label_Name
            // 
            this.UI_Label_Name.AutoSize = true;
            this.UI_Label_Name.Location = new System.Drawing.Point(376, 74);
            this.UI_Label_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_Label_Name.Name = "UI_Label_Name";
            this.UI_Label_Name.Size = new System.Drawing.Size(55, 20);
            this.UI_Label_Name.TabIndex = 6;
            this.UI_Label_Name.Text = "Name:";
            // 
            // UI_TextBox
            // 
            this.UI_TextBox.Location = new System.Drawing.Point(442, 74);
            this.UI_TextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_TextBox.Name = "UI_TextBox";
            this.UI_TextBox.Size = new System.Drawing.Size(283, 26);
            this.UI_TextBox.TabIndex = 0;
            // 
            // UI_ListBox_ListOfNamesSorted
            // 
            this.UI_ListBox_ListOfNamesSorted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_ListBox_ListOfNamesSorted.FormattingEnabled = true;
            this.UI_ListBox_ListOfNamesSorted.ItemHeight = 20;
            this.UI_ListBox_ListOfNamesSorted.Location = new System.Drawing.Point(764, 74);
            this.UI_ListBox_ListOfNamesSorted.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_ListBox_ListOfNamesSorted.Name = "UI_ListBox_ListOfNamesSorted";
            this.UI_ListBox_ListOfNamesSorted.Size = new System.Drawing.Size(312, 344);
            this.UI_ListBox_ListOfNamesSorted.TabIndex = 8;
            this.UI_ListBox_ListOfNamesSorted.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 511);
            this.Controls.Add(this.UI_ListBox_ListOfNamesSorted);
            this.Controls.Add(this.UI_TextBox);
            this.Controls.Add(this.UI_Label_Name);
            this.Controls.Add(this.UI_Label_ListOfNamesSorted);
            this.Controls.Add(this.UI_Label_ListOfNamesOrderOfEntry);
            this.Controls.Add(this.UI_ListBox_ListOfNamesOrderOfEntry);
            this.Controls.Add(this.UI_Button_Search);
            this.Controls.Add(this.UI_Button_AddName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_Button_AddName;
        private System.Windows.Forms.Button UI_Button_Search;
        private System.Windows.Forms.ListBox UI_ListBox_ListOfNamesOrderOfEntry;
        private System.Windows.Forms.Label UI_Label_ListOfNamesOrderOfEntry;
        private System.Windows.Forms.Label UI_Label_ListOfNamesSorted;
        private System.Windows.Forms.Label UI_Label_Name;
        private System.Windows.Forms.TextBox UI_TextBox;
        private System.Windows.Forms.ListBox UI_ListBox_ListOfNamesSorted;
    }
}

