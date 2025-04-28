
namespace ICA11_AdrianBaira
{
    partial class SupportDiocs
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
            this.UI_BTN_Font = new System.Windows.Forms.Button();
            this.UI_BTN_Colour = new System.Windows.Forms.Button();
            this.UI_TXT_Font = new System.Windows.Forms.TextBox();
            this.UI_TXT_Colour = new System.Windows.Forms.TextBox();
            this.UI_BTN_Ok = new System.Windows.Forms.Button();
            this.UI_FontDIO = new System.Windows.Forms.FontDialog();
            this.UI_ColorDIO = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // UI_BTN_Font
            // 
            this.UI_BTN_Font.Location = new System.Drawing.Point(37, 62);
            this.UI_BTN_Font.Name = "UI_BTN_Font";
            this.UI_BTN_Font.Size = new System.Drawing.Size(127, 36);
            this.UI_BTN_Font.TabIndex = 0;
            this.UI_BTN_Font.Text = "Select Font";
            this.UI_BTN_Font.UseVisualStyleBackColor = true;
            this.UI_BTN_Font.Click += new System.EventHandler(this.UI_BTN_Font_Click);
            // 
            // UI_BTN_Colour
            // 
            this.UI_BTN_Colour.Location = new System.Drawing.Point(37, 142);
            this.UI_BTN_Colour.Name = "UI_BTN_Colour";
            this.UI_BTN_Colour.Size = new System.Drawing.Size(127, 36);
            this.UI_BTN_Colour.TabIndex = 1;
            this.UI_BTN_Colour.Text = "Select Colour";
            this.UI_BTN_Colour.UseVisualStyleBackColor = true;
            this.UI_BTN_Colour.Click += new System.EventHandler(this.UI_BTN_Colour_Click);
            // 
            // UI_TXT_Font
            // 
            this.UI_TXT_Font.Location = new System.Drawing.Point(191, 67);
            this.UI_TXT_Font.Name = "UI_TXT_Font";
            this.UI_TXT_Font.ReadOnly = true;
            this.UI_TXT_Font.Size = new System.Drawing.Size(718, 26);
            this.UI_TXT_Font.TabIndex = 2;
            // 
            // UI_TXT_Colour
            // 
            this.UI_TXT_Colour.Location = new System.Drawing.Point(191, 147);
            this.UI_TXT_Colour.Name = "UI_TXT_Colour";
            this.UI_TXT_Colour.ReadOnly = true;
            this.UI_TXT_Colour.Size = new System.Drawing.Size(718, 26);
            this.UI_TXT_Colour.TabIndex = 3;
            // 
            // UI_BTN_Ok
            // 
            this.UI_BTN_Ok.Location = new System.Drawing.Point(364, 195);
            this.UI_BTN_Ok.Name = "UI_BTN_Ok";
            this.UI_BTN_Ok.Size = new System.Drawing.Size(102, 36);
            this.UI_BTN_Ok.TabIndex = 4;
            this.UI_BTN_Ok.Text = "OK";
            this.UI_BTN_Ok.UseVisualStyleBackColor = true;
            this.UI_BTN_Ok.Click += new System.EventHandler(this.UI_BTN_Ok_Click);
            // 
            // SupportDiocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 256);
            this.Controls.Add(this.UI_BTN_Ok);
            this.Controls.Add(this.UI_TXT_Colour);
            this.Controls.Add(this.UI_TXT_Font);
            this.Controls.Add(this.UI_BTN_Colour);
            this.Controls.Add(this.UI_BTN_Font);
            this.Name = "SupportDiocs";
            this.Text = "SupportDiocs";
            this.Load += new System.EventHandler(this.SupportDiocs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_Font;
        private System.Windows.Forms.Button UI_BTN_Colour;
        private System.Windows.Forms.TextBox UI_TXT_Font;
        private System.Windows.Forms.TextBox UI_TXT_Colour;
        private System.Windows.Forms.Button UI_BTN_Ok;
        private System.Windows.Forms.FontDialog UI_FontDIO;
        private System.Windows.Forms.ColorDialog UI_ColorDIO;
    }
}