namespace CeDev.DataMng
{
    partial class SeriesMng
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
            gridWave = new DataGridView();
            label1 = new Label();
            gridPu = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            gridTat = new DataGridView();
            btnPuSearch = new Button();
            btnWaveSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)gridWave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridPu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridTat).BeginInit();
            SuspendLayout();
            // 
            // gridWave
            // 
            gridWave.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridWave.Location = new Point(12, 282);
            gridWave.Name = "gridWave";
            gridWave.Size = new Size(466, 252);
            gridWave.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 252);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 37;
            label1.Text = "파장정보";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // gridPu
            // 
            gridPu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPu.Location = new Point(12, 39);
            gridPu.Name = "gridPu";
            gridPu.Size = new Size(466, 188);
            gridPu.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 39;
            label2.Text = "PU 구간 정보";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(518, 252);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 41;
            label3.Text = "TAT 시작지점 설정";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // gridTat
            // 
            gridTat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTat.Location = new Point(498, 282);
            gridTat.Name = "gridTat";
            gridTat.Size = new Size(343, 252);
            gridTat.TabIndex = 42;
            // 
            // btnPuSearch
            // 
            btnPuSearch.Location = new Point(395, 6);
            btnPuSearch.Name = "btnPuSearch";
            btnPuSearch.Size = new Size(83, 27);
            btnPuSearch.TabIndex = 49;
            btnPuSearch.Text = "조회";
            btnPuSearch.UseVisualStyleBackColor = true;
            btnPuSearch.Click += btnPuSearch_Click;
            // 
            // btnWaveSearch
            // 
            btnWaveSearch.Location = new Point(395, 252);
            btnWaveSearch.Name = "btnWaveSearch";
            btnWaveSearch.Size = new Size(83, 27);
            btnWaveSearch.TabIndex = 50;
            btnWaveSearch.Text = "조회";
            btnWaveSearch.UseVisualStyleBackColor = true;
            btnWaveSearch.Click += btnWaveSearch_Click;
            // 
            // SeriesMng
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 542);
            Controls.Add(btnWaveSearch);
            Controls.Add(btnPuSearch);
            Controls.Add(gridTat);
            Controls.Add(label3);
            Controls.Add(gridPu);
            Controls.Add(label2);
            Controls.Add(gridWave);
            Controls.Add(label1);
            Name = "SeriesMng";
            Text = "Series 설정";
            Load += SeriesMng_Load;
            ((System.ComponentModel.ISupportInitialize)gridWave).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridPu).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridTat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridWave;
        private Label label1;
        private DataGridView gridPu;
        private Label label2;
        private Label label3;
        private DataGridView gridTat;
        private Button btnPuSearch;
        private Button btnWaveSearch;
    }
}