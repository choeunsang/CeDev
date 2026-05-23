using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Web;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;

namespace CeDev
{
    public partial class ReceTran : Form
    {
        public ReceTran()
        {
            InitializeComponent();
            InitCont();
            InitEvent();
        }

        private void InitCont()
        {


            txtCity.Text = "서울특별시";
            txtFrom.Text = "202604";
            txtTo.Text = "202604";
        }

        private void InitEvent()
        {
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string city = txtCity.Text.Trim();
            string dangi = txtDangi.Text.Trim();
            string fromDt = txtFrom.Text.Trim();
            string toDt = txtTo.Text.Trim();

            string url =
                "http://localhost:9081/api/recent-transactions" +
                $"?city={HttpUtility.UrlEncode(city)}" +
                $"&dangi={HttpUtility.UrlEncode(dangi)}" +
                $"&startYearMonth={HttpUtility.UrlEncode(fromDt)}" +
                $"&endYearMonth={HttpUtility.UrlEncode(toDt)}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
                
                dataGridView1.DataSource = dt;

                //-------------------------------------------------------------------------------------------
                // Grid Setting
                //-------------------------------------------------------------------------------------------
                dataGridView1.Columns["city"].HeaderText = "지역";
                dataGridView1.Columns["dangi"].HeaderText = "단지";
                dataGridView1.Columns["DediArea"].HeaderText = "면적";
                dataGridView1.Columns["ContDate"].HeaderText = "일";
                dataGridView1.Columns["amount"].HeaderText = "금액";
                dataGridView1.Columns["Floor"].HeaderText = "층";

                dataGridView1.Columns["city"].Width = 220;
                dataGridView1.Columns["dangi"].Width = 180;
                dataGridView1.Columns["DediArea"].Width = 90;
                dataGridView1.Columns["ContDate"].Width = 70;
                dataGridView1.Columns["amount"].Width = 110;
                dataGridView1.Columns["Floor"].Width = 60;

                dataGridView1.Columns["DediArea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["Floor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridView1.RowTemplate.Height = 28;
                dataGridView1.ColumnHeadersHeight = 30;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;

                lblResult.Text = dt.Rows.Count.ToString() + " 건";
            }
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

            if (dataGridView1.CurrentRow.IsNewRow)
            {
                return;
            }

            string city = dataGridView1.CurrentRow.Cells["city"].Value?.ToString() ?? "";
            string dangi = dataGridView1.CurrentRow.Cells["dangi"].Value?.ToString() ?? "";
            string dediArea = dataGridView1.CurrentRow.Cells["DediArea"].Value?.ToString() ?? "";

            string url =
                "http://localhost:9081/api/real-estate-detail" +
                $"?city={HttpUtility.UrlEncode(city)}" +
                $"&dangi={HttpUtility.UrlEncode(dangi)}" +
                $"&dediArea={HttpUtility.UrlEncode(dediArea)}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                dataGridView2.DataSource = dt;

                SetDetailGrid();
                SetPriceChart(dt);
                SetSummaryInfo(city, dangi, dediArea, dt);
            }
        }

        private void SetSummaryInfo(string city, string dangi, string dediArea, DataTable dt)
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
                    dataGridView1.CurrentRow.Cells["amount"].Value?.ToString().Replace(",", ""),
                    out selectedPrice
                );
            }

            txtDetail.Text = $"{city} {dangi} / {dediArea}㎡ / {selectedPrice:N0}";

            foreach (DataRow row in dt.Rows)
            {
                int avgAmount = 0;

                int.TryParse(
                    row["avgAmount"].ToString().Replace(",", ""),
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
            if (dataGridView2.Columns.Contains("ContYear"))
            {
                var col = dataGridView2.Columns["ContYear"];
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

            dataGridView2.Columns["ContYear"].DisplayIndex = 0;
            dataGridView2.Columns["avgAmount"].DisplayIndex = 1;
            dataGridView2.Columns["cnt"].DisplayIndex = 2;
        }

        private void SetPriceChart(DataTable dt)
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

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string contYear = dt.Rows[i]["ContYear"].ToString().Trim();

                int avgAmount = 0;
                int.TryParse(dt.Rows[i]["avgAmount"].ToString().Replace(",", ""), out avgAmount);

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
    }



}