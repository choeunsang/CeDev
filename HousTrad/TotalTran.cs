using CeDev.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Web;
using System.Windows.Forms.DataVisualization.Charting;

namespace CeDev
{
    public partial class TotalTran : Form
    {
        public TotalTran()
        {
            InitializeComponent();
            InitEvent();
            //InitCont();
        }

        private void InitEvent()
        {
            this.Load += TotalTran_Load;

            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            cboSido.SelectedIndexChanged += cboSido_SelectedIndexChanged;
            cboSigungu.SelectedIndexChanged += cboSigungu_SelectedIndexChanged;
        }

        private async void TotalTran_Load(object? sender, EventArgs e)
        {
            await InitCont();
            await DoSearch();
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
                //txtYear.Text = DateTime.Now.Year.ToString();

                //temp
                txtFrom.Text = "202604";
                txtTo.Text = "202604";
            }

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------
            //await DoSearch();
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

            RecentTransactionDto item = dataGridView1.CurrentRow.DataBoundItem as RecentTransactionDto;

            if (item == null)
            {
                return;
            }

            string url =
                "http://localhost:9081/api/real-estate-detail" +
                $"?sido={HttpUtility.UrlEncode(item.sido)}" +
                $"&sigungu={HttpUtility.UrlEncode(item.sigungu)}" +
                $"&dong={HttpUtility.UrlEncode(item.dong)}" +
                $"&dangi={HttpUtility.UrlEncode(item.dangi)}" +
                $"&dediArea={HttpUtility.UrlEncode(item.dediArea)}";

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);

                List<RealEstateDetailDto> detailList =
                    JsonConvert.DeserializeObject<List<RealEstateDetailDto>>(json);

                dataGridView2.DataSource = detailList;

