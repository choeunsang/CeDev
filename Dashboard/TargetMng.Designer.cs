namespace CeDev.DataMng
{
    partial class TargetMng
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
            lblCnt = new Label();
            gridTarget = new DataGridView();
            gridKpi = new DataGridView();
            label1 = new Label();
            cboYearTarget = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            cboYearKpi = new ComboBox();
            btnSearchTarget = new Button();
            btnSearchKpi = new Button();
            btnTargetHis = new Button();
            btnSaveTarget = new Button();
            btnSaveKpi = new Button();
            ((System.ComponentModel.ISupportInitialize)gridTarget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridKpi).BeginInit();
            SuspendLayout();
            // 
            // lblCnt
            // 
            lblCnt.AutoSize = true;
            lblCnt.Location = new Point(12, 44);
            lblCnt.Name = "lblCnt";
            lblCnt.Size = new Size(142, 15);
            lblCnt.TabIndex = 33;
            lblCnt.Text = "파장 및 PU구간 목표관리";
            lblCnt.TextAlign = ContentAlignment.TopRight;
            // 
            // gridTarget
            // 
            gridTarget.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTarget.Location = new Point(12, 73);
            gridTarget.Name = "gridTarget";
            gridTarget.Size = new Size(1451, 252);
            gridTarget.TabIndex = 34;
            // 
            // gridKpi
            // 
            gridKpi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridKpi.Location = new Point(12, 395);
            gridKpi.Name = "gridKpi";
            gridKpi.Size = new Size(1451, 252);
            gridKpi.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 365);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 35;
            label1.Text = "KPI 정보";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // cboYearTarget
            // 
            cboYearTarget.FormattingEnabled = true;
            cboYearTarget.Location = new Point(1154, 35);
            cboYearTarget.Name = "cboYearTarget";
            cboYearTarget.Size = new Size(121, 23);
            cboYearTarget.TabIndex = 44;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1096, 38);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 45;
            label2.Text = "년도";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1083, 365);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 47;
            label3.Text = "년도";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // cboYearKpi
            // 
            cboYearKpi.FormattingEnabled = true;
            cboYearKpi.Location = new Point(1141, 362);
            cboYearKpi.Name = "cboYearKpi";
            cboYearKpi.Size = new Size(121, 23);
            cboYearKpi.TabIndex = 46;
            // 
            // btnSearchTarget
            // 
            btnSearchTarget.Location = new Point(1291, 32);
            btnSearchTarget.Name = "btnSearchTarget";
            btnSearchTarget.Size = new Size(83, 27);
            btnSearchTarget.TabIndex = 48;
            btnSearchTarget.Text = "조회";
            btnSearchTarget.UseVisualStyleBackColor = true;
            btnSearchTarget.Click += btnSearchTarget_Click;
            // 
            // btnSearchKpi
            // 
            btnSearchKpi.Location = new Point(1278, 358);
            btnSearchKpi.Name = "btnSearchKpi";
            btnSearchKpi.Size = new Size(83, 27);
            btnSearchKpi.TabIndex = 49;
            btnSearchKpi.Text = "조회";
            btnSearchKpi.UseVisualStyleBackColor = true;
            btnSearchKpi.Click += btnSearchKpi_Click;
            // 
            // btnTargetHis
            // 
            btnTargetHis.Location = new Point(1380, 32);
            btnTargetHis.Name = "btnTargetHis";
            btnTargetHis.Size = new Size(83, 27);
            btnTargetHis.TabIndex = 50;
            btnTargetHis.Text = "이력보기";
            btnTargetHis.UseVisualStyleBackColor = true;
            // 
            // btnSaveTarget
            // 
            btnSaveTarget.Location = new Point(1380, 331);
            btnSaveTarget.Name = "btnSaveTarget";
            btnSaveTarget.Size = new Size(83, 27);
            btnSaveTarget.TabIndex = 51;
            btnSaveTarget.Text = "저장";
            btnSaveTarget.UseVisualStyleBackColor = true;
            btnSaveTarget.Click += btnSaveTarget_Click;
            // 
            // btnSaveKpi
            // 
            btnSaveKpi.Location = new Point(1380, 653);
            btnSaveKpi.Name = "btnSaveKpi";
            btnSaveKpi.Size = new Size(83, 27);
            btnSaveKpi.TabIndex = 52;
            btnSaveKpi.Text = "저장";
            btnSaveKpi.UseVisualStyleBackColor = true;
            // 
            // TargetMng
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 684);
            Controls.Add(btnSaveKpi);
            Controls.Add(btnSaveTarget);
            Controls.Add(btnTargetHis);
            Controls.Add(btnSearchKpi);
            Controls.Add(btnSearchTarget);
            Controls.Add(label3);
            Controls.Add(cboYearKpi);
            Controls.Add(label2);
            Controls.Add(cboYearTarget);
            Controls.Add(gridKpi);
            Controls.Add(label1);
            Controls.Add(gridTarget);
            Controls.Add(lblCnt);
            Name = "TargetMng";
            Text = "KPI 목표관리";
            Load += TargetMng_Load;
            ((System.ComponentModel.ISupportInitialize)gridTarget).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridKpi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCnt;
        private DataGridView gridTarget;
        private DataGridView gridKpi;
        private Label label1;
        private ComboBox cboYearTarget;
        private Label label2;
        private Label label3;
        private ComboBox cboYearKpi;
        private Button btnSearchTarget;
        private Button btnSearchKpi;
        private Button btnTargetHis;
        private Button btnSaveTarget;
        private Button btnSaveKpi;
    }
}