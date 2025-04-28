
namespace Lab03_AdrianBaira
{
    partial class AnimationSpeed
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
            this.UI_TrackBar = new System.Windows.Forms.TrackBar();
            this.UI_LBL_Left = new System.Windows.Forms.Label();
            this.UI_LBL_Right = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_TrackBar
            // 
            this.UI_TrackBar.Location = new System.Drawing.Point(12, 25);
            this.UI_TrackBar.Maximum = 400;
            this.UI_TrackBar.Minimum = 10;
            this.UI_TrackBar.Name = "UI_TrackBar";
            this.UI_TrackBar.Size = new System.Drawing.Size(389, 45);
            this.UI_TrackBar.TabIndex = 0;
            this.UI_TrackBar.TickFrequency = 10;
            this.UI_TrackBar.Value = 10;
            this.UI_TrackBar.Scroll += new System.EventHandler(this.UI_TrackBar_Scroll);
            // 
            // UI_LBL_Left
            // 
            this.UI_LBL_Left.AutoSize = true;
            this.UI_LBL_Left.Location = new System.Drawing.Point(12, 73);
            this.UI_LBL_Left.Name = "UI_LBL_Left";
            this.UI_LBL_Left.Size = new System.Drawing.Size(32, 13);
            this.UI_LBL_Left.TabIndex = 1;
            this.UI_LBL_Left.Text = "10ms";
            // 
            // UI_LBL_Right
            // 
            this.UI_LBL_Right.AutoSize = true;
            this.UI_LBL_Right.Location = new System.Drawing.Point(366, 73);
            this.UI_LBL_Right.Name = "UI_LBL_Right";
            this.UI_LBL_Right.Size = new System.Drawing.Size(38, 13);
            this.UI_LBL_Right.TabIndex = 2;
            this.UI_LBL_Right.Text = "200ms";
            // 
            // AnimationSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 104);
            this.Controls.Add(this.UI_LBL_Right);
            this.Controls.Add(this.UI_LBL_Left);
            this.Controls.Add(this.UI_TrackBar);
            this.Name = "AnimationSpeed";
            this.Text = "Animation Speed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnimationSpeed_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar UI_TrackBar;
        private System.Windows.Forms.Label UI_LBL_Left;
        private System.Windows.Forms.Label UI_LBL_Right;
    }
}