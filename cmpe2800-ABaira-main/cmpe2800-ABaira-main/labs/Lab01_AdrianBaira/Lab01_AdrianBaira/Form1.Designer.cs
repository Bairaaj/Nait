namespace Lab01_AdrianBaira
{
    partial class ImagePress
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
            this.UI_LBL_ThreshHoldValue = new System.Windows.Forms.Label();
            this.UI_LBL_DragDropImagein = new System.Windows.Forms.Label();
            this.UI_TXT_ThreshHoldValue = new System.Windows.Forms.TextBox();
            this.UI_BTN_Reduce = new System.Windows.Forms.Button();
            this.UI_PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_LBL_ThreshHoldValue
            // 
            this.UI_LBL_ThreshHoldValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LBL_ThreshHoldValue.AutoSize = true;
            this.UI_LBL_ThreshHoldValue.Location = new System.Drawing.Point(445, 19);
            this.UI_LBL_ThreshHoldValue.Name = "UI_LBL_ThreshHoldValue";
            this.UI_LBL_ThreshHoldValue.Size = new System.Drawing.Size(132, 20);
            this.UI_LBL_ThreshHoldValue.TabIndex = 0;
            this.UI_LBL_ThreshHoldValue.Text = "Threshold Value: ";
            // 
            // UI_LBL_DragDropImagein
            // 
            this.UI_LBL_DragDropImagein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_LBL_DragDropImagein.AutoSize = true;
            this.UI_LBL_DragDropImagein.Location = new System.Drawing.Point(12, 570);
            this.UI_LBL_DragDropImagein.Name = "UI_LBL_DragDropImagein";
            this.UI_LBL_DragDropImagein.Size = new System.Drawing.Size(262, 20);
            this.UI_LBL_DragDropImagein.TabIndex = 1;
            this.UI_LBL_DragDropImagein.Text = "Drag and drop and image to begin...";
            // 
            // UI_TXT_ThreshHoldValue
            // 
            this.UI_TXT_ThreshHoldValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TXT_ThreshHoldValue.Location = new System.Drawing.Point(577, 16);
            this.UI_TXT_ThreshHoldValue.Name = "UI_TXT_ThreshHoldValue";
            this.UI_TXT_ThreshHoldValue.ReadOnly = true;
            this.UI_TXT_ThreshHoldValue.Size = new System.Drawing.Size(106, 26);
            this.UI_TXT_ThreshHoldValue.TabIndex = 2;
            this.UI_TXT_ThreshHoldValue.Text = "1";
            this.UI_TXT_ThreshHoldValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UI_BTN_Reduce
            // 
            this.UI_BTN_Reduce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_Reduce.Location = new System.Drawing.Point(689, 12);
            this.UI_BTN_Reduce.Name = "UI_BTN_Reduce";
            this.UI_BTN_Reduce.Size = new System.Drawing.Size(99, 34);
            this.UI_BTN_Reduce.TabIndex = 3;
            this.UI_BTN_Reduce.Text = "Reduce";
            this.UI_BTN_Reduce.UseVisualStyleBackColor = true;
            this.UI_BTN_Reduce.Click += new System.EventHandler(this.UI_BTN_Reduce_Click);
            // 
            // UI_PictureBox
            // 
            this.UI_PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_PictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UI_PictureBox.Location = new System.Drawing.Point(12, 66);
            this.UI_PictureBox.Name = "UI_PictureBox";
            this.UI_PictureBox.Size = new System.Drawing.Size(762, 478);
            this.UI_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UI_PictureBox.TabIndex = 4;
            this.UI_PictureBox.TabStop = false;
            this.UI_PictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.UI_PictureBox_DragDrop);
            this.UI_PictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.UI_PictureBox_DragEnter);
            // 
            // ImagePress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 610);
            this.Controls.Add(this.UI_PictureBox);
            this.Controls.Add(this.UI_BTN_Reduce);
            this.Controls.Add(this.UI_TXT_ThreshHoldValue);
            this.Controls.Add(this.UI_LBL_DragDropImagein);
            this.Controls.Add(this.UI_LBL_ThreshHoldValue);
            this.Name = "ImagePress";
            this.Text = "Image Press";
            ((System.ComponentModel.ISupportInitialize)(this.UI_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UI_LBL_ThreshHoldValue;
        private System.Windows.Forms.Label UI_LBL_DragDropImagein;
        private System.Windows.Forms.TextBox UI_TXT_ThreshHoldValue;
        private System.Windows.Forms.Button UI_BTN_Reduce;
        private System.Windows.Forms.PictureBox UI_PictureBox;
    }
}

