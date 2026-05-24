namespace CeDev
{
    partial class HousTradDetailVolume
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
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cboDong = new ComboBox();
            label5 = new Label();
            cboSigungu = new ComboBox();
            label2 = new Label();
            cboSido = new ComboBox();
            label1 = new Label();
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
            dataGridView1.Location = new Point(28, 401);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(618, 157);
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
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(28, 72);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(1073, 323);
            chart1.TabIndex = 6;
            chart1.Text = "chart1";
            // 
            // cboDong
            // 
            cboDong.FormattingEnabled = true;
            cboDong.Location = new Point(471, 26);
            cboDong.Name = "cboDong";
            cboDong.Size = new Size(166, 23);
            cboDong.TabIndex = 30;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(434, 29);
            label5.Name = "label5";
            label5.Size = new Size(19, 15);
            label5.TabIndex = 29;
            label5.Text = "동";
            // 
            // cboSigungu
            // 
            cboSigungu.FormattingEnabled = true;
            cboSigungu.Location = new Point(278, 26);
            cboSigungu.Name = "cboSigungu";
            cboSigungu.Size = new Size(150, 23);
            cboSigungu.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(215, 29);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 27;
            label2.Text = "시군구";
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
            // lblCnt
            // 
            lblCnt.AutoSize = true;
            lblCnt.Location = new Point(534, 561);
            lblCnt.Name = "lblCnt";
            lblCnt.Size = new Size(47, 15);
            lblCnt.TabIndex = 32;
            lblCnt.Text = "총 건수";
            lblCnt.TextAlign = ContentAlignment.TopRight;
            // 
            // HousTradDetailVolume
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 579);
            Controls.Add(lblCnt);
            Controls.Add(cboDong);
            Controls.Add(label5);
            Controls.Add(cboSigungu);
            Controls.Add(label2);
            Controls.Add(cboSido);
            Controls.Add(label1);
            Controls.Add(chart1);
            Controls.Add(txtYear);
            Controls.Add(lblYear);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Name = "HousTradDetailVolume";
            Text = "주택 매매 거래량";
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox cboDong;
        private Label label5;
        private ComboBox cboSigungu;
        private Label label2;
        private ComboBox cboSido;
        private Label label1;
        private Label lblCnt;
    }
}
