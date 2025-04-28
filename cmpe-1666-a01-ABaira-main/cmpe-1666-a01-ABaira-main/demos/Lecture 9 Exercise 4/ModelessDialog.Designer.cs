namespace Lecture_9_Exercise_4
{
    partial class ModelessDialog
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
            this.UI_Red_Radio = new System.Windows.Forms.RadioButton();
            this.UI_Purple_Radio = new System.Windows.Forms.RadioButton();
            this.UI_Yellow_Radio = new System.Windows.Forms.RadioButton();
            this.UI_Op_Track = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Op_Track)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_Red_Radio
            // 
            this.UI_Red_Radio.AutoSize = true;
            this.UI_Red_Radio.Checked = true;
            this.UI_Red_Radio.Location = new System.Drawing.Point(55, 23);
            this.UI_Red_Radio.Name = "UI_Red_Radio";
            this.UI_Red_Radio.Size = new System.Drawing.Size(45, 17);
            this.UI_Red_Radio.TabIndex = 0;
            this.UI_Red_Radio.TabStop = true;
            this.UI_Red_Radio.Text = "Red";
            this.UI_Red_Radio.UseVisualStyleBackColor = true;
            this.UI_Red_Radio.CheckedChanged += new System.EventHandler(this.UI_Red_Radio_CheckedChanged);
            // 
            // UI_Purple_Radio
            // 
            this.UI_Purple_Radio.AutoSize = true;
            this.UI_Purple_Radio.Location = new System.Drawing.Point(55, 83);
            this.UI_Purple_Radio.Name = "UI_Purple_Radio";
            this.UI_Purple_Radio.Size = new System.Drawing.Size(55, 17);
            this.UI_Purple_Radio.TabIndex = 1;
            this.UI_Purple_Radio.Text = "Purple";
            this.UI_Purple_Radio.UseVisualStyleBackColor = true;
            this.UI_Purple_Radio.CheckedChanged += new System.EventHandler(this.UI_Red_Radio_CheckedChanged);
            // 
            // UI_Yellow_Radio
            // 
            this.UI_Yellow_Radio.AutoSize = true;
            this.UI_Yellow_Radio.Location = new System.Drawing.Point(55, 157);
            this.UI_Yellow_Radio.Name = "UI_Yellow_Radio";
            this.UI_Yellow_Radio.Size = new System.Drawing.Size(56, 17);
            this.UI_Yellow_Radio.TabIndex = 2;
            this.UI_Yellow_Radio.Text = "Yellow";
            this.UI_Yellow_Radio.UseVisualStyleBackColor = true;
            this.UI_Yellow_Radio.CheckedChanged += new System.EventHandler(this.UI_Red_Radio_CheckedChanged);
            // 
            // UI_Op_Track
            // 
            this.UI_Op_Track.Location = new System.Drawing.Point(179, 271);
            this.UI_Op_Track.Name = "UI_Op_Track";
            this.UI_Op_Track.Size = new System.Drawing.Size(452, 45);
            this.UI_Op_Track.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UI_Yellow_Radio);
            this.groupBox1.Controls.Add(this.UI_Purple_Radio);
            this.groupBox1.Controls.Add(this.UI_Red_Radio);
            this.groupBox1.Location = new System.Drawing.Point(295, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 219);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // ModelessDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 422);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UI_Op_Track);
            this.Name = "ModelessDialog";
            this.Text = "ModelessDialog";
            ((System.ComponentModel.ISupportInitialize)(this.UI_Op_Track)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton UI_Red_Radio;
        private System.Windows.Forms.RadioButton UI_Purple_Radio;
        private System.Windows.Forms.RadioButton UI_Yellow_Radio;
        private System.Windows.Forms.TrackBar UI_Op_Track;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}