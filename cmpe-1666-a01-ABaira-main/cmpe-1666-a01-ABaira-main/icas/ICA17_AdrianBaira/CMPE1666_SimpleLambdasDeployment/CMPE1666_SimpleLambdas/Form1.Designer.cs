namespace CMPE1666_SimpleLambdas
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
            this.UI_B_RemoveSmall = new System.Windows.Forms.Button();
            this.UI_LB_Status = new System.Windows.Forms.ListBox();
            this.UI_B_Add100 = new System.Windows.Forms.Button();
            this.UI_B_RemoveBigBalls = new System.Windows.Forms.Button();
            this.UI_B_Green = new System.Windows.Forms.Button();
            this.UI_B_Left = new System.Windows.Forms.Button();
            this.UI_B_AvgSize = new System.Windows.Forms.Button();
            this.UI_B_Clear = new System.Windows.Forms.Button();
            this.UI_B_Hole = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UI_B_RemoveSmall
            // 
            this.UI_B_RemoveSmall.Location = new System.Drawing.Point(174, 12);
            this.UI_B_RemoveSmall.Name = "UI_B_RemoveSmall";
            this.UI_B_RemoveSmall.Size = new System.Drawing.Size(156, 23);
            this.UI_B_RemoveSmall.TabIndex = 0;
            this.UI_B_RemoveSmall.Text = "Remove Small Balls";
            this.UI_B_RemoveSmall.UseVisualStyleBackColor = true;
            this.UI_B_RemoveSmall.Click += new System.EventHandler(this.UI_B_RemoveSmall_Click);
            // 
            // UI_LB_Status
            // 
            this.UI_LB_Status.FormattingEnabled = true;
            this.UI_LB_Status.Location = new System.Drawing.Point(12, 70);
            this.UI_LB_Status.Name = "UI_LB_Status";
            this.UI_LB_Status.Size = new System.Drawing.Size(642, 368);
            this.UI_LB_Status.TabIndex = 1;
            // 
            // UI_B_Add100
            // 
            this.UI_B_Add100.Location = new System.Drawing.Point(12, 12);
            this.UI_B_Add100.Name = "UI_B_Add100";
            this.UI_B_Add100.Size = new System.Drawing.Size(156, 23);
            this.UI_B_Add100.TabIndex = 2;
            this.UI_B_Add100.Text = "Add 100 Random Balls!";
            this.UI_B_Add100.UseVisualStyleBackColor = true;
            this.UI_B_Add100.Click += new System.EventHandler(this.UI_B_Add100_Click);
            // 
            // UI_B_RemoveBigBalls
            // 
            this.UI_B_RemoveBigBalls.Location = new System.Drawing.Point(174, 41);
            this.UI_B_RemoveBigBalls.Name = "UI_B_RemoveBigBalls";
            this.UI_B_RemoveBigBalls.Size = new System.Drawing.Size(156, 23);
            this.UI_B_RemoveBigBalls.TabIndex = 3;
            this.UI_B_RemoveBigBalls.Text = "Remove Big Balls";
            this.UI_B_RemoveBigBalls.UseVisualStyleBackColor = true;
            this.UI_B_RemoveBigBalls.Click += new System.EventHandler(this.UI_B_RemoveBigBalls_Click);
            // 
            // UI_B_Green
            // 
            this.UI_B_Green.Location = new System.Drawing.Point(336, 12);
            this.UI_B_Green.Name = "UI_B_Green";
            this.UI_B_Green.Size = new System.Drawing.Size(156, 23);
            this.UI_B_Green.TabIndex = 4;
            this.UI_B_Green.Text = "Green?";
            this.UI_B_Green.UseVisualStyleBackColor = true;
            this.UI_B_Green.Click += new System.EventHandler(this.UI_B_NoGreen_Click);
            // 
            // UI_B_Left
            // 
            this.UI_B_Left.Location = new System.Drawing.Point(498, 12);
            this.UI_B_Left.Name = "UI_B_Left";
            this.UI_B_Left.Size = new System.Drawing.Size(156, 23);
            this.UI_B_Left.TabIndex = 5;
            this.UI_B_Left.Text = "Left Balls!";
            this.UI_B_Left.UseVisualStyleBackColor = true;
            this.UI_B_Left.Click += new System.EventHandler(this.UI_B_Left_Click);
            // 
            // UI_B_AvgSize
            // 
            this.UI_B_AvgSize.Location = new System.Drawing.Point(336, 41);
            this.UI_B_AvgSize.Name = "UI_B_AvgSize";
            this.UI_B_AvgSize.Size = new System.Drawing.Size(156, 23);
            this.UI_B_AvgSize.TabIndex = 6;
            this.UI_B_AvgSize.Text = "Average Size";
            this.UI_B_AvgSize.UseVisualStyleBackColor = true;
            this.UI_B_AvgSize.Click += new System.EventHandler(this.UI_B_AvgSize_Click);
            // 
            // UI_B_Clear
            // 
            this.UI_B_Clear.Location = new System.Drawing.Point(12, 41);
            this.UI_B_Clear.Name = "UI_B_Clear";
            this.UI_B_Clear.Size = new System.Drawing.Size(156, 23);
            this.UI_B_Clear.TabIndex = 7;
            this.UI_B_Clear.Text = "Clear Balls";
            this.UI_B_Clear.UseVisualStyleBackColor = true;
            this.UI_B_Clear.Click += new System.EventHandler(this.UI_B_Clear_Click);
            // 
            // UI_B_Hole
            // 
            this.UI_B_Hole.Location = new System.Drawing.Point(498, 41);
            this.UI_B_Hole.Name = "UI_B_Hole";
            this.UI_B_Hole.Size = new System.Drawing.Size(156, 23);
            this.UI_B_Hole.TabIndex = 8;
            this.UI_B_Hole.Text = "Make Hole!";
            this.UI_B_Hole.UseVisualStyleBackColor = true;
            this.UI_B_Hole.Click += new System.EventHandler(this.UI_B_Hole_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 450);
            this.Controls.Add(this.UI_B_Hole);
            this.Controls.Add(this.UI_B_Clear);
            this.Controls.Add(this.UI_B_AvgSize);
            this.Controls.Add(this.UI_B_Left);
            this.Controls.Add(this.UI_B_Green);
            this.Controls.Add(this.UI_B_RemoveBigBalls);
            this.Controls.Add(this.UI_B_Add100);
            this.Controls.Add(this.UI_LB_Status);
            this.Controls.Add(this.UI_B_RemoveSmall);
            this.Name = "Form1";
            this.Text = "Lambdas!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button UI_B_RemoveSmall;
        private System.Windows.Forms.ListBox UI_LB_Status;
        private System.Windows.Forms.Button UI_B_Add100;
        private System.Windows.Forms.Button UI_B_RemoveBigBalls;
        private System.Windows.Forms.Button UI_B_Green;
        private System.Windows.Forms.Button UI_B_Left;
        private System.Windows.Forms.Button UI_B_AvgSize;
        private System.Windows.Forms.Button UI_B_Clear;
        private System.Windows.Forms.Button UI_B_Hole;
    }
}

