
namespace ICA16_AdrianBaira
{
    partial class ICA16
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
            this.UI_LISTBOX_SensorsWithTemp = new System.Windows.Forms.ListBox();
            this.UI_RAD_Ascending = new System.Windows.Forms.RadioButton();
            this.UI_GROUPBOX_SortOrder = new System.Windows.Forms.GroupBox();
            this.UI_RAD_Descending = new System.Windows.Forms.RadioButton();
            this.UI_LBL_RawDataList = new System.Windows.Forms.Label();
            this.UI_GROUPBOX_SortCriteria = new System.Windows.Forms.GroupBox();
            this.UI_RAD_Temperature = new System.Windows.Forms.RadioButton();
            this.UI_RAD_SensorId = new System.Windows.Forms.RadioButton();
            this.UI_GROUPBOX_SelectionCriteria = new System.Windows.Forms.GroupBox();
            this.UI_RAD_LessthanEqual = new System.Windows.Forms.RadioButton();
            this.UI_RAD_GreaterthanEqual = new System.Windows.Forms.RadioButton();
            this.UI_TXTBOX_NumberOfSensors = new System.Windows.Forms.TextBox();
            this.UI_BTN_GenerateSensors = new System.Windows.Forms.Button();
            this.UI_TXTBOX_TemperatureValue = new System.Windows.Forms.TextBox();
            this.UI_LBL_DataSortedOn = new System.Windows.Forms.Label();
            this.UI_LBL_SensorsWithTemp = new System.Windows.Forms.Label();
            this.UI_LISTBOX_DataSortedOn = new System.Windows.Forms.ListBox();
            this.UI_LISTBOX_RawData = new System.Windows.Forms.ListBox();
            this.UI_LBL_NumberofSensors = new System.Windows.Forms.Label();
            this.UI_BTN_Redisplay = new System.Windows.Forms.Button();
            this.UI_BTN_DisplaySorted = new System.Windows.Forms.Button();
            this.UI_BTN_DisplaySelected = new System.Windows.Forms.Button();
            this.UI_LBL_TemperatureValue = new System.Windows.Forms.Label();
            this.UI_GROUPBOX_SortOrder.SuspendLayout();
            this.UI_GROUPBOX_SortCriteria.SuspendLayout();
            this.UI_GROUPBOX_SelectionCriteria.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_LISTBOX_SensorsWithTemp
            // 
            this.UI_LISTBOX_SensorsWithTemp.FormattingEnabled = true;
            this.UI_LISTBOX_SensorsWithTemp.ItemHeight = 20;
            this.UI_LISTBOX_SensorsWithTemp.Location = new System.Drawing.Point(1008, 57);
            this.UI_LISTBOX_SensorsWithTemp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_LISTBOX_SensorsWithTemp.Name = "UI_LISTBOX_SensorsWithTemp";
            this.UI_LISTBOX_SensorsWithTemp.Size = new System.Drawing.Size(410, 424);
            this.UI_LISTBOX_SensorsWithTemp.TabIndex = 0;
            // 
            // UI_RAD_Ascending
            // 
            this.UI_RAD_Ascending.AutoSize = true;
            this.UI_RAD_Ascending.Checked = true;
            this.UI_RAD_Ascending.Location = new System.Drawing.Point(42, 71);
            this.UI_RAD_Ascending.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_Ascending.Name = "UI_RAD_Ascending";
            this.UI_RAD_Ascending.Size = new System.Drawing.Size(109, 24);
            this.UI_RAD_Ascending.TabIndex = 2;
            this.UI_RAD_Ascending.TabStop = true;
            this.UI_RAD_Ascending.Text = "Ascending";
            this.UI_RAD_Ascending.UseVisualStyleBackColor = true;
            // 
            // UI_GROUPBOX_SortOrder
            // 
            this.UI_GROUPBOX_SortOrder.Controls.Add(this.UI_RAD_Descending);
            this.UI_GROUPBOX_SortOrder.Controls.Add(this.UI_RAD_Ascending);
            this.UI_GROUPBOX_SortOrder.Location = new System.Drawing.Point(546, 666);
            this.UI_GROUPBOX_SortOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_GROUPBOX_SortOrder.Name = "UI_GROUPBOX_SortOrder";
            this.UI_GROUPBOX_SortOrder.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_GROUPBOX_SortOrder.Size = new System.Drawing.Size(412, 154);
            this.UI_GROUPBOX_SortOrder.TabIndex = 4;
            this.UI_GROUPBOX_SortOrder.TabStop = false;
            this.UI_GROUPBOX_SortOrder.Text = "Sort Order";
            // 
            // UI_RAD_Descending
            // 
            this.UI_RAD_Descending.AutoSize = true;
            this.UI_RAD_Descending.Location = new System.Drawing.Point(238, 71);
            this.UI_RAD_Descending.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_Descending.Name = "UI_RAD_Descending";
            this.UI_RAD_Descending.Size = new System.Drawing.Size(119, 24);
            this.UI_RAD_Descending.TabIndex = 3;
            this.UI_RAD_Descending.Text = "Decsending";
            this.UI_RAD_Descending.UseVisualStyleBackColor = true;
            // 
            // UI_LBL_RawDataList
            // 
            this.UI_LBL_RawDataList.AutoSize = true;
            this.UI_LBL_RawDataList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LBL_RawDataList.Location = new System.Drawing.Point(164, 14);
            this.UI_LBL_RawDataList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_LBL_RawDataList.Name = "UI_LBL_RawDataList";
            this.UI_LBL_RawDataList.Size = new System.Drawing.Size(216, 37);
            this.UI_LBL_RawDataList.TabIndex = 0;
            this.UI_LBL_RawDataList.Text = "Raw Data List";
            // 
            // UI_GROUPBOX_SortCriteria
            // 
            this.UI_GROUPBOX_SortCriteria.Controls.Add(this.UI_RAD_Temperature);
            this.UI_GROUPBOX_SortCriteria.Controls.Add(this.UI_RAD_SensorId);
            this.UI_GROUPBOX_SortCriteria.Location = new System.Drawing.Point(546, 503);
            this.UI_GROUPBOX_SortCriteria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_GROUPBOX_SortCriteria.Name = "UI_GROUPBOX_SortCriteria";
            this.UI_GROUPBOX_SortCriteria.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_GROUPBOX_SortCriteria.Size = new System.Drawing.Size(412, 154);
            this.UI_GROUPBOX_SortCriteria.TabIndex = 7;
            this.UI_GROUPBOX_SortCriteria.TabStop = false;
            this.UI_GROUPBOX_SortCriteria.Text = "Sort Criteria";
            // 
            // UI_RAD_Temperature
            // 
            this.UI_RAD_Temperature.AutoSize = true;
            this.UI_RAD_Temperature.Location = new System.Drawing.Point(238, 72);
            this.UI_RAD_Temperature.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_Temperature.Name = "UI_RAD_Temperature";
            this.UI_RAD_Temperature.Size = new System.Drawing.Size(125, 24);
            this.UI_RAD_Temperature.TabIndex = 3;
            this.UI_RAD_Temperature.Text = "Temperature";
            this.UI_RAD_Temperature.UseVisualStyleBackColor = true;
            // 
            // UI_RAD_SensorId
            // 
            this.UI_RAD_SensorId.AutoSize = true;
            this.UI_RAD_SensorId.Checked = true;
            this.UI_RAD_SensorId.Location = new System.Drawing.Point(42, 71);
            this.UI_RAD_SensorId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_SensorId.Name = "UI_RAD_SensorId";
            this.UI_RAD_SensorId.Size = new System.Drawing.Size(99, 24);
            this.UI_RAD_SensorId.TabIndex = 2;
            this.UI_RAD_SensorId.TabStop = true;
            this.UI_RAD_SensorId.Text = "SensorId";
            this.UI_RAD_SensorId.UseVisualStyleBackColor = true;
            // 
            // UI_GROUPBOX_SelectionCriteria
            // 
            this.UI_GROUPBOX_SelectionCriteria.Controls.Add(this.UI_RAD_LessthanEqual);
            this.UI_GROUPBOX_SelectionCriteria.Controls.Add(this.UI_RAD_GreaterthanEqual);
            this.UI_GROUPBOX_SelectionCriteria.Location = new System.Drawing.Point(1008, 666);
            this.UI_GROUPBOX_SelectionCriteria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_GROUPBOX_SelectionCriteria.Name = "UI_GROUPBOX_SelectionCriteria";
            this.UI_GROUPBOX_SelectionCriteria.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_GROUPBOX_SelectionCriteria.Size = new System.Drawing.Size(417, 154);
            this.UI_GROUPBOX_SelectionCriteria.TabIndex = 8;
            this.UI_GROUPBOX_SelectionCriteria.TabStop = false;
            this.UI_GROUPBOX_SelectionCriteria.Text = "Selection Criteria";
            // 
            // UI_RAD_LessthanEqual
            // 
            this.UI_RAD_LessthanEqual.AutoSize = true;
            this.UI_RAD_LessthanEqual.Location = new System.Drawing.Point(226, 71);
            this.UI_RAD_LessthanEqual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_LessthanEqual.Name = "UI_RAD_LessthanEqual";
            this.UI_RAD_LessthanEqual.Size = new System.Drawing.Size(167, 24);
            this.UI_RAD_LessthanEqual.TabIndex = 3;
            this.UI_RAD_LessthanEqual.TabStop = true;
            this.UI_RAD_LessthanEqual.Text = "Less than or Equal";
            this.UI_RAD_LessthanEqual.UseVisualStyleBackColor = true;
            // 
            // UI_RAD_GreaterthanEqual
            // 
            this.UI_RAD_GreaterthanEqual.AutoSize = true;
            this.UI_RAD_GreaterthanEqual.Checked = true;
            this.UI_RAD_GreaterthanEqual.Location = new System.Drawing.Point(24, 71);
            this.UI_RAD_GreaterthanEqual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_RAD_GreaterthanEqual.Name = "UI_RAD_GreaterthanEqual";
            this.UI_RAD_GreaterthanEqual.Size = new System.Drawing.Size(192, 24);
            this.UI_RAD_GreaterthanEqual.TabIndex = 2;
            this.UI_RAD_GreaterthanEqual.TabStop = true;
            this.UI_RAD_GreaterthanEqual.Text = "Greater than or Equal ";
            this.UI_RAD_GreaterthanEqual.UseVisualStyleBackColor = true;
            // 
            // UI_TXTBOX_NumberOfSensors
            // 
            this.UI_TXTBOX_NumberOfSensors.Location = new System.Drawing.Point(69, 732);
            this.UI_TXTBOX_NumberOfSensors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_TXTBOX_NumberOfSensors.Name = "UI_TXTBOX_NumberOfSensors";
            this.UI_TXTBOX_NumberOfSensors.Size = new System.Drawing.Size(410, 26);
            this.UI_TXTBOX_NumberOfSensors.TabIndex = 13;
            // 
            // UI_BTN_GenerateSensors
            // 
            this.UI_BTN_GenerateSensors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_BTN_GenerateSensors.Location = new System.Drawing.Point(69, 552);
            this.UI_BTN_GenerateSensors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_BTN_GenerateSensors.Name = "UI_BTN_GenerateSensors";
            this.UI_BTN_GenerateSensors.Size = new System.Drawing.Size(412, 69);
            this.UI_BTN_GenerateSensors.TabIndex = 14;
            this.UI_BTN_GenerateSensors.Text = "Generate Sensors";
            this.UI_BTN_GenerateSensors.UseVisualStyleBackColor = true;
            this.UI_BTN_GenerateSensors.Click += new System.EventHandler(this.UI_BTN_GenerateSensors_Click);
            // 
            // UI_TXTBOX_TemperatureValue
            // 
            this.UI_TXTBOX_TemperatureValue.Location = new System.Drawing.Point(1008, 591);
            this.UI_TXTBOX_TemperatureValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_TXTBOX_TemperatureValue.Name = "UI_TXTBOX_TemperatureValue";
            this.UI_TXTBOX_TemperatureValue.Size = new System.Drawing.Size(415, 26);
            this.UI_TXTBOX_TemperatureValue.TabIndex = 17;
            // 
            // UI_LBL_DataSortedOn
            // 
            this.UI_LBL_DataSortedOn.AutoSize = true;
            this.UI_LBL_DataSortedOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LBL_DataSortedOn.Location = new System.Drawing.Point(628, 14);
            this.UI_LBL_DataSortedOn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_LBL_DataSortedOn.Name = "UI_LBL_DataSortedOn";
            this.UI_LBL_DataSortedOn.Size = new System.Drawing.Size(240, 37);
            this.UI_LBL_DataSortedOn.TabIndex = 22;
            this.UI_LBL_DataSortedOn.Text = "Data Sorted On";
            // 
            // UI_LBL_SensorsWithTemp
            // 
            this.UI_LBL_SensorsWithTemp.AutoSize = true;
            this.UI_LBL_SensorsWithTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LBL_SensorsWithTemp.Location = new System.Drawing.Point(1000, 14);
            this.UI_LBL_SensorsWithTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_LBL_SensorsWithTemp.Name = "UI_LBL_SensorsWithTemp";
            this.UI_LBL_SensorsWithTemp.Size = new System.Drawing.Size(416, 37);
            this.UI_LBL_SensorsWithTemp.TabIndex = 23;
            this.UI_LBL_SensorsWithTemp.Text = "Sensors With Temperatures";
            // 
            // UI_LISTBOX_DataSortedOn
            // 
            this.UI_LISTBOX_DataSortedOn.FormattingEnabled = true;
            this.UI_LISTBOX_DataSortedOn.ItemHeight = 20;
            this.UI_LISTBOX_DataSortedOn.Location = new System.Drawing.Point(546, 57);
            this.UI_LISTBOX_DataSortedOn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_LISTBOX_DataSortedOn.Name = "UI_LISTBOX_DataSortedOn";
            this.UI_LISTBOX_DataSortedOn.Size = new System.Drawing.Size(410, 424);
            this.UI_LISTBOX_DataSortedOn.TabIndex = 24;
            // 
            // UI_LISTBOX_RawData
            // 
            this.UI_LISTBOX_RawData.FormattingEnabled = true;
            this.UI_LISTBOX_RawData.ItemHeight = 20;
            this.UI_LISTBOX_RawData.Location = new System.Drawing.Point(69, 57);
            this.UI_LISTBOX_RawData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_LISTBOX_RawData.Name = "UI_LISTBOX_RawData";
            this.UI_LISTBOX_RawData.Size = new System.Drawing.Size(410, 424);
            this.UI_LISTBOX_RawData.TabIndex = 25;
            // 
            // UI_LBL_NumberofSensors
            // 
            this.UI_LBL_NumberofSensors.AutoSize = true;
            this.UI_LBL_NumberofSensors.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LBL_NumberofSensors.Location = new System.Drawing.Point(123, 689);
            this.UI_LBL_NumberofSensors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_LBL_NumberofSensors.Name = "UI_LBL_NumberofSensors";
            this.UI_LBL_NumberofSensors.Size = new System.Drawing.Size(294, 37);
            this.UI_LBL_NumberofSensors.TabIndex = 26;
            this.UI_LBL_NumberofSensors.Text = "Number of Sensors";
            // 
            // UI_BTN_Redisplay
            // 
            this.UI_BTN_Redisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_BTN_Redisplay.Location = new System.Drawing.Point(69, 862);
            this.UI_BTN_Redisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_BTN_Redisplay.Name = "UI_BTN_Redisplay";
            this.UI_BTN_Redisplay.Size = new System.Drawing.Size(412, 69);
            this.UI_BTN_Redisplay.TabIndex = 27;
            this.UI_BTN_Redisplay.Text = "Redisplay";
            this.UI_BTN_Redisplay.UseVisualStyleBackColor = true;
            this.UI_BTN_Redisplay.Click += new System.EventHandler(this.UI_BTN_Redisplay_Click);
            // 
            // UI_BTN_DisplaySorted
            // 
            this.UI_BTN_DisplaySorted.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_BTN_DisplaySorted.Location = new System.Drawing.Point(555, 862);
            this.UI_BTN_DisplaySorted.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_BTN_DisplaySorted.Name = "UI_BTN_DisplaySorted";
            this.UI_BTN_DisplaySorted.Size = new System.Drawing.Size(412, 69);
            this.UI_BTN_DisplaySorted.TabIndex = 28;
            this.UI_BTN_DisplaySorted.Text = "Display Sorted";
            this.UI_BTN_DisplaySorted.UseVisualStyleBackColor = true;
            this.UI_BTN_DisplaySorted.Click += new System.EventHandler(this.UI_BTN_DisplaySorted_Click);
            // 
            // UI_BTN_DisplaySelected
            // 
            this.UI_BTN_DisplaySelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_BTN_DisplaySelected.Location = new System.Drawing.Point(1006, 862);
            this.UI_BTN_DisplaySelected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UI_BTN_DisplaySelected.Name = "UI_BTN_DisplaySelected";
            this.UI_BTN_DisplaySelected.Size = new System.Drawing.Size(412, 69);
            this.UI_BTN_DisplaySelected.TabIndex = 29;
            this.UI_BTN_DisplaySelected.Text = "DIsplay Selected";
            this.UI_BTN_DisplaySelected.UseVisualStyleBackColor = true;
            this.UI_BTN_DisplaySelected.Click += new System.EventHandler(this.UI_BTN_DisplaySelected_Click);
            // 
            // UI_LBL_TemperatureValue
            // 
            this.UI_LBL_TemperatureValue.AutoSize = true;
            this.UI_LBL_TemperatureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_LBL_TemperatureValue.Location = new System.Drawing.Point(1068, 548);
            this.UI_LBL_TemperatureValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UI_LBL_TemperatureValue.Name = "UI_LBL_TemperatureValue";
            this.UI_LBL_TemperatureValue.Size = new System.Drawing.Size(291, 37);
            this.UI_LBL_TemperatureValue.TabIndex = 30;
            this.UI_LBL_TemperatureValue.Text = "Temperature Value";
            // 
            // ICA16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 997);
            this.Controls.Add(this.UI_LBL_TemperatureValue);
            this.Controls.Add(this.UI_BTN_DisplaySelected);
            this.Controls.Add(this.UI_BTN_DisplaySorted);
            this.Controls.Add(this.UI_BTN_Redisplay);
            this.Controls.Add(this.UI_LBL_NumberofSensors);
            this.Controls.Add(this.UI_LISTBOX_RawData);
            this.Controls.Add(this.UI_LISTBOX_DataSortedOn);
            this.Controls.Add(this.UI_LBL_SensorsWithTemp);
            this.Controls.Add(this.UI_LBL_DataSortedOn);
            this.Controls.Add(this.UI_TXTBOX_TemperatureValue);
            this.Controls.Add(this.UI_BTN_GenerateSensors);
            this.Controls.Add(this.UI_TXTBOX_NumberOfSensors);
            this.Controls.Add(this.UI_GROUPBOX_SelectionCriteria);
            this.Controls.Add(this.UI_GROUPBOX_SortCriteria);
            this.Controls.Add(this.UI_LBL_RawDataList);
            this.Controls.Add(this.UI_GROUPBOX_SortOrder);
            this.Controls.Add(this.UI_LISTBOX_SensorsWithTemp);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ICA16";
            this.Text = "ICA16";
            this.UI_GROUPBOX_SortOrder.ResumeLayout(false);
            this.UI_GROUPBOX_SortOrder.PerformLayout();
            this.UI_GROUPBOX_SortCriteria.ResumeLayout(false);
            this.UI_GROUPBOX_SortCriteria.PerformLayout();
            this.UI_GROUPBOX_SelectionCriteria.ResumeLayout(false);
            this.UI_GROUPBOX_SelectionCriteria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UI_LISTBOX_SensorsWithTemp;
        private System.Windows.Forms.RadioButton UI_RAD_Ascending;
        private System.Windows.Forms.GroupBox UI_GROUPBOX_SortOrder;
        private System.Windows.Forms.RadioButton UI_RAD_Descending;
        private System.Windows.Forms.Label UI_LBL_RawDataList;
        private System.Windows.Forms.GroupBox UI_GROUPBOX_SortCriteria;
        private System.Windows.Forms.RadioButton UI_RAD_Temperature;
        private System.Windows.Forms.RadioButton UI_RAD_SensorId;
        private System.Windows.Forms.GroupBox UI_GROUPBOX_SelectionCriteria;
        private System.Windows.Forms.RadioButton UI_RAD_LessthanEqual;
        private System.Windows.Forms.RadioButton UI_RAD_GreaterthanEqual;
        private System.Windows.Forms.TextBox UI_TXTBOX_NumberOfSensors;
        private System.Windows.Forms.Button UI_BTN_GenerateSensors;
        private System.Windows.Forms.TextBox UI_TXTBOX_TemperatureValue;
        private System.Windows.Forms.Label UI_LBL_DataSortedOn;
        private System.Windows.Forms.Label UI_LBL_SensorsWithTemp;
        private System.Windows.Forms.ListBox UI_LISTBOX_DataSortedOn;
        private System.Windows.Forms.ListBox UI_LISTBOX_RawData;
        private System.Windows.Forms.Label UI_LBL_NumberofSensors;
        private System.Windows.Forms.Button UI_BTN_Redisplay;
        private System.Windows.Forms.Button UI_BTN_DisplaySorted;
        private System.Windows.Forms.Button UI_BTN_DisplaySelected;
        private System.Windows.Forms.Label UI_LBL_TemperatureValue;
    }
}

