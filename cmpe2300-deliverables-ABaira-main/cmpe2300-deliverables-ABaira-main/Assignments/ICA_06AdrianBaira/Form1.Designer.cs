namespace ICA_04AdrianBaira
{
    partial class UI_Form
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
            this.UI_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.UI_BTN_Add = new System.Windows.Forms.Button();
            this.UI_RAD_Color = new System.Windows.Forms.RadioButton();
            this.UI_RAD_Distance = new System.Windows.Forms.RadioButton();
            this.UI_RAD_Radius = new System.Windows.Forms.RadioButton();
            this.UI_GroupBox = new System.Windows.Forms.GroupBox();
            this.UI_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_ProgressBar
            // 
            this.UI_ProgressBar.Location = new System.Drawing.Point(12, 152);
            this.UI_ProgressBar.Maximum = 1000;
            this.UI_ProgressBar.Name = "UI_ProgressBar";
            this.UI_ProgressBar.Size = new System.Drawing.Size(391, 23);
            this.UI_ProgressBar.Step = 1;
            this.UI_ProgressBar.TabIndex = 0;
            // 
            // UI_BTN_Add
            // 
            this.UI_BTN_Add.Location = new System.Drawing.Point(12, 12);
            this.UI_BTN_Add.Name = "UI_BTN_Add";
            this.UI_BTN_Add.Size = new System.Drawing.Size(391, 59);
            this.UI_BTN_Add.TabIndex = 1;
            this.UI_BTN_Add.Text = "Add Balls : Size 1";
            this.UI_BTN_Add.UseVisualStyleBackColor = true;
            this.UI_BTN_Add.Click += new System.EventHandler(this.UI_BTN_Add_Click);
            this.UI_BTN_Add.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UI_GroupBox_PreviewKeyDown);
            // 
            // UI_RAD_Color
            // 
            this.UI_RAD_Color.AutoSize = true;
            this.UI_RAD_Color.Location = new System.Drawing.Point(299, 29);
            this.UI_RAD_Color.Name = "UI_RAD_Color";
            this.UI_RAD_Color.Size = new System.Drawing.Size(49, 17);
            this.UI_RAD_Color.TabIndex = 2;
            this.UI_RAD_Color.TabStop = true;
            this.UI_RAD_Color.Text = "Color";
            this.UI_RAD_Color.UseVisualStyleBackColor = true;
            this.UI_RAD_Color.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UI_GroupBox_PreviewKeyDown);
            // 
            // UI_RAD_Distance
            // 
            this.UI_RAD_Distance.AutoSize = true;
            this.UI_RAD_Distance.Location = new System.Drawing.Point(164, 29);
            this.UI_RAD_Distance.Name = "UI_RAD_Distance";
            this.UI_RAD_Distance.Size = new System.Drawing.Size(67, 17);
            this.UI_RAD_Distance.TabIndex = 1;
            this.UI_RAD_Distance.TabStop = true;
            this.UI_RAD_Distance.Text = "Distance";
            this.UI_RAD_Distance.UseVisualStyleBackColor = true;
            this.UI_RAD_Distance.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UI_GroupBox_PreviewKeyDown);
            // 
            // UI_RAD_Radius
            // 
            this.UI_RAD_Radius.AutoSize = true;
            this.UI_RAD_Radius.Location = new System.Drawing.Point(32, 29);
            this.UI_RAD_Radius.Name = "UI_RAD_Radius";
            this.UI_RAD_Radius.Size = new System.Drawing.Size(58, 17);
            this.UI_RAD_Radius.TabIndex = 0;
            this.UI_RAD_Radius.TabStop = true;
            this.UI_RAD_Radius.Text = "Radius";
            this.UI_RAD_Radius.UseVisualStyleBackColor = true;
            this.UI_RAD_Radius.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UI_GroupBox_PreviewKeyDown);
            // 
            // UI_GroupBox
            // 
            this.UI_GroupBox.Controls.Add(this.UI_RAD_Color);
            this.UI_GroupBox.Controls.Add(this.UI_RAD_Distance);
            this.UI_GroupBox.Controls.Add(this.UI_RAD_Radius);
            this.UI_GroupBox.Location = new System.Drawing.Point(12, 77);
            this.UI_GroupBox.Name = "UI_GroupBox";
            this.UI_GroupBox.Size = new System.Drawing.Size(391, 69);
            this.UI_GroupBox.TabIndex = 2;
            this.UI_GroupBox.TabStop = false;
            this.UI_GroupBox.Text = "Sort Type";
            this.UI_GroupBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UI_GroupBox_PreviewKeyDown);
            // 
            // UI_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 187);
            this.Controls.Add(this.UI_GroupBox);
            this.Controls.Add(this.UI_BTN_Add);
            this.Controls.Add(this.UI_ProgressBar);
            this.Name = "UI_Form";
            this.Text = "Equals Balls";
            this.UI_GroupBox.ResumeLayout(false);
            this.UI_GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar UI_ProgressBar;
        private System.Windows.Forms.Button UI_BTN_Add;
        private System.Windows.Forms.RadioButton UI_RAD_Color;
        private System.Windows.Forms.RadioButton UI_RAD_Distance;
        private System.Windows.Forms.RadioButton UI_RAD_Radius;
        private System.Windows.Forms.GroupBox UI_GroupBox;
    }
}

