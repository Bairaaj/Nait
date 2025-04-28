
namespace ICA11_AdrianBaira
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
            this.UI_LABEL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_LABEL
            // 
            this.UI_LABEL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UI_LABEL.Location = new System.Drawing.Point(0, 0);
            this.UI_LABEL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UI_LABEL.Name = "UI_LABEL";
            this.UI_LABEL.Size = new System.Drawing.Size(588, 353);
            this.UI_LABEL.TabIndex = 0;
            this.UI_LABEL.Text = "Adrian Baira ICA 11 Fontify";
            this.UI_LABEL.Click += new System.EventHandler(this.UI_LABEL_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 353);
            this.Controls.Add(this.UI_LABEL);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UI_LABEL;
    }
}

