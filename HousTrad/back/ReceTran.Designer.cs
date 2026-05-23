namespace CeDev
{
    partial class ReceTran
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
            lblRegion = new Label();
            lblDangi = new Label();
            lblFrom = new Label();
            lblTo = new Label();
            txtCity = new TextBox();
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
            lblRegion.Location = new Point(28, 44);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new Size(31, 15);
            lblRegion.TabIndex = 2;
            lblRegion.Text = "지역";
            // 
            // lblDangi
            // 
            lblDangi.AutoSize = true;
            lblDangi.Location = new Point(275, 44);
            lblDangi.Name = "lblDangi";
            lblDangi.Size = new Size(31, 15);
            lblDangi.TabIndex = 3;
            lblDangi.Text = "단지";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(459, 44);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(35, 15);
            lblFrom.TabIndex = 4;
            lblFrom.Text = "From";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(623, 44);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(20, 15);
            lblTo.TabIndex = 5;
            lblTo.Text = "To";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(80, 41);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(178, 23);
            txtCity.TabIndex = 6;
            // 
            // txtDangi
            // 
            txtDangi.Location = new Point(312, 41);
            txtDangi.Name = "txtDangi";
            txtDangi.Size = new Size(141, 23);
            txtDangi.TabIndex = 7;
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(500, 41);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(100, 23);
            txtFrom.TabIndex = 8;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(660, 41);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(100, 23);
            txtTo.TabIndex = 9;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(966, 297);
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
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(518, 380);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
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
            // txtResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 592);
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
            Controls.Add(txtCity);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Controls.Add(lblDangi);
            Controls.Add(lblRegion);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Name = "txtResult";
            Text = "최근 거래건";
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
        private TextBox txtCity;
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
    }
}
