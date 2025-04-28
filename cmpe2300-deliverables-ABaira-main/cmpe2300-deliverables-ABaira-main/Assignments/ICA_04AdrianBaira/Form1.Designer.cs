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
            this.SuspendLayout();
            // 
            // UI_ProgressBar
            // 
            this.UI_ProgressBar.Location = new System.Drawing.Point(12, 85);
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
            this.UI_BTN_Add.Size = new System.Drawing.Size(391, 67);
            this.UI_BTN_Add.TabIndex = 1;
            this.UI_BTN_Add.Text = "Add Balls : Size 1";
            this.UI_BTN_Add.UseVisualStyleBackColor = true;
            this.UI_BTN_Add.Click += new System.EventHandler(this.UI_BTN_Add_Click);
            this.UI_BTN_Add.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UI_BTN_Add_KeyDown);
            this.UI_BTN_Add.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_Form_MouseClick);
            // 
            // UI_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 127);
            this.Controls.Add(this.UI_BTN_Add);
            this.Controls.Add(this.UI_ProgressBar);
            this.Name = "UI_Form";
            this.Text = "Equals Balls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar UI_ProgressBar;
        private System.Windows.Forms.Button UI_BTN_Add;
    }
}

