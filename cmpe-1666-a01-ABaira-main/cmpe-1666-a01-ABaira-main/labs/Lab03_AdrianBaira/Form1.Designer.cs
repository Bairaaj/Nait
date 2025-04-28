
namespace Lab03_AdrianBaira
{
    partial class MainForm
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
            this.UI_CHKBOX_ShowScore = new System.Windows.Forms.CheckBox();
            this.UI_CHKBOX_ShowAnimationSpeed = new System.Windows.Forms.CheckBox();
            this.UI_BTN_Play = new System.Windows.Forms.Button();
            this.UI_Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_CHKBOX_ShowScore
            // 
            this.UI_CHKBOX_ShowScore.AutoSize = true;
            this.UI_CHKBOX_ShowScore.Location = new System.Drawing.Point(21, 20);
            this.UI_CHKBOX_ShowScore.Name = "UI_CHKBOX_ShowScore";
            this.UI_CHKBOX_ShowScore.Size = new System.Drawing.Size(84, 17);
            this.UI_CHKBOX_ShowScore.TabIndex = 0;
            this.UI_CHKBOX_ShowScore.Text = "Show Score";
            this.UI_CHKBOX_ShowScore.UseVisualStyleBackColor = true;
            this.UI_CHKBOX_ShowScore.CheckedChanged += new System.EventHandler(this.UI_CHKBOX_ShowScore_CheckedChanged);
            // 
            // UI_CHKBOX_ShowAnimationSpeed
            // 
            this.UI_CHKBOX_ShowAnimationSpeed.AutoSize = true;
            this.UI_CHKBOX_ShowAnimationSpeed.Location = new System.Drawing.Point(21, 43);
            this.UI_CHKBOX_ShowAnimationSpeed.Name = "UI_CHKBOX_ShowAnimationSpeed";
            this.UI_CHKBOX_ShowAnimationSpeed.Size = new System.Drawing.Size(136, 17);
            this.UI_CHKBOX_ShowAnimationSpeed.TabIndex = 1;
            this.UI_CHKBOX_ShowAnimationSpeed.Text = "Show Animation Speed";
            this.UI_CHKBOX_ShowAnimationSpeed.UseVisualStyleBackColor = true;
            this.UI_CHKBOX_ShowAnimationSpeed.CheckedChanged += new System.EventHandler(this.UI_CHKBOX_ShowAnimationSpeed_CheckedChanged);
            // 
            // UI_BTN_Play
            // 
            this.UI_BTN_Play.Location = new System.Drawing.Point(93, 75);
            this.UI_BTN_Play.Name = "UI_BTN_Play";
            this.UI_BTN_Play.Size = new System.Drawing.Size(75, 23);
            this.UI_BTN_Play.TabIndex = 2;
            this.UI_BTN_Play.Text = "Play";
            this.UI_BTN_Play.UseVisualStyleBackColor = true;
            this.UI_BTN_Play.Click += new System.EventHandler(this.UI_BTN_Play_Click);
            // 
            // UI_Timer
            // 
            this.UI_Timer.Tick += new System.EventHandler(this.UI_Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 123);
            this.Controls.Add(this.UI_BTN_Play);
            this.Controls.Add(this.UI_CHKBOX_ShowAnimationSpeed);
            this.Controls.Add(this.UI_CHKBOX_ShowScore);
            this.Name = "MainForm";
            this.Text = "Main Form Lab 2 Ballz";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox UI_CHKBOX_ShowScore;
        private System.Windows.Forms.CheckBox UI_CHKBOX_ShowAnimationSpeed;
        private System.Windows.Forms.Button UI_BTN_Play;
        private System.Windows.Forms.Timer UI_Timer;
    }
}

