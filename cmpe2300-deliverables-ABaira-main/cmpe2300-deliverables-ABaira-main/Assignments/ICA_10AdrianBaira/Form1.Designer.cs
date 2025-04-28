namespace ICA_10AdrianBaira
{
    partial class ICA10
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
            this.UI_BTN_MakeList = new System.Windows.Forms.Button();
            this.UI_BTN_ShuffleIt = new System.Windows.Forms.Button();
            this.UI_BTN__FilterOrder = new System.Windows.Forms.Button();
            this.UI__BTN_PopulateLinked = new System.Windows.Forms.Button();
            this.UI_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.UI_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_BTN_MakeList
            // 
            this.UI_BTN_MakeList.Location = new System.Drawing.Point(12, 38);
            this.UI_BTN_MakeList.Name = "UI_BTN_MakeList";
            this.UI_BTN_MakeList.Size = new System.Drawing.Size(194, 70);
            this.UI_BTN_MakeList.TabIndex = 0;
            this.UI_BTN_MakeList.Text = "Make List";
            this.UI_BTN_MakeList.UseVisualStyleBackColor = true;
            this.UI_BTN_MakeList.Click += new System.EventHandler(this.UI_BTN_MakeList_Click);
            // 
            // UI_BTN_ShuffleIt
            // 
            this.UI_BTN_ShuffleIt.Location = new System.Drawing.Point(12, 114);
            this.UI_BTN_ShuffleIt.Name = "UI_BTN_ShuffleIt";
            this.UI_BTN_ShuffleIt.Size = new System.Drawing.Size(194, 70);
            this.UI_BTN_ShuffleIt.TabIndex = 1;
            this.UI_BTN_ShuffleIt.Text = "Shuffle it !";
            this.UI_BTN_ShuffleIt.UseVisualStyleBackColor = true;
            this.UI_BTN_ShuffleIt.Click += new System.EventHandler(this.UI_BTN_ShuffleIt_Click);
            // 
            // UI_BTN__FilterOrder
            // 
            this.UI_BTN__FilterOrder.Location = new System.Drawing.Point(12, 266);
            this.UI_BTN__FilterOrder.Name = "UI_BTN__FilterOrder";
            this.UI_BTN__FilterOrder.Size = new System.Drawing.Size(194, 70);
            this.UI_BTN__FilterOrder.TabIndex = 2;
            this.UI_BTN__FilterOrder.Text = "Filter and Order Linked List";
            this.UI_BTN__FilterOrder.UseVisualStyleBackColor = true;
            this.UI_BTN__FilterOrder.Click += new System.EventHandler(this.UI_BTN__FilterOrder_Click);
            // 
            // UI__BTN_PopulateLinked
            // 
            this.UI__BTN_PopulateLinked.Location = new System.Drawing.Point(12, 190);
            this.UI__BTN_PopulateLinked.Name = "UI__BTN_PopulateLinked";
            this.UI__BTN_PopulateLinked.Size = new System.Drawing.Size(194, 70);
            this.UI__BTN_PopulateLinked.TabIndex = 3;
            this.UI__BTN_PopulateLinked.Text = "Populate Linked List";
            this.UI__BTN_PopulateLinked.UseVisualStyleBackColor = true;
            this.UI__BTN_PopulateLinked.Click += new System.EventHandler(this.UI__BTN_PopulateLinked_Click);
            // 
            // UI_NumericUpDown
            // 
            this.UI_NumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.UI_NumericUpDown.Location = new System.Drawing.Point(12, 12);
            this.UI_NumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.UI_NumericUpDown.Name = "UI_NumericUpDown";
            this.UI_NumericUpDown.Size = new System.Drawing.Size(194, 20);
            this.UI_NumericUpDown.TabIndex = 4;
            this.UI_NumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // ICA10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 359);
            this.Controls.Add(this.UI_NumericUpDown);
            this.Controls.Add(this.UI__BTN_PopulateLinked);
            this.Controls.Add(this.UI_BTN__FilterOrder);
            this.Controls.Add(this.UI_BTN_ShuffleIt);
            this.Controls.Add(this.UI_BTN_MakeList);
            this.Name = "ICA10";
            this.Text = "ICA10";
            ((System.ComponentModel.ISupportInitialize)(this.UI_NumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_MakeList;
        private System.Windows.Forms.Button UI_BTN_ShuffleIt;
        private System.Windows.Forms.Button UI_BTN__FilterOrder;
        private System.Windows.Forms.Button UI__BTN_PopulateLinked;
        private System.Windows.Forms.NumericUpDown UI_NumericUpDown;
    }
}

