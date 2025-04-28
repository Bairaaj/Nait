
namespace Lab04_AdrianBaira
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
            this.UI_LISTBOX = new System.Windows.Forms.ListBox();
            this.UI_LBL_DROPFILES = new System.Windows.Forms.Label();
            this.UI_BTN_FINDDUPLICATES = new System.Windows.Forms.Button();
            this.UI_BTN_RESOLVEDUPLICATES = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UI_LISTBOX
            // 
            this.UI_LISTBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LISTBOX.FormattingEnabled = true;
            this.UI_LISTBOX.Location = new System.Drawing.Point(8, 8);
            this.UI_LISTBOX.Margin = new System.Windows.Forms.Padding(2);
            this.UI_LISTBOX.Name = "UI_LISTBOX";
            this.UI_LISTBOX.Size = new System.Drawing.Size(443, 355);
            this.UI_LISTBOX.TabIndex = 0;
            // 
            // UI_LBL_DROPFILES
            // 
            this.UI_LBL_DROPFILES.AllowDrop = true;
            this.UI_LBL_DROPFILES.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UI_LBL_DROPFILES.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UI_LBL_DROPFILES.Location = new System.Drawing.Point(483, 26);
            this.UI_LBL_DROPFILES.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UI_LBL_DROPFILES.Name = "UI_LBL_DROPFILES";
            this.UI_LBL_DROPFILES.Size = new System.Drawing.Size(235, 118);
            this.UI_LBL_DROPFILES.TabIndex = 1;
            this.UI_LBL_DROPFILES.Text = "Drop Files Here!";
            this.UI_LBL_DROPFILES.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UI_LBL_DROPFILES.DragDrop += new System.Windows.Forms.DragEventHandler(this.UI_LBL_DROPFILES_DragDrop);
            this.UI_LBL_DROPFILES.DragEnter += new System.Windows.Forms.DragEventHandler(this.UI_LBL_DROPFILES_DragEnter);
            // 
            // UI_BTN_FINDDUPLICATES
            // 
            this.UI_BTN_FINDDUPLICATES.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UI_BTN_FINDDUPLICATES.Location = new System.Drawing.Point(486, 283);
            this.UI_BTN_FINDDUPLICATES.Margin = new System.Windows.Forms.Padding(2);
            this.UI_BTN_FINDDUPLICATES.Name = "UI_BTN_FINDDUPLICATES";
            this.UI_BTN_FINDDUPLICATES.Size = new System.Drawing.Size(232, 22);
            this.UI_BTN_FINDDUPLICATES.TabIndex = 2;
            this.UI_BTN_FINDDUPLICATES.Text = "Find Duplicates";
            this.UI_BTN_FINDDUPLICATES.UseVisualStyleBackColor = true;
            this.UI_BTN_FINDDUPLICATES.Click += new System.EventHandler(this.UI_BTN_FINDDUPLICATES_Click);
            // 
            // UI_BTN_RESOLVEDUPLICATES
            // 
            this.UI_BTN_RESOLVEDUPLICATES.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UI_BTN_RESOLVEDUPLICATES.Location = new System.Drawing.Point(486, 333);
            this.UI_BTN_RESOLVEDUPLICATES.Margin = new System.Windows.Forms.Padding(2);
            this.UI_BTN_RESOLVEDUPLICATES.Name = "UI_BTN_RESOLVEDUPLICATES";
            this.UI_BTN_RESOLVEDUPLICATES.Size = new System.Drawing.Size(232, 22);
            this.UI_BTN_RESOLVEDUPLICATES.TabIndex = 3;
            this.UI_BTN_RESOLVEDUPLICATES.Text = "Resolve Duplicates";
            this.UI_BTN_RESOLVEDUPLICATES.UseVisualStyleBackColor = true;
            this.UI_BTN_RESOLVEDUPLICATES.Click += new System.EventHandler(this.UI_BTN_RESOLVEDUPLICATES_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(738, 380);
            this.Controls.Add(this.UI_BTN_RESOLVEDUPLICATES);
            this.Controls.Add(this.UI_BTN_FINDDUPLICATES);
            this.Controls.Add(this.UI_LBL_DROPFILES);
            this.Controls.Add(this.UI_LISTBOX);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox UI_LISTBOX;
        private System.Windows.Forms.Label UI_LBL_DROPFILES;
        private System.Windows.Forms.Button UI_BTN_FINDDUPLICATES;
        private System.Windows.Forms.Button UI_BTN_RESOLVEDUPLICATES;
    }
}

