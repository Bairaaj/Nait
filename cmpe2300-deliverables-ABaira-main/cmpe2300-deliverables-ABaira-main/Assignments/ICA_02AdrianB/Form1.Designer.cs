namespace ICA02_AdrianB
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
            this.components = new System.ComponentModel.Container();
            this.UI_TIMER = new System.Windows.Forms.Timer(this.components);
            this.UI_TXT_Rad = new System.Windows.Forms.TextBox();
            this.UI_CHKBOX_All = new System.Windows.Forms.CheckBox();
            this.UI_TXTBOX_Display = new System.Windows.Forms.TextBox();
            this.UI_TXT_Opacity = new System.Windows.Forms.TextBox();
            this.UI_LBL_Rad = new System.Windows.Forms.Label();
            this.UI_LBL_Opa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_TIMER
            // 
            this.UI_TIMER.Enabled = true;
            this.UI_TIMER.Interval = 20;
            this.UI_TIMER.Tick += new System.EventHandler(this.UI_TIMER_Tick);
            // 
            // UI_TXT_Rad
            // 
            this.UI_TXT_Rad.Location = new System.Drawing.Point(59, 12);
            this.UI_TXT_Rad.Name = "UI_TXT_Rad";
            this.UI_TXT_Rad.ReadOnly = true;
            this.UI_TXT_Rad.Size = new System.Drawing.Size(54, 20);
            this.UI_TXT_Rad.TabIndex = 0;
            this.UI_TXT_Rad.TabStop = false;
            // 
            // UI_CHKBOX_All
            // 
            this.UI_CHKBOX_All.AutoSize = true;
            this.UI_CHKBOX_All.Location = new System.Drawing.Point(12, 49);
            this.UI_CHKBOX_All.Name = "UI_CHKBOX_All";
            this.UI_CHKBOX_All.Size = new System.Drawing.Size(37, 17);
            this.UI_CHKBOX_All.TabIndex = 1;
            this.UI_CHKBOX_All.Text = "All";
            this.UI_CHKBOX_All.UseVisualStyleBackColor = true;
            // 
            // UI_TXTBOX_Display
            // 
            this.UI_TXTBOX_Display.Location = new System.Drawing.Point(13, 82);
            this.UI_TXTBOX_Display.Name = "UI_TXTBOX_Display";
            this.UI_TXTBOX_Display.ReadOnly = true;
            this.UI_TXTBOX_Display.Size = new System.Drawing.Size(344, 20);
            this.UI_TXTBOX_Display.TabIndex = 2;
            // 
            // UI_TXT_Opacity
            // 
            this.UI_TXT_Opacity.Location = new System.Drawing.Point(257, 12);
            this.UI_TXT_Opacity.Name = "UI_TXT_Opacity";
            this.UI_TXT_Opacity.ReadOnly = true;
            this.UI_TXT_Opacity.Size = new System.Drawing.Size(59, 20);
            this.UI_TXT_Opacity.TabIndex = 3;
            // 
            // UI_LBL_Rad
            // 
            this.UI_LBL_Rad.AutoSize = true;
            this.UI_LBL_Rad.Location = new System.Drawing.Point(10, 15);
            this.UI_LBL_Rad.Name = "UI_LBL_Rad";
            this.UI_LBL_Rad.Size = new System.Drawing.Size(43, 13);
            this.UI_LBL_Rad.TabIndex = 4;
            this.UI_LBL_Rad.Text = "Radius:";
            // 
            // UI_LBL_Opa
            // 
            this.UI_LBL_Opa.AutoSize = true;
            this.UI_LBL_Opa.Location = new System.Drawing.Point(202, 15);
            this.UI_LBL_Opa.Name = "UI_LBL_Opa";
            this.UI_LBL_Opa.Size = new System.Drawing.Size(49, 13);
            this.UI_LBL_Opa.TabIndex = 5;
            this.UI_LBL_Opa.Text = "Opacity: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 118);
            this.Controls.Add(this.UI_LBL_Opa);
            this.Controls.Add(this.UI_LBL_Rad);
            this.Controls.Add(this.UI_TXT_Opacity);
            this.Controls.Add(this.UI_TXTBOX_Display);
            this.Controls.Add(this.UI_CHKBOX_All);
            this.Controls.Add(this.UI_TXT_Rad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer UI_TIMER;
        private System.Windows.Forms.TextBox UI_TXT_Rad;
        private System.Windows.Forms.CheckBox UI_CHKBOX_All;
        private System.Windows.Forms.TextBox UI_TXTBOX_Display;
        private System.Windows.Forms.TextBox UI_TXT_Opacity;
        private System.Windows.Forms.Label UI_LBL_Rad;
        private System.Windows.Forms.Label UI_LBL_Opa;
    }
}

