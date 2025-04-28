namespace ICA05_AdrianBaira
{
    partial class UI_FORM
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
            this.UI_BTN_AddBlocks = new System.Windows.Forms.Button();
            this.UI_GroupBox_Sorttypes = new System.Windows.Forms.GroupBox();
            this.UI_RAD_ColSize = new System.Windows.Forms.RadioButton();
            this.UI_RAD_Color = new System.Windows.Forms.RadioButton();
            this.UI_RAD_Distance = new System.Windows.Forms.RadioButton();
            this.UI_RAD_Size = new System.Windows.Forms.RadioButton();
            this.UI_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.UI_GroupBox_Sorttypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_BTN_AddBlocks
            // 
            this.UI_BTN_AddBlocks.Location = new System.Drawing.Point(12, 12);
            this.UI_BTN_AddBlocks.Name = "UI_BTN_AddBlocks";
            this.UI_BTN_AddBlocks.Size = new System.Drawing.Size(375, 58);
            this.UI_BTN_AddBlocks.TabIndex = 0;
            this.UI_BTN_AddBlocks.Text = "Add Blocks (6)";
            this.UI_BTN_AddBlocks.UseVisualStyleBackColor = true;
            this.UI_BTN_AddBlocks.Click += new System.EventHandler(this.UI_BTN_AddBlocks_Click);
            this.UI_BTN_AddBlocks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_FORM_KeyDown);
            // 
            // UI_GroupBox_Sorttypes
            // 
            this.UI_GroupBox_Sorttypes.Controls.Add(this.UI_RAD_ColSize);
            this.UI_GroupBox_Sorttypes.Controls.Add(this.UI_RAD_Color);
            this.UI_GroupBox_Sorttypes.Controls.Add(this.UI_RAD_Distance);
            this.UI_GroupBox_Sorttypes.Controls.Add(this.UI_RAD_Size);
            this.UI_GroupBox_Sorttypes.Location = new System.Drawing.Point(12, 76);
            this.UI_GroupBox_Sorttypes.Name = "UI_GroupBox_Sorttypes";
            this.UI_GroupBox_Sorttypes.Size = new System.Drawing.Size(375, 74);
            this.UI_GroupBox_Sorttypes.TabIndex = 1;
            this.UI_GroupBox_Sorttypes.TabStop = false;
            this.UI_GroupBox_Sorttypes.Text = "Sort Type";
            // 
            // UI_RAD_ColSize
            // 
            this.UI_RAD_ColSize.AutoSize = true;
            this.UI_RAD_ColSize.Location = new System.Drawing.Point(261, 36);
            this.UI_RAD_ColSize.Name = "UI_RAD_ColSize";
            this.UI_RAD_ColSize.Size = new System.Drawing.Size(93, 17);
            this.UI_RAD_ColSize.TabIndex = 3;
            this.UI_RAD_ColSize.TabStop = true;
            this.UI_RAD_ColSize.Text = "Color and Size";
            this.UI_RAD_ColSize.UseVisualStyleBackColor = true;
            this.UI_RAD_ColSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_FORM_KeyDown);
            this.UI_RAD_ColSize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_RAD_Size_MouseClick);
            // 
            // UI_RAD_Color
            // 
            this.UI_RAD_Color.AutoSize = true;
            this.UI_RAD_Color.Location = new System.Drawing.Point(187, 36);
            this.UI_RAD_Color.Name = "UI_RAD_Color";
            this.UI_RAD_Color.Size = new System.Drawing.Size(49, 17);
            this.UI_RAD_Color.TabIndex = 2;
            this.UI_RAD_Color.TabStop = true;
            this.UI_RAD_Color.Text = "Color";
            this.UI_RAD_Color.UseVisualStyleBackColor = true;
            this.UI_RAD_Color.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_FORM_KeyDown);
            this.UI_RAD_Color.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_RAD_Size_MouseClick);
            // 
            // UI_RAD_Distance
            // 
            this.UI_RAD_Distance.AutoSize = true;
            this.UI_RAD_Distance.Location = new System.Drawing.Point(91, 36);
            this.UI_RAD_Distance.Name = "UI_RAD_Distance";
            this.UI_RAD_Distance.Size = new System.Drawing.Size(67, 17);
            this.UI_RAD_Distance.TabIndex = 1;
            this.UI_RAD_Distance.TabStop = true;
            this.UI_RAD_Distance.Text = "Distance";
            this.UI_RAD_Distance.UseVisualStyleBackColor = true;
            this.UI_RAD_Distance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_FORM_KeyDown);
            this.UI_RAD_Distance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_RAD_Size_MouseClick);
            // 
            // UI_RAD_Size
            // 
            this.UI_RAD_Size.AutoSize = true;
            this.UI_RAD_Size.Location = new System.Drawing.Point(17, 36);
            this.UI_RAD_Size.Name = "UI_RAD_Size";
            this.UI_RAD_Size.Size = new System.Drawing.Size(45, 17);
            this.UI_RAD_Size.TabIndex = 0;
            this.UI_RAD_Size.Text = "Size";
            this.UI_RAD_Size.UseVisualStyleBackColor = true;
            this.UI_RAD_Size.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_FORM_KeyDown);
            this.UI_RAD_Size.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_RAD_Size_MouseClick);
            // 
            // UI_ProgressBar
            // 
            this.UI_ProgressBar.Location = new System.Drawing.Point(12, 156);
            this.UI_ProgressBar.Name = "UI_ProgressBar";
            this.UI_ProgressBar.Size = new System.Drawing.Size(375, 23);
            this.UI_ProgressBar.TabIndex = 1;
            // 
            // UI_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 190);
            this.Controls.Add(this.UI_ProgressBar);
            this.Controls.Add(this.UI_GroupBox_Sorttypes);
            this.Controls.Add(this.UI_BTN_AddBlocks);
            this.Name = "UI_FORM";
            this.Text = "Blockz";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_FORM_KeyDown);
            this.UI_GroupBox_Sorttypes.ResumeLayout(false);
            this.UI_GroupBox_Sorttypes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_AddBlocks;
        private System.Windows.Forms.GroupBox UI_GroupBox_Sorttypes;
        private System.Windows.Forms.RadioButton UI_RAD_Color;
        private System.Windows.Forms.RadioButton UI_RAD_Distance;
        private System.Windows.Forms.RadioButton UI_RAD_Size;
        private System.Windows.Forms.ProgressBar UI_ProgressBar;
        private System.Windows.Forms.RadioButton UI_RAD_ColSize;
    }
}

