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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            gridLot = new DataGridView();
            stackChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            gridSection = new DataGridView();
            detailChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            cboWave = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnSearch = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            gridDay = new DataGridView();
            gridWeek = new DataGridView();
            gridMonth = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stackChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detailChart).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridDay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridWeek).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridMonth).BeginInit();
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
            tableLayoutPanel1.Controls.Add(stackChart, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 1, 2);
            tableLayoutPanel1.Controls.Add(detailChart, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Controls.Add(gridLot, 0, 2);
            tableLayoutPanel1.Location = new Point(12, 48);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.1928377F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.80716F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 177F));
            tableLayoutPanel1.Size = new Size(1247, 605);
            tableLayoutPanel1.TabIndex = 50;
            // 
            // gridLot
            // 
            gridLot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLot.Location = new Point(3, 430);
            gridLot.Name = "gridLot";
            gridLot.Size = new Size(617, 172);
            gridLot.TabIndex = 55;
            // 
            // stackChart
            // 
            chartArea1.Name = "ChartArea1";
            stackChart.ChartAreas.Add(chartArea1);
            stackChart.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            stackChart.Legends.Add(legend1);
            stackChart.Location = new Point(3, 46);
            stackChart.Name = "stackChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            dataPoint1.Label = "전일";
            dataPoint2.IsValueShownAsLabel = true;
            dataPoint2.Label = "주별";
            dataPoint3.IsValueShownAsLabel = true;
            dataPoint3.Label = "월별";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            stackChart.Series.Add(series1);
            stackChart.Size = new Size(617, 378);
            stackChart.TabIndex = 0;
            stackChart.Text = "chart1";
            // 
            // gridSection
            // 
            gridSection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSection.Location = new Point(1265, 94);
            gridSection.Name = "gridSection";
            gridSection.Size = new Size(175, 120);
            gridSection.TabIndex = 1;
            // 
            // detailChart
            // 
            chartArea2.Name = "ChartArea1";
            detailChart.ChartAreas.Add(chartArea2);
            detailChart.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            detailChart.Legends.Add(legend2);
            detailChart.Location = new Point(626, 46);
            detailChart.Name = "detailChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            detailChart.Series.Add(series2);
            detailChart.Size = new Size(618, 378);
            detailChart.TabIndex = 52;
            detailChart.Text = "chart1";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90.47619F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.523809F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tableLayoutPanel2.Controls.Add(label1, 1, 0);
            tableLayoutPanel2.Controls.Add(cboWave, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(626, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(618, 37);
            tableLayoutPanel2.TabIndex = 53;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(424, 11);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 52;
            label1.Text = "파장";
            // 
            // cboWave
            // 
            cboWave.Anchor = AnchorStyles.None;
            cboWave.FormattingEnabled = true;
            cboWave.Location = new Point(478, 7);
            cboWave.Name = "cboWave";
            cboWave.Size = new Size(123, 23);
            cboWave.TabIndex = 51;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102F));
            tableLayoutPanel3.Controls.Add(btnSearch, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(617, 37);
            tableLayoutPanel3.TabIndex = 54;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(517, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(91, 30);
            btnSearch.TabIndex = 51;
            btnSearch.Text = "조회";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 212F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 194F));
            tableLayoutPanel4.Controls.Add(gridMonth, 2, 0);
            tableLayoutPanel4.Controls.Add(gridWeek, 1, 0);
            tableLayoutPanel4.Controls.Add(gridDay, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(626, 430);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(618, 172);
            tableLayoutPanel4.TabIndex = 51;
            // 
            // gridDay
            // 
            gridDay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDay.Dock = DockStyle.Fill;
            gridDay.Location = new Point(3, 3);
            gridDay.Name = "gridDay";
            gridDay.Size = new Size(206, 166);
            gridDay.TabIndex = 2;
            // 
            // gridWeek
            // 
            gridWeek.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridWeek.Dock = DockStyle.Fill;
            gridWeek.Location = new Point(215, 3);
            gridWeek.Name = "gridWeek";
            gridWeek.Size = new Size(206, 166);
            gridWeek.TabIndex = 3;
            // 
            // gridMonth
            // 
            gridMonth.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMonth.Dock = DockStyle.Fill;
            gridMonth.Location = new Point(427, 3);
            gridMonth.Name = "gridMonth";
            gridMonth.Size = new Size(188, 166);
            gridMonth.TabIndex = 4;
            // 
            // TDashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1452, 665);
            Controls.Add(gridSection);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label2);
            Name = "TDashBoard";
            Text = "대쉬보드";
            Load += SeriesMng_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridLot).EndInit();
            ((System.ComponentModel.ISupportInitialize)stackChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSection).EndInit();
            ((System.ComponentModel.ISupportInitialize)detailChart).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridDay).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridWeek).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridMonth).EndInit();
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
        private ComboBox cboWave;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView gridLot;
        private TableLayoutPanel tableLayoutPanel4;
        private DataGridView gridMonth;
        private DataGridView gridWeek;
        private DataGridView gridDay;
    }
}