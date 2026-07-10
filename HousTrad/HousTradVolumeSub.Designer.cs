namespace CeDev
{
    partial class HousTradVolumeSub
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            lblCnt = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            rdoBtnYear = new RadioButton();
            rdoBtnMon = new RadioButton();
            cboMon = new ComboBox();
            lblCnt2 = new Label();
            progressBar2 = new ProgressBar();
            dataGridView2 = new DataGridView();
            progressBar1 = new ProgressBar();
            dataGridView3 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtSido = new TextBox();
            txtSigungu = new TextBox();
            txtDangi = new TextBox();
            txtDong = new TextBox();
            txtHisCnt = new TextBox();
            txtAmount = new TextBox();
            txtDediArea = new TextBox();
            progressBar3 = new ProgressBar();
            lblCnt3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
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
            chartArea3.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart1.Legends.Add(legend3);
            chart1.Location = new Point(642, 55);
            chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chart1.Series.Add(series3);
            chart1.Size = new Size(665, 312);
            chart1.TabIndex = 33;
            chart1.Text = "chart1";
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
            // progressBar2
            // 
            progressBar2.Location = new Point(448, 714);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(188, 23);
            progressBar2.TabIndex = 39;
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
            // progressBar1
            // 
            progressBar1.Location = new Point(448, 373);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(188, 23);
            progressBar1.TabIndex = 36;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(1002, 402);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(305, 306);
            dataGridView3.TabIndex = 44;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(664, 402);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 45;
            label1.Text = "시도";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(664, 435);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 46;
            label2.Text = "시군구";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(664, 506);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 48;
            label3.Text = "단지명";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(664, 471);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 47;
            label4.Text = "동";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(664, 561);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 50;
            label5.Text = "가격";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(664, 535);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 49;
            label6.Text = "평형";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(664, 640);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 51;
            label7.Text = "거래이력건수";
            // 
            // txtSido
            // 
            txtSido.Location = new Point(766, 399);
            txtSido.Name = "txtSido";
            txtSido.Size = new Size(213, 23);
            txtSido.TabIndex = 52;
            // 
            // txtSigungu
            // 
            txtSigungu.Location = new Point(766, 428);
            txtSigungu.Name = "txtSigungu";
            txtSigungu.Size = new Size(213, 23);
            txtSigungu.TabIndex = 53;
            // 
            // txtDangi
            // 
            txtDangi.Location = new Point(766, 503);
            txtDangi.Name = "txtDangi";
            txtDangi.Size = new Size(213, 23);
            txtDangi.TabIndex = 55;
            // 
            // txtDong
            // 
            txtDong.Location = new Point(766, 457);
            txtDong.Name = "txtDong";
            txtDong.Size = new Size(213, 23);
            txtDong.TabIndex = 54;
            // 
            // txtHisCnt
            // 
            txtHisCnt.Location = new Point(766, 633);
            txtHisCnt.Name = "txtHisCnt";
            txtHisCnt.Size = new Size(213, 23);
            txtHisCnt.TabIndex = 57;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(766, 561);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(213, 23);
            txtAmount.TabIndex = 56;
            // 
            // txtDediArea
            // 
            txtDediArea.Location = new Point(766, 532);
            txtDediArea.Name = "txtDediArea";
            txtDediArea.Size = new Size(213, 23);
            txtDediArea.TabIndex = 58;
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(1119, 711);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(188, 23);
            progressBar3.TabIndex = 59;
            // 
            // lblCnt3
            // 
            lblCnt3.AutoSize = true;
            lblCnt3.Location = new Point(1002, 714);
            lblCnt3.Name = "lblCnt3";
            lblCnt3.Size = new Size(47, 15);
            lblCnt3.TabIndex = 60;
            lblCnt3.Text = "총 건수";
            lblCnt3.TextAlign = ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(766, 691);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(126, 23);
            textBox1.TabIndex = 64;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(766, 662);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(126, 23);
            textBox2.TabIndex = 63;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(664, 698);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 62;
            label8.Text = "최저가";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(664, 670);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 61;
            label9.Text = "최고가";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(898, 690);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(81, 23);
            textBox3.TabIndex = 66;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(898, 662);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(81, 23);
            textBox4.TabIndex = 65;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // HousTradVolumeSub
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1319, 742);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(lblCnt3);
            Controls.Add(progressBar3);
            Controls.Add(txtDediArea);
            Controls.Add(txtHisCnt);
            Controls.Add(txtAmount);
            Controls.Add(txtDangi);
            Controls.Add(txtDong);
            Controls.Add(txtSigungu);
            Controls.Add(txtSido);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView3);
            Controls.Add(cboMon);
            Controls.Add(rdoBtnMon);
            Controls.Add(rdoBtnYear);
            Controls.Add(progressBar2);
            Controls.Add(lblCnt2);
            Controls.Add(dataGridView2);
            Controls.Add(progressBar1);
            Controls.Add(chart1);
            Controls.Add(lblCnt);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Name = "HousTradVolumeSub";
            Text = "전국 주택 거래량(Sub)";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private DataGridView dataGridView1;
        private Label lblCnt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private RadioButton rdoBtnYear;
        private RadioButton rdoBtnMon;
        private ComboBox cboMon;
        private Label lblCnt2;
        private ProgressBar progressBar2;
        private DataGridView dataGridView2;
        private ProgressBar progressBar1;
        private DataGridView dataGridView3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtSido;
        private TextBox txtSigungu;
        private TextBox txtDangi;
        private TextBox txtDong;
        private TextBox txtHisCnt;
        private TextBox txtAmount;
        private TextBox txtDediArea;
        private ProgressBar progressBar3;
        private Label lblCnt3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label8;
        private Label label9;
        private TextBox textBox3;
        private TextBox textBox4;
    }
}
