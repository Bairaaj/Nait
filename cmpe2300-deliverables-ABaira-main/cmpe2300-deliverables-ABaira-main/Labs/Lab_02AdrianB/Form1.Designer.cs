namespace Lab_02AdrianB
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
            this.UI_BTN_NewTable = new System.Windows.Forms.Button();
            this.UI_TXTBOX_Friction = new System.Windows.Forms.TextBox();
            this.UI_GROUPBOX_Sort = new System.Windows.Forms.GroupBox();
            this.UI_RAD_TotalHits = new System.Windows.Forms.RadioButton();
            this.UI_RAD_Hits = new System.Windows.Forms.RadioButton();
            this.UI_RAD_Radius = new System.Windows.Forms.RadioButton();
            this.UI_DataGridView = new System.Windows.Forms.DataGridView();
            this.UI_LBL_Friction = new System.Windows.Forms.Label();
            this.UI_LBL_TotalCol = new System.Windows.Forms.Label();
            this.UI_GROUPBOX_Sort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_BTN_NewTable
            // 
            this.UI_BTN_NewTable.Location = new System.Drawing.Point(18, 14);
            this.UI_BTN_NewTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_BTN_NewTable.Name = "UI_BTN_NewTable";
            this.UI_BTN_NewTable.Size = new System.Drawing.Size(206, 43);
            this.UI_BTN_NewTable.TabIndex = 0;
            this.UI_BTN_NewTable.Text = "New Table [10]";
            this.UI_BTN_NewTable.UseVisualStyleBackColor = true;
            // 
            // UI_TXTBOX_Friction
            // 
            this.UI_TXTBOX_Friction.Location = new System.Drawing.Point(352, 18);
            this.UI_TXTBOX_Friction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_TXTBOX_Friction.Name = "UI_TXTBOX_Friction";
            this.UI_TXTBOX_Friction.ReadOnly = true;
            this.UI_TXTBOX_Friction.Size = new System.Drawing.Size(134, 26);
            this.UI_TXTBOX_Friction.TabIndex = 1;
            this.UI_TXTBOX_Friction.Text = "0.991";
            // 
            // UI_GROUPBOX_Sort
            // 
            this.UI_GROUPBOX_Sort.Controls.Add(this.UI_RAD_TotalHits);
            this.UI_GROUPBOX_Sort.Controls.Add(this.UI_RAD_Hits);
            this.UI_GROUPBOX_Sort.Controls.Add(this.UI_RAD_Radius);
            this.UI_GROUPBOX_Sort.Location = new System.Drawing.Point(18, 66);
            this.UI_GROUPBOX_Sort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_GROUPBOX_Sort.Name = "UI_GROUPBOX_Sort";
            this.UI_GROUPBOX_Sort.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_GROUPBOX_Sort.Size = new System.Drawing.Size(471, 94);
            this.UI_GROUPBOX_Sort.TabIndex = 2;
            this.UI_GROUPBOX_Sort.TabStop = false;
            this.UI_GROUPBOX_Sort.Text = "Sort Mode";
            // 
            // UI_RAD_TotalHits
            // 
            this.UI_RAD_TotalHits.AutoSize = true;
            this.UI_RAD_TotalHits.Location = new System.Drawing.Point(357, 43);
            this.UI_RAD_TotalHits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_TotalHits.Name = "UI_RAD_TotalHits";
            this.UI_RAD_TotalHits.Size = new System.Drawing.Size(101, 24);
            this.UI_RAD_TotalHits.TabIndex = 2;
            this.UI_RAD_TotalHits.TabStop = true;
            this.UI_RAD_TotalHits.Text = "Total Hits";
            this.UI_RAD_TotalHits.UseVisualStyleBackColor = true;
            // 
            // UI_RAD_Hits
            // 
            this.UI_RAD_Hits.AutoSize = true;
            this.UI_RAD_Hits.Location = new System.Drawing.Point(204, 43);
            this.UI_RAD_Hits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_Hits.Name = "UI_RAD_Hits";
            this.UI_RAD_Hits.Size = new System.Drawing.Size(62, 24);
            this.UI_RAD_Hits.TabIndex = 1;
            this.UI_RAD_Hits.TabStop = true;
            this.UI_RAD_Hits.Text = "Hits";
            this.UI_RAD_Hits.UseVisualStyleBackColor = true;
            // 
            // UI_RAD_Radius
            // 
            this.UI_RAD_Radius.AutoSize = true;
            this.UI_RAD_Radius.Location = new System.Drawing.Point(9, 43);
            this.UI_RAD_Radius.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_Radius.Name = "UI_RAD_Radius";
            this.UI_RAD_Radius.Size = new System.Drawing.Size(84, 24);
            this.UI_RAD_Radius.TabIndex = 0;
            this.UI_RAD_Radius.TabStop = true;
            this.UI_RAD_Radius.Text = "Radius";
            this.UI_RAD_Radius.UseVisualStyleBackColor = true;
            // 
            // UI_DataGridView
            // 
            this.UI_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DataGridView.Location = new System.Drawing.Point(18, 169);
            this.UI_DataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_DataGridView.Name = "UI_DataGridView";
            this.UI_DataGridView.RowHeadersWidth = 62;
            this.UI_DataGridView.Size = new System.Drawing.Size(471, 406);
            this.UI_DataGridView.TabIndex = 3;
            // 
            // UI_LBL_Friction
            // 
            this.UI_LBL_Friction.AutoSize = true;
            this.UI_LBL_Friction.Location = new System.Drawing.Point(273, 23);
            this.UI_LBL_Friction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_LBL_Friction.Name = "UI_LBL_Friction";
            this.UI_LBL_Friction.Size = new System.Drawing.Size(69, 20);
            this.UI_LBL_Friction.TabIndex = 4;
            this.UI_LBL_Friction.Text = "Friction :";
            // 
            // UI_LBL_TotalCol
            // 
            this.UI_LBL_TotalCol.AutoSize = true;
            this.UI_LBL_TotalCol.Location = new System.Drawing.Point(23, 599);
            this.UI_LBL_TotalCol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_LBL_TotalCol.Name = "UI_LBL_TotalCol";
            this.UI_LBL_TotalCol.Size = new System.Drawing.Size(122, 20);
            this.UI_LBL_TotalCol.TabIndex = 5;
            this.UI_LBL_TotalCol.Text = "Total Collisions: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 648);
            this.Controls.Add(this.UI_LBL_TotalCol);
            this.Controls.Add(this.UI_LBL_Friction);
            this.Controls.Add(this.UI_DataGridView);
            this.Controls.Add(this.UI_GROUPBOX_Sort);
            this.Controls.Add(this.UI_TXTBOX_Friction);
            this.Controls.Add(this.UI_BTN_NewTable);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Lab 02 Pool";
            this.UI_GROUPBOX_Sort.ResumeLayout(false);
            this.UI_GROUPBOX_Sort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_NewTable;
        private System.Windows.Forms.TextBox UI_TXTBOX_Friction;
        private System.Windows.Forms.GroupBox UI_GROUPBOX_Sort;
        private System.Windows.Forms.RadioButton UI_RAD_TotalHits;
        private System.Windows.Forms.RadioButton UI_RAD_Hits;
        private System.Windows.Forms.RadioButton UI_RAD_Radius;
        private System.Windows.Forms.DataGridView UI_DataGridView;
        private System.Windows.Forms.Label UI_LBL_Friction;
        private System.Windows.Forms.Label UI_LBL_TotalCol;
    }
}

