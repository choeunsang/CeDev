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
            gridCoin = new DataGridView();
            label2 = new Label();
            btnSectSearch = new Button();
            coinPicture = new PictureBox();
            lblCoinNm = new Label();
            txtCoinKrNm = new TextBox();
            txtCoinCd = new TextBox();
            txtCoinEnNm = new TextBox();
            txtDesc = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)gridCoin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coinPicture).BeginInit();
            SuspendLayout();
            // 
            // gridCoin
            // 
            gridCoin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCoin.Location = new Point(24, 40);
            gridCoin.Name = "gridCoin";
            gridCoin.Size = new Size(370, 579);
            gridCoin.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 39;
            label2.Text = "코인목록";
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
            // coinPicture
            // 
            coinPicture.Location = new Point(431, 75);
            coinPicture.Name = "coinPicture";
            coinPicture.Size = new Size(344, 246);
            coinPicture.TabIndex = 50;
            coinPicture.TabStop = false;
            // 
            // lblCoinNm
            // 
            lblCoinNm.AutoSize = true;
            lblCoinNm.Location = new Point(431, 40);
            lblCoinNm.Name = "lblCoinNm";
            lblCoinNm.Size = new Size(43, 15);
            lblCoinNm.TabIndex = 51;
            lblCoinNm.Text = "코인명";
            lblCoinNm.TextAlign = ContentAlignment.TopRight;
            // 
            // txtCoinKrNm
            // 
            txtCoinKrNm.Location = new Point(610, 37);
            txtCoinKrNm.Name = "txtCoinKrNm";
            txtCoinKrNm.Size = new Size(272, 23);
            txtCoinKrNm.TabIndex = 53;
            // 
            // txtCoinCd
            // 
            txtCoinCd.Location = new Point(480, 37);
            txtCoinCd.Name = "txtCoinCd";
            txtCoinCd.Size = new Size(124, 23);
            txtCoinCd.TabIndex = 54;
            // 
            // txtCoinEnNm
            // 
            txtCoinEnNm.Location = new Point(888, 37);
            txtCoinEnNm.Name = "txtCoinEnNm";
            txtCoinEnNm.Size = new Size(213, 23);
            txtCoinEnNm.TabIndex = 55;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(480, 333);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(621, 23);
            txtDesc.TabIndex = 57;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(431, 336);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 56;
            label1.Text = "설명";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // ConiInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 630);
            Controls.Add(txtDesc);
            Controls.Add(label1);
            Controls.Add(txtCoinEnNm);
            Controls.Add(txtCoinCd);
            Controls.Add(txtCoinKrNm);
            Controls.Add(lblCoinNm);
            Controls.Add(coinPicture);
            Controls.Add(btnSectSearch);
            Controls.Add(gridCoin);
            Controls.Add(label2);
            Name = "ConiInfo";
            Text = "업비트 코인목록";
            Load += CoinInfo_Load;
            ((System.ComponentModel.ISupportInitialize)gridCoin).EndInit();
            ((System.ComponentModel.ISupportInitialize)coinPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView gridCoin;
        private Label label2;
        private Button btnSectSearch;
        private PictureBox coinPicture;
        private Label lblCoinNm;
        private TextBox txtCoinKrNm;
        private TextBox txtCoinCd;
        private TextBox txtCoinEnNm;
        private TextBox txtDesc;
        private Label label1;
    }
}