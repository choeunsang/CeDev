namespace CeDev
{
    partial class TotalTran
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
            lblRegion = new Label();
            lblDangi = new Label();
            lblFrom = new Label();
            lblTo = new Label();
            txtDangi = new TextBox();
            txtFrom = new TextBox();
            txtTo = new TextBox();
            lblResult = new Label();
            dataGridView2 = new DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label1 = new Label();
            txtDetail = new TextBox();
            txtChangeRateFromPeak = new TextBox();
            txtMaxPrice = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cboSido = new ComboBox();
            cboSigungu = new ComboBox();
            label2 = new Label();
            cboDong = new ComboBox();
            label5 = new Label();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(900, 31);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(121, 33);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "조회";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(993, 220);
            dataGridView1.TabIndex = 1;
            // 
            // lblRegion
            // 
            lblRegion.AutoSize = true;
            lblRegion.Location = new Point(25, 40);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new Size(31, 15);
            lblRegion.TabIndex = 2;
            lblRegion.Text = "시도";
            // 
            // lblDangi
            // 
            lblDangi.AutoSize = true;
            lblDangi.Location = new Point(667, 40);
            lblDangi.Name = "lblDangi";
            lblDangi.Size = new Size(31, 15);
            lblDangi.TabIndex = 3;
            lblDangi.Text = "단지";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(614, 6);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(35, 15);
            lblFrom.TabIndex = 4;
            lblFrom.Text = "From";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(764, 7);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(20, 15);
            lblTo.TabIndex = 5;
            lblTo.Text = "To";
            // 
            // txtDangi
            // 
            txtDangi.Location = new Point(704, 37);
            txtDangi.Name = "txtDangi";
            txtDangi.Size = new Size(187, 23);
            txtDangi.TabIndex = 7;
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(655, 3);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(100, 23);
            txtFrom.TabIndex = 8;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(790, 3);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(100, 23);
            txtTo.TabIndex = 9;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(28, 297);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(55, 15);
            lblResult.TabIndex = 10;
            lblResult.Text = "거래건수";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(28, 380);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(466, 200);
            dataGridView2.TabIndex = 11;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(518, 380);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(503, 200);
            chart1.TabIndex = 12;
            chart1.Text = "chart1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 327);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 13;
            label1.Text = "상세정보";
            // 
            // txtDetail
            // 
            txtDetail.Location = new Point(89, 324);
            txtDetail.Name = "txtDetail";
            txtDetail.Size = new Size(560, 23);
            txtDetail.TabIndex = 14;
            // 
            // txtChangeRateFromPeak
            // 
            txtChangeRateFromPeak.Location = new Point(939, 324);
            txtChangeRateFromPeak.Name = "txtChangeRateFromPeak";
            txtChangeRateFromPeak.Size = new Size(82, 23);
            txtChangeRateFromPeak.TabIndex = 19;
            // 
            // txtMaxPrice
            // 
            txtMaxPrice.Location = new Point(704, 324);
            txtMaxPrice.Name = "txtMaxPrice";
            txtMaxPrice.Size = new Size(112, 23);
            txtMaxPrice.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(822, 327);
            label3.Name = "label3";
            label3.Size = new Size(111, 15);
            label3.TabIndex = 16;
            label3.Text = "최고가 대비 변동폭";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(655, 327);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 15;
            label4.Text = "최고가";
            // 
            // cboSido
            // 
            cboSido.FormattingEnabled = true;
            cboSido.Location = new Point(69, 37);
            cboSido.Name = "cboSido";
            cboSido.Size = new Size(123, 23);
            cboSido.TabIndex = 20;
            cboSido.SelectedIndexChanged += cboSido_SelectedIndexChanged_1;
            // 
            // cboSigungu
            // 
            cboSigungu.FormattingEnabled = true;
            cboSigungu.Location = new Point(266, 37);
            cboSigungu.Name = "cboSigungu";
            cboSigungu.Size = new Size(150, 23);
            cboSigungu.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(203, 40);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 21;
            label2.Text = "시군구";
            // 
            // cboDong
            // 
            cboDong.FormattingEnabled = true;
            cboDong.Location = new Point(459, 37);
            cboDong.Name = "cboDong";
            cboDong.Size = new Size(166, 23);
            cboDong.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(422, 40);
            label5.Name = "label5";
            label5.Size = new Size(19, 15);
            label5.TabIndex = 23;
            label5.Text = "동";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(833, 295);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(188, 23);
            progressBar1.TabIndex = 36;
            // 
            // TotalTran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 592);
            Controls.Add(progressBar1);
            Controls.Add(cboDong);
            Controls.Add(label5);
            Controls.Add(cboSigungu);
            Controls.Add(label2);
            Controls.Add(cboSido);
            Controls.Add(txtChangeRateFromPeak);
            Controls.Add(txtMaxPrice);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtDetail);
            Controls.Add(label1);
            Controls.Add(chart1);
            Controls.Add(dataGridView2);
            Controls.Add(lblResult);
            Controls.Add(txtTo);
            Controls.Add(txtFrom);
            Controls.Add(txtDangi);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Controls.Add(lblDangi);
            Controls.Add(lblRegion);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Name = "TotalTran";
            Text = "주택가격 변동상세";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private DataGridView dataGridView1;
        private Label lblRegion;
        private Label lblDangi;
        private Label lblFrom;
        private Label lblTo;
        private TextBox txtDangi;
        private TextBox txtFrom;
        private TextBox txtTo;
        private Label lblResult;
        private DataGridView dataGridView2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label label1;
        private TextBox txtDetail;
        private TextBox txtChangeRateFromPeak;
        private TextBox txtMaxPrice;
        private Label label3;
        private Label label4;
        private ComboBox cboSido;
        private ComboBox cboSigungu;
        private Label label2;
        private ComboBox cboDong;
        private Label label5;
        private ProgressBar progressBar1;
    }
}
