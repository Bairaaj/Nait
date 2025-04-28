namespace ica03_AdrianBaira
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
            this.UI_LBL_DropFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_LBL_DropFile
            // 
            this.UI_LBL_DropFile.AllowDrop = true;
            this.UI_LBL_DropFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LBL_DropFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UI_LBL_DropFile.Location = new System.Drawing.Point(12, 9);
            this.UI_LBL_DropFile.Name = "UI_LBL_DropFile";
            this.UI_LBL_DropFile.Size = new System.Drawing.Size(226, 164);
            this.UI_LBL_DropFile.TabIndex = 0;
            this.UI_LBL_DropFile.Text = "UI_LBL_DropFile";
            this.UI_LBL_DropFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UI_LBL_DropFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.UI_LBL_DropFile_DragDrop);
            this.UI_LBL_DropFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.UI_LBL_DropFile_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 182);
            this.Controls.Add(this.UI_LBL_DropFile);
            this.Name = "Form1";
            this.Text = "ICA03";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UI_LBL_DropFile;
    }
}

