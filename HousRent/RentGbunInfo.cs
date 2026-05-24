using CeDev.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Web;

namespace CeDev
{
    public partial class RentGbunInfo : Form
    {
        public RentGbunInfo()
        {
            InitializeComponent();
            InitEvent();
            _ = InitCont();

        }

        private void InitEvent()
        {
            //cboSido.SelectedIndexChanged += cboSido_SelectedIndexChanged;
            //cboSigungu.SelectedIndexChanged += cboSigungu_SelectedIndexChanged;
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

            ////전월세 구분
            //cboGubun.Items.Clear();
            //cboGubun.Items.Add("전체");
            //cboGubun.Items.Add("전세");
            //cboGubun.Items.Add("월세");
            //cboGubun.SelectedIndex = 0;

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

                //cboSigungu.Items.Clear();
                //cboSigungu.Items.Add("전체");
                //cboSigungu.SelectedIndex = 0;

                //cboDong.Items.Clear();
                //cboDong.Items.Add("전체");
                //cboDong.SelectedIndex = 0;

                //txtYear.Text = "2025";
                //txtYear.Text = "2026";

                txtYear.Text = DateTime.Now.Year.ToString();
            }
        }

        //private async void cboSido_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //-------------------------------------------------------------------------------------------
        //    // Declare and initialize variables
        //    //-------------------------------------------------------------------------------------------
        //    string sido = cboSido.Text.Trim();

        //    string url =
        //        $"http://localhost:9081/api/region/sigungu" +
        //        $"?sido={Uri.EscapeDataString(sido)}";

        //    //-------------------------------------------------------------------------------------------
        //    // Processing
        //    //-------------------------------------------------------------------------------------------
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string json = await client.GetStringAsync(url);

        //        cboSigungu.DataSource = null;
        //        cboSigungu.Items.Clear();
        //        cboSigungu.Items.Add("전체");

        //        List<string> sigunguList = JsonConvert.DeserializeObject<List<string>>(json);

        //        foreach (string sigungu in sigunguList)
        //        {
        //            cboSigungu.Items.Add(sigungu);
        //        }

        //        cboSigungu.SelectedIndex = 0;

        //        cboDong.DataSource = null;
        //        cboDong.Items.Clear();
        //        cboDong.Items.Add("전체");
        //        cboDong.SelectedIndex = 0;
        //    }
        //}

        //private async void cboSigungu_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //-------------------------------------------------------------------------------------------
        //    // Declare and initialize variables
        //    //-------------------------------------------------------------------------------------------
        //    string sido = cboSido.Text.Trim();
        //    string sigungu = cboSigungu.Text.Trim();

        //    if (string.IsNullOrEmpty(sido) || sigungu == "전체")
        //    {
        //        cboDong.DataSource = null;
        //        cboDong.Items.Clear();
        //        cboDong.Items.Add("전체");
        //        cboDong.SelectedIndex = 0;
        //        return;
        //    }

        //    string url =
        //        $"http://localhost:9081/api/region/dong" +
        //        $"?sido={Uri.EscapeDataString(sido)}" +
        //        $"&sigungu={Uri.EscapeDataString(sigungu)}";

        //    //-------------------------------------------------------------------------------------------
        //    // Processing
        //    //-------------------------------------------------------------------------------------------
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string json = await client.GetStringAsync(url);

        //        cboDong.DataSource = null;
        //        cboDong.Items.Clear();
        //        cboDong.Items.Add("전체");

        //        List<string> dongList = JsonConvert.DeserializeObject<List<string>>(json);

        //        foreach (string dong in dongList)
        //        {
        //            cboDong.Items.Add(dong);
        //        }

        //        cboDong.SelectedIndex = 0;
        //    }
        //}

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
            //model.Sigungu = cboSigungu.Text == "전체" ? "" : cboSigungu.Text.Trim();
            //model.Dong = cboDong.Text == "전체" ? "" : cboDong.Text.Trim();
            model.Year = txtYear.Text.Trim();
            //model.Gubun = cboGubun.Text == "전체" ? "" : cboGubun.Text.Trim();

            //string url =
            //    $"http://localhost:9081/api/rent-info" +
            //    $"?sido={Uri.EscapeDataString(model.Sido)}" +
            //    $"&sigungu={Uri.EscapeDataString(model.Sigungu)}" +
            //    $"&dong={Uri.EscapeDataString(model.Dong)}" +
            //    $"&year={Uri.EscapeDataString(model.Year)}" +
            //    $"&gubun={Uri.EscapeDataString(model.Gubun)}";

            //string baseUrl = "http://localhost:9081/api/rent-info";
            string baseUrl = "http://localhost:9081/api/housing-rentGbun-status";
            string queryString = BuildQueryString(model);
            string url = $"{baseUrl}?{queryString}";
            
            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------            
            Stopwatch stopwatch = Stopwatch.StartNew();

            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            List<RentGbunItem> list = JsonConvert.DeserializeObject<List<RentGbunItem>>(json);

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
            dataGridView1.Columns["sigungu"].HeaderText = "시군구";

            dataGridView1.Columns["newContractCnt"].HeaderText = "신규";
            dataGridView1.Columns["renewContractCnt"].HeaderText = "갱신";
            dataGridView1.Columns["usedRightCnt"].HeaderText = "갱신요구권 사용";
            dataGridView1.Columns["usePercent"].HeaderText = "갱신요구권 사용률";


            //------------------------------------------------------------------------------------------- 
            // [해결] 글자 짤림 방지 및 화면 꽉 채우기 설정
            //------------------------------------------------------------------------------------------- 
            // 1. 기존의 잘못된 너비 모드 설정 방지하기 위해 기본값 초기화
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // 2. 전체 화면 너비에 맞게 컬럼들을 비율대로 자동 배분 (한 줄 출력 확보)
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 3. (선택사항) 특히 글자가 긴 '갱신요구권 사용' 컬럼 비율을 더 넓게 지정하고 싶다면 아래 주석 해제
            // dataGridView1.Columns["usedRightCnt"].FillWeight = 150; 

            // [추천 추가] usePercent 컬럼 데이터 뒤에 자동으로 % 기호를 붙여 화면에 출력합니다.
            // 데이터 자체는 double 숫자이므로 그리드에서 '정렬(Sort)' 기능도 완벽하게 작동합니다.
            dataGridView1.Columns["usePercent"].DefaultCellStyle.Format = "0.00'%'";
        }
    }
}