                SetDetailGrid();
                SetPriceChart(detailList);
                SetSummaryInfo(item, detailList);
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
            await DoSearch();
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
                await GetTotalTradeInfo();
            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.MarqueeAnimationSpeed = 0;
                btnSearch.Enabled = true;
            }
        }

        private async Task GetTotalTradeInfo()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            RecentTransactionSearchModel model = new RecentTransactionSearchModel();

            model.Sido = cboSido.SelectedItem?.ToString() ?? "";
            model.Sigungu = cboSigungu.SelectedItem?.ToString() ?? "";
            model.Dong = cboDong.SelectedItem?.ToString() ?? "";

            if (model.Sigungu == "전체")
            {
                model.Sigungu = "";
            }

            if (model.Dong == "전체")
            {
                model.Dong = "";
            }

            model.Dangi = txtDangi.Text.Trim();
            model.StartYearMonth = txtFrom.Text.Trim();
            model.EndYearMonth = txtTo.Text.Trim();

            string baseUrl = "http://localhost:9081/api/recent-transactions";
            string queryString = BuildQueryString(model);
            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                string json = await client.GetStringAsync(url);
                List<RecentTransactionDto> list = JsonConvert.DeserializeObject<List<RecentTransactionDto>>(json);

                stopwatch.Stop();
                long elapsedMs = stopwatch.ElapsedMilliseconds;
                double seconds = elapsedMs / 1000.0; // 초 단위 변환 (0.8초)

                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("조회된 데이터가 없습니다.");

                    dataGridView1.DataSource = list;
                    lblResult.Text = $"{list.Count:N0} 건({seconds:0.0}초)";

                    dataGridView1.DataSource = null;
                    dataGridView2.DataSource = null;

                    txtDetail.Text = "";
                    txtMaxPrice.Text = "";
                    txtChangeRateFromPeak.Text = "";

                    chart1.Series.Clear();

                    return;
                }

                dataGridView1.DataSource = list;
                SetMainGrid();

                lblResult.Text = $"{list.Count:N0} 건({seconds:0.0}초)";
            }
        }


        private void SetSummaryInfo(RecentTransactionDto item, List<RealEstateDetailDto> list)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            int selectedPrice = 0;
            int maxPrice = 0;
            double changeRate = 0;

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            if (dataGridView1.CurrentRow != null)
            {
                int.TryParse(
                    item.amount.Replace(",", ""),
                    out selectedPrice
                );
            }

            txtDetail.Text = $"{item.city} {item.dangi} / {item.dediArea}㎡ / {selectedPrice:N0}";

            foreach (var row in list)
            {
                int avgAmount = 0;

                int.TryParse(
                    row.avgAmount.ToString().Replace(",", ""),
                    out avgAmount
                );

                if (avgAmount > maxPrice)
                {
                    maxPrice = avgAmount;
                }
            }

            if (maxPrice > 0)
            {
                changeRate = ((double)selectedPrice - maxPrice) / maxPrice * 100.0;
            }

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------
            txtMaxPrice.Text = maxPrice.ToString("N0");
            txtChangeRateFromPeak.Text = changeRate.ToString("0.##") + "%";
        }

        private void SetDetailGrid()
        {
            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------

            // 전체 컬럼 먼저 숨김
            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                col.Visible = false;
            }

            // 필요한 컬럼만 표시
            if (dataGridView2.Columns.Contains("contYear"))
            {
                var col = dataGridView2.Columns["contYear"];
                col.Visible = true;
                col.HeaderText = "계약년월";
                col.Width = 90;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dataGridView2.Columns.Contains("avgAmount"))
            {
                var col = dataGridView2.Columns["avgAmount"];
                col.Visible = true;
                col.HeaderText = "평균금액";
                col.Width = 120;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.DefaultCellStyle.Format = "N0"; // 천단위 콤마
            }

            if (dataGridView2.Columns.Contains("cnt"))
            {
                var col = dataGridView2.Columns["cnt"];
                col.Visible = true;
                col.HeaderText = "건수";
                col.Width = 70;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 공통 설정
            dataGridView2.RowTemplate.Height = 28;
            dataGridView2.ColumnHeadersHeight = 30;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;

            dataGridView2.Columns["contYear"].DisplayIndex = 0;
            dataGridView2.Columns["avgAmount"].DisplayIndex = 1;
            dataGridView2.Columns["cnt"].DisplayIndex = 2;
        }

        private void SetPriceChart(List<RealEstateDetailDto> list)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            ChartArea chartArea = new ChartArea("PriceArea");
            Series series = new Series("가격변동");

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            chart1.ChartAreas.Add(chartArea);

            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 7;
            series.XValueType = ChartValueType.Int32;
            series.YValueType = ChartValueType.Int32;

            chart1.Series.Add(series);

            for (int i = 0; i < list.Count; i++)
            {
                string contYear = list[i].contYear;

                int avgAmount = 0;
                int.TryParse(list[i].avgAmount.ToString().Replace(",", ""), out avgAmount);

                DataPoint point = new DataPoint();
                point.XValue = i + 1;
                point.YValues = new double[] { avgAmount };
                point.AxisLabel = contYear;

                series.Points.Add(point);
            }

            chartArea.AxisX.Title = "계약년월";
            chartArea.AxisY.Title = "평균금액";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisY.LabelStyle.Format = "#,##0";
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea.AxisX.MajorGrid.Enabled = false;
        }

        private string BuildQueryString(RecentTransactionSearchModel model)
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

            query["dangi"] = model.Dangi;

            query["startYearMonth"] = model.StartYearMonth;
            query["endYearMonth"] = model.EndYearMonth;

            return query.ToString();
        }

        private void SetMainGrid()
        {
            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            dataGridView1.Columns["city"].HeaderText = "지역";
            dataGridView1.Columns["dangi"].HeaderText = "단지";
            dataGridView1.Columns["dediArea"].HeaderText = "면적";
            dataGridView1.Columns["contDate"].HeaderText = "일";
            dataGridView1.Columns["amount"].HeaderText = "금액";
            dataGridView1.Columns["floor"].HeaderText = "층";

            dataGridView1.Columns["city"].Width = 220;
            dataGridView1.Columns["dangi"].Width = 180;
            dataGridView1.Columns["dediArea"].Width = 90;
            dataGridView1.Columns["contDate"].Width = 70;
            dataGridView1.Columns["amount"].Width = 110;
            dataGridView1.Columns["floor"].Width = 60;
        }

        private void cboSido_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}