
namespace ICA_05_AdrianB
{
    partial class form1Structs
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
            this.UI_TimerTick = new System.Windows.Forms.Timer(this.components);
            this.UI_LabelBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_TimerTick
            // 
            this.UI_TimerTick.Enabled = true;
            this.UI_TimerTick.Interval = 50;
            this.UI_TimerTick.Tick += new System.EventHandler(this.UI_TimerTick_Tick);
            // 
            // UI_LabelBox
            // 
            this.UI_LabelBox.AutoSize = true;
            this.UI_LabelBox.Location = new System.Drawing.Point(114, 69);
            this.UI_LabelBox.Name = "UI_LabelBox";
            this.UI_LabelBox.Size = new System.Drawing.Size(55, 13);
            this.UI_LabelBox.TabIndex = 0;
            this.UI_LabelBox.Text = "State_Idle";
            this.UI_LabelBox.Click += new System.EventHandler(this.UI_LabelBox_Click);
            // 
            // form1Structs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 156);
            this.Controls.Add(this.UI_LabelBox);
            this.Name = "form1Structs";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.UI_TimerTick_Tick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer UI_TimerTick;
        private System.Windows.Forms.Label UI_LabelBox;
    }
}

