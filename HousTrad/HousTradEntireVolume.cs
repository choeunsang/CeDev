using CeDev.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms.DataVisualization.Charting;

namespace CeDev
{
    public partial class HousTradEntireVolume : Form
    {
        public HousTradEntireVolume()
        {
            InitializeComponent();            
            InitEvent();            
        }

        private void InitEvent()
        {
            this.Load += HousTradEntireVolume_Load;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private async Task InitCont()
        {
            txtYear.Text = DateTime.Now.Year.ToString();            
        }

        private async void HousTradEntireVolume_Load(object? sender, EventArgs e)
        {
            await InitCont();
            await DoSearch();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            EntireMonthlyTradeVolumeDto item = dataGridView1.CurrentRow.DataBoundItem as EntireMonthlyTradeVolumeDto;

            if (item == null)
            {
                return;
            }

            string[] months =
            {
                "1월", "2월", "3월", "4월", "5월", "6월",
                "7월", "8월", "9월", "10월", "11월", "12월"
            };

                    int[] values =
                    {
                item.month01,
                item.month02,
                item.month03,
                item.month04,
                item.month05,
                item.month06,
                item.month07,
                item.month08,
                item.month09,
                item.month10,
                item.month11,
                item.month12
            };

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea area = new ChartArea("MainArea");

            area.AxisX.Minimum = 0.5;
            area.AxisX.Maximum = 12.5;
            area.AxisX.Interval = 1;

            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;

            area.AxisY.Minimum = 0;

            for (int i = 0; i < months.Length; i++)
            {
                area.AxisX.CustomLabels.Add(
                    i + 0.5,
                    i + 1.5,
                    months[i]
                );
            }

            chart1.ChartAreas.Add(area);

            Series series = new Series(item.sido);

            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 4;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > 0)
                {
                    series.Points.AddXY(i + 1, values[i]);
                }
            }

            chart1.Series.Add(series);
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
                await GetEntireMonthVolumn();
            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.MarqueeAnimationSpeed = 0;
                btnSearch.Enabled = true;
            }
        }

        private async Task GetEntireMonthVolumn()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            EntireMonthlySearchModel model = new EntireMonthlySearchModel();

            string year = txtYear.Text.Trim();

            //model.Sido = cboSido.Text.Trim();
            model.StartYearMonth = year + "01";
            model.EndYearMonth = year + "12";
            
            string baseUrl = "http://localhost:9081/api/housing-trade-volume/entire-monthly";

            string queryString = BuildQueryString(model);

            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                string json = await client.GetStringAsync(url);
                List<EntireMonthlyTradeVolumeDto> list = JsonConvert.DeserializeObject<List<EntireMonthlyTradeVolumeDto>>(json);

                stopwatch.Stop();

                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("조회된 데이터가 없습니다.");
                    dataGridView1.DataSource = null;
                    chart1.Series.Clear();
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

        private void DrawChart(DataTable dt)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string[] months =
            {
                "1월", "2월", "3월", "4월", "5월", "6월",
                "7월", "8월", "9월", "10월", "11월", "12월"
            };

            ChartArea area;
            Legend legend;

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            area = new ChartArea("MainArea");

            area.AxisX.Minimum = 0.5;
            area.AxisX.Maximum = 12.5;
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;

            area.AxisY.Minimum = 0;
            area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

            for (int i = 0; i < months.Length; i++)
            {
                area.AxisX.CustomLabels.Add(
                    i + 0.5,
                    i + 1.5,
                    months[i]
                );
            }

            chart1.ChartAreas.Add(area);

            legend = new Legend();
            legend.Docking = Docking.Right;
            chart1.Legends.Add(legend);

            foreach (DataRow row in dt.Rows)
            {
                string sigungu = row["sigungu"].ToString();

                Series series = new Series(sigungu);
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 3;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 7;
                series.IsValueShownAsLabel = false;

                for (int i = 0; i < months.Length; i++)
                {
                    string colName = months[i];
                    int value = Convert.ToInt32(row[colName]);

                    series.Points.AddXY(i + 1, value);
                }

                chart1.Series.Add(series);
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
            //-------------------------------------------------------------------------------------------
            // 컬럼명 변경
            //-------------------------------------------------------------------------------------------
            dataGridView1.Columns["sido"].HeaderText = "시도";

            dataGridView1.Columns["month01"].HeaderText = "1월";
            dataGridView1.Columns["month02"].HeaderText = "2월";
            dataGridView1.Columns["month03"].HeaderText = "3월";
            dataGridView1.Columns["month04"].HeaderText = "4월";
            dataGridView1.Columns["month05"].HeaderText = "5월";
            dataGridView1.Columns["month06"].HeaderText = "6월";
            dataGridView1.Columns["month07"].HeaderText = "7월";
            dataGridView1.Columns["month08"].HeaderText = "8월";
            dataGridView1.Columns["month09"].HeaderText = "9월";
            dataGridView1.Columns["month10"].HeaderText = "10월";
            dataGridView1.Columns["month11"].HeaderText = "11월";
            dataGridView1.Columns["month12"].HeaderText = "12월";
        }
    }
}