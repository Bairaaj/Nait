namespace ICA13_AdrianB
{
    partial class ColorOpacity
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UI_TrackBar_Blue = new System.Windows.Forms.TrackBar();
            this.UI_TrackBar_Green = new System.Windows.Forms.TrackBar();
            this.UI_TrackBar_red = new System.Windows.Forms.TrackBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UI_TrackBar_Opacity = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar_red)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar_Opacity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UI_TrackBar_Blue);
            this.groupBox1.Controls.Add(this.UI_TrackBar_Green);
            this.groupBox1.Controls.Add(this.UI_TrackBar_red);
            this.groupBox1.Location = new System.Drawing.Point(32, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colour";
            // 
            // UI_TrackBar_Blue
            // 
            this.UI_TrackBar_Blue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.UI_TrackBar_Blue.Location = new System.Drawing.Point(6, 130);
            this.UI_TrackBar_Blue.Maximum = 255;
            this.UI_TrackBar_Blue.Name = "UI_TrackBar_Blue";
            this.UI_TrackBar_Blue.Size = new System.Drawing.Size(722, 45);
            this.UI_TrackBar_Blue.TabIndex = 2;
            this.UI_TrackBar_Blue.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.UI_TrackBar_Blue.Scroll += new System.EventHandler(this.UI_TrackBar_red_Scroll);
            // 
            // UI_TrackBar_Green
            // 
            this.UI_TrackBar_Green.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.UI_TrackBar_Green.Location = new System.Drawing.Point(6, 70);
            this.UI_TrackBar_Green.Maximum = 255;
            this.UI_TrackBar_Green.Name = "UI_TrackBar_Green";
            this.UI_TrackBar_Green.Size = new System.Drawing.Size(722, 45);
            this.UI_TrackBar_Green.TabIndex = 1;
            this.UI_TrackBar_Green.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.UI_TrackBar_Green.Scroll += new System.EventHandler(this.UI_TrackBar_red_Scroll);
            // 
            // UI_TrackBar_red
            // 
            this.UI_TrackBar_red.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.UI_TrackBar_red.Location = new System.Drawing.Point(6, 19);
            this.UI_TrackBar_red.Maximum = 255;
            this.UI_TrackBar_red.Name = "UI_TrackBar_red";
            this.UI_TrackBar_red.Size = new System.Drawing.Size(722, 45);
            this.UI_TrackBar_red.TabIndex = 0;
            this.UI_TrackBar_red.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.UI_TrackBar_red.Scroll += new System.EventHandler(this.UI_TrackBar_red_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UI_TrackBar_Opacity);
            this.groupBox2.Location = new System.Drawing.Point(32, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 98);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opacity";
            // 
            // UI_TrackBar_Opacity
            // 
            this.UI_TrackBar_Opacity.BackColor = System.Drawing.Color.Silver;
            this.UI_TrackBar_Opacity.Location = new System.Drawing.Point(6, 19);
            this.UI_TrackBar_Opacity.Maximum = 100;
            this.UI_TrackBar_Opacity.Name = "UI_TrackBar_Opacity";
            this.UI_TrackBar_Opacity.Size = new System.Drawing.Size(722, 45);
            this.UI_TrackBar_Opacity.TabIndex = 3;
            this.UI_TrackBar_Opacity.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.UI_TrackBar_Opacity.Value = 100;
            this.UI_TrackBar_Opacity.Scroll += new System.EventHandler(this.UI_TrackBar_red_Scroll);
            // 
            // ColorOpacity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 364);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ColorOpacity";
            this.Text = "ColorOpacity";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar_red)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar_Opacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar UI_TrackBar_Blue;
        private System.Windows.Forms.TrackBar UI_TrackBar_Green;
        private System.Windows.Forms.TrackBar UI_TrackBar_red;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar UI_TrackBar_Opacity;
    }
}