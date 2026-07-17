namespace CeDev.DataMng
{
    partial class TDashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSearch = new Button();
            stackChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            gridSection = new DataGridView();
            detailChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detailChart).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 39;
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnSearch, 0, 0);
            tableLayoutPanel1.Controls.Add(stackChart, 0, 1);
            tableLayoutPanel1.Controls.Add(gridSection, 0, 2);
            tableLayoutPanel1.Controls.Add(detailChart, 1, 1);
            tableLayoutPanel1.Location = new Point(12, 48);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.1928377F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.80716F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 177F));
            tableLayoutPanel1.Size = new Size(1247, 605);
            tableLayoutPanel1.TabIndex = 50;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(3, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 30);
            btnSearch.TabIndex = 51;
            btnSearch.Text = "조회";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // stackChart
            // 
            chartArea3.Name = "ChartArea1";
            stackChart.ChartAreas.Add(chartArea3);
            stackChart.Dock = DockStyle.Fill;
            legend3.Name = "Legend1";
            stackChart.Legends.Add(legend3);
            stackChart.Location = new Point(3, 46);
            stackChart.Name = "stackChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            dataPoint4.Label = "전일";
            dataPoint5.IsValueShownAsLabel = true;
            dataPoint5.Label = "주별";
            dataPoint6.IsValueShownAsLabel = true;
            dataPoint6.Label = "월별";
            series3.Points.Add(dataPoint4);
            series3.Points.Add(dataPoint5);
            series3.Points.Add(dataPoint6);
            stackChart.Series.Add(series3);
            stackChart.Size = new Size(617, 378);
            stackChart.TabIndex = 0;
            stackChart.Text = "chart1";
            // 
            // gridSection
            // 
            gridSection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSection.Dock = DockStyle.Fill;
            gridSection.Location = new Point(3, 430);
            gridSection.Name = "gridSection";
            gridSection.Size = new Size(617, 172);
            gridSection.TabIndex = 1;
            // 
            // detailChart
            // 
            chartArea4.Name = "ChartArea1";
            detailChart.ChartAreas.Add(chartArea4);
            detailChart.Dock = DockStyle.Fill;
            legend4.Name = "Legend1";
            detailChart.Legends.Add(legend4);
            detailChart.Location = new Point(626, 46);
            detailChart.Name = "detailChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            detailChart.Series.Add(series4);
            detailChart.Size = new Size(618, 378);
            detailChart.TabIndex = 52;
            detailChart.Text = "chart1";
            // 
            // TDashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 665);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label2);
            Name = "TDashBoard";
            Text = "대쉬보드";
            Load += SeriesMng_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stackChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSection).EndInit();
            ((System.ComponentModel.ISupportInitialize)detailChart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSearch;
        private System.Windows.Forms.DataVisualization.Charting.Chart stackChart;
        private DataGridView gridSection;
        private System.Windows.Forms.DataVisualization.Charting.Chart detailChart;
    }
}