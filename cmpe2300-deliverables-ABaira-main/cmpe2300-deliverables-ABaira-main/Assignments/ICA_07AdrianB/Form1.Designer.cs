namespace ICA_07AdrianB
{
    partial class ICA07
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
            this.UI_BTN_Populate = new System.Windows.Forms.Button();
            this.UI_BTN_Color = new System.Windows.Forms.Button();
            this.UI_BTN_Width = new System.Windows.Forms.Button();
            this.UI_BTN_WidthDesc = new System.Windows.Forms.Button();
            this.UI_BTN_WidthColor = new System.Windows.Forms.Button();
            this.UI_BTN_Bright = new System.Windows.Forms.Button();
            this.UI_BTN_Longerthan = new System.Windows.Forms.Button();
            this.UI_TrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_BTN_Populate
            // 
            this.UI_BTN_Populate.Location = new System.Drawing.Point(12, 12);
            this.UI_BTN_Populate.Name = "UI_BTN_Populate";
            this.UI_BTN_Populate.Size = new System.Drawing.Size(302, 53);
            this.UI_BTN_Populate.TabIndex = 0;
            this.UI_BTN_Populate.Text = "Populate";
            this.UI_BTN_Populate.UseVisualStyleBackColor = true;
            this.UI_BTN_Populate.Click += new System.EventHandler(this.UI_BTN_Populate_Click);
            // 
            // UI_BTN_Color
            // 
            this.UI_BTN_Color.Location = new System.Drawing.Point(12, 71);
            this.UI_BTN_Color.Name = "UI_BTN_Color";
            this.UI_BTN_Color.Size = new System.Drawing.Size(302, 53);
            this.UI_BTN_Color.TabIndex = 1;
            this.UI_BTN_Color.Text = "Color";
            this.UI_BTN_Color.UseVisualStyleBackColor = true;
            this.UI_BTN_Color.Click += new System.EventHandler(this.UI_BTN_Color_Click);
            // 
            // UI_BTN_Width
            // 
            this.UI_BTN_Width.Location = new System.Drawing.Point(12, 130);
            this.UI_BTN_Width.Name = "UI_BTN_Width";
            this.UI_BTN_Width.Size = new System.Drawing.Size(302, 53);
            this.UI_BTN_Width.TabIndex = 2;
            this.UI_BTN_Width.Text = "Width";
            this.UI_BTN_Width.UseVisualStyleBackColor = true;
            this.UI_BTN_Width.Click += new System.EventHandler(this.UI_BTN_Width_Click);
            // 
            // UI_BTN_WidthDesc
            // 
            this.UI_BTN_WidthDesc.Location = new System.Drawing.Point(12, 189);
            this.UI_BTN_WidthDesc.Name = "UI_BTN_WidthDesc";
            this.UI_BTN_WidthDesc.Size = new System.Drawing.Size(302, 53);
            this.UI_BTN_WidthDesc.TabIndex = 3;
            this.UI_BTN_WidthDesc.Text = "Width Desc";
            this.UI_BTN_WidthDesc.UseVisualStyleBackColor = true;
            this.UI_BTN_WidthDesc.Click += new System.EventHandler(this.UI_BTN_WidthDesc_Click);
            // 
            // UI_BTN_WidthColor
            // 
            this.UI_BTN_WidthColor.Location = new System.Drawing.Point(12, 248);
            this.UI_BTN_WidthColor.Name = "UI_BTN_WidthColor";
            this.UI_BTN_WidthColor.Size = new System.Drawing.Size(302, 53);
            this.UI_BTN_WidthColor.TabIndex = 4;
            this.UI_BTN_WidthColor.Text = "Width, Color";
            this.UI_BTN_WidthColor.UseVisualStyleBackColor = true;
            this.UI_BTN_WidthColor.Click += new System.EventHandler(this.UI_BTN_WidthColor_Click);
            // 
            // UI_BTN_Bright
            // 
            this.UI_BTN_Bright.Location = new System.Drawing.Point(11, 307);
            this.UI_BTN_Bright.Name = "UI_BTN_Bright";
            this.UI_BTN_Bright.Size = new System.Drawing.Size(302, 53);
            this.UI_BTN_Bright.TabIndex = 5;
            this.UI_BTN_Bright.Text = "Bright";
            this.UI_BTN_Bright.UseVisualStyleBackColor = true;
            this.UI_BTN_Bright.Click += new System.EventHandler(this.UI_BTN_Bright_Click);
            // 
            // UI_BTN_Longerthan
            // 
            this.UI_BTN_Longerthan.Location = new System.Drawing.Point(11, 366);
            this.UI_BTN_Longerthan.Name = "UI_BTN_Longerthan";
            this.UI_BTN_Longerthan.Size = new System.Drawing.Size(302, 53);
            this.UI_BTN_Longerthan.TabIndex = 6;
            this.UI_BTN_Longerthan.Text = "Longer than 100";
            this.UI_BTN_Longerthan.UseVisualStyleBackColor = true;
            this.UI_BTN_Longerthan.Click += new System.EventHandler(this.UI_BTN_Longerthan_Click);
            // 
            // UI_TrackBar
            // 
            this.UI_TrackBar.Location = new System.Drawing.Point(11, 441);
            this.UI_TrackBar.Maximum = 190;
            this.UI_TrackBar.Minimum = 1;
            this.UI_TrackBar.Name = "UI_TrackBar";
            this.UI_TrackBar.Size = new System.Drawing.Size(302, 45);
            this.UI_TrackBar.TabIndex = 7;
            this.UI_TrackBar.Value = 10;
            this.UI_TrackBar.Scroll += new System.EventHandler(this.UI_TrackBar_Scroll);
            // 
            // ICA07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 546);
            this.Controls.Add(this.UI_TrackBar);
            this.Controls.Add(this.UI_BTN_Longerthan);
            this.Controls.Add(this.UI_BTN_Bright);
            this.Controls.Add(this.UI_BTN_WidthColor);
            this.Controls.Add(this.UI_BTN_WidthDesc);
            this.Controls.Add(this.UI_BTN_Width);
            this.Controls.Add(this.UI_BTN_Color);
            this.Controls.Add(this.UI_BTN_Populate);
            this.Name = "ICA07";
            this.Text = "ICA07 - PrediBars";
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_Populate;
        private System.Windows.Forms.Button UI_BTN_Color;
        private System.Windows.Forms.Button UI_BTN_Width;
        private System.Windows.Forms.Button UI_BTN_WidthDesc;
        private System.Windows.Forms.Button UI_BTN_WidthColor;
        private System.Windows.Forms.Button UI_BTN_Bright;
        private System.Windows.Forms.Button UI_BTN_Longerthan;
        private System.Windows.Forms.TrackBar UI_TrackBar;
    }
}

