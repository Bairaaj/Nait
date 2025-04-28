namespace MMC_AdrianB_GriffinB
{
    partial class MMC
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
            this.UI_DataGrid = new System.Windows.Forms.DataGridView();
            this.UI_BTN_SortByName = new System.Windows.Forms.Button();
            this.UI_BTN_SingleCharSymbols = new System.Windows.Forms.Button();
            this.UI_BTN_SortByAtomic = new System.Windows.Forms.Button();
            this.UI_LBL_ChemicalFormula = new System.Windows.Forms.Label();
            this.UI_LBL_Search = new System.Windows.Forms.Label();
            this.UI_LBL_ApproxMolarMass = new System.Windows.Forms.Label();
            this.UI_TXT_ChemicalFormula = new System.Windows.Forms.TextBox();
            this.UI_TXT_Search = new System.Windows.Forms.TextBox();
            this.UI_TxtBox_AproxMolarMass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_DataGrid
            // 
            this.UI_DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DataGrid.Location = new System.Drawing.Point(12, 12);
            this.UI_DataGrid.Name = "UI_DataGrid";
            this.UI_DataGrid.RowHeadersWidth = 62;
            this.UI_DataGrid.Size = new System.Drawing.Size(436, 240);
            this.UI_DataGrid.TabIndex = 0;
            // 
            // UI_BTN_SortByName
            // 
            this.UI_BTN_SortByName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_SortByName.Location = new System.Drawing.Point(454, 12);
            this.UI_BTN_SortByName.Name = "UI_BTN_SortByName";
            this.UI_BTN_SortByName.Size = new System.Drawing.Size(167, 23);
            this.UI_BTN_SortByName.TabIndex = 1;
            this.UI_BTN_SortByName.Text = "Sort By Name";
            this.UI_BTN_SortByName.UseVisualStyleBackColor = true;
            this.UI_BTN_SortByName.Click += new System.EventHandler(this.UI_BTN_SortByName_Click);
            // 
            // UI_BTN_SingleCharSymbols
            // 
            this.UI_BTN_SingleCharSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_SingleCharSymbols.Location = new System.Drawing.Point(454, 41);
            this.UI_BTN_SingleCharSymbols.Name = "UI_BTN_SingleCharSymbols";
            this.UI_BTN_SingleCharSymbols.Size = new System.Drawing.Size(167, 23);
            this.UI_BTN_SingleCharSymbols.TabIndex = 2;
            this.UI_BTN_SingleCharSymbols.Text = "Single Character Symbols";
            this.UI_BTN_SingleCharSymbols.UseVisualStyleBackColor = true;
            this.UI_BTN_SingleCharSymbols.Click += new System.EventHandler(this.UI_BTN_SingleCharSymbols_Click);
            // 
            // UI_BTN_SortByAtomic
            // 
            this.UI_BTN_SortByAtomic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_SortByAtomic.Location = new System.Drawing.Point(454, 70);
            this.UI_BTN_SortByAtomic.Name = "UI_BTN_SortByAtomic";
            this.UI_BTN_SortByAtomic.Size = new System.Drawing.Size(167, 23);
            this.UI_BTN_SortByAtomic.TabIndex = 3;
            this.UI_BTN_SortByAtomic.Text = "Sort By Atomic #";
            this.UI_BTN_SortByAtomic.UseVisualStyleBackColor = true;
            this.UI_BTN_SortByAtomic.Click += new System.EventHandler(this.UI_BTN_SortByAtomic_Click);
            // 
            // UI_LBL_ChemicalFormula
            // 
            this.UI_LBL_ChemicalFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_LBL_ChemicalFormula.AutoSize = true;
            this.UI_LBL_ChemicalFormula.Location = new System.Drawing.Point(8, 261);
            this.UI_LBL_ChemicalFormula.Name = "UI_LBL_ChemicalFormula";
            this.UI_LBL_ChemicalFormula.Size = new System.Drawing.Size(96, 13);
            this.UI_LBL_ChemicalFormula.TabIndex = 4;
            this.UI_LBL_ChemicalFormula.Text = "Chemical Formula: ";
            // 
            // UI_LBL_Search
            // 
            this.UI_LBL_Search.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UI_LBL_Search.AutoSize = true;
            this.UI_LBL_Search.Location = new System.Drawing.Point(454, 145);
            this.UI_LBL_Search.Name = "UI_LBL_Search";
            this.UI_LBL_Search.Size = new System.Drawing.Size(41, 13);
            this.UI_LBL_Search.TabIndex = 5;
            this.UI_LBL_Search.Text = "Search";
            // 
            // UI_LBL_ApproxMolarMass
            // 
            this.UI_LBL_ApproxMolarMass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LBL_ApproxMolarMass.AutoSize = true;
            this.UI_LBL_ApproxMolarMass.Location = new System.Drawing.Point(341, 261);
            this.UI_LBL_ApproxMolarMass.Name = "UI_LBL_ApproxMolarMass";
            this.UI_LBL_ApproxMolarMass.Size = new System.Drawing.Size(103, 13);
            this.UI_LBL_ApproxMolarMass.TabIndex = 6;
            this.UI_LBL_ApproxMolarMass.Text = "Approx. Molar Mass:";
            // 
            // UI_TXT_ChemicalFormula
            // 
            this.UI_TXT_ChemicalFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_TXT_ChemicalFormula.Location = new System.Drawing.Point(99, 258);
            this.UI_TXT_ChemicalFormula.Name = "UI_TXT_ChemicalFormula";
            this.UI_TXT_ChemicalFormula.Size = new System.Drawing.Size(236, 20);
            this.UI_TXT_ChemicalFormula.TabIndex = 7;
            this.UI_TXT_ChemicalFormula.TextChanged += new System.EventHandler(this.UI_TXT_ChemicalFormula_TextChanged);
            // 
            // UI_TXT_Search
            // 
            this.UI_TXT_Search.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UI_TXT_Search.Location = new System.Drawing.Point(453, 161);
            this.UI_TXT_Search.Name = "UI_TXT_Search";
            this.UI_TXT_Search.Size = new System.Drawing.Size(167, 20);
            this.UI_TXT_Search.TabIndex = 8;
            this.UI_TXT_Search.TextChanged += new System.EventHandler(this.UI_TXT_Search_TextChanged);
            // 
            // UI_TxtBox_AproxMolarMass
            // 
            this.UI_TxtBox_AproxMolarMass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TxtBox_AproxMolarMass.BackColor = System.Drawing.Color.White;
            this.UI_TxtBox_AproxMolarMass.ForeColor = System.Drawing.SystemColors.InfoText;
            this.UI_TxtBox_AproxMolarMass.Location = new System.Drawing.Point(450, 258);
            this.UI_TxtBox_AproxMolarMass.Name = "UI_TxtBox_AproxMolarMass";
            this.UI_TxtBox_AproxMolarMass.ReadOnly = true;
            this.UI_TxtBox_AproxMolarMass.Size = new System.Drawing.Size(167, 20);
            this.UI_TxtBox_AproxMolarMass.TabIndex = 9;
            this.UI_TxtBox_AproxMolarMass.Text = "Input a Formula";
            this.UI_TxtBox_AproxMolarMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 292);
            this.Controls.Add(this.UI_TxtBox_AproxMolarMass);
            this.Controls.Add(this.UI_TXT_Search);
            this.Controls.Add(this.UI_TXT_ChemicalFormula);
            this.Controls.Add(this.UI_LBL_ApproxMolarMass);
            this.Controls.Add(this.UI_LBL_Search);
            this.Controls.Add(this.UI_LBL_ChemicalFormula);
            this.Controls.Add(this.UI_BTN_SortByAtomic);
            this.Controls.Add(this.UI_BTN_SingleCharSymbols);
            this.Controls.Add(this.UI_BTN_SortByName);
            this.Controls.Add(this.UI_DataGrid);
            this.Name = "MMC";
            this.Text = "LINQ MMC - Adrian Baira, Griffin Bravo";
            this.Load += new System.EventHandler(this.MMC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UI_DataGrid;
        private System.Windows.Forms.Button UI_BTN_SortByName;
        private System.Windows.Forms.Button UI_BTN_SingleCharSymbols;
        private System.Windows.Forms.Button UI_BTN_SortByAtomic;
        private System.Windows.Forms.Label UI_LBL_ChemicalFormula;
        private System.Windows.Forms.Label UI_LBL_Search;
        private System.Windows.Forms.Label UI_LBL_ApproxMolarMass;
        private System.Windows.Forms.TextBox UI_TXT_ChemicalFormula;
        private System.Windows.Forms.TextBox UI_TXT_Search;
        private System.Windows.Forms.TextBox UI_TxtBox_AproxMolarMass;
    }
}

