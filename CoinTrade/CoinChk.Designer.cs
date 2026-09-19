namespace CeDev.DataMng
{
    partial class CoinChk
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
            txtCntry = new TextBox();
            label5 = new Label();
            gridPrice = new DataGridView();
            label3 = new Label();
            txtStartPrice = new TextBox();
            label6 = new Label();
            txtMinPrice = new TextBox();
            label7 = new Label();
            txtStartPriceDt = new TextBox();
            txtMinPriceDt = new TextBox();
            txtShotCnt = new TextBox();
            label4 = new Label();
            txtDt = new TextBox();
            label8 = new Label();
            txtShotLastDt = new TextBox();
            label2 = new Label();
            lblCnt = new Label();
            txtMaxPriceDt = new TextBox();
            txtMaxPrice = new TextBox();
            label9 = new Label();
            chkBoxUpDown = new CheckBox();
            txtChangeRate = new TextBox();
            label10 = new Label();
            chkBoxOldCoinYn = new CheckBox();
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
            gridCoin.Size = new Size(393, 565);
            gridCoin.TabIndex = 40;
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
            txtPrice.Location = new Point(854, 104);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(150, 23);
            txtPrice.TabIndex = 59;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(777, 107);
            lblPrice.Name = "lblPrice";
            lblPrice.RightToLeft = RightToLeft.No;
            lblPrice.Size = new Size(31, 15);
            lblPrice.TabIndex = 58;
            lblPrice.Text = "종가";
            lblPrice.TextAlign = ContentAlignment.TopRight;
            // 
            // txtPriceDt
            // 
            txtPriceDt.Location = new Point(1010, 104);
            txtPriceDt.Name = "txtPriceDt";
            txtPriceDt.Size = new Size(91, 23);
            txtPriceDt.TabIndex = 61;
            // 
            // txtCntry
            // 
            txtCntry.Location = new Point(854, 292);
            txtCntry.Name = "txtCntry";
            txtCntry.Size = new Size(150, 23);
            txtCntry.TabIndex = 63;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(795, 295);
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
            // txtStartPrice
            // 
            txtStartPrice.Location = new Point(854, 75);
            txtStartPrice.Name = "txtStartPrice";
            txtStartPrice.Size = new Size(150, 23);
            txtStartPrice.TabIndex = 67;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(777, 78);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 66;
            label6.Text = "시초가";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // txtMinPrice
            // 
            txtMinPrice.Location = new Point(854, 161);
            txtMinPrice.Name = "txtMinPrice";
            txtMinPrice.Size = new Size(150, 23);
            txtMinPrice.TabIndex = 69;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(777, 164);
            label7.Name = "label7";
            label7.Size = new Size(71, 15);
            label7.TabIndex = 68;
            label7.Text = "장중 최저가";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // txtStartPriceDt
            // 
            txtStartPriceDt.Location = new Point(1010, 75);
            txtStartPriceDt.Name = "txtStartPriceDt";
            txtStartPriceDt.Size = new Size(91, 23);
            txtStartPriceDt.TabIndex = 70;
            // 
            // txtMinPriceDt
            // 
            txtMinPriceDt.Location = new Point(1010, 161);
            txtMinPriceDt.Name = "txtMinPriceDt";
            txtMinPriceDt.Size = new Size(91, 23);
            txtMinPriceDt.TabIndex = 71;
            // 
            // txtShotCnt
            // 
            txtShotCnt.Location = new Point(854, 229);
            txtShotCnt.Name = "txtShotCnt";
            txtShotCnt.Size = new Size(150, 23);
            txtShotCnt.TabIndex = 73;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(793, 232);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 72;
            label4.Text = "슈팅횟수";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // txtDt
            // 
            txtDt.Location = new Point(73, 9);
            txtDt.Name = "txtDt";
            txtDt.Size = new Size(124, 23);
            txtDt.TabIndex = 75;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(24, 12);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 74;
            label8.Text = "날짜";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // txtShotLastDt
            // 
            txtShotLastDt.Location = new Point(854, 258);
            txtShotLastDt.Name = "txtShotLastDt";
            txtShotLastDt.Size = new Size(150, 23);
            txtShotLastDt.TabIndex = 77;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(781, 261);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 76;
            label2.Text = "최근슈팅일";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // lblCnt
            // 
            lblCnt.AutoSize = true;
            lblCnt.Location = new Point(24, 608);
            lblCnt.Name = "lblCnt";
            lblCnt.Size = new Size(47, 15);
            lblCnt.TabIndex = 78;
            lblCnt.Text = "총 건수";
            lblCnt.TextAlign = ContentAlignment.TopRight;
            // 
            // txtMaxPriceDt
            // 
            txtMaxPriceDt.Location = new Point(1010, 132);
            txtMaxPriceDt.Name = "txtMaxPriceDt";
            txtMaxPriceDt.Size = new Size(91, 23);
            txtMaxPriceDt.TabIndex = 81;
            // 
            // txtMaxPrice
            // 
            txtMaxPrice.Location = new Point(854, 132);
            txtMaxPrice.Name = "txtMaxPrice";
            txtMaxPrice.Size = new Size(150, 23);
            txtMaxPrice.TabIndex = 80;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(777, 135);
            label9.Name = "label9";
            label9.Size = new Size(71, 15);
            label9.TabIndex = 79;
            label9.Text = "장중 최고가";
            label9.TextAlign = ContentAlignment.TopRight;
            // 
            // chkBoxUpDown
            // 
            chkBoxUpDown.AutoSize = true;
            chkBoxUpDown.Location = new Point(315, 11);
            chkBoxUpDown.Name = "chkBoxUpDown";
            chkBoxUpDown.Size = new Size(102, 19);
            chkBoxUpDown.TabIndex = 82;
            chkBoxUpDown.Text = "등락률 하락만";
            chkBoxUpDown.UseVisualStyleBackColor = true;
            // 
            // txtChangeRate
            // 
            txtChangeRate.Location = new Point(854, 190);
            txtChangeRate.Name = "txtChangeRate";
            txtChangeRate.Size = new Size(150, 23);
            txtChangeRate.TabIndex = 84;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(777, 190);
            label10.Name = "label10";
            label10.Size = new Size(43, 15);
            label10.TabIndex = 83;
            label10.Text = "등락률";
            label10.TextAlign = ContentAlignment.TopRight;
            // 
            // chkBoxOldCoinYn
            // 
            chkBoxOldCoinYn.AutoSize = true;
            chkBoxOldCoinYn.Location = new Point(207, 11);
            chkBoxOldCoinYn.Name = "chkBoxOldCoinYn";
            chkBoxOldCoinYn.Size = new Size(102, 19);
            chkBoxOldCoinYn.TabIndex = 85;
            chkBoxOldCoinYn.Text = "신규코인 제외";
            chkBoxOldCoinYn.UseVisualStyleBackColor = true;
            // 
            // CoinChk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 630);
            Controls.Add(chkBoxOldCoinYn);
            Controls.Add(txtChangeRate);
            Controls.Add(label10);
            Controls.Add(chkBoxUpDown);
            Controls.Add(txtMaxPriceDt);
            Controls.Add(txtMaxPrice);
            Controls.Add(label9);
            Controls.Add(lblCnt);
            Controls.Add(txtShotLastDt);
            Controls.Add(label2);
            Controls.Add(txtDt);
            Controls.Add(label8);
            Controls.Add(txtShotCnt);
            Controls.Add(label4);
            Controls.Add(txtMinPriceDt);
            Controls.Add(txtStartPriceDt);
            Controls.Add(txtMinPrice);
            Controls.Add(label7);
            Controls.Add(txtStartPrice);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(gridPrice);
            Controls.Add(txtCntry);
            Controls.Add(label5);
            Controls.Add(txtPriceDt);
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
            Name = "CoinChk";
            Text = "변동성 코인목록";
            Load += CoinInfo_Load;
            ((System.ComponentModel.ISupportInitialize)gridCoin).EndInit();
            ((System.ComponentModel.ISupportInitialize)coinPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView gridCoin;
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
        private TextBox txtCntry;
        private Label label5;
        private DataGridView gridPrice;
        private Label label3;
        private TextBox txtStartPrice;
        private Label label6;
        private TextBox txtMinPrice;
        private Label label7;
        private TextBox txtStartPriceDt;
        private TextBox txtMinPriceDt;
        private TextBox txtShotCnt;
        private Label label4;
        private TextBox txtDt;
        private Label label8;
        private TextBox txtShotLastDt;
        private Label label2;
        private Label lblCnt;
        private TextBox txtMaxPriceDt;
        private TextBox txtMaxPrice;
        private Label label9;
        private CheckBox chkBoxUpDown;
        private TextBox txtChangeRate;
        private Label label10;
        private CheckBox chkBoxOldCoinYn;
    }
}