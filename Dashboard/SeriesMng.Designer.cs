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
            gridSect = new DataGridView();
            label2 = new Label();
            btnSectSearch = new Button();
            btnWaveSearch = new Button();
            btnPuSearch = new Button();
            gridPu = new DataGridView();
            label4 = new Label();
            btnPuSave = new Button();
            btnWaveSave = new Button();
            ((System.ComponentModel.ISupportInitialize)gridWave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSect).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridPu).BeginInit();
            SuspendLayout();
            // 
            // gridWave
            // 
            gridWave.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridWave.Location = new Point(12, 339);
            gridWave.Name = "gridWave";
            gridWave.Size = new Size(466, 252);
            gridWave.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 309);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 37;
            label1.Text = "파장정보";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // gridSect
            // 
            gridSect.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSect.Location = new Point(12, 39);
            gridSect.Name = "gridSect";
            gridSect.Size = new Size(466, 188);
            gridSect.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 39;
            label2.Text = "SECTION 정보";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // btnSectSearch
            // 
            btnSectSearch.Location = new Point(395, 6);
            btnSectSearch.Name = "btnSectSearch";
            btnSectSearch.Size = new Size(83, 27);
            btnSectSearch.TabIndex = 49;
            btnSectSearch.Text = "조회";
            btnSectSearch.UseVisualStyleBackColor = true;
            btnSectSearch.Click += btnSectSearch_Click;
            // 
            // btnWaveSearch
            // 
            btnWaveSearch.Location = new Point(395, 309);
            btnWaveSearch.Name = "btnWaveSearch";
            btnWaveSearch.Size = new Size(83, 27);
            btnWaveSearch.TabIndex = 50;
            btnWaveSearch.Text = "조회";
            btnWaveSearch.UseVisualStyleBackColor = true;
            btnWaveSearch.Click += btnWaveSearch_Click;
            // 
            // btnPuSearch
            // 
            btnPuSearch.Location = new Point(825, 6);
            btnPuSearch.Name = "btnPuSearch";
            btnPuSearch.Size = new Size(83, 27);
            btnPuSearch.TabIndex = 53;
            btnPuSearch.Text = "조회";
            btnPuSearch.UseVisualStyleBackColor = true;
            btnPuSearch.Click += btnPuSearch_Click;
            // 
            // gridPu
            // 
            gridPu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPu.Location = new Point(500, 39);
            gridPu.Name = "gridPu";
            gridPu.Size = new Size(408, 188);
            gridPu.TabIndex = 52;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(500, 12);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 51;
            label4.Text = "PU 구간 정보";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // btnPuSave
            // 
            btnPuSave.Location = new Point(825, 233);
            btnPuSave.Name = "btnPuSave";
            btnPuSave.Size = new Size(83, 27);
            btnPuSave.TabIndex = 54;
            btnPuSave.Text = "저장";
            btnPuSave.UseVisualStyleBackColor = true;
            btnPuSave.Click += btnPuSave_Click;
            // 
            // btnWaveSave
            // 
            btnWaveSave.Location = new Point(395, 597);
            btnWaveSave.Name = "btnWaveSave";
            btnWaveSave.Size = new Size(83, 27);
            btnWaveSave.TabIndex = 55;
            btnWaveSave.Text = "저장";
            btnWaveSave.UseVisualStyleBackColor = true;
            btnWaveSave.Click += btnWaveSave_Click;
            // 
            // SeriesMng
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 630);
            Controls.Add(btnWaveSave);
            Controls.Add(btnPuSave);
            Controls.Add(btnPuSearch);
            Controls.Add(gridPu);
            Controls.Add(label4);
            Controls.Add(btnWaveSearch);
            Controls.Add(btnSectSearch);
            Controls.Add(gridSect);
            Controls.Add(label2);
            Controls.Add(gridWave);
            Controls.Add(label1);
            Name = "SeriesMng";
            Text = "Series 설정";
            Load += SeriesMng_Load;
            ((System.ComponentModel.ISupportInitialize)gridWave).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSect).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridPu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridWave;
        private Label label1;
        private DataGridView gridSect;
        private Label label2;
        private Button btnSectSearch;
        private Button btnWaveSearch;
        private Button btnPuSearch;
        private DataGridView gridPu;
        private Label label4;
        private Button btnPuSave;
        private Button btnWaveSave;
    }
}