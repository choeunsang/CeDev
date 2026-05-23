using CeDev.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Windows.Forms.DataVisualization.Charting;

namespace CeDev
{
    public partial class HousTradSigunguDetailVolume : Form
    {
        public HousTradSigunguDetailVolume()
        {
            InitializeComponent();
            _ = InitCont();
            InitEvent();
        }

        private void InitEvent()
        {
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
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
            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------

            // 👉 필요에 따라 변경
            await GetSigunguMonthVolumn();
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

            SigunguMonthlyTradeVolumeDto item =
                dataGridView1.CurrentRow.DataBoundItem
                as SigunguMonthlyTradeVolumeDto;

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

            Series series = new Series(item.sigungu);

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


        private async Task GetSigunguMonthVolumn()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            SigunguMonthlySearchModel model = new SigunguMonthlySearchModel();

            string year = txtYear.Text.Trim();

            model.Sido = cboSido.Text.Trim();
            model.StartYearMonth = year + "01";
            model.EndYearMonth = year + "12";

            string baseUrl =
                "http://localhost:9081/api/housing-trade-volume/sigungu-monthly";

            string queryString = BuildQueryString(model);

            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);

                List<SigunguMonthlyTradeVolumeDto> list =
                    JsonConvert.DeserializeObject<List<SigunguMonthlyTradeVolumeDto>>(json);

                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("조회된 데이터가 없습니다.");
                    dataGridView1.DataSource = null;
                    chart1.Series.Clear();
                    return;
                }

                dataGridView1.DataSource = list;
                SetGridHeader();

                dataGridView1.Columns["sigungu"].HeaderText = "시군구";
                dataGridView1.Columns["sigungu"].Width = 120;
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

        private string BuildQueryString(SigunguMonthlySearchModel model)
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
            dataGridView1.Columns["sigungu"].HeaderText = "시군구";

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