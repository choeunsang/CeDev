using CeDev.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace CeDev
{
    public partial class RentInfo : Form
    {
        public RentInfo()
        {
            InitializeComponent();
            InitEvent();
            _ = InitCont();

        }

        private void InitEvent()
        {
            cboSido.SelectedIndexChanged += cboSido_SelectedIndexChanged;
            cboSigungu.SelectedIndexChanged += cboSigungu_SelectedIndexChanged;
        }

        private async Task InitCont()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string url = "http://localhost:9081/api/region/sido";

            progressBar1.Visible = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;

            //전월세 구분
            cboGubun.Items.Clear();
            cboGubun.Items.Add("전체");
            cboGubun.Items.Add("전세");
            cboGubun.Items.Add("월세");
            cboGubun.SelectedIndex = 0;

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);

                var sidoList = JsonConvert.DeserializeObject<List<string>>(json);

                cboSido.Items.Clear();

                foreach (string sido in sidoList)
                {
                    cboSido.Items.Add(sido);
                }

                if (cboSido.Items.Contains("서울특별시"))
                {
                    cboSido.SelectedItem = "서울특별시";
                }

                cboSigungu.Items.Clear();
                cboSigungu.Items.Add("전체");
                cboSigungu.SelectedIndex = 0;

                cboDong.Items.Clear();
                cboDong.Items.Add("전체");
                cboDong.SelectedIndex = 0;

                //txtYear.Text = "2025";
                //txtYear.Text = "2026";

                txtYear.Text = DateTime.Now.Year.ToString();
            }


        }

        private async void cboSido_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string sido = cboSido.Text.Trim();

            string url =
                $"http://localhost:9081/api/region/sigungu" +
                $"?sido={Uri.EscapeDataString(sido)}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);

                cboSigungu.DataSource = null;
                cboSigungu.Items.Clear();
                cboSigungu.Items.Add("전체");

                List<string> sigunguList = JsonConvert.DeserializeObject<List<string>>(json);

                foreach (string sigungu in sigunguList)
                {
                    cboSigungu.Items.Add(sigungu);
                }

                cboSigungu.SelectedIndex = 0;

                cboDong.DataSource = null;
                cboDong.Items.Clear();
                cboDong.Items.Add("전체");
                cboDong.SelectedIndex = 0;
            }
        }

        private async void cboSigungu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string sido = cboSido.Text.Trim();
            string sigungu = cboSigungu.Text.Trim();

            if (string.IsNullOrEmpty(sido) || sigungu == "전체")
            {
                cboDong.DataSource = null;
                cboDong.Items.Clear();
                cboDong.Items.Add("전체");
                cboDong.SelectedIndex = 0;
                return;
            }

            string url =
                $"http://localhost:9081/api/region/dong" +
                $"?sido={Uri.EscapeDataString(sido)}" +
                $"&sigungu={Uri.EscapeDataString(sigungu)}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);

                cboDong.DataSource = null;
                cboDong.Items.Clear();
                cboDong.Items.Add("전체");

                List<string> dongList = JsonConvert.DeserializeObject<List<string>>(json);

                foreach (string dong in dongList)
                {
                    cboDong.Items.Add(dong);
                }

                cboDong.SelectedIndex = 0;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            btnSearch.Enabled = false;

            try
            {
                await GetRentInfoList();
            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.MarqueeAnimationSpeed = 0;
                btnSearch.Enabled = true;
            }
        }

        private async Task GetRentInfoList()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            RentInfoSearchModel model = new RentInfoSearchModel();

            model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();
            model.Sigungu = cboSigungu.Text == "전체" ? "" : cboSigungu.Text.Trim();
            model.Dong = cboDong.Text == "전체" ? "" : cboDong.Text.Trim();
            model.Year = txtYear.Text.Trim();
            model.Gubun = cboGubun.Text == "전체" ? "" : cboGubun.Text.Trim();

            //string url =
            //    $"http://localhost:9081/api/rent-info" +
            //    $"?sido={Uri.EscapeDataString(model.Sido)}" +
            //    $"&sigungu={Uri.EscapeDataString(model.Sigungu)}" +
            //    $"&dong={Uri.EscapeDataString(model.Dong)}" +
            //    $"&year={Uri.EscapeDataString(model.Year)}" +
            //    $"&gubun={Uri.EscapeDataString(model.Gubun)}";

            string baseUrl = "http://localhost:9081/api/rent-info";
            string queryString = BuildQueryString(model);
            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------            
            Stopwatch stopwatch = Stopwatch.StartNew();

            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            List<RentInfoDto> list = JsonConvert.DeserializeObject<List<RentInfoDto>>(json);

            stopwatch.Stop();

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------            
            if (list == null || list.Count == 0)
            {
                lblCnt.Text = "0 건";
                dataGridView1.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            long elapsedMs = stopwatch.ElapsedMilliseconds;
            double seconds = elapsedMs / 1000.0; // 초 단위 변환 (0.8초)

            dataGridView1.DataSource = list;
            lblCnt.Text = $"{list.Count:N0} 건({seconds:0.0}초)";

            SetGridHeader();
        }

        private string BuildQueryString(RentInfoSearchModel model)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            var query = HttpUtility.ParseQueryString(string.Empty);

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            query["sido"] = model.Sido;
            query["sigungu"] = model.Sigungu;
            query["dong"] = model.Dong;
            query["year"] = model.Year;
            query["gubun"] = model.Gubun;

            return query.ToString();
        }

        private void SetGridHeader()
        {
            //-------------------------------------------------------------------------------------------
            // 컬럼명 변경
            //-------------------------------------------------------------------------------------------
            dataGridView1.Columns["sido"].HeaderText = "시도";
            dataGridView1.Columns["sigungu"].HeaderText = "시군구";
            dataGridView1.Columns["dong"].HeaderText = "동";

            dataGridView1.Columns["Bungi"].HeaderText = "번지";
            dataGridView1.Columns["BonBun"].HeaderText = "본번";
            dataGridView1.Columns["BuBun"].HeaderText = "부번";

            dataGridView1.Columns["Dangi"].HeaderText = "단지명";
            dataGridView1.Columns["Gubun"].HeaderText = "거래구분";

            dataGridView1.Columns["DediArea"].HeaderText = "전용면적";

            dataGridView1.Columns["ContYear"].HeaderText = "계약년월";
            dataGridView1.Columns["ContDate"].HeaderText = "계약일";

            dataGridView1.Columns["Deposit"].HeaderText = "보증금";
            dataGridView1.Columns["MonPay"].HeaderText = "월세";

            dataGridView1.Columns["Floor"].HeaderText = "층";

            dataGridView1.Columns["ConsYear"].HeaderText = "건축년도";

            dataGridView1.Columns["Road"].HeaderText = "도로명";

            dataGridView1.Columns["Term"].HeaderText = "계약기간";
            dataGridView1.Columns["TermGubun"].HeaderText = "계약구분";

            dataGridView1.Columns["RightRequ"].HeaderText = "갱신요구권";            

            dataGridView1.Columns["PrevDeposit"].HeaderText = "종전보증금";
            dataGridView1.Columns["PrevMonPay"].HeaderText = "종전월세";

            dataGridView1.Columns["HousKind"].HeaderText = "주택유형";

            dataGridView1.Columns["City"].Visible = false;

            //-------------------------------------------------------------------------------------------
            // 컬럼 순서 지정
            //-------------------------------------------------------------------------------------------
            dataGridView1.Columns["sido"].DisplayIndex = 0;
            dataGridView1.Columns["sigungu"].DisplayIndex = 1;
            dataGridView1.Columns["dong"].DisplayIndex = 2;

            dataGridView1.Columns["Bungi"].DisplayIndex = 3;
            dataGridView1.Columns["BonBun"].DisplayIndex = 4;
            dataGridView1.Columns["BuBun"].DisplayIndex = 5;

            dataGridView1.Columns["Dangi"].DisplayIndex = 6;
            dataGridView1.Columns["Gubun"].DisplayIndex = 7;

            dataGridView1.Columns["DediArea"].DisplayIndex = 8;

            dataGridView1.Columns["ContYear"].DisplayIndex = 9;
            dataGridView1.Columns["ContDate"].DisplayIndex = 10;

            dataGridView1.Columns["Deposit"].DisplayIndex = 11;
            dataGridView1.Columns["MonPay"].DisplayIndex = 12;

            dataGridView1.Columns["Floor"].DisplayIndex = 13;

            dataGridView1.Columns["ConsYear"].DisplayIndex = 14;

            dataGridView1.Columns["Road"].DisplayIndex = 15;

            dataGridView1.Columns["Term"].DisplayIndex = 16;
            dataGridView1.Columns["TermGubun"].DisplayIndex = 17;

            dataGridView1.Columns["RightRequ"].DisplayIndex = 18;

            dataGridView1.Columns["PrevDeposit"].DisplayIndex = 19;
            dataGridView1.Columns["PrevMonPay"].DisplayIndex = 20;

            dataGridView1.Columns["HousKind"].DisplayIndex = 21;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }


    }
}