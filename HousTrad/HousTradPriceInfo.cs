using CeDev.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web;

namespace CeDev
{
    public partial class HousTradPriceInfo : Form
    {
        public HousTradPriceInfo()
        {
            InitializeComponent();            
            InitEvent();            
        }

        private async void HousTradPriceInfo_Load(object? sender, EventArgs e)
        {
            await InitCont();
            await DoSearch();
        }

        private void InitEvent()
        {
            this.Load += HousTradPriceInfo_Load;

            //dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;            
            dataGridView1.CellClick += DataGridView1_CellClick;
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
            await DoSearch();            
        }

        private async void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            HousingTradePriceInfoDto item = dataGridView1.CurrentRow.DataBoundItem as HousingTradePriceInfoDto;

            if (item == null)
            {
                return;
            }

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            await GetHousTradPriceDetailInfo(item);
        }

        private async void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            HousingTradePriceInfoDto item = dataGridView1.CurrentRow.DataBoundItem as HousingTradePriceInfoDto;

            if (item == null)
            {
                return;
            }

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            await GetHousTradPriceDetailInfo(item);
        }

        private async Task DoSearch()
        {
            //Declare and initialize variables 
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            btnSearch.Enabled = false;

            //Processingg
            try
            {
                await GetHousTradPriceInfo();
            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.MarqueeAnimationSpeed = 0;
                btnSearch.Enabled = true;
            }
        }

        private async Task GetHousTradPriceDetailInfo(HousingTradePriceInfoDto pItem)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            EntireMonthlySearchModel model = new EntireMonthlySearchModel();

            string year = txtYear.Text.Trim();

            //model.Sido = cboSido.Text.Trim();
            //model.Sigungu = cboSigungu.Text == "전체" ? "" : cboSigungu.Text.Trim();
            //model.Dong = cboDong.Text == "전체" ? "" : cboDong.Text.Trim();

            model.Sido = pItem.Sido;
            model.Sigungu = pItem.Sigungu;
            model.Dong = pItem.Dong;

            model.AreaPyeong = pItem.AreaPyeong;


            model.StartYearMonth = year + "01";
            model.EndYearMonth = year + "12";

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
                    dataGridView2.DataSource = null;
                    //chart1.Series.Clear();
                    return;
                }

                long elapsedMs = stopwatch.ElapsedMilliseconds;
                double seconds = elapsedMs / 1000.0; // 초 단위 변환 (0.8초)

                dataGridView2.DataSource = list;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                lblCnt2.Text = $"{list.Count:N0} 건({seconds:0.0}초)";

                //SetGridHeader();
            }
        }

        private async Task GetHousTradPriceInfo()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //------------------------------------------------------------^------------------------------
            EntireMonthlySearchModel model = new EntireMonthlySearchModel();

            string year = txtYear.Text.Trim();

            model.Sido = cboSido.Text.Trim();
            model.StartYearMonth = year + "01";
            model.EndYearMonth = year + "12";

            string baseUrl = "http://localhost:9081/api/housing-tradePrice-info";

            string queryString = BuildQueryString(model);

            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                string json = await client.GetStringAsync(url);
                List<HousingTradePriceInfoDto> list = JsonConvert.DeserializeObject<List<HousingTradePriceInfoDto>>(json);

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
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


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
            query["sigungu"] = model.Sigungu;
            query["dong"] = model.Dong;
            query["startYearMonth"] = model.StartYearMonth;
            query["endYearMonth"] = model.EndYearMonth;

            query["areaPyeong"] = model.AreaPyeong;

            return query.ToString();
        }

        private void SetGridHeader()
        {
            //컬럼명 변경            
            dataGridView1.Columns["sido"].HeaderText = "시도";
            dataGridView1.Columns["sigungu"].HeaderText = "시군구";
            dataGridView1.Columns["dong"].HeaderText = "법정동";

            dataGridView1.Columns["areaPyeong"].HeaderText = "전용면적(평)";
            dataGridView1.Columns["tradCnt"].HeaderText = "거래건수";
            dataGridView1.Columns["avgPrice"].HeaderText = "평균금액(만원)";
            dataGridView1.Columns["minPrice"].HeaderText = "최저금액(만원)";
            dataGridView1.Columns["maxPrice"].HeaderText = "최고금액(만원)";

            // 헤더 텍스트 줄바꿈 방지 (한 줄 출력 보장)
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            //데이터 바인딩 또는 조회 완료 후 실행
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


        }
    }
}