using CeDev.DataMng;
using CeDev.Login;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Windows.Forms;

namespace CeDev
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
            WindowState = FormWindowState.Maximized;

            // 👈 MainForm이 로드될 때 쿠키 검증 로직을 실행하도록 이벤트 연결
            this.Load += MainForm_Load;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await CeDev.Common.AuthManager.CheckAuthAsync(this);

        }



        private void 회원정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo form = new UserInfo();

            form.MdiParent = this;
            form.Show();
        }

        private void 자료업데이트ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataUpdate form = new DataUpdate();

            form.MdiParent = this;
            form.Show();
        }


        private void 주택거래량ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HousTradDetailVolume form = new HousTradDetailVolume();

            form.MdiParent = this;
            form.Show();

        }


        private void 주택거래량시별통계ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HousTradSigunguDetailVolume form = new HousTradSigunguDetailVolume();

            form.MdiParent = this;
            form.Show();
        }




        private void 주택가격변동상세ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TotalTran form = new TotalTran();

            form.MdiParent = this;
            form.Show();
        }

        private void 전월세거래량ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HousRentVolume form = new HousRentVolume();

            form.MdiParent = this;
            form.Show();
        }

        private void 주택_전월세_거래조회ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentInfo form = new RentInfo();

            form.MdiParent = this;
            form.Show();
        }

        private void 주택전월세갱신신규현황ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentGbunInfo form = new RentGbunInfo();

            form.MdiParent = this;
            form.Show();
        }
    }
}
