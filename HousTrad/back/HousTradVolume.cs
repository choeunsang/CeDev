using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;

namespace CeDev
{
    public partial class HousTradVolume : Form
    {
        public HousTradVolume()
        {
            InitializeComponent();
            InitCont();
        }

        private void InitCont()
        {
            txtRegion.Text = "서울특별시";
            txtYear.Text = "2025";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------

            // 👉 필요에 따라 변경
            //await GetDetailVolumn();
            await GetMonthVolumn();
        }

        //-------------------------------------------------------------------------------------------
        // 상세 거래량 (동 단위)
        //-------------------------------------------------------------------------------------------
        private async Task GetDetailVolumn()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string city = txtRegion.Text.Trim();
            string year = txtYear.Text.Trim();

            string startYearMonth = year + "01";
            string endYearMonth = year + "12";

            string url =
                $"http://localhost:9081/api/housing-trade-volume" +
                $"?city={Uri.EscapeDataString(city)}" +
                $"&startYearMonth={startYearMonth}" +
                $"&endYearMonth={endYearMonth}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                dataGridView1.DataSource = dt;

                // 컬럼 설정
                dataGridView1.Columns["city"].HeaderText = "지역";
                dataGridView1.Columns["ContYear"].HeaderText = "계약년월";
                dataGridView1.Columns["cnt"].HeaderText = "거래량";

                dataGridView1.Columns["city"].Width = 250;
                dataGridView1.Columns["ContYear"].Width = 100;
                dataGridView1.Columns["cnt"].Width = 80;
            }
        }

        //-------------------------------------------------------------------------------------------
        // 월별 합계
        //-------------------------------------------------------------------------------------------
        private async Task GetMonthVolumn()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string city = txtRegion.Text.Trim();
            string year = txtYear.Text.Trim();

            string startYearMonth = year + "01";
            string endYearMonth = year + "12";

            string url =
                $"http://localhost:9081/api/housing-trade-volume/monthly" +
                $"?city={Uri.EscapeDataString(city)}" +
                $"&startYearMonth={startYearMonth}" +
                $"&endYearMonth={endYearMonth}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                dataGridView1.DataSource = dt;

                // 컬럼 설정
                dataGridView1.Columns["ContYear"].HeaderText = "계약년월";
                dataGridView1.Columns["cnt"].HeaderText = "거래량";

                dataGridView1.Columns["ContYear"].Width = 120;
                dataGridView1.Columns["cnt"].Width = 100;

                DrawChart(dt);
            }
        }

        private void DrawChart(DataTable dt)
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
            area.AxisX.Maximum = dt.Rows.Count + 0.5;
            area.AxisX.MajorGrid.Enabled = false;

            area.AxisX.LabelStyle.Enabled = true;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.LabelStyle.IsEndLabelVisible = true;

            area.AxisY.Minimum = 0;

            area.AxisX.LabelStyle.Enabled = true;
            area.AxisX.Interval = 1;

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

            foreach (DataRow row in dt.Rows)
            {
                string contYear = row["ContYear"].ToString();

                if (contYear.Length == 6)
                {
                    contYear =
                        Convert.ToInt32(
                            contYear.Substring(4, 2)
                        ).ToString() + "월";
                }

                int cnt = Convert.ToInt32(row["cnt"]);

                series.Points.AddXY(monthIndex, cnt);

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