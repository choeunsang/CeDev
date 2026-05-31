using CeDev.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Windows.Forms.DataVisualization.Charting;

namespace CeDev
{
    public partial class HousTradInfo : Form
    {
        public HousTradInfo()
        {
            InitializeComponent();
            _ = InitCont();
            InitEvent();
        }

        private void InitEvent()
        {
            //dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private async Task InitCont()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string url = "http://localhost:9081/api/region/sido";

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
                txtYear.Text = DateTime.Now.Year.ToString();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await GetHousTradeInfo();
        }

        private async Task GetHousTradeInfo()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            EntireMonthlySearchModel model = new EntireMonthlySearchModel();

            string year = txtYear.Text.Trim();

            model.Sido = cboSido.Text.Trim();
            model.StartYearMonth = year + "01";
            model.EndYearMonth = year + "12";

            //string baseUrl = "http://localhost:9081/api/housing-trade-volume/entire-monthly";
            string baseUrl = "http://localhost:9081/api/housing-trade-info";

            string queryString = BuildQueryString(model);

            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                string json = await client.GetStringAsync(url);
                List<HousingTradeInfoDto> list = JsonConvert.DeserializeObject<List<HousingTradeInfoDto>>(json);

                stopwatch.Stop();

                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("조회된 데이터가 없습니다.");
                    dataGridView1.DataSource = null;
                    //chart1.Series.Clear();
                    return;
                }

                long elapsedMs = stopwatch.ElapsedMilliseconds;
                double seconds = elapsedMs / 1000.0; // 초 단위 변환 (0.8초)

                dataGridView1.DataSource = list;
                lblCnt.Text = $"{list.Count:N0} 건({seconds:0.0}초)";

                SetGridHeader();

                dataGridView1.Columns["sido"].HeaderText = "시도";
                dataGridView1.Columns["sido"].Width = 120;
            }
        }


        private string BuildQueryString(EntireMonthlySearchModel model)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            var query = HttpUtility.ParseQueryString(string.Empty);

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            query["sido"] = model.Sido;
            query["startYearMonth"] = model.StartYearMonth;
            query["endYearMonth"] = model.EndYearMonth;

            return query.ToString();
        }

        private void SetGridHeader()
        {
            if (dataGridView1.Columns["City"] != null) dataGridView1.Columns["City"].HeaderText = "시도";
            if (dataGridView1.Columns["Bungi"] != null) dataGridView1.Columns["Bungi"].HeaderText = "번지";
            if (dataGridView1.Columns["Bonbun"] != null) dataGridView1.Columns["Bonbun"].HeaderText = "본번";
            if (dataGridView1.Columns["Bubun"] != null) dataGridView1.Columns["Bubun"].HeaderText = "부번";
            if (dataGridView1.Columns["Dangi"] != null) dataGridView1.Columns["Dangi"].HeaderText = "단지명";

            if (dataGridView1.Columns["DediArea"] != null) dataGridView1.Columns["DediArea"].HeaderText = "전용면적";
            if (dataGridView1.Columns["ContYear"] != null) dataGridView1.Columns["ContYear"].HeaderText = "계약년월";
            if (dataGridView1.Columns["ContDate"] != null) dataGridView1.Columns["ContDate"].HeaderText = "계약일";
            if (dataGridView1.Columns["Amount"] != null) dataGridView1.Columns["Amount"].HeaderText = "거래금액(만원)";
            if (dataGridView1.Columns["Floor"] != null) dataGridView1.Columns["Floor"].HeaderText = "층";

            if (dataGridView1.Columns["ConsYear"] != null) dataGridView1.Columns["ConsYear"].HeaderText = "건축년도";
            if (dataGridView1.Columns["Road"] != null) dataGridView1.Columns["Road"].HeaderText = "도로명";
            if (dataGridView1.Columns["DateCancel"] != null) dataGridView1.Columns["DateCancel"].HeaderText = "취소일자";
            if (dataGridView1.Columns["TransType"] != null) dataGridView1.Columns["TransType"].HeaderText = "거래유형";
            if (dataGridView1.Columns["BrokerLoc"] != null) dataGridView1.Columns["BrokerLoc"].HeaderText = "중개사소재지";

            if (dataGridView1.Columns["RegiDt"] != null) dataGridView1.Columns["RegiDt"].HeaderText = "등록일자";
            if (dataGridView1.Columns["Sido"] != null) dataGridView1.Columns["Sido"].HeaderText = "시도코드";
            if (dataGridView1.Columns["Sigungu"] != null) dataGridView1.Columns["Sigungu"].HeaderText = "시군구코드";
            if (dataGridView1.Columns["Dong"] != null) dataGridView1.Columns["Dong"].HeaderText = "법정동코드";

        }

        private void HousTradInfo_Load(object sender, EventArgs e)
        {

        }
    }
}