using CeDev.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms.DataVisualization.Charting;

namespace CeDev
{
    public partial class HousTradVolume : Form
    {
        public HousTradVolume()
        {
            InitializeComponent();
            InitEvent();
        }

        private async void HousTradEntireVolume_Load(object? sender, EventArgs e)
        {
            await InitCont();
            await DoSearch();
        }

        private void InitEvent()
        {
            this.Load += HousTradEntireVolume_Load;

            rdoBtnYear.CheckedChanged += RdoBtn_CheckedChanged;
            rdoBtnMon.CheckedChanged += RdoBtn_CheckedChanged;

            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView2.SelectionChanged += dataGridView2_SelectionChanged;
        }

        private void RdoBtn_CheckedChanged(object? sender, EventArgs e)
        {
            if (rdoBtnYear.Checked)
            {
                //MessageBox.Show("Year!!");
                cboMon.Enabled = false;
                cboMon.SelectedIndex = 0;
            }
            else
            {
                //MessageBox.Show("Month!!");
                cboMon.Enabled = true;
                cboMon.SelectedIndex = 1;
            }
        }



        private async Task InitCont()
        {
            //txtYear.Text = DateTime.Now.Year.ToString();            

            cboMon.Items.Add("");
            cboMon.Items.Add("2023");
            cboMon.Items.Add("2024");
            cboMon.Items.Add("2025");
            cboMon.Items.Add("2026");

            cboMon.Enabled = false;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------------------------------
            //Declare and initialize variables
            //------------------------------------------------------------------------------------
            //if (rdoBtnYear.Checked)
            //{
            //    //MessageBox.Show("Year!!");
            //    cboMon.Enabled = false;
            //    cboMon.SelectedIndex = 0;
            //}
            //else
            //{
            //    //MessageBox.Show("Month!!");
            //    cboMon.Enabled = true;
            //    cboMon.SelectedIndex = 1;
            //}

            //------------------------------------------------------------------------------------
            //Processing
            //------------------------------------------------------------------------------------
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

            TradVolumeDto item = dataGridView1.CurrentRow.DataBoundItem as TradVolumeDto;

            if (item == null)
            {
                return;
            }

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------            
            progressBar2.Visible = true;
            progressBar2.Style = ProgressBarStyle.Marquee;
            progressBar2.MarqueeAnimationSpeed = 30;
            btnSearch.Enabled = false;

            try
            {


                if (rdoBtnYear.Checked == true)
                {
                    await GetTradDetailInfo(item);
                }
                else
                {
                    await GetTradDetailInfo_Mon(item);
                }
            }
            finally
            {
                progressBar2.Visible = false;
                progressBar2.MarqueeAnimationSpeed = 0;
                btnSearch.Enabled = true;
            }
        }

        private void dataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            //--------------------------------------------------------------------------------
            //Decalre and initialize variables 
            //--------------------------------------------------------------------------------
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            TradVolumeDto item = dataGridView1.CurrentRow.DataBoundItem as TradVolumeDto;

            if (item == null)
            {
                return;
            }

            //--------------------------------------------------------------------------------
            //Processing
            //--------------------------------------------------------------------------------
            if (rdoBtnYear.Checked)
            {
                DrawChart(item);
            }
            else
            {
                DrawChart_Mon(item);
            }
        }

        private void dataGridView2_SelectionChanged(object? sender, EventArgs e)
        {
            //--------------------------------------------------------------------------------
            //Decalre and initialize variables 
            //--------------------------------------------------------------------------------
            if (dataGridView2.CurrentRow == null)
            {
                return;
            }

            TradVolumeDto item = dataGridView2.CurrentRow.DataBoundItem as TradVolumeDto;

            if (item == null)
            {
                return;
            }

            //--------------------------------------------------------------------------------
            //Processing
            //--------------------------------------------------------------------------------
            if (rdoBtnYear.Checked)
            {
                DrawChart2(item);
            }
            else
            {
                DrawChart2_Mon(item);
            }
        }

        private void DrawChart(TradVolumeDto pItem)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string[] years =
            {
                "2023년", "2024년", "2025년", "2026년"
            };

