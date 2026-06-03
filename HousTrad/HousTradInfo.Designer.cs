namespace CeDev
{
    partial class HousTradInfo
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
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            lblYear = new Label();
            txtYear = new TextBox();
            lblCnt = new Label();
            cboSido = new ComboBox();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            cboDong = new ComboBox();
            label5 = new Label();
            cboSigungu = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            dataGridView1.Size = new Size(1064, 638);
            dataGridView1.TabIndex = 1;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(786, 31);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(31, 15);
            lblYear.TabIndex = 2;
            lblYear.Text = "년도";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(838, 26);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(114, 23);
            txtYear.TabIndex = 5;
            // 
            // lblCnt
            // 
            lblCnt.AutoSize = true;
            lblCnt.Location = new Point(37, 702);
            lblCnt.Name = "lblCnt";
            lblCnt.Size = new Size(47, 15);
            lblCnt.TabIndex = 32;
            lblCnt.Text = "총 건수";
            lblCnt.TextAlign = ContentAlignment.TopRight;
            // 
            // cboSido
            // 
            cboSido.FormattingEnabled = true;
            cboSido.Location = new Point(89, 26);
            cboSido.Name = "cboSido";
            cboSido.Size = new Size(123, 23);
            cboSido.TabIndex = 34;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 31);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 33;
            label1.Text = "시도";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(913, 702);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(188, 23);
            progressBar1.TabIndex = 35;
            // 
            // cboDong
            // 
            cboDong.FormattingEnabled = true;
            cboDong.Location = new Point(492, 26);
            cboDong.Name = "cboDong";
            cboDong.Size = new Size(166, 23);
            cboDong.TabIndex = 39;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(455, 29);
            label5.Name = "label5";
            label5.Size = new Size(19, 15);
            label5.TabIndex = 38;
            label5.Text = "동";
            // 
            // cboSigungu
            // 
            cboSigungu.FormattingEnabled = true;
            cboSigungu.Location = new Point(299, 26);
            cboSigungu.Name = "cboSigungu";
            cboSigungu.Size = new Size(150, 23);
            cboSigungu.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 29);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 36;
            label2.Text = "시군구";
            // 
            // HousTradInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 742);
            Controls.Add(cboDong);
            Controls.Add(label5);
            Controls.Add(cboSigungu);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Controls.Add(cboSido);
            Controls.Add(label1);
            Controls.Add(lblCnt);
            Controls.Add(txtYear);
            Controls.Add(lblYear);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Name = "HousTradInfo";
            Text = "주택 매매 정보";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private DataGridView dataGridView1;
        private Label lblYear;
        private TextBox txtYear;
        private Label lblCnt;
        private ComboBox cboSido;
        private Label label1;
        private ProgressBar progressBar1;
        private ComboBox cboDong;
        private Label label5;
        private ComboBox cboSigungu;
        private Label label2;
    }
}
