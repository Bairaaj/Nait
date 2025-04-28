namespace ICA11_AdrianBaira
{
    partial class ICA10
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
            this.UI_DataGridView = new System.Windows.Forms.DataGridView();
            this.UI_PictureBox = new System.Windows.Forms.PictureBox();
            this.UI_BTN_AVG = new System.Windows.Forms.Button();
            this.UI_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_DataGridView
            // 
            this.UI_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DataGridView.Location = new System.Drawing.Point(12, 167);
            this.UI_DataGridView.Name = "UI_DataGridView";
            this.UI_DataGridView.Size = new System.Drawing.Size(275, 283);
            this.UI_DataGridView.TabIndex = 0;
            // 
            // UI_PictureBox
            // 
            this.UI_PictureBox.Location = new System.Drawing.Point(14, 13);
            this.UI_PictureBox.Name = "UI_PictureBox";
            this.UI_PictureBox.Size = new System.Drawing.Size(273, 107);
            this.UI_PictureBox.TabIndex = 1;
            this.UI_PictureBox.TabStop = false;
            this.UI_PictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.UI_PictureBox_DragDrop);
            this.UI_PictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.UI_PictureBox_DragEnter);
            // 
            // UI_BTN_AVG
            // 
            this.UI_BTN_AVG.Location = new System.Drawing.Point(13, 126);
            this.UI_BTN_AVG.Name = "UI_BTN_AVG";
            this.UI_BTN_AVG.Size = new System.Drawing.Size(274, 35);
            this.UI_BTN_AVG.TabIndex = 2;
            this.UI_BTN_AVG.Text = "Average: ";
            this.UI_BTN_AVG.UseVisualStyleBackColor = true;
            // 
            // ICA10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 550);
            this.Controls.Add(this.UI_BTN_AVG);
            this.Controls.Add(this.UI_PictureBox);
            this.Controls.Add(this.UI_DataGridView);
            this.Name = "ICA10";
            this.Text = "ICA 10: Pixel Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UI_DataGridView;
        private System.Windows.Forms.PictureBox UI_PictureBox;
        private System.Windows.Forms.Button UI_BTN_AVG;
        private System.Windows.Forms.BindingSource UI_BindingSource;
    }
}

