namespace CeDev.DataMng
{
    partial class ConiInfo
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
            gridSect = new DataGridView();
            label2 = new Label();
            btnSectSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)gridSect).BeginInit();
            SuspendLayout();
            // 
            // gridSect
            // 
            gridSect.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSect.Location = new Point(12, 39);
            gridSect.Name = "gridSect";
            gridSect.Size = new Size(1089, 579);
            gridSect.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 39;
            label2.Text = "상장코인 목록";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // btnSectSearch
            // 
            btnSectSearch.Location = new Point(1018, 6);
            btnSectSearch.Name = "btnSectSearch";
            btnSectSearch.Size = new Size(83, 27);
            btnSectSearch.TabIndex = 49;
            btnSectSearch.Text = "조회";
            btnSectSearch.UseVisualStyleBackColor = true;
            btnSectSearch.Click += btnSectSearch_Click;
            // 
            // ConiInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 630);
            Controls.Add(btnSectSearch);
            Controls.Add(gridSect);
            Controls.Add(label2);
            Name = "ConiInfo";
            Text = "업비트 코인목록";
            Load += SeriesMng_Load;
            ((System.ComponentModel.ISupportInitialize)gridSect).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView gridSect;
        private Label label2;
        private Button btnSectSearch;
    }
}