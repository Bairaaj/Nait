
namespace Lab03_AdrianBaira
{
    partial class Score
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
            this.UI_LBL_Score = new System.Windows.Forms.Label();
            this.UI_LBL_Points = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_LBL_Score
            // 
            this.UI_LBL_Score.AutoSize = true;
            this.UI_LBL_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LBL_Score.Location = new System.Drawing.Point(31, 37);
            this.UI_LBL_Score.Name = "UI_LBL_Score";
            this.UI_LBL_Score.Size = new System.Drawing.Size(74, 25);
            this.UI_LBL_Score.TabIndex = 0;
            this.UI_LBL_Score.Text = "Score:";
            // 
            // UI_LBL_Points
            // 
            this.UI_LBL_Points.AutoSize = true;
            this.UI_LBL_Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LBL_Points.Location = new System.Drawing.Point(156, 37);
            this.UI_LBL_Points.Name = "UI_LBL_Points";
            this.UI_LBL_Points.Size = new System.Drawing.Size(60, 25);
            this.UI_LBL_Points.TabIndex = 1;
            this.UI_LBL_Points.Text = "0000";
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 100);
            this.Controls.Add(this.UI_LBL_Points);
            this.Controls.Add(this.UI_LBL_Score);
            this.Name = "Score";
            this.Text = "Score";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Score_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UI_LBL_Score;
        private System.Windows.Forms.Label UI_LBL_Points;
    }
}