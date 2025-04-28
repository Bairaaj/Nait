
namespace ICA10_AdrianBaira
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
            this.UI_TextBox_NumberofValues = new System.Windows.Forms.TextBox();
            this.UI_TextBox_MinimumValues = new System.Windows.Forms.TextBox();
            this.UI_TextBox_MaximumValues = new System.Windows.Forms.TextBox();
            this.UI_TextBox_SortingTime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UI_RadioButton_QuickSort = new System.Windows.Forms.RadioButton();
            this.UI_RadioButton_SelectionSort = new System.Windows.Forms.RadioButton();
            this.UI_Button_GenerateValues = new System.Windows.Forms.Button();
            this.UI_Button_SortValues = new System.Windows.Forms.Button();
            this.UI_Button_ClearRaw = new System.Windows.Forms.Button();
            this.UI_Button_Redisplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UI_Button_ClearSorted = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.UI_TextBox_SortedValues = new System.Windows.Forms.TextBox();
            this.UI_TextBox_GeneratedValues = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_TextBox_NumberofValues
            // 
            this.UI_TextBox_NumberofValues.Location = new System.Drawing.Point(466, 32);
            this.UI_TextBox_NumberofValues.Name = "UI_TextBox_NumberofValues";
            this.UI_TextBox_NumberofValues.Size = new System.Drawing.Size(90, 20);
            this.UI_TextBox_NumberofValues.TabIndex = 0;
            // 
            // UI_TextBox_MinimumValues
            // 
            this.UI_TextBox_MinimumValues.Location = new System.Drawing.Point(466, 63);
            this.UI_TextBox_MinimumValues.Name = "UI_TextBox_MinimumValues";
            this.UI_TextBox_MinimumValues.Size = new System.Drawing.Size(90, 20);
            this.UI_TextBox_MinimumValues.TabIndex = 1;
            // 
            // UI_TextBox_MaximumValues
            // 
            this.UI_TextBox_MaximumValues.Location = new System.Drawing.Point(466, 99);
            this.UI_TextBox_MaximumValues.Name = "UI_TextBox_MaximumValues";
            this.UI_TextBox_MaximumValues.Size = new System.Drawing.Size(90, 20);
            this.UI_TextBox_MaximumValues.TabIndex = 2;
            // 
            // UI_TextBox_SortingTime
            // 
            this.UI_TextBox_SortingTime.Location = new System.Drawing.Point(466, 400);
            this.UI_TextBox_SortingTime.Name = "UI_TextBox_SortingTime";
            this.UI_TextBox_SortingTime.ReadOnly = true;
            this.UI_TextBox_SortingTime.Size = new System.Drawing.Size(90, 20);
            this.UI_TextBox_SortingTime.TabIndex = 5;
            this.UI_TextBox_SortingTime.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UI_RadioButton_QuickSort);
            this.groupBox1.Controls.Add(this.UI_RadioButton_SelectionSort);
            this.groupBox1.Location = new System.Drawing.Point(372, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 178);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sorting Method";
            // 
            // UI_RadioButton_QuickSort
            // 
            this.UI_RadioButton_QuickSort.AutoSize = true;
            this.UI_RadioButton_QuickSort.Location = new System.Drawing.Point(31, 107);
            this.UI_RadioButton_QuickSort.Name = "UI_RadioButton_QuickSort";
            this.UI_RadioButton_QuickSort.Size = new System.Drawing.Size(75, 17);
            this.UI_RadioButton_QuickSort.TabIndex = 1;
            this.UI_RadioButton_QuickSort.Text = "Quick Sort";
            this.UI_RadioButton_QuickSort.UseVisualStyleBackColor = true;
            // 
            // UI_RadioButton_SelectionSort
            // 
            this.UI_RadioButton_SelectionSort.AutoSize = true;
            this.UI_RadioButton_SelectionSort.Checked = true;
            this.UI_RadioButton_SelectionSort.Location = new System.Drawing.Point(31, 59);
            this.UI_RadioButton_SelectionSort.Name = "UI_RadioButton_SelectionSort";
            this.UI_RadioButton_SelectionSort.Size = new System.Drawing.Size(91, 17);
            this.UI_RadioButton_SelectionSort.TabIndex = 0;
            this.UI_RadioButton_SelectionSort.TabStop = true;
            this.UI_RadioButton_SelectionSort.Text = "Selection Sort";
            this.UI_RadioButton_SelectionSort.UseVisualStyleBackColor = true;
            // 
            // UI_Button_GenerateValues
            // 
            this.UI_Button_GenerateValues.Location = new System.Drawing.Point(420, 141);
            this.UI_Button_GenerateValues.Name = "UI_Button_GenerateValues";
            this.UI_Button_GenerateValues.Size = new System.Drawing.Size(99, 29);
            this.UI_Button_GenerateValues.TabIndex = 3;
            this.UI_Button_GenerateValues.Text = "Generate Values";
            this.UI_Button_GenerateValues.UseVisualStyleBackColor = true;
            this.UI_Button_GenerateValues.Click += new System.EventHandler(this.UI_Button_GenerateValues_Click);
            // 
            // UI_Button_SortValues
            // 
            this.UI_Button_SortValues.Location = new System.Drawing.Point(420, 360);
            this.UI_Button_SortValues.Name = "UI_Button_SortValues";
            this.UI_Button_SortValues.Size = new System.Drawing.Size(99, 29);
            this.UI_Button_SortValues.TabIndex = 5;
            this.UI_Button_SortValues.Text = "Sort Values";
            this.UI_Button_SortValues.UseVisualStyleBackColor = true;
            this.UI_Button_SortValues.Click += new System.EventHandler(this.UI_Button_SortValues_Click);
            // 
            // UI_Button_ClearRaw
            // 
            this.UI_Button_ClearRaw.Location = new System.Drawing.Point(38, 430);
            this.UI_Button_ClearRaw.Name = "UI_Button_ClearRaw";
            this.UI_Button_ClearRaw.Size = new System.Drawing.Size(99, 29);
            this.UI_Button_ClearRaw.TabIndex = 6;
            this.UI_Button_ClearRaw.Text = "Clear Raw";
            this.UI_Button_ClearRaw.UseVisualStyleBackColor = true;
            this.UI_Button_ClearRaw.Click += new System.EventHandler(this.UI_Button_ClearRaw_Click);
            // 
            // UI_Button_Redisplay
            // 
            this.UI_Button_Redisplay.Location = new System.Drawing.Point(143, 430);
            this.UI_Button_Redisplay.Name = "UI_Button_Redisplay";
            this.UI_Button_Redisplay.Size = new System.Drawing.Size(99, 29);
            this.UI_Button_Redisplay.TabIndex = 7;
            this.UI_Button_Redisplay.Text = "Redisplay";
            this.UI_Button_Redisplay.UseVisualStyleBackColor = true;
            this.UI_Button_Redisplay.Click += new System.EventHandler(this.UI_Button_Redisplay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Number of Values:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Minimum Value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Maximum Value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Sorting time (ticks):";
            // 
            // UI_Button_ClearSorted
            // 
            this.UI_Button_ClearSorted.Location = new System.Drawing.Point(782, 430);
            this.UI_Button_ClearSorted.Name = "UI_Button_ClearSorted";
            this.UI_Button_ClearSorted.Size = new System.Drawing.Size(99, 29);
            this.UI_Button_ClearSorted.TabIndex = 8;
            this.UI_Button_ClearSorted.Text = "Clear Sorted";
            this.UI_Button_ClearSorted.UseVisualStyleBackColor = true;
            this.UI_Button_ClearSorted.Click += new System.EventHandler(this.UI_Button_ClearSorted_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(125, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Generated Values";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(767, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "Sorted Values";
            // 
            // UI_TextBox_SortedValues
            // 
            this.UI_TextBox_SortedValues.Location = new System.Drawing.Point(675, 73);
            this.UI_TextBox_SortedValues.Multiline = true;
            this.UI_TextBox_SortedValues.Name = "UI_TextBox_SortedValues";
            this.UI_TextBox_SortedValues.ReadOnly = true;
            this.UI_TextBox_SortedValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UI_TextBox_SortedValues.Size = new System.Drawing.Size(294, 351);
            this.UI_TextBox_SortedValues.TabIndex = 19;
            this.UI_TextBox_SortedValues.TabStop = false;
            // 
            // UI_TextBox_GeneratedValues
            // 
            this.UI_TextBox_GeneratedValues.Location = new System.Drawing.Point(38, 73);
            this.UI_TextBox_GeneratedValues.Multiline = true;
            this.UI_TextBox_GeneratedValues.Name = "UI_TextBox_GeneratedValues";
            this.UI_TextBox_GeneratedValues.ReadOnly = true;
            this.UI_TextBox_GeneratedValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UI_TextBox_GeneratedValues.Size = new System.Drawing.Size(294, 351);
            this.UI_TextBox_GeneratedValues.TabIndex = 20;
            this.UI_TextBox_GeneratedValues.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 497);
            this.Controls.Add(this.UI_TextBox_GeneratedValues);
            this.Controls.Add(this.UI_TextBox_SortedValues);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UI_Button_ClearSorted);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UI_Button_Redisplay);
            this.Controls.Add(this.UI_Button_ClearRaw);
            this.Controls.Add(this.UI_Button_SortValues);
            this.Controls.Add(this.UI_Button_GenerateValues);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UI_TextBox_SortingTime);
            this.Controls.Add(this.UI_TextBox_MaximumValues);
            this.Controls.Add(this.UI_TextBox_MinimumValues);
            this.Controls.Add(this.UI_TextBox_NumberofValues);
            this.Name = "Form1";
            this.Text = "ICA 10 Adrian Baira";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox UI_TextBox_NumberofValues;
        private System.Windows.Forms.TextBox UI_TextBox_MinimumValues;
        private System.Windows.Forms.TextBox UI_TextBox_MaximumValues;
        private System.Windows.Forms.TextBox UI_TextBox_SortingTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton UI_RadioButton_QuickSort;
        private System.Windows.Forms.RadioButton UI_RadioButton_SelectionSort;
        private System.Windows.Forms.Button UI_Button_GenerateValues;
        private System.Windows.Forms.Button UI_Button_SortValues;
        private System.Windows.Forms.Button UI_Button_ClearRaw;
        private System.Windows.Forms.Button UI_Button_Redisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button UI_Button_ClearSorted;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox UI_TextBox_SortedValues;
        private System.Windows.Forms.TextBox UI_TextBox_GeneratedValues;
    }
}

