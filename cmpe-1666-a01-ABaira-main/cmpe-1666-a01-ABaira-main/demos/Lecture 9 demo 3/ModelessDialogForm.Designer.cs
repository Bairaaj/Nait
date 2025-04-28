namespace Lecture_9_demo_3
{
    partial class ModelessDialogForm
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
            this.UI_Textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UI_Textbox
            // 
            this.UI_Textbox.Location = new System.Drawing.Point(12, 44);
            this.UI_Textbox.Name = "UI_Textbox";
            this.UI_Textbox.Size = new System.Drawing.Size(386, 20);
            this.UI_Textbox.TabIndex = 0;
            this.UI_Textbox.TextChanged += new System.EventHandler(this.UI_Textbox_TextChanged);
            // 
            // ModelessDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 105);
            this.Controls.Add(this.UI_Textbox);
            this.Name = "ModelessDialogForm";
            this.Text = "ModelessDialogForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelessDialogForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UI_Textbox;
    }
}