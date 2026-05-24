namespace CeDev
{
    partial class HousTradSigunguDetailVolume
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
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            lblYear = new Label();
            txtYear = new TextBox();
            cboSido = new ComboBox();
            label1 = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblCnt = new Label();
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
            dataGridView1.Location = new Point(37, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1064, 307);
            dataGridView1.TabIndex = 1;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(766, 31);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(31, 15);
            lblYear.TabIndex = 2;
            lblYear.Text = "년도";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(818, 26);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(114, 23);
            txtYear.TabIndex = 5;
            // 
            // cboSido
            // 
            cboSido.FormattingEnabled = true;
            cboSido.Location = new Point(81, 26);
            cboSido.Name = "cboSido";
            cboSido.Size = new Size(123, 23);
            cboSido.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 29);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 25;
            label1.Text = "시도";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(37, 396);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(1064, 377);
            chart1.TabIndex = 27;
            chart1.Text = "chart1";
            // 
            // lblCnt
            // 
            lblCnt.AutoSize = true;
            lblCnt.Location = new Point(974, 371);
            lblCnt.Name = "lblCnt";
            lblCnt.Size = new Size(47, 15);
            lblCnt.TabIndex = 32;
            lblCnt.Text = "총 건수";
            lblCnt.TextAlign = ContentAlignment.TopRight;
            // 
            // HousTradSigunguDetailVolume
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 785);
            Controls.Add(lblCnt);
            Controls.Add(chart1);
            Controls.Add(cboSido);
            Controls.Add(label1);
            Controls.Add(txtYear);
            Controls.Add(lblYear);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Name = "HousTradSigunguDetailVolume";
            Text = "주택 매매 거래량 시별 통계";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private DataGridView dataGridView1;
        private Label lblYear;
        private TextBox txtYear;
        private ComboBox cboSido;
        private Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label lblCnt;
    }
}
