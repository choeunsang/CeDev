using CeDev.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Windows.Forms.DataVisualization.Charting;

namespace CeDev
{
    public partial class HousRentVolume : Form
    {
        public HousRentVolume()
        {
            InitializeComponent();
            InitEvent();
            _ = InitCont();

            this.Load += HousTradDetailVolume_Load;
        }

        private async void HousTradDetailVolume_Load(object? sender, EventArgs e)
        {
            await CeDev.Common.AuthManager.CheckAuthAsync(this);


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
            await GetMonthVolumn();
        }

        private async Task GetMonthVolumn()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            HousTradeVolumeSearchModel model = new HousTradeVolumeSearchModel();

            string year = txtYear.Text.Trim();

            model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();
            model.Sigungu = cboSigungu.Text == "전체" ? "" : cboSigungu.Text.Trim();
            model.Dong = cboDong.Text == "전체" ? "" : cboDong.Text.Trim();
            model.StartYearMonth = year + "01";
            model.EndYearMonth = year + "12";

            //string baseUrl = "http://localhost:9081/api/housing-trade-volume/monthly";
            string baseUrl = "http://localhost:9081/api/housing-rent-volume/monthly";
            string queryString = BuildQueryString(model);

            string url = $"{baseUrl}?{queryString}";


            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------            
            Stopwatch stopwatch = Stopwatch.StartNew();

            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            List<HousingTradeVolumeMonthlyDto> list = JsonConvert.DeserializeObject<List<HousingTradeVolumeMonthlyDto>>(json);

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
            DrawChart(list);

            ////-------------------------------------------------------------------------------------------
            //// Processing
            ////-------------------------------------------------------------------------------------------
            //using (HttpClient client = new HttpClient())
            //{
            //    string json = await client.GetStringAsync(url);

            //    List<HousingTradeVolumeMonthlyDto> list = JsonConvert.DeserializeObject<List<HousingTradeVolumeMonthlyDto>>(json);

            //    if (list == null || list.Count == 0)
            //    {
            //        MessageBox.Show("조회된 데이터가 없습니다.");
            //        dataGridView1.DataSource = null;
            //        chart1.Series.Clear();
            //        return;
            //    }

            //    dataGridView1.DataSource = list;

            //    SetGridHeader();
            //    DrawChart(list);
            //}
        }

        private string BuildQueryString(HousTradeVolumeSearchModel model)
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

            return query.ToString();
        }

        private void SetGridHeader()
        {
            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            dataGridView1.Columns["contYear"].HeaderText = "계약년월";
            dataGridView1.Columns["cnt"].HeaderText = "거래량";

            dataGridView1.Columns["contYear"].Width = 120;
            dataGridView1.Columns["cnt"].Width = 100;
        }

        private void DrawChart(List<HousingTradeVolumeMonthlyDto> list)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            ChartArea area;
            Legend legend;
            Series series;
            int monthIndex;

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            area = new ChartArea("MainArea");

            area.AxisX.Interval = 1;
            area.AxisX.Minimum = 0.5;
            area.AxisX.Maximum = list.Count + 0.5;
            area.AxisX.MajorGrid.Enabled = false;

            area.AxisX.LabelStyle.Enabled = true;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.LabelStyle.IsEndLabelVisible = true;

            area.AxisY.Minimum = 0;
            area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

            chart1.ChartAreas.Add(area);

            legend = new Legend();
            legend.Docking = Docking.Right;
            chart1.Legends.Add(legend);

            series = new Series("거래량");
            series.ChartType = SeriesChartType.Column;
            series.Color = System.Drawing.Color.Coral;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "#,##0";
            series.Font = new System.Drawing.Font("맑은 고딕", 8);
            series.LabelForeColor = System.Drawing.Color.Black;
            series["PointWidth"] = "0.6";

            monthIndex = 1;

            foreach (HousingTradeVolumeMonthlyDto item in list)
            {
                string contYear = item.contYear;

                if (!string.IsNullOrEmpty(contYear) && contYear.Length == 6)
                {
                    contYear =
                        Convert.ToInt32(
                            contYear.Substring(4, 2)
                        ).ToString() + "월";
                }

                series.Points.AddXY(monthIndex, item.cnt);

                area.AxisX.CustomLabels.Add(
                    monthIndex - 0.5,
                    monthIndex + 0.5,
                    contYear
                );

                monthIndex++;
            }

            chart1.Series.Add(series);
        }

    }
}