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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            stackChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel4 = new TableLayoutPanel();
            gridMonth = new DataGridView();
            gridWeek = new DataGridView();
            gridDay = new DataGridView();
            detailChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            cboWave = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnSearch = new Button();
            gridLot = new DataGridView();
            gridSection = new DataGridView();
            chartSite = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartEquip = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartTech = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackChart).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridWeek).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridDay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detailChart).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartSite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartEquip).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTech).BeginInit();
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.5068169F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.4931831F));
            tableLayoutPanel1.Controls.Add(stackChart, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 1, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Controls.Add(detailChart, 1, 1);
            tableLayoutPanel1.Controls.Add(gridSection, 0, 2);
            tableLayoutPanel1.Location = new Point(12, 48);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.1928377F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.80716F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 285F));
            tableLayoutPanel1.Size = new Size(1247, 684);
            tableLayoutPanel1.TabIndex = 50;
            // 
            // stackChart
            // 
            chartArea11.Name = "ChartArea1";
            stackChart.ChartAreas.Add(chartArea11);
            stackChart.Dock = DockStyle.Fill;
            legend11.Name = "Legend1";
            stackChart.Legends.Add(legend11);
            stackChart.Location = new Point(3, 43);
            stackChart.Name = "stackChart";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            dataPoint7.Label = "전일";
            dataPoint8.IsValueShownAsLabel = true;
            dataPoint8.Label = "주별";
            dataPoint9.IsValueShownAsLabel = true;
            dataPoint9.Label = "월별";
            series11.Points.Add(dataPoint7);
            series11.Points.Add(dataPoint8);
            series11.Points.Add(dataPoint9);
            stackChart.Series.Add(series11);
            stackChart.Size = new Size(549, 352);
            stackChart.TabIndex = 0;
            stackChart.Text = "chart1";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 232F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 223F));
            tableLayoutPanel4.Controls.Add(chartTech, 2, 0);
            tableLayoutPanel4.Controls.Add(chartEquip, 1, 0);
            tableLayoutPanel4.Controls.Add(chartSite, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(558, 401);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(686, 280);
            tableLayoutPanel4.TabIndex = 51;
            // 
            // gridMonth
            // 
            gridMonth.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMonth.Location = new Point(1265, 567);
            gridMonth.Name = "gridMonth";
            gridMonth.Size = new Size(158, 124);
            gridMonth.TabIndex = 4;
            // 
            // gridWeek
            // 
            gridWeek.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridWeek.Location = new Point(1265, 438);
            gridWeek.Name = "gridWeek";
            gridWeek.Size = new Size(158, 123);
            gridWeek.TabIndex = 3;
            // 
            // gridDay
            // 
            gridDay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDay.Location = new Point(1265, 325);
            gridDay.Name = "gridDay";
            gridDay.Size = new Size(158, 107);
            gridDay.TabIndex = 2;
            // 
            // detailChart
            // 
            chartArea12.Name = "ChartArea1";
            detailChart.ChartAreas.Add(chartArea12);
            detailChart.Dock = DockStyle.Fill;
            legend12.Name = "Legend1";
            detailChart.Legends.Add(legend12);
            detailChart.Location = new Point(558, 43);
            detailChart.Name = "detailChart";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            detailChart.Series.Add(series12);
            detailChart.Size = new Size(686, 352);
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
            tableLayoutPanel2.Location = new Point(558, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(686, 34);
            tableLayoutPanel2.TabIndex = 53;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(489, 9);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 52;
            label1.Text = "파장";
            // 
            // cboWave
            // 
            cboWave.Anchor = AnchorStyles.None;
            cboWave.FormattingEnabled = true;
            cboWave.Location = new Point(546, 5);
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
            tableLayoutPanel3.Size = new Size(549, 34);
            tableLayoutPanel3.TabIndex = 54;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(449, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(91, 28);
            btnSearch.TabIndex = 51;
            btnSearch.Text = "조회";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // gridLot
            // 
            gridLot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLot.Location = new Point(1265, 48);
            gridLot.Name = "gridLot";
            gridLot.Size = new Size(158, 145);
            gridLot.TabIndex = 55;
            // 
            // gridSection
            // 
            gridSection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSection.Dock = DockStyle.Fill;
            gridSection.Location = new Point(3, 401);
            gridSection.Name = "gridSection";
            gridSection.Size = new Size(549, 280);
            gridSection.TabIndex = 1;
            // 
            // chartSite
            // 
            chartArea13.Name = "ChartArea1";
            chartSite.ChartAreas.Add(chartArea13);
            chartSite.Dock = DockStyle.Fill;
            legend13.Name = "Legend1";
            chartSite.Legends.Add(legend13);
            chartSite.Location = new Point(3, 3);
            chartSite.Name = "chartSite";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            chartSite.Series.Add(series13);
            chartSite.Size = new Size(225, 274);
            chartSite.TabIndex = 53;
            chartSite.Text = "chart1";
            // 
            // chartEquip
            // 
            chartArea14.Name = "ChartArea1";
            chartEquip.ChartAreas.Add(chartArea14);
            chartEquip.Dock = DockStyle.Fill;
            legend14.Name = "Legend1";
            chartEquip.Legends.Add(legend14);
            chartEquip.Location = new Point(234, 3);
            chartEquip.Name = "chartEquip";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            chartEquip.Series.Add(series14);
            chartEquip.Size = new Size(226, 274);
            chartEquip.TabIndex = 54;
            chartEquip.Text = "chart2";
            // 
            // chartTech
            // 
            chartArea15.Name = "ChartArea1";
            chartTech.ChartAreas.Add(chartArea15);
            chartTech.Dock = DockStyle.Fill;
            legend15.Name = "Legend1";
            chartTech.Legends.Add(legend15);
            chartTech.Location = new Point(466, 3);
            chartTech.Name = "chartTech";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            chartTech.Series.Add(series15);
            chartTech.Size = new Size(217, 274);
            chartTech.TabIndex = 55;
            chartTech.Text = "chart3";
            // 
            // TDashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1452, 780);
            Controls.Add(gridMonth);
            Controls.Add(gridWeek);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(gridDay);
            Controls.Add(label2);
            Controls.Add(gridLot);
            Name = "TDashBoard";
            Text = "대쉬보드";
            Load += SeriesMng_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stackChart).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridWeek).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridDay).EndInit();
            ((System.ComponentModel.ISupportInitialize)detailChart).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridLot).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSection).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartSite).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartEquip).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTech).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTech;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEquip;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSite;
    }
}