            int[] values =
            {
                pItem.y2023,
                pItem.y2024,
                pItem.y2025,
                pItem.y2026
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

            for (int i = 0; i < years.Length; i++)
            {
                area.AxisX.CustomLabels.Add(
                    i + 0.5,
                    i + 1.5,
                    years[i]
                );
            }

            chart1.ChartAreas.Add(area);

            Series series = new Series(pItem.sido);

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

        private void DrawChart_Mon(TradVolumeDto pItem)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            //string[] years =
            //{
            //    "2023년", "2024년", "2025년", "2026년"
            //};

            string[] months =
            {
                "1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월","9월", "10월", "11월", "12월"
            };

            int[] values =
            {
                pItem.m01,
                pItem.m02,
                pItem.m03,
                pItem.m04,
                pItem.m05,
                pItem.m06,
                pItem.m07,
                pItem.m08,
                pItem.m09,
                pItem.m10,
                pItem.m11,
                pItem.m12
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

            //for (int i = 0; i < years.Length; i++)
            for (int i = 0; i < months.Length; i++)
            {
                area.AxisX.CustomLabels.Add(
                    i + 0.5,
                    i + 1.5,
                    //years[i]
                    months[i]
                );
            }

            chart1.ChartAreas.Add(area);

            Series series = new Series(pItem.sido);

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

        private void DrawChart2(TradVolumeDto pItem)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string[] years =
            {
                "2023년", "2024년", "2025년", "2026년"
            };

            int[] values =
            {
                pItem.y2023,
                pItem.y2024,
                pItem.y2025,
                pItem.y2026
            };

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();

            ChartArea area = new ChartArea("MainArea");

            area.AxisX.Minimum = 0.5;
            area.AxisX.Maximum = 12.5;
            area.AxisX.Interval = 1;

            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;

            area.AxisY.Minimum = 0;

            for (int i = 0; i < years.Length; i++)
            {
                area.AxisX.CustomLabels.Add(
                    i + 0.5,
                    i + 1.5,
                    years[i]
                );
            }

            chart2.ChartAreas.Add(area);

            Series series = new Series(pItem.sido);

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

            chart2.Series.Add(series);
        }

        private void DrawChart2_Mon(TradVolumeDto pItem)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            //string[] years =
            //{
            //    "2023년", "2024년", "2025년", "2026년"
            //};

            string[] months =
            {
                "1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월","9월", "10월", "11월", "12월"
            };

            int[] values =
            {
                pItem.m01,
                pItem.m02,
                pItem.m03,
                pItem.m04,
                pItem.m05,
                pItem.m06,
                pItem.m07,
                pItem.m08,
                pItem.m09,
                pItem.m10,
                pItem.m11,
                pItem.m12
            };

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();

            ChartArea area = new ChartArea("MainArea");

            area.AxisX.Minimum = 0.5;
            area.AxisX.Maximum = 12.5;
            area.AxisX.Interval = 1;

            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;

            area.AxisY.Minimum = 0;

            //for (int i = 0; i < years.Length; i++)
            for (int i = 0; i < months.Length; i++)
            {
                area.AxisX.CustomLabels.Add(
                    i + 0.5,
                    i + 1.5,
                    //years[i]
                    months[i]
                );
            }

            chart2.ChartAreas.Add(area);

            Series series = new Series(pItem.sido);

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

            chart2.Series.Add(series);
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
                if (rdoBtnYear.Checked == true)
                {
                    await GetTradInfo();
                }
                else
                {
                    await GetTradInfo_Mon();
                }

            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.MarqueeAnimationSpeed = 0;
                btnSearch.Enabled = true;
            }
        }

        private async Task GetTradInfo()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            TradInfoSearchModel model = new TradInfoSearchModel();

            string baseUrl = "http://localhost:9081/api/housTrad/VolInfo-sido";
            string queryString = BuildQueryString(model);
            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                string json = await client.GetStringAsync(url);
                List<TradVolumeDto> list = JsonConvert.DeserializeObject<List<TradVolumeDto>>(json);

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
            }
        }

        private async Task GetTradInfo_Mon()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            TradInfoSearchModel model = new TradInfoSearchModel();
            model.Year = cboMon.SelectedItem.ToString();

            string baseUrl = "http://localhost:9081/api/housTrad/VolInfo-sido-mon";
            string queryString = BuildQueryString(model);
            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                string json = await client.GetStringAsync(url);
                List<TradVolumeDto> list = JsonConvert.DeserializeObject<List<TradVolumeDto>>(json);

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
            }
        }


        private async Task GetTradDetailInfo(TradVolumeDto pItem)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            TradInfoSearchModel model = new TradInfoSearchModel();

            //string year = txtYear.Text.Trim();

            //model.Sido = cboSido.Text.Trim();
            //model.Sigungu = cboSigungu.Text == "전체" ? "" : cboSigungu.Text.Trim();
            //model.Dong = cboDong.Text == "전체" ? "" : cboDong.Text.Trim();

            model.Sido = pItem.sido;
            //model.Sigungu = pItem.Sigungu;
            //model.Dong = pItem.Dong;

            //model.AreaPyeong = pItem.AreaPyeong;


            //model.StartYearMonth = year + "01";
            //model.EndYearMonth = year + "12";

            //string baseUrl = "http://localhost:9081/api/housing-trade-info";
            string baseUrl = "http://localhost:9081/api/housTrad/VolInfo-sigungu";

            string queryString = BuildQueryString(model);

            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                string json = await client.GetStringAsync(url);
                List<TradVolumeDto> list = JsonConvert.DeserializeObject<List<TradVolumeDto>>(json);

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

                SetGridHeader2();
            }
        }

        private async Task GetTradDetailInfo_Mon(TradVolumeDto pItem)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            TradInfoSearchModel model = new TradInfoSearchModel();

            model.Sido = pItem.sido;
            model.Year = cboMon.SelectedItem.ToString();


            string baseUrl = "http://localhost:9081/api/housTrad/VolInfo-sigungu-mon";

            string queryString = BuildQueryString(model);

            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                string json = await client.GetStringAsync(url);
                List<TradVolumeDto> list = JsonConvert.DeserializeObject<List<TradVolumeDto>>(json);

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

                SetGridHeader2();
            }
        }


        private string BuildQueryString(TradInfoSearchModel model)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            var query = HttpUtility.ParseQueryString(string.Empty);

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            //query["sido"] = model.Sido;
            if (!string.IsNullOrEmpty(model.Sido))
            {
                query["sido"] = model.Sido;
            }

            if (!string.IsNullOrEmpty(model.Year))
            {
                query["year"] = model.Year;
            }

            //query["startYearMonth"] = model.StartYearMonth;
            //query["endYearMonth"] = model.EndYearMonth;

            return query.ToString();
        }

        private void SetGridHeader()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables 
            //-------------------------------------------------------------------------------------------
            dataGridView1.Columns["sido"].HeaderText = "시도";

            dataGridView1.Columns["sigungu"].Visible = false;
            dataGridView1.Columns["dong"].Visible = false;

            dataGridView1.Columns["y2023"].HeaderText = "2023년";
            dataGridView1.Columns["y2024"].HeaderText = "2024년";
            dataGridView1.Columns["y2025"].HeaderText = "2025년";
            dataGridView1.Columns["y2026"].HeaderText = "2026년";

            dataGridView1.Columns["m01"].HeaderText = "1월";
            dataGridView1.Columns["m02"].HeaderText = "2월";
            dataGridView1.Columns["m03"].HeaderText = "3월";
            dataGridView1.Columns["m04"].HeaderText = "4월";
            dataGridView1.Columns["m05"].HeaderText = "5월";
            dataGridView1.Columns["m06"].HeaderText = "6월";
            dataGridView1.Columns["m07"].HeaderText = "7월";
            dataGridView1.Columns["m08"].HeaderText = "8월";
            dataGridView1.Columns["m09"].HeaderText = "9월";
            dataGridView1.Columns["m10"].HeaderText = "10월";
            dataGridView1.Columns["m11"].HeaderText = "11월";
            dataGridView1.Columns["m12"].HeaderText = "12월";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            if (rdoBtnYear.Checked)
            {
                dataGridView1.Columns["y2023"].Visible = true;
                dataGridView1.Columns["y2024"].Visible = true;
                dataGridView1.Columns["y2025"].Visible = true;
                dataGridView1.Columns["y2026"].Visible = true;

                dataGridView1.Columns["m01"].Visible = false;
                dataGridView1.Columns["m02"].Visible = false;
                dataGridView1.Columns["m03"].Visible = false;
                dataGridView1.Columns["m04"].Visible = false;
                dataGridView1.Columns["m05"].Visible = false;
                dataGridView1.Columns["m06"].Visible = false;
                dataGridView1.Columns["m07"].Visible = false;
                dataGridView1.Columns["m08"].Visible = false;
                dataGridView1.Columns["m09"].Visible = false;
                dataGridView1.Columns["m10"].Visible = false;
                dataGridView1.Columns["m11"].Visible = false;
                dataGridView1.Columns["m12"].Visible = false;
            }
            else
            {
                dataGridView1.Columns["y2023"].Visible = false;
                dataGridView1.Columns["y2024"].Visible = false;
                dataGridView1.Columns["y2025"].Visible = false;
                dataGridView1.Columns["y2026"].Visible = false;

                dataGridView1.Columns["m01"].Visible = true;
                dataGridView1.Columns["m02"].Visible = true;
                dataGridView1.Columns["m03"].Visible = true;
                dataGridView1.Columns["m04"].Visible = true;
                dataGridView1.Columns["m05"].Visible = true;
                dataGridView1.Columns["m06"].Visible = true;
                dataGridView1.Columns["m07"].Visible = true;
                dataGridView1.Columns["m08"].Visible = true;
                dataGridView1.Columns["m09"].Visible = true;
                dataGridView1.Columns["m10"].Visible = true;
                dataGridView1.Columns["m11"].Visible = true;
                dataGridView1.Columns["m12"].Visible = true;
            }
        }

        private void SetGridHeader2()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables 
            //-------------------------------------------------------------------------------------------
            dataGridView2.Columns["sido"].HeaderText = "시도";
            dataGridView2.Columns["sigungu"].HeaderText = "시군구";

            dataGridView2.Columns["dong"].Visible = false;

            dataGridView2.Columns["y2023"].HeaderText = "2023년";
            dataGridView2.Columns["y2024"].HeaderText = "2024년";
            dataGridView2.Columns["y2025"].HeaderText = "2025년";
            dataGridView2.Columns["y2026"].HeaderText = "2026년";

            dataGridView2.Columns["m01"].HeaderText = "1월";
            dataGridView2.Columns["m02"].HeaderText = "2월";
            dataGridView2.Columns["m03"].HeaderText = "3월";
            dataGridView2.Columns["m04"].HeaderText = "4월";
            dataGridView2.Columns["m05"].HeaderText = "5월";
            dataGridView2.Columns["m06"].HeaderText = "6월";
            dataGridView2.Columns["m07"].HeaderText = "7월";
            dataGridView2.Columns["m08"].HeaderText = "8월";
            dataGridView2.Columns["m09"].HeaderText = "9월";
            dataGridView2.Columns["m10"].HeaderText = "10월";
            dataGridView2.Columns["m11"].HeaderText = "11월";
            dataGridView2.Columns["m12"].HeaderText = "12월";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            if (rdoBtnYear.Checked)
            {
                dataGridView2.Columns["y2023"].Visible = true;
                dataGridView2.Columns["y2024"].Visible = true;
                dataGridView2.Columns["y2025"].Visible = true;
                dataGridView2.Columns["y2026"].Visible = true;

                dataGridView2.Columns["m01"].Visible = false;
                dataGridView2.Columns["m02"].Visible = false;
                dataGridView2.Columns["m03"].Visible = false;
                dataGridView2.Columns["m04"].Visible = false;
                dataGridView2.Columns["m05"].Visible = false;
                dataGridView2.Columns["m06"].Visible = false;
                dataGridView2.Columns["m07"].Visible = false;
                dataGridView2.Columns["m08"].Visible = false;
                dataGridView2.Columns["m09"].Visible = false;
                dataGridView2.Columns["m10"].Visible = false;
                dataGridView2.Columns["m11"].Visible = false;
                dataGridView2.Columns["m12"].Visible = false;
            }
            else
            {
                dataGridView2.Columns["y2023"].Visible = false;
                dataGridView2.Columns["y2024"].Visible = false;
                dataGridView2.Columns["y2025"].Visible = false;
                dataGridView2.Columns["y2026"].Visible = false;

                dataGridView2.Columns["m01"].Visible = true;
                dataGridView2.Columns["m02"].Visible = true;
                dataGridView2.Columns["m03"].Visible = true;
                dataGridView2.Columns["m04"].Visible = true;
                dataGridView2.Columns["m05"].Visible = true;
                dataGridView2.Columns["m06"].Visible = true;
                dataGridView2.Columns["m07"].Visible = true;
                dataGridView2.Columns["m08"].Visible = true;
                dataGridView2.Columns["m09"].Visible = true;
                dataGridView2.Columns["m10"].Visible = true;
                dataGridView2.Columns["m11"].Visible = true;
                dataGridView2.Columns["m12"].Visible = true;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 헤더 클릭 시 예외 처리 및 유효한 행인지 검사
            if (e.RowIndex >= 0)
            {
                // '시군구' 컬럼의 인덱스 또는 컬럼명을 지정합니다. (여기서는 컬럼명이 "sigungu"라고 가정)
                string sigunguValue = dataGridView2.Rows[e.RowIndex].Cells["sigungu"].Value?.ToString();

                //// 선택한 행의 시군구 값이 '관악구'인지 확인
                //if (sigunguValue == "관악구")
                //{
                //    MessageBox.Show("관악구", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                MessageBox.Show(sigunguValue);
            }
        }
    }
}