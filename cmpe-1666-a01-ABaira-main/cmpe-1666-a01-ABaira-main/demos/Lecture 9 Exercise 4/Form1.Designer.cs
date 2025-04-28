namespace Lecture_9_Exercise_4
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
            this.UI_BTN_Show = new System.Windows.Forms.Button();
            this.UI_BTN_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UI_BTN_Show
            // 
            this.UI_BTN_Show.Location = new System.Drawing.Point(89, 72);
            this.UI_BTN_Show.Name = "UI_BTN_Show";
            this.UI_BTN_Show.Size = new System.Drawing.Size(108, 52);
            this.UI_BTN_Show.TabIndex = 0;
            this.UI_BTN_Show.Text = "Show Button";
            this.UI_BTN_Show.UseVisualStyleBackColor = true;
            this.UI_BTN_Show.Click += new System.EventHandler(this.UI_BTN_Show_Click);
            // 
            // UI_BTN_btn
            // 
            this.UI_BTN_btn.Location = new System.Drawing.Point(89, 191);
            this.UI_BTN_btn.Name = "UI_BTN_btn";
            this.UI_BTN_btn.Size = new System.Drawing.Size(108, 52);
            this.UI_BTN_btn.TabIndex = 1;
            this.UI_BTN_btn.Text = "Hide Button";
            this.UI_BTN_btn.UseVisualStyleBackColor = true;
            this.UI_BTN_btn.Click += new System.EventHandler(this.UI_BTN_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 393);
            this.Controls.Add(this.UI_BTN_btn);
            this.Controls.Add(this.UI_BTN_Show);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_Show;
        private System.Windows.Forms.Button UI_BTN_btn;
    }
}

