namespace ica04_AdrianBaira
{
    partial class ICA04
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
            this.UI_LBL_DropFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UI_LBL_DropFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UI_LBL_DropFile.Location = new System.Drawing.Point(12, 9);
            this.UI_LBL_DropFile.Name = "UI_LBL_DropFile";
            this.UI_LBL_DropFile.Size = new System.Drawing.Size(466, 251);
            this.UI_LBL_DropFile.TabIndex = 0;
            this.UI_LBL_DropFile.Text = "Drop File";
            this.UI_LBL_DropFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.UI_LBL_DropFile_DragDrop);
            this.UI_LBL_DropFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.UI_LBL_DropFile_DragEnter);
            // 
            // ICA04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 282);
            this.Controls.Add(this.UI_LBL_DropFile);
            this.Name = "ICA04";
            this.Text = "ICA04";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UI_LBL_DropFile;
    }
}

