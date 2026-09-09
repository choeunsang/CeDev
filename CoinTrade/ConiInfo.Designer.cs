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
            txtPrice = new TextBox();
            lblPrice = new Label();
            txtPriceDt = new TextBox();
            label4 = new Label();
            txtCntry = new TextBox();
            label5 = new Label();
            gridPrice = new DataGridView();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)gridCoin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coinPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridPrice).BeginInit();
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
            // txtPrice
            // 
            txtPrice.Location = new Point(844, 75);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(160, 23);
            txtPrice.TabIndex = 59;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(795, 78);
            lblPrice.Name = "lblPrice";
            lblPrice.RightToLeft = RightToLeft.No;
            lblPrice.Size = new Size(31, 15);
            lblPrice.TabIndex = 58;
            lblPrice.Text = "가격";
            lblPrice.TextAlign = ContentAlignment.TopRight;
            // 
            // txtPriceDt
            // 
            txtPriceDt.Location = new Point(844, 104);
            txtPriceDt.Name = "txtPriceDt";
            txtPriceDt.Size = new Size(160, 23);
            txtPriceDt.TabIndex = 61;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(795, 107);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 60;
            label4.Text = "일자";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // txtCntry
            // 
            txtCntry.Location = new Point(844, 133);
            txtCntry.Name = "txtCntry";
            txtCntry.Size = new Size(160, 23);
            txtCntry.TabIndex = 63;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(795, 136);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 62;
            label5.Text = "발행국";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // gridPrice
            // 
            gridPrice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPrice.Location = new Point(431, 384);
            gridPrice.Name = "gridPrice";
            gridPrice.Size = new Size(670, 221);
            gridPrice.TabIndex = 64;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(431, 366);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 65;
            label3.Text = "일자별 가격";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // ConiInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 630);
            Controls.Add(label3);
            Controls.Add(gridPrice);
            Controls.Add(txtCntry);
            Controls.Add(label5);
            Controls.Add(txtPriceDt);
            Controls.Add(label4);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
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
            ((System.ComponentModel.ISupportInitialize)gridPrice).EndInit();
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
        private TextBox txtPrice;
        private Label lblPrice;
        private TextBox txtPriceDt;
        private Label label4;
        private TextBox txtCntry;
        private Label label5;
        private DataGridView gridPrice;
        private Label label3;
    }
}