
namespace ICA15_AdrianBaira
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
            this.components = new System.ComponentModel.Container();
            this.UI_ListBox = new System.Windows.Forms.ListBox();
            this.UI_BTN_Go = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_ListBox
            // 
            this.UI_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_ListBox.FormattingEnabled = true;
            this.UI_ListBox.Location = new System.Drawing.Point(17, 18);
            this.UI_ListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UI_ListBox.Name = "UI_ListBox";
            this.UI_ListBox.Size = new System.Drawing.Size(726, 238);
            this.UI_ListBox.TabIndex = 0;
            // 
            // UI_BTN_Go
            // 
            this.UI_BTN_Go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_Go.Location = new System.Drawing.Point(659, 256);
            this.UI_BTN_Go.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UI_BTN_Go.Name = "UI_BTN_Go";
            this.UI_BTN_Go.Size = new System.Drawing.Size(84, 29);
            this.UI_BTN_Go.TabIndex = 1;
            this.UI_BTN_Go.Text = "Go!";
            this.UI_BTN_Go.UseVisualStyleBackColor = true;
            this.UI_BTN_Go.Click += new System.EventHandler(this.UI_BTN_Go_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 292);
            this.Controls.Add(this.UI_BTN_Go);
            this.Controls.Add(this.UI_ListBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox UI_ListBox;
        private System.Windows.Forms.Button UI_BTN_Go;
        private System.Windows.Forms.Timer timer1;
    }
}

