namespace CeDev
{
    partial class HousTradVolume
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            lblYear = new Label();
            lblRegion = new Label();
            txtRegion = new TextBox();
            txtYear = new TextBox();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(985, 17);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(116, 38);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "조회";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 414);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(618, 153);
            dataGridView1.TabIndex = 1;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(316, 31);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(31, 15);
            lblYear.TabIndex = 2;
            lblYear.Text = "년도";
            // 
            // lblRegion
            // 
            lblRegion.AutoSize = true;
            lblRegion.Location = new Point(32, 31);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new Size(31, 15);
            lblRegion.TabIndex = 3;
            lblRegion.Text = "지역";
            // 
            // txtRegion
            // 
            txtRegion.Location = new Point(93, 26);
            txtRegion.Name = "txtRegion";
            txtRegion.Size = new Size(187, 23);
            txtRegion.TabIndex = 4;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(368, 26);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(114, 23);
            txtYear.TabIndex = 5;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(28, 72);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(1073, 323);
            chart1.TabIndex = 6;
            chart1.Text = "chart1";
            // 
            // HousTradVolume
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 579);
            Controls.Add(chart1);
            Controls.Add(txtYear);
            Controls.Add(txtRegion);
            Controls.Add(lblRegion);
            Controls.Add(lblYear);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Name = "HousTradVolume";
            Text = "주택 거래량";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private DataGridView dataGridView1;
        private Label lblYear;
        private Label lblRegion;
        private TextBox txtRegion;
        private TextBox txtYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
