namespace CeDev.DataMng
{
    partial class HisPop
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
            btnClose = new Button();
            label1 = new Label();
            txtChgReason = new TextBox();
            gridHisMaster = new DataGridView();
            gridHisDetail = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridHisMaster).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridHisDetail).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(966, 411);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 27);
            btnClose.TabIndex = 42;
            btnClose.Text = "닫기";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 285);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 41;
            label1.Text = "변경사유";
            // 
            // txtChgReason
            // 
            txtChgReason.Location = new Point(26, 303);
            txtChgReason.Multiline = true;
            txtChgReason.Name = "txtChgReason";
            txtChgReason.Size = new Size(399, 102);
            txtChgReason.TabIndex = 40;
            // 
            // gridHisMaster
            // 
            gridHisMaster.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridHisMaster.Location = new Point(26, 18);
            gridHisMaster.Name = "gridHisMaster";
            gridHisMaster.Size = new Size(399, 256);
            gridHisMaster.TabIndex = 39;
            // 
            // gridHisDetail
            // 
            gridHisDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridHisDetail.Location = new Point(431, 18);
            gridHisDetail.Name = "gridHisDetail";
            gridHisDetail.Size = new Size(635, 387);
            gridHisDetail.TabIndex = 43;
            // 
            // HisPop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 450);
            Controls.Add(gridHisDetail);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(txtChgReason);
            Controls.Add(gridHisMaster);
            Name = "HisPop";
            Text = "파장 및  PU구간 이력팝업";
            Load += HisPop_Load;
            ((System.ComponentModel.ISupportInitialize)gridHisMaster).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridHisDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Label label1;
        private TextBox txtChgReason;
        private DataGridView gridHisMaster;
        private DataGridView gridHisDetail;
    }
}