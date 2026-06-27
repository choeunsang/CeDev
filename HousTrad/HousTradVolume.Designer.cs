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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            lblCnt = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            lblCnt2 = new Label();
            dataGridView2 = new DataGridView();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            rdoBtnYear = new RadioButton();
            rdoBtnMon = new RadioButton();
            cboMon = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1191, 12);
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
            dataGridView1.Location = new Point(37, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(599, 306);
            dataGridView1.TabIndex = 1;
            // 
            // lblCnt
            // 
            lblCnt.AutoSize = true;
            lblCnt.Location = new Point(37, 370);
            lblCnt.Name = "lblCnt";
            lblCnt.Size = new Size(47, 15);
            lblCnt.TabIndex = 32;
            lblCnt.Text = "총 건수";
            lblCnt.TextAlign = ContentAlignment.TopRight;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(642, 55);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(665, 312);
            chart1.TabIndex = 33;
            chart1.Text = "chart1";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(448, 373);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(188, 23);
            progressBar1.TabIndex = 36;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(448, 714);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(188, 23);
            progressBar2.TabIndex = 39;
            // 
            // lblCnt2
            // 
            lblCnt2.AutoSize = true;
            lblCnt2.Location = new Point(37, 711);
            lblCnt2.Name = "lblCnt2";
            lblCnt2.Size = new Size(47, 15);
            lblCnt2.TabIndex = 38;
            lblCnt2.Text = "총 건수";
            lblCnt2.TextAlign = ContentAlignment.TopRight;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(37, 402);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(599, 306);
            dataGridView2.TabIndex = 37;
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart2.Legends.Add(legend2);
            chart2.Location = new Point(659, 402);
            chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart2.Series.Add(series2);
            chart2.Size = new Size(665, 312);
            chart2.TabIndex = 40;
            chart2.Text = "chart2";
            // 
            // rdoBtnYear
            // 
            rdoBtnYear.AutoSize = true;
            rdoBtnYear.Checked = true;
            rdoBtnYear.Location = new Point(37, 22);
            rdoBtnYear.Name = "rdoBtnYear";
            rdoBtnYear.Size = new Size(61, 19);
            rdoBtnYear.TabIndex = 41;
            rdoBtnYear.TabStop = true;
            rdoBtnYear.Text = "년도별";
            rdoBtnYear.UseVisualStyleBackColor = true;
            // 
            // rdoBtnMon
            // 
            rdoBtnMon.AutoSize = true;
            rdoBtnMon.Location = new Point(160, 22);
            rdoBtnMon.Name = "rdoBtnMon";
            rdoBtnMon.Size = new Size(49, 19);
            rdoBtnMon.TabIndex = 42;
            rdoBtnMon.TabStop = true;
            rdoBtnMon.Text = "월별";
            rdoBtnMon.UseVisualStyleBackColor = true;
            // 
            // cboMon
            // 
            cboMon.FormattingEnabled = true;
            cboMon.Location = new Point(287, 21);
            cboMon.Name = "cboMon";
            cboMon.Size = new Size(121, 23);
            cboMon.TabIndex = 43;
            // 
            // HousTradVolume
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1319, 742);
            Controls.Add(cboMon);
            Controls.Add(rdoBtnMon);
            Controls.Add(rdoBtnYear);
            Controls.Add(chart2);
            Controls.Add(progressBar2);
            Controls.Add(lblCnt2);
            Controls.Add(dataGridView2);
            Controls.Add(progressBar1);
            Controls.Add(chart1);
            Controls.Add(lblCnt);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Name = "HousTradVolume";
            Text = "전국 주택 거래량";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private DataGridView dataGridView1;
        private Label lblCnt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label lblCnt2;
        private DataGridView dataGridView2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private RadioButton rdoBtnYear;
        private RadioButton rdoBtnMon;
        private ComboBox cboMon;
    }
}
