namespace CeDev
{
    partial class DangiInfo
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
            cboSido = new ComboBox();
            label1 = new Label();
            lblCnt = new Label();
            progressBar1 = new ProgressBar();
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
            dataGridView1.Location = new Point(28, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1073, 434);
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
            cboSido.Size = new Size(110, 23);
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
            lblCnt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCnt.AutoSize = true;
            lblCnt.Location = new Point(28, 518);
            lblCnt.Name = "lblCnt";
            lblCnt.Size = new Size(47, 15);
            lblCnt.TabIndex = 31;
            lblCnt.Text = "총 건수";
            lblCnt.TextAlign = ContentAlignment.BottomRight;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(913, 518);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(188, 23);
            progressBar1.TabIndex = 32;
            // 
            // DangiInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 579);
            Controls.Add(progressBar1);
            Controls.Add(lblCnt);
            Controls.Add(cboSido);
            Controls.Add(label1);
            Controls.Add(txtYear);
            Controls.Add(lblYear);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Name = "DangiInfo";
            Text = "단지정보";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private Label lblCnt;
        private ProgressBar progressBar1;
    }
}
