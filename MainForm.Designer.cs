namespace CeDev
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            부동산ToolStripMenuItem = new ToolStripMenuItem();
            단지정보ToolStripMenuItem = new ToolStripMenuItem();
            매매ToolStripMenuItem = new ToolStripMenuItem();
            주택매매정보ToolStripMenuItem = new ToolStripMenuItem();
            주택매매평균가격ToolStripMenuItem = new ToolStripMenuItem();
            전국주택거래량ToolStripMenuItem = new ToolStripMenuItem();
            월별주택거래량ToolStripMenuItem = new ToolStripMenuItem();
            시도별거래량월별통계ToolStripMenuItem = new ToolStripMenuItem();
            시군구별주택거래량상세ToolStripMenuItem = new ToolStripMenuItem();
            주택가격변동상세ToolStripMenuItem = new ToolStripMenuItem();
            전월세ToolStripMenuItem = new ToolStripMenuItem();
            전월세거래량ToolStripMenuItem = new ToolStripMenuItem();
            전월세정보ToolStripMenuItem = new ToolStripMenuItem();
            주택전월세갱신신규현황ToolStripMenuItem = new ToolStripMenuItem();
            데이터ToolStripMenuItem = new ToolStripMenuItem();
            자료업데이트ToolStripMenuItem = new ToolStripMenuItem();
            회원정보ToolStripMenuItem = new ToolStripMenuItem();
            회원관리ToolStripMenuItem = new ToolStripMenuItem();
            기준정보ToolStripMenuItem1 = new ToolStripMenuItem();
            기준정보ToolStripMenuItem = new ToolStripMenuItem();
            kPI목표관리ToolStripMenuItem = new ToolStripMenuItem();
            series설정ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 부동산ToolStripMenuItem, 매매ToolStripMenuItem, 전월세ToolStripMenuItem, 데이터ToolStripMenuItem, 회원정보ToolStripMenuItem, 기준정보ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(901, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 부동산ToolStripMenuItem
            // 
            부동산ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 단지정보ToolStripMenuItem });
            부동산ToolStripMenuItem.Name = "부동산ToolStripMenuItem";
            부동산ToolStripMenuItem.Size = new Size(67, 20);
            부동산ToolStripMenuItem.Text = "기준정보";
            // 
            // 단지정보ToolStripMenuItem
            // 
            단지정보ToolStripMenuItem.Name = "단지정보ToolStripMenuItem";
            단지정보ToolStripMenuItem.Size = new Size(122, 22);
            단지정보ToolStripMenuItem.Text = "단지정보";
            단지정보ToolStripMenuItem.Click += 단지정보ToolStripMenuItem_Click;
            // 
            // 매매ToolStripMenuItem
            // 
            매매ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 주택매매정보ToolStripMenuItem, 주택매매평균가격ToolStripMenuItem, 전국주택거래량ToolStripMenuItem, 월별주택거래량ToolStripMenuItem, 시도별거래량월별통계ToolStripMenuItem, 시군구별주택거래량상세ToolStripMenuItem, 주택가격변동상세ToolStripMenuItem });
            매매ToolStripMenuItem.Name = "매매ToolStripMenuItem";
            매매ToolStripMenuItem.Size = new Size(43, 20);
            매매ToolStripMenuItem.Text = "매매";
            // 
            // 주택매매정보ToolStripMenuItem
            // 
            주택매매정보ToolStripMenuItem.Name = "주택매매정보ToolStripMenuItem";
            주택매매정보ToolStripMenuItem.Size = new Size(218, 22);
            주택매매정보ToolStripMenuItem.Text = "주택 매매 정보";
            주택매매정보ToolStripMenuItem.Click += 주택매매정보ToolStripMenuItem_Click;
            // 
            // 주택매매평균가격ToolStripMenuItem
            // 
            주택매매평균가격ToolStripMenuItem.Name = "주택매매평균가격ToolStripMenuItem";
            주택매매평균가격ToolStripMenuItem.Size = new Size(218, 22);
            주택매매평균가격ToolStripMenuItem.Text = "주택 매매 평균가격";
            주택매매평균가격ToolStripMenuItem.Click += 주택매매평균가격ToolStripMenuItem_Click;
            // 
            // 전국주택거래량ToolStripMenuItem
            // 
            전국주택거래량ToolStripMenuItem.Name = "전국주택거래량ToolStripMenuItem";
            전국주택거래량ToolStripMenuItem.Size = new Size(218, 22);
            전국주택거래량ToolStripMenuItem.Text = "전국 주택 거래량";
            전국주택거래량ToolStripMenuItem.Click += 전국주택거래량ToolStripMenuItem_Click;
            // 
            // 월별주택거래량ToolStripMenuItem
            // 
            월별주택거래량ToolStripMenuItem.Name = "월별주택거래량ToolStripMenuItem";
            월별주택거래량ToolStripMenuItem.Size = new Size(218, 22);
            월별주택거래량ToolStripMenuItem.Text = "월별 주택 거래량";
            월별주택거래량ToolStripMenuItem.Click += 월별주택거래량ToolStripMenuItem_Click;
            // 
            // 시도별거래량월별통계ToolStripMenuItem
            // 
            시도별거래량월별통계ToolStripMenuItem.Name = "시도별거래량월별통계ToolStripMenuItem";
            시도별거래량월별통계ToolStripMenuItem.Size = new Size(218, 22);
            시도별거래량월별통계ToolStripMenuItem.Text = "시도별 거래량 월별 통계";
            시도별거래량월별통계ToolStripMenuItem.Click += 시도별거래량월별통계ToolStripMenuItem_Click;
            // 
            // 시군구별주택거래량상세ToolStripMenuItem
            // 
            시군구별주택거래량상세ToolStripMenuItem.Name = "시군구별주택거래량상세ToolStripMenuItem";
            시군구별주택거래량상세ToolStripMenuItem.Size = new Size(218, 22);
            시군구별주택거래량상세ToolStripMenuItem.Text = "시군구별 주택 거래량 상세";
            시군구별주택거래량상세ToolStripMenuItem.Click += 시군구별주택거래량상세ToolStripMenuItem_Click;
            // 
            // 주택가격변동상세ToolStripMenuItem
            // 
            주택가격변동상세ToolStripMenuItem.Name = "주택가격변동상세ToolStripMenuItem";
            주택가격변동상세ToolStripMenuItem.Size = new Size(218, 22);
            주택가격변동상세ToolStripMenuItem.Text = "주택가격 변동상세";
            주택가격변동상세ToolStripMenuItem.Click += 주택가격변동상세ToolStripMenuItem1_Click;
            // 
            // 전월세ToolStripMenuItem
            // 
            전월세ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 전월세거래량ToolStripMenuItem, 전월세정보ToolStripMenuItem, 주택전월세갱신신규현황ToolStripMenuItem });
            전월세ToolStripMenuItem.Name = "전월세ToolStripMenuItem";
            전월세ToolStripMenuItem.Size = new Size(55, 20);
            전월세ToolStripMenuItem.Text = "전월세";
            // 
            // 전월세거래량ToolStripMenuItem
            // 
            전월세거래량ToolStripMenuItem.Name = "전월세거래량ToolStripMenuItem";
            전월세거래량ToolStripMenuItem.Size = new Size(223, 22);
            전월세거래량ToolStripMenuItem.Text = "전월세 거래량";
            전월세거래량ToolStripMenuItem.Click += 전월세거래량ToolStripMenuItem_Click;
            // 
            // 전월세정보ToolStripMenuItem
            // 
            전월세정보ToolStripMenuItem.Name = "전월세정보ToolStripMenuItem";
            전월세정보ToolStripMenuItem.Size = new Size(223, 22);
            전월세정보ToolStripMenuItem.Text = "주택 전월세 거래조회";
            전월세정보ToolStripMenuItem.Click += 주택_전월세_거래조회ToolStripMenuItem_Click;
            // 
            // 주택전월세갱신신규현황ToolStripMenuItem
            // 
            주택전월세갱신신규현황ToolStripMenuItem.Name = "주택전월세갱신신규현황ToolStripMenuItem";
            주택전월세갱신신규현황ToolStripMenuItem.Size = new Size(223, 22);
            주택전월세갱신신규현황ToolStripMenuItem.Text = "주택 전월세 갱신/신규 현황";
            주택전월세갱신신규현황ToolStripMenuItem.Click += 주택전월세갱신신규현황ToolStripMenuItem_Click;
            // 
            // 데이터ToolStripMenuItem
            // 
            데이터ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 자료업데이트ToolStripMenuItem });
            데이터ToolStripMenuItem.Name = "데이터ToolStripMenuItem";
            데이터ToolStripMenuItem.Size = new Size(83, 20);
            데이터ToolStripMenuItem.Text = "데이터 관리";
            // 
            // 자료업데이트ToolStripMenuItem
            // 
            자료업데이트ToolStripMenuItem.Name = "자료업데이트ToolStripMenuItem";
            자료업데이트ToolStripMenuItem.Size = new Size(150, 22);
            자료업데이트ToolStripMenuItem.Text = "자료 업데이트";
            자료업데이트ToolStripMenuItem.Click += 자료업데이트ToolStripMenuItem_Click;
            // 
            // 회원정보ToolStripMenuItem
            // 
            회원정보ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 회원관리ToolStripMenuItem, 기준정보ToolStripMenuItem1 });
            회원정보ToolStripMenuItem.Name = "회원정보ToolStripMenuItem";
            회원정보ToolStripMenuItem.Size = new Size(67, 20);
            회원정보ToolStripMenuItem.Text = "회원관리";
            // 
            // 회원관리ToolStripMenuItem
            // 
            회원관리ToolStripMenuItem.Name = "회원관리ToolStripMenuItem";
            회원관리ToolStripMenuItem.Size = new Size(122, 22);
            회원관리ToolStripMenuItem.Text = "회원정보";
            회원관리ToolStripMenuItem.Click += 회원정보ToolStripMenuItem_Click;
            // 
            // 기준정보ToolStripMenuItem1
            // 
            기준정보ToolStripMenuItem1.Name = "기준정보ToolStripMenuItem1";
            기준정보ToolStripMenuItem1.Size = new Size(122, 22);
            기준정보ToolStripMenuItem1.Text = "기준정보";
            // 
            // 기준정보ToolStripMenuItem
            // 
            기준정보ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kPI목표관리ToolStripMenuItem, series설정ToolStripMenuItem });
            기준정보ToolStripMenuItem.Name = "기준정보ToolStripMenuItem";
            기준정보ToolStripMenuItem.Size = new Size(67, 20);
            기준정보ToolStripMenuItem.Text = "기준정보";
            // 
            // kPI목표관리ToolStripMenuItem
            // 
            kPI목표관리ToolStripMenuItem.Name = "kPI목표관리ToolStripMenuItem";
            kPI목표관리ToolStripMenuItem.Size = new Size(180, 22);
            kPI목표관리ToolStripMenuItem.Text = "KPI 목표관리";
            kPI목표관리ToolStripMenuItem.Click += kPI목표관리ToolStripMenuItem_Click;
            // 
            // series설정ToolStripMenuItem
            // 
            series설정ToolStripMenuItem.Name = "series설정ToolStripMenuItem";
            series설정ToolStripMenuItem.Size = new Size(180, 22);
            series설정ToolStripMenuItem.Text = "Series 설정";
            series설정ToolStripMenuItem.Click += series설정ToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 482);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "CeDev 부동산";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 부동산ToolStripMenuItem;
        private ToolStripMenuItem 주택가격변동상세ToolStripMenuItem;
        private ToolStripMenuItem 회원정보ToolStripMenuItem;
        private ToolStripMenuItem 회원관리ToolStripMenuItem;
        private ToolStripMenuItem 데이터ToolStripMenuItem;
        private ToolStripMenuItem 자료업데이트ToolStripMenuItem;
        private ToolStripMenuItem 매매ToolStripMenuItem;
        private ToolStripMenuItem 시군구별주택거래량상세ToolStripMenuItem;
        private ToolStripMenuItem 시도별거래량월별통계ToolStripMenuItem;
        private ToolStripMenuItem 전월세ToolStripMenuItem;
        
        private ToolStripMenuItem 전월세거래량ToolStripMenuItem;
        private ToolStripMenuItem 전월세정보ToolStripMenuItem;
        private ToolStripMenuItem 주택전월세갱신신규현황ToolStripMenuItem;
        private ToolStripMenuItem 월별주택거래량ToolStripMenuItem;
        private ToolStripMenuItem 주택매매정보ToolStripMenuItem;
        private ToolStripMenuItem 주택매매평균가격ToolStripMenuItem;
        private ToolStripMenuItem 단지정보ToolStripMenuItem;
        private ToolStripMenuItem 전국주택거래량ToolStripMenuItem;
        private ToolStripMenuItem 기준정보ToolStripMenuItem;
        private ToolStripMenuItem kPI목표관리ToolStripMenuItem;
        private ToolStripMenuItem series설정ToolStripMenuItem;
        private ToolStripMenuItem 기준정보ToolStripMenuItem1;
    }
}
