using Accessibility;
using CeDev.Models;
using CeDev.Models.BaseMng;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace CeDev.DataMng
{
    public partial class TDashBoard : Form
    {
        private string _currYear = string.Empty;
        private string _currMon = string.Empty;
        private string _today = string.Empty;

        private string catagory = string.Empty;

        private List<string> daylist = new List<string>();
        private List<string> weeklist = new List<string>();
        private List<string> monlist = new List<string>();

        List<LotItem> _lotlist = new List<LotItem>();

        List<DetailItem> _dayDetailList = new List<DetailItem>();
        List<DetailItem> _weekDetailList = new List<DetailItem>();
        List<DetailItem> _monDetailList = new List<DetailItem>();
        List<DetailItem> _yearDetailList = new List<DetailItem>();
        List<DetailItem> _targetDetailList = new List<DetailItem>();

        List<SummaryItem> totalSummaryList = new List<SummaryItem>();

        private List<SummaryItem> _daySummaryList = new List<SummaryItem>();
        private List<SummaryItem> _weekSummaryList = new List<SummaryItem>();
        private List<SummaryItem> _monSummaryList = new List<SummaryItem>();
        private List<SummaryItem> _yearSummaryList = new List<SummaryItem>();
        private List<SummaryItem> _targetSummaryList = new List<SummaryItem>();

        public TDashBoard()
        {
            InitializeComponent();
            InitEvents();
            InitControls();
        }

        private void InitEvents()
        {
            stackChart.MouseClick += StackChart_MouseClick;
            detailChart.MouseClick += DetailChart_MouseClick;
        }

        private void InitControls()
        {
            gridLot.Visible = false;
            gridDay.Visible = false;
            gridWeek.Visible = false;
            gridMonth.Visible = false;

            //await GetPuInfo();
            //await GetWaveInfo();
            //await GetSectInfo();
            //SetSeries();

            //------------------------------------------------------------------------
            //파장 콤보 설정
            //------------------------------------------------------------------------
            cboWave.DataSource = null;
            cboWave.Items.Clear();

            cboWave.Items.Add("ALL");
            cboWave.Items.Add("EUV");
            cboWave.Items.Add("Arf_I");
            cboWave.Items.Add("Arf_F");

            cboWave.SelectedIndex = 0;
        }

        private async void SeriesMng_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------------------------------
            //Declare and initialize variables
            //-----------------------------------------------------------------------
            SetDayInfo();
            await GetSectInfo();
            await GetLotInfo();

            //-----------------------------------------------------------------------
            //Processing 
            //-----------------------------------------------------------------------
            SetSeriesStackChart();
            SetSeriesDetailChart();

            DrawStackChart();
        }

        private void SetDayInfo()
        {
            //================================================================================================
            //Declare and initialize variables 
            //================================================================================================
            //List<string> daylist = new List<string>();
            //List<string> weeklist = new List<string>();
            //List<string> monlist = new List<string>();

            //condYear = DateTime.Now.Year.ToString();
            _currYear = DateTime.Now.ToString("yyyy");

            //_currMon = DateTime.Now.ToString("yyyyMMdd").Substring(4, 2);
            _currMon = "07";

            //_today = DateTime.Now.ToString("yyyyMMdd");
            _today = "20260718";

            //-----------------------------------------------------------------------------
            //(1).한달치 날짜 정보
            //-----------------------------------------------------------------------------
            DateTime today = DateTime.Today;

            //for (int i = 1; i <= 30; i++)
            //{
            //    DateTime targetDay = today.AddDays(-i);
            //    daylist.Add(targetDay.ToString("yyyyMMdd"));
            //}

            for (int i = 1; i <= 30; i++)
            {
                DateTime targetDay = today.AddDays(-i);
                daylist.Add(targetDay.ToString("yyyyMMdd"));
            }

            daylist.Reverse();

            //-----------------------------------------------------------------------------
            //(2).올해 부터 현재 까지 주차
            //-----------------------------------------------------------------------------
            int currYear = today.Year;
            CultureInfo culture = CultureInfo.CurrentCulture;
            Calendar calendar = culture.Calendar;

            DateTime startDate = new DateTime(currYear, 1, 1);

            while (startDate <= today)
            {
                // ISO 8601 표준 규격으로 주차 계산
                int weekNumber = calendar.GetWeekOfYear(
                    startDate,
                    CalendarWeekRule.FirstFourDayWeek, // 목요일 포함 기준 (ISO 8601)
                    DayOfWeek.Sunday                  // 월요일 시작 기준
                );

                // "WW01", "WW02" 형태로 포맷팅 (2자리 고정)
                string weekString = $"WW{weekNumber:D2}";

                // 리스트에 중복되지 않은 주차만 추가
                if (!weeklist.Contains(weekString))
                {
                    weeklist.Add(weekString);
                }

                // 다음 날로 이동
                startDate = startDate.AddDays(1);
            }

            //-----------------------------------------------------------------------------
            //(3).올해 ~ 현재 월까지
            //-----------------------------------------------------------------------------
            int currMonth = DateTime.Today.Month;

            for (int i = 1; i <= currMonth; i++)
            {
                monlist.Add($"{i:D2}월");
                //monlist.Add($"{i:D2}");
            }
        }

        private void StackChart_MouseClick(object? sender, MouseEventArgs e)
        {
            // 클릭한 위치의 요소를 테스트합니다.
            HitTestResult result = stackChart.HitTest(e.X, e.Y);

            // 클릭한 곳이 데이터 포인트(막대)인 경우에만 실행합니다.
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int pointIndex = result.PointIndex;
                Series selectedSeries = result.Series;
                string axisLabel = selectedSeries.Points[pointIndex].AxisLabel;

                switch (axisLabel)
                {
                    case "전일":
                        ShowDetailChart(axisLabel);
                        break;

                    case "금주":
                        ShowDetailChart(axisLabel);
                        break;

                    case "금월":
                        ShowDetailChart(axisLabel);
                        break;

                    case "연누적":
                        ClearSubChart();
                        break;

                    case "목표":
                        ClearSubChart();
                        break;

                    default:
                        MessageBox.Show("없다");
                        break;
                }

                catagory = axisLabel;
            }
        }

        private void ClearSubChart()
        {
            foreach (var series in detailChart.Series)
            {
                series.Points.Clear();
            }

            chartSite.Series.Clear();
            chartEquip.Series.Clear();
            chartTech.Series.Clear();
        }



        private void DetailChart_MouseClick(object? sender, MouseEventArgs e)
        {
            // 클릭한 위치의 요소를 테스트합니다.
            HitTestResult result = detailChart.HitTest(e.X, e.Y);

            // 클릭한 곳이 데이터 포인트(막대)인 경우에만 실행합니다.
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int pointIndex = result.PointIndex;
                Series selectedSeries = result.Series;
                string axisLabel = selectedSeries.Points[pointIndex].AxisLabel;

                //MessageBox.Show(axisLabel);

                switch (catagory)
                {
                    case "전일":
                        {
                            //ShowPieChart(chartSite, axisLabel);
                            //ShowPieChart(chartTech, axisLabel);

                            ShowPieChartByGruop_Day(chartSite, "SITE", axisLabel);
                            ShowPieChartByGruop_Day(chartEquip, "EQUIP", axisLabel);
                            ShowPieChartByGruop_Day(chartTech, "TECH", axisLabel);
                        }
                        break;

                    case "금주":
                        ////MessageBox.Show(axisLabel);
                        //ShowDetailChart(axisLabel);

                        ShowPieChartByGruop_Week(chartSite, "SITE", axisLabel);
                        ShowPieChartByGruop_Week(chartEquip, "EQUIP", axisLabel);
                        ShowPieChartByGruop_Week(chartTech, "TECH", axisLabel);

                        break;

                    case "금월":
                        ////MessageBox.Show(axisLabel);
                        //ShowDetailChart(axisLabel);

                        ShowPieChartByGruop_Mon(chartSite, "SITE", axisLabel);
                        ShowPieChartByGruop_Mon(chartEquip, "EQUIP", axisLabel);
                        ShowPieChartByGruop_Mon(chartTech, "TECH", axisLabel);

                        break;

                    default:
                        MessageBox.Show("없다");
                        break;
                }
            }
        }

        private void ShowDetailChart(string pKind)
        {
            //================================================================================================
            //Declare and initialize variables 
            //================================================================================================
            foreach (var series in detailChart.Series)
            {
                series.Points.Clear();
            }

            //================================================================================================
            //Processing
            //================================================================================================
            switch (pKind)
            {
                case "전일":
                    {
                        ShowDetailChart_Day();
                    }
                    break;

                case "금주":
                    {
                        ShowDetailChart_Week();
                    }
                    break;

                case "금월":
                    {
                        ShowDetailChart_Month();
                    }
                    break;

                default:
                    MessageBox.Show("상세차트 그릴 수 없다");
                    break;
            }
        }

        private void ShowPieChart(Chart pChart, string pKey)
        {
            //================================================================================================
            //Declare and initialize variables 
            //================================================================================================
            //foreach (var series in pChart.Series)
            //{
            //    series.Points.Clear();
            //}





            //================================================================================================
            //Processing
            //================================================================================================
            switch (catagory)
            {
                case "전일":
                    {
                        //ShowPieChart_Site(pKey);

                        ShowPieChartByGruop_Day(chartSite, "SITE", pKey);
                        ShowPieChartByGruop_Day(chartEquip, "EQUIP", pKey);
                        ShowPieChartByGruop_Day(chartTech, "TECH", pKey);
                    }
                    break;

                case "금주":
                    {
                        ShowDetailChart_Week();

                        //ShowPieChartByGruop_Week(chartSite, "SITE", pKey);
                    }
                    break;

                case "금월":
                    {
                        //ShowDetailChart_Month();
                    }
                    break;

                default:
                    MessageBox.Show("상세차트 그릴 수 없다");
                    break;
            }
        }


        private void DrawStackChart2()
        {
            //--------------------------------------------------------------------------------------------------------------------------
            //Declare and initialize variables 
            //--------------------------------------------------------------------------------------------------------------------------
            foreach (var series in stackChart.Series)
            {
                series.Points.Clear();
            }

            //total
            double dayTotal = 0;
            double weekTotal = 0;
            double monTotal = 0;
            double yearTotal = 0;
            double targetTotal = 0;

            //--------------------------------------------------------------------------------------------------------------------------
            //Processing
            //--------------------------------------------------------------------------------------------------------------------------
            List<ChartDataRow> list = FetchWorkResultFromDB();

            foreach (var stackItem in stackChart.Series)
            {
                if (stackItem.Name == "ToTal") continue;

                foreach (var item in list)
                {
                    switch (item.Gubun)
                    {
                        case "전일":
                            {
                                if (stackItem.Name == item.SectNm)
                                {
                                    int index = stackItem.Points.AddXY(0, item.Val);
                                    stackItem.Points[index].AxisLabel = "전일";

                                    dayTotal += item.Val;
                                }
                            }
                            break;

                        case "금주":
                            {
                                if (stackItem.Name == item.SectNm)
                                {
                                    int index = stackItem.Points.AddXY(1, item.Val);
                                    stackItem.Points[index].AxisLabel = "금주";

                                    weekTotal += item.Val;
                                }
                            }
                            break;


                        case "금월":
                            {
                                if (stackItem.Name == item.SectNm)
                                {
                                    int index = stackItem.Points.AddXY(2, item.Val);
                                    stackItem.Points[index].AxisLabel = "금월";

                                    monTotal += item.Val;
                                }
                            }
                            break;

                        case "연누적":
                            {
                                if (stackItem.Name == item.SectNm)
                                {
                                    int index = stackItem.Points.AddXY(3, item.Val);
                                    stackItem.Points[index].AxisLabel = "연누적";

                                    yearTotal += item.Val;
                                }
                            }
                            break;

                        case "목표":
                            {
                                if (stackItem.Name == item.SectNm)
                                {
                                    int index = stackItem.Points.AddXY(4, item.Val);
                                    stackItem.Points[index].AxisLabel = "목표";

                                    targetTotal += item.Val;
                                }
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------
            // ⭐ [핵심 추가] ToTal 시리즈에 5개 행의 자리를 만들어주고, 전일 위치에 합계 값 넣기
            //--------------------------------------------------------------------------------------------------------------------------
            var totalSeries = stackChart.Series["ToTal"];
            if (totalSeries != null)
            {
                // 1. 차트 레이아웃의 데이터 순서(0=전일, 1=주별...)와 동일하게 0점을 잡아 포인트 배열을 생성합니다.
                int idx0 = totalSeries.Points.AddXY(0, 0); // 전일 행
                int idx1 = totalSeries.Points.AddXY(1, 0); // 주별 행
                int idx2 = totalSeries.Points.AddXY(2, 0); // 월별 행
                int idx3 = totalSeries.Points.AddXY(3, 0); // 연누적 행
                int idx4 = totalSeries.Points.AddXY(4, 0); // 목표 행

                //totalSeries.Color = System.Drawing.Color.Transparent;
                totalSeries["BarLabelStyle"] = "Left";

                totalSeries.Points[idx0].Label = "      " + dayTotal.ToString();
                totalSeries.Points[idx1].Label = "      " + weekTotal.ToString();
                totalSeries.Points[idx2].Label = "      " + monTotal.ToString();
                totalSeries.Points[idx3].Label = "      " + yearTotal.ToString();
                totalSeries.Points[idx4].Label = "      " + targetTotal.ToString();
            }

            totalSeries.LabelFormat = "#";

            //totalSeries.BackColor = System.Drawing.Color.White;

            //--------------------------------------------------------------------------------------------------------------------------
            //Output
            //--------------------------------------------------------------------------------------------------------------------------
            stackChart.ChartAreas[0].AxisX.IsReversed = true;
            //stackChart.Series[0].IsValueShownAsLabel = true;

            //stackChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        }

        private void DrawStackChart()
        {
            //--------------------------------------------------------------------------------------------------------------------------
            //Declare and initialize variables 
            //--------------------------------------------------------------------------------------------------------------------------
            foreach (var series in stackChart.Series)
            {
                series.Points.Clear();
            }

            //total
            double dayTotal = 0;
            double weekTotal = 0;
            double monTotal = 0;
            double yearTotal = 0;
            double targetTotal = 0;

            //--------------------------------------------------------------------------------------------------------------------------
            //Processing
            //--------------------------------------------------------------------------------------------------------------------------            
            foreach (var stackItem in stackChart.Series)
            {
                if (stackItem.Name == "ToTal") continue;

                foreach (var item in totalSummaryList)
                {
                    double currVal = 0;

                    switch (stackItem.Name)
                    {
                        case "PG In":
                            currVal = item.vPgIn;
                            break;
                        case "노광":
                            currVal = item.vNoGwang;
                            break;
                        case "1st A":
                            currVal = item.v1stA;
                            break;
                        case "1st B":
                            currVal = item.v1stB;
                            break;
                        case "2nd":
                            currVal = item.v2nd;
                            break;
                        case "추가":
                            currVal = item.vAdd;
                            break;
                        default:
                            break;
                    }

                    switch (item.catagory)
                    {
                        case "전일":
                            {
                                int index = stackItem.Points.AddXY(0, currVal);
                                stackItem.Points[index].AxisLabel = "전일";

                                dayTotal += currVal;
                            }
                            break;

                        case "금주":
                            {
                                int index = stackItem.Points.AddXY(1, currVal);
                                stackItem.Points[index].AxisLabel = "금주";

                                weekTotal += currVal;
                            }
                            break;


                        case "금월":
                            {
                                int index = stackItem.Points.AddXY(2, currVal);
                                stackItem.Points[index].AxisLabel = "금월";

                                monTotal += currVal;
                            }
                            break;

                        case "연누적":
                            {
                                int index = stackItem.Points.AddXY(3, currVal);
                                stackItem.Points[index].AxisLabel = "연누적";

                                yearTotal += currVal;
                            }
                            break;

                        case "목표":
                            {
                                int index = stackItem.Points.AddXY(4, currVal);
                                stackItem.Points[index].AxisLabel = "목표";

                                targetTotal += currVal;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------
            // ⭐ [핵심 추가] ToTal 시리즈에 5개 행의 자리를 만들어주고, 전일 위치에 합계 값 넣기
            //--------------------------------------------------------------------------------------------------------------------------
            var totalSeries = stackChart.Series["ToTal"];
            if (totalSeries != null)
            {
                // 1. 차트 레이아웃의 데이터 순서(0=전일, 1=주별...)와 동일하게 0점을 잡아 포인트 배열을 생성합니다.
                int idx0 = totalSeries.Points.AddXY(0, 0); // 전일 행
                int idx1 = totalSeries.Points.AddXY(1, 0); // 주별 행
                int idx2 = totalSeries.Points.AddXY(2, 0); // 월별 행
                int idx3 = totalSeries.Points.AddXY(3, 0); // 연누적 행
                int idx4 = totalSeries.Points.AddXY(4, 0); // 목표 행

                //totalSeries.Color = System.Drawing.Color.Transparent;
                totalSeries["BarLabelStyle"] = "Left";

                totalSeries.Points[idx0].Label = "      " + dayTotal.ToString();
                totalSeries.Points[idx1].Label = "      " + weekTotal.ToString();
                totalSeries.Points[idx2].Label = "      " + monTotal.ToString();
                totalSeries.Points[idx3].Label = "      " + yearTotal.ToString();
                totalSeries.Points[idx4].Label = "      " + targetTotal.ToString();

            }

            totalSeries.LabelFormat = "#";
            //totalSeries.BackColor = System.Drawing.Color.White;

            //totalSeries.Points[idx4].Label = "      " + targetTotal.ToString();

            //--------------------------------------------------------------------------------------------------------------------------
            //Output
            //--------------------------------------------------------------------------------------------------------------------------
            stackChart.ChartAreas[0].AxisX.IsReversed = true;
            //stackChart.Series[0].IsValueShownAsLabel = true;
        }

        private void SetSeriesStackChart()
        {
            //---------------------------------------------------------------------------------------------------
            //Declare and initialize variables
            //---------------------------------------------------------------------------------------------------
            var list = gridSection.DataSource as List<SectItem>;

            //---------------------------------------------------------------------------------------------------
            //Processing 
            //---------------------------------------------------------------------------------------------------
            stackChart.Series.Clear();

            foreach (var item in list)
            {
                Series series = new Series(item.Nm);
                series.ChartType = SeriesChartType.StackedBar;

                series.IsValueShownAsLabel = true;
                stackChart.Series.Add(series);
            }


            //총계값 보여줄 - Total series 추가 
            var addSeries = new Series("ToTal");
            addSeries.ChartType = SeriesChartType.StackedBar;
            //addSeries.IsValueShownAsLabel = true;
            addSeries.IsVisibleInLegend = false;

            stackChart.Series.Add(addSeries);

            //---------------------------------------------------------------------------------------------------
            //Output
            //---------------------------------------------------------------------------------------------------
            SetSeriesColor(stackChart, true);
        }



        private void SetSeriesDetailChart()
        {
            //---------------------------------------------------------------------------------------------------
            //Declare and initialize variables
            //---------------------------------------------------------------------------------------------------
            var list = gridSection.DataSource as List<SectItem>;
            var r_list = list.AsEnumerable().Reverse().ToList();

            //---------------------------------------------------------------------------------------------------
            //Processing 
            //---------------------------------------------------------------------------------------------------
            detailChart.Series.Clear();

            //foreach (var item in list)
            foreach (var item in r_list)
            {
                Series series = new Series(item.Nm);
                series.ChartType = SeriesChartType.StackedColumn;

                detailChart.Series.Add(series);
            }

            //---------------------------------------------------------------------------------------------------
            //Output
            //---------------------------------------------------------------------------------------------------
            SetSeriesColor(detailChart, false);
        }


        private void SetSeriesColor(Chart pChart, bool pAsc)
        {
            Color[] customColors = new Color[]
            {
                Color.FromArgb(65, 140, 240),   // PG In (밝은 파랑)
                Color.FromArgb(252, 180, 65),   // 노광 (노랑/주황)
                Color.FromArgb(224, 64, 10),    // 1st A (다홍/빨강)
                Color.FromArgb(14, 93, 149),    // 1st B (바다색/청록)
                Color.FromArgb(193, 193, 193),  // 2nd (회색)
                Color.FromArgb(29, 57, 106)     // 추가 (진한 남색)
            };

            //int i = 0;



            //foreach (var item in pChart.Series)
            //{
            //    item.Color = customColors[i];
            //    i++;
            //}

            int cnt = pChart.Series.Count;

            if (pAsc)
            {
                //int cnt = pChart.Series.Count;

                for (int i = 0; i < cnt; i++)
                {
                    //pChart.Series[i].Color = customColors[i];
                    pChart.Series[i].Color = customColors[i % customColors.Length];
                }
            }
            else
            {
                int colorIndex = 0;
                //int cnt = pChart.Series.Count;

                for (int i = cnt - 1; i >= 0; i--)
                {
                    //pChart.Series[i].Color = customColors[i];

                    pChart.Series[i].Color = customColors[colorIndex % customColors.Length];
                    //pChart.Series[i].Color = customColors[i - 1];
                    colorIndex++; // 색상 인덱스는 0부터 차례대로 증가시킵니다.
                }
            }


        }

        //foreach (var series in detailChart.Series)
        //{
        //    series.Points.Clear();
        //}

        //detailChart.Series[0].Points.AddXY(0, daylist[0]);
        //detailChart.Series[0].Points.AddXY(1, daylist[1]);
        //detailChart.Series[0].Points.AddXY(1, daylist[2]);

        private void ShowPieChart_Site(string pKey)
        {
            //----------------------------------------------------------------------------------------------
            //Declare and initialize variables 
            //----------------------------------------------------------------------------------------------
            chartSite.Series.Clear();

            //var list = _lotlist
            //          .Where(x => x.StdDt == pKey)
            //          .Select(x => x.SiteNm)
            //          .Distinct()
            //          .ToList();

            //foreach (var item in list)
            //{
            //    Series series = new Series(item);
            //    series.ChartType = SeriesChartType.StackedColumn;

            //    chartSite.Series.Add(series);
            //}

            Series pieSeries = new Series("SiteRatio");
            pieSeries.ChartType = SeriesChartType.Pie;
            pieSeries.IsValueShownAsLabel = true; // 라벨 표시 활성화
            chartSite.Series.Add(pieSeries);

            //----------------------------------------------------------------------------------------------
            //Processing
            //----------------------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------
            // 2. 데이터 가공 및 개수 집계 (Processing)
            //----------------------------------------------------------------------------------------------
            // 해당 날짜(pKey)의 전체 데이터 개수(총합)를 구합니다.
            double totalCount = _lotlist.Count(x => x.StdDt == pKey);

            // 해당 날짜의 데이터를 사이트별로 그룹화하여 각각의 개수를 구합니다.
            var siteDataList = _lotlist
                              .Where(x => x.StdDt == pKey)
                              .GroupBy(g => g.SiteNm)
                              .Select(g => new
                              {
                                  SiteNm = g.Key,
                                  RowCount = g.Count() // 💡 vPgIn 대신 데이터 개수를 셉니다.
                              })
                              .ToList();

            //----------------------------------------------------------------------------------------------
            // 3. 차트에 데이터 주입
            //----------------------------------------------------------------------------------------------
            foreach (var data in siteDataList)
            {
                // 차트 조각의 비율 크기를 결정하기 위해 개수(RowCount)를 주입합니다.
                int index = pieSeries.Points.AddXY(data.SiteNm, data.RowCount);

                // 백분율(%) 계산 (현재 사이트 데이터 개수 / 전체 데이터 개수 * 100)
                double percentage = totalCount > 0 ? (data.RowCount / totalCount) * 100 : 0.0;

                //// 우측 범례(Legend)에 사이트명 표시
                //pieSeries.Points[index].LegendText = data.SiteNm;

                // 파이 조각 내부에 백분율 표기 (예: "청주\n(35.5%)")
                //pieSeries.Points[index].Label = $"{data.SiteNm}\n({Math.Round(percentage, 1)}%)";
                pieSeries.Points[index].Label = $"{data.SiteNm}";
            }
        }

        private void ShowPieChartByGruop_Day(Chart pChart, string pGrpVal, string pKey)
        {
            //=================================================================================================================================
            //Declare and initialize variables 
            //=================================================================================================================================
            pChart.Series.Clear();

            Series pieSeries = new Series("SiteRatio");
            pieSeries.ChartType = SeriesChartType.Pie;
            pieSeries.IsValueShownAsLabel = true; // 라벨 표시 활성화
            pChart.Series.Add(pieSeries);

            Func<LotItem, string> grpSel = pGrpVal switch
            {
                "SITE" => x => x.SiteNm,
                "EQUIP" => x => x.EquipNm,
                "TECH" => x => x.TechNm,
                _ => x => x.Site,
            };

            //=================================================================================================================================
            //Processing
            //=================================================================================================================================
            double totalCount = _lotlist.Count(x => x.StdDt == pKey);
            var dateList = _lotlist
                              .Where(x => x.StdDt == pKey)
                              .GroupBy(grpSel)
                              .Select(g => new
                              {
                                  GrpNm = g.Key,
                                  RowCount = g.Count(),
                                  Ratio = totalCount > 0 ? (g.Count() / totalCount) * 100 : 0
                              })
                              .ToList();


            //=================================================================================================================================
            //Output
            //=================================================================================================================================
            foreach (var data in dateList)
            {
                int index = pieSeries.Points.AddXY(data.GrpNm, data.RowCount);
                double percentage = totalCount > 0 ? (data.RowCount / totalCount) * 100 : 0.0;

                //pieSeries.Points[index].Label = $"{data.GrpNm}";
                //pieSeries.Points[index].Label = $"{data.GrpNm}" + "_" + data.Ratio.ToString() + "%";
                pieSeries.Points[index].Label = $"{data.GrpNm}" + "_" + data.RowCount.ToString();
            }
        }

        private void ShowPieChartByGruop_Week(Chart pChart, string pGrpVal, string pKey)
        {
            //=================================================================================================================================
            //Declare and initialize variables 
            //=================================================================================================================================
            pChart.Series.Clear();

            Series pieSeries = new Series("SiteRatio");
            pieSeries.ChartType = SeriesChartType.Pie;
            pieSeries.IsValueShownAsLabel = true; // 라벨 표시 활성화
            pChart.Series.Add(pieSeries);

            Func<LotItem, string> grpSel = pGrpVal switch
            {
                "SITE" => x => x.SiteNm,
                "EQUIP" => x => x.EquipNm,
                "TECH" => x => x.TechNm,
                _ => x => x.Site,
            };

            //=================================================================================================================================
            //Processing
            //=================================================================================================================================
            string startOfThisYear = DateTime.Today.ToString("yyyy0101");

            Calendar cal = CultureInfo.InvariantCulture.Calendar;
            CalendarWeekRule rule = CalendarWeekRule.FirstFourDayWeek;
            DayOfWeek firstDay = DayOfWeek.Sunday;

            var dayInWeeklist = _lotlist
                            .Where(x => string.Compare(x.StdDt, startOfThisYear) >= 0)
                            .Select(x =>
                            {
                                var parsedDate = DateTime.ParseExact(x.StdDt, "yyyyMMdd", CultureInfo.InvariantCulture);
                                return new
                                {
                                    Item = x,
                                    WeekKey = $"WW{cal.GetWeekOfYear(parsedDate, rule, firstDay):D2}"
                                };
                            })
                            .Where(x => x.WeekKey == pKey)
                            .Select(x => x.Item)
                            .ToList();

            double totalCount = dayInWeeklist.Count();

            var dateList = dayInWeeklist
                              .GroupBy(grpSel)
                              .Select(g => new
                              {
                                  GrpNm = g.Key,
                                  RowCount = g.Count(),
                                  Ratio = totalCount > 0 ? (g.Count() / totalCount) * 100 : 0
                              })
                              .ToList();

            //=================================================================================================================================
            //Output
            //=================================================================================================================================
            foreach (var data in dateList)
            {
                int index = pieSeries.Points.AddXY(data.GrpNm, data.RowCount);
                double percentage = totalCount > 0 ? (data.RowCount / totalCount) * 100 : 0.0;

                //pieSeries.Points[index].Label = $"{data.GrpNm}";
                //pieSeries.Points[index].Label = $"{data.GrpNm}" + "_" + data.Ratio.ToString() + "%";
                pieSeries.Points[index].Label = $"{data.GrpNm}" + "_" + data.RowCount.ToString();
            }
        }

        private void ShowPieChartByGruop_Mon(Chart pChart, string pGrpVal, string pKey)
        {
            //=================================================================================================================================
            //Declare and initialize variables 
            //=================================================================================================================================
            pChart.Series.Clear();

            Series pieSeries = new Series("SiteRatio");
            pieSeries.ChartType = SeriesChartType.Pie;
            pieSeries.IsValueShownAsLabel = true; // 라벨 표시 활성화
            pChart.Series.Add(pieSeries);

            Func<LotItem, string> grpSel = pGrpVal switch
            {
                "SITE" => x => x.SiteNm,
                "EQUIP" => x => x.EquipNm,
                "TECH" => x => x.TechNm,
                _ => x => x.Site,
            };

            //=================================================================================================================================
            //Processing
            //=================================================================================================================================
            string startOfThisYear = DateTime.Today.ToString("yyyy0101");

            var dayInMonthlist = _lotlist
                                    .Where(x => string.Compare(x.StdDt, startOfThisYear) >= 0)
                                    .Select(x => new
                                    {
                                        MonthKey = x.StdDt.Substring(4, 2), // "yyyyMMdd"에서 MM 추출
                                        Item = x
                                    })
                                    .Where(x => x.MonthKey == pKey)
                                    .Select(x => x.Item)
                                    .ToList();


            double totalCount = dayInMonthlist.Count();

            var dateList = dayInMonthlist
                              .GroupBy(grpSel)
                              .Select(g => new
                              {
                                  GrpNm = g.Key,
                                  RowCount = g.Count(),
                                  Ratio = totalCount > 0 ? (g.Count() / totalCount) * 100 : 0
                              })
                              .ToList();

            //=================================================================================================================================
            //Output
            //=================================================================================================================================
            foreach (var data in dateList)
            {
                int index = pieSeries.Points.AddXY(data.GrpNm, data.RowCount);
                double percentage = totalCount > 0 ? (data.RowCount / totalCount) * 100 : 0.0;

                //pieSeries.Points[index].Label = $"{data.GrpNm}";
                //pieSeries.Points[index].Label = $"{data.GrpNm}" + "_" + data.Ratio.ToString() + "%";
                pieSeries.Points[index].Label = $"{data.GrpNm}" + "_" + data.RowCount.ToString();
            }
        }

        private void ShowDetailChart_Day()
        {
            double val = 0;

            foreach (var seriesItem in detailChart.Series)
            {
                for (int i = 0; i < _dayDetailList.Count; i++)
                {
                    switch (seriesItem.Name)
                    {
                        case "PG In":
                            {
                                val = _dayDetailList[i].vPgIn;
                            }
                            break;

                        case "Ebeam":
                            {
                                val = _dayDetailList[i].vNoGwang;
                            }
                            break;

                        case "1st":
                            {
                                double avg = _dayDetailList[i].v1stA + _dayDetailList[i].v1stB / 2.0;
                            }
                            break;

                        case "2nd":
                            {
                                val = _dayDetailList[i].v2nd;
                            }
                            break;

                        case "Add":
                            {
                                val = _dayDetailList[i].vAdd;
                            }
                            break;
                    }

                    int index = seriesItem.Points.AddXY(i, val);
                    seriesItem.Points[index].AxisLabel = _dayDetailList[i].kind;
                }
            }

            detailChart.ChartAreas[0].AxisX.Interval = 1;
            detailChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
        }

        private void ShowDetailChart_Week()
        {
            double val = 0;

            foreach (var seriesItem in detailChart.Series)
            {
                for (int i = 0; i < _weekDetailList.Count; i++)
                {
                    switch (seriesItem.Name)
                    {
                        case "PG In":
                            {
                                val = _weekDetailList[i].vPgIn;
                            }
                            break;

                        case "Ebeam":
                            {
                                val = _weekDetailList[i].vNoGwang;
                            }
                            break;

                        case "1st":
                            {
                                double avg = _weekDetailList[i].v1stA + _weekDetailList[i].v1stB / 2.0;
                            }
                            break;

                        case "2nd":
                            {
                                val = _weekDetailList[i].v2nd;
                            }
                            break;

                        case "Add":
                            {
                                val = _weekDetailList[i].vAdd;
                            }
                            break;
                    }

                    int index = seriesItem.Points.AddXY(i, val);
                    seriesItem.Points[index].AxisLabel = _weekDetailList[i].kind;
                }
            }

            detailChart.ChartAreas[0].AxisX.Interval = 1;
            detailChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
        }

        private void ShowDetailChart_Month()
        {
            double val = 0;

            foreach (var seriesItem in detailChart.Series)
            {

                for (int i = 0; i < _monDetailList.Count; i++)
                {
                    switch (seriesItem.Name)
                    {
                        case "PG In":
                            {
                                val = _monDetailList[i].vPgIn;
                            }
                            break;

                        case "Ebeam":
                            {
                                val = _monDetailList[i].vNoGwang;
                            }
                            break;

                        case "1st":
                            {
                                double avg = _monDetailList[i].v1stA + _monDetailList[i].v1stB / 2.0;
                            }
                            break;

                        case "2nd":
                            {
                                val = _monDetailList[i].v2nd;
                            }
                            break;

                        case "Add":
                            {
                                val = _monDetailList[i].vAdd;
                            }
                            break;
                    }

                    int index = seriesItem.Points.AddXY(i, val);
                    seriesItem.Points[index].AxisLabel = _monDetailList[i].kind;
                }

                //if(12 - _monDetailList.Count > 0)
                //{ 
                //    var remaCnt = 12 - _monDetailList.Count;
                //    var startMon = _monDetailList.Count + 1;

                //    for(int i = 0; i < remaCnt; i++)
                //    {
                //        int index2 = seriesItem.Points.AddXY(startMon + (i - 1) , 0);
                //        seriesItem.Points[index2].AxisLabel = (startMon + i).ToString("D2") ;
                //    }
                //}

                if (12 - _monDetailList.Count > 0)
                {
                    var remaCnt = 12 - _monDetailList.Count;
                    var startMon = _monDetailList.Count + 1;

                    for (int i = 0; i < remaCnt; i++)
                    {
                        int index2 = seriesItem.Points.AddXY(seriesItem.Points.Count, 0);
                        seriesItem.Points[index2].AxisLabel = (startMon + i).ToString("D2");
                    }
                }
            }

            detailChart.ChartAreas[0].AxisX.Interval = 1;
            detailChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DrawStackChart();
        }


        private async Task GetSectInfo()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            SectSearchModel model = new SectSearchModel();

            //string year = txtYear.Text.Trim();
            //model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();

            string baseUrl = "http://localhost:9081/api/basemng-section-info";

            //string queryString = BuildQueryString(model);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            //query["sido"] = model.Sido;
            //query["sigungu"] = model.Sigungu;

            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------            
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            List<SectItem> list = JsonConvert.DeserializeObject<List<SectItem>>(json);

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------            
            if (list == null || list.Count == 0)
            {
                gridSection.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridSection.DataSource = list;
        }

        private async Task GetLotInfo()
        {
            //===============================================================================================================================
            // Declare and initialize variables
            //===============================================================================================================================
            LotSearchModel model = new LotSearchModel();

            //string year = txtYear.Text.Trim();
            //model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();

            string baseUrl = "http://localhost:9081/api/basemng-lot-info";

            //string queryString = BuildQueryString(model);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            //query["sido"] = model.Sido;
            //query["sigungu"] = model.Sigungu;

            string url = $"{baseUrl}?{queryString}";

            //===============================================================================================================================
            // Processing
            //===============================================================================================================================
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);

            //List<LotItem> list = JsonConvert.DeserializeObject<List<LotItem>>(json);
            List<LotItem> list = JsonConvert.DeserializeObject<List<LotItem>>(json);

            //===============================================================================================================================
            // Output
            //===============================================================================================================================
            if (list == null || list.Count == 0)
            {
                gridLot.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridLot.DataSource = list;

            _lotlist = list.ToList();

            ShowKpiYieldInfo();
            ShowKpiTatInfo();
            ShowShipRateIn10();

            MakeDataList();
        }

        private void ShowKpiTatInfo()
        {
            //-----------------------------------------------------------------------------------------------------------------
            //Declare and initialize variables
            //-----------------------------------------------------------------------------------------------------------------
            var tatlist = _lotlist
                            .Select(x =>
                            {
                                var totalTat = (x.vPgIn ?? 0.0)
                                                + (x.vNoGwang ?? 0.0)

                                                + (x.v1stA ?? 0.0)
                                                + (x.v1stA2 ?? 0.0)
                                                + (x.v1stB ?? 0.0)
                                                + (x.v1stB2 ?? 0.0)

                                                + (x.v2nd ?? 0.0)
                                                + (x.vAdd ?? 0.0);

                                return new
                                {
                                    tat = Math.Round(totalTat, 2),
                                    Item = x
                                };

                            }).ToList();

            //-----------------------------------------------------------------------------------------------------------------
            //Processing
            //-----------------------------------------------------------------------------------------------------------------
            //파장(wave) - 코드 정보
            //EUV       --01
            //Arf_I     --02 
            //Arf_F     --03

            //var totalCnt = tatlist.Count;
            //var euvCnt = tatlist.Count(x => x.Item.Wave == "01");
            //var arf_I_Cnt = tatlist.Count(x => x.Item.Wave == "02");
            //var arf_F_Cnt = tatlist.Count(x => x.Item.Wave == "03");

            //var dfdfeg = euvCnt + arf_I_Cnt + arf_F_Cnt;

            var euvTat = Math.Round(tatlist.Where(x => x.Item.Wave == "01").Average(x => x.tat), 2);
            var arf_I_Tat = Math.Round(tatlist.Where(x => x.Item.Wave == "02").Average(x => x.tat), 2);
            var arf_F_Tat = Math.Round(tatlist.Where(x => x.Item.Wave == "03").Average(x => x.tat), 2);

            //-----------------------------------------------------------------------------------------------------------------
            //Output
            //-----------------------------------------------------------------------------------------------------------------
            lblEuv_Tat.Text = $"{euvTat:F2}";
            lblArf_I_Tat.Text = $"{arf_I_Tat:F2}";
            lblArf_F_Tat.Text = $"{arf_F_Tat:F2}";
        }

        private void ShowKpiYieldInfo()
        {
            //-----------------------------------------------------------------------------------------------------------------
            //Declare and initialize variables
            //-----------------------------------------------------------------------------------------------------------------
            var totalCnt = _lotlist.ToList().Count;
            var goodCnt = _lotlist.Where(x => x.LotInfo == "정품").ToList().Count;
            var defectCnt = _lotlist.Where(x => x.LotInfo != "정품").ToList().Count;

            //파장(wave) - 코드 정보
            //EUV       --01
            //Arf_I     --02 
            //Arf_F     --03

            var euv_Cnt = _lotlist.Where(x => x.Wave == "01").ToList().Count;
            var euv_goodCnt = _lotlist.Where(x => x.LotInfo == "정품" && x.Wave == "01").ToList().Count;
            var euv_defectCnt = _lotlist.Where(x => x.LotInfo != "정품" && x.Wave == "01").ToList().Count;

            var arf_I_Cnt = _lotlist.Where(x => x.Wave == "02").ToList().Count;
            var arf_I_goodCnt = _lotlist.Where(x => x.LotInfo == "정품" && x.Wave == "02").ToList().Count;
            var arf_I_defectCnt = _lotlist.Where(x => x.LotInfo != "정품" && x.Wave == "02").ToList().Count;

            var arf_F_Cnt = _lotlist.Where(x => x.Wave == "03").ToList().Count;
            var arf_F_goodCnt = _lotlist.Where(x => x.LotInfo == "정품" && x.Wave == "03").ToList().Count;
            var arf_F_defectCnt = _lotlist.Where(x => x.LotInfo != "정품" && x.Wave == "03").ToList().Count;

            //-----------------------------------------------------------------------------------------------------------------
            //Processing
            //-----------------------------------------------------------------------------------------------------------------
            double euvYield = 0;
            double arf_I_Yield = 0;
            double arf_F_Yield = 0;


            euvYield = Math.Round(((double)euv_goodCnt / euv_Cnt) * 100, 2);
            arf_I_Yield = Math.Round(((double)arf_I_goodCnt / arf_I_Cnt) * 100, 2);
            arf_F_Yield = Math.Round(((double)arf_F_goodCnt / arf_F_Cnt) * 100, 2);

            //var ccc = "333";

            //-----------------------------------------------------------------------------------------------------------------
            //Output
            //-----------------------------------------------------------------------------------------------------------------
            lblEuvYield.Text = euvYield.ToString() + "%";
            lblArf_I_Yield.Text = arf_I_Yield.ToString() + "%";
            lblArf_F_Yield.Text = arf_F_Yield.ToString() + "%";
            
        }

        private void ShowShipRateIn10()
        {
            //-----------------------------------------------------------------------------------------------------------------
            //Declare and initialize variables
            //-----------------------------------------------------------------------------------------------------------------
            var totalCnt = _lotlist.ToList().Count;
            //var goodCnt = _lotlist.Where(x => x.LotInfo == "정품").ToList().Count;
            //var defectCnt = _lotlist.Where(x => x.LotInfo != "정품").ToList().Count;

            //var outCnt = _lotlist.Where(x => x.End != null).ToList();
            var tatlist = _lotlist
                         .Select(x =>
                         {
                             var totalTat = (x.vPgIn ?? 0.0)
                                            + (x.vNoGwang ?? 0.0)

                                            + (x.v1stA ?? 0.0)
                                            + (x.v1stA2 ?? 0.0)
                                            + (x.v1stB ?? 0.0)
                                            + (x.v1stB2 ?? 0.0)

                                            + (x.v2nd ?? 0.0)
                                            + (x.vAdd ?? 0.0);

                             return new
                             {
                                 tat = totalTat,
                                 Item = x
                             };
                         })
                         .ToList();
                         //.Where(x => x.Item.End != null).ToList();

            var dfdf = "333";



            ////파장(wave) - 코드 정보
            ////EUV       --01
            ////Arf_I     --02 
            ////Arf_F     --03


            var all_total = tatlist.Where(x => x.Item.End != null).ToList();            
            var all_In = all_total.Where(x => x.tat <= 1.8).ToList();
            var all_Over = all_total.Where(x => x.tat > 1.8).ToList();

            var euv_total = all_total.Where(x => x.Item.Wave == "01").ToList();
            var euv_In = all_total.Where(x => x.Item.Wave == "01" &&  x.tat <= 1.8).ToList();
            var euv_Over = all_total.Where(x => x.Item.Wave == "01" && x.tat > 1.8).ToList();

            var arf_I_total = all_total.Where(x => x.Item.Wave == "02").ToList();
            var arf_I_In = all_total.Where(x => x.Item.Wave == "02" && x.tat <= 1.8).ToList();
            var arf_I_Over = all_total.Where(x => x.Item.Wave == "02" && x.tat > 1.8).ToList();

            var arf_F_total = all_total.Where(x => x.Item.Wave == "03").ToList();
            var arf_F_In = all_total.Where(x => x.Item.Wave == "03" && x.tat <= 1.8).ToList();
            var arf_F_Over = all_total.Where(x => x.Item.Wave == "03" && x.tat > 1.8).ToList();

            //-----------------------------------------------------------------------------------------------------------------
            //Processing
            //-----------------------------------------------------------------------------------------------------------------
            double allShipIn = 0;
            double euvShipIn = 0;
            double arf_I_ShipIn = 0;
            double arf_F_ShipIn = 0;

            double allShipOver = 0;
            double euvShipOver = 0;
            double arf_I_ShipOver = 0;
            double arf_F_ShipOver = 0;

            allShipIn = Math.Round(((double)all_In.Count / all_total.Count) * 100, 2);            
            euvShipIn = Math.Round(((double)euv_In.Count / euv_total.Count) * 100, 2);
            arf_I_ShipIn = Math.Round(((double)arf_I_In.Count / arf_I_total.Count) * 100, 2);
            arf_F_ShipIn = Math.Round(((double)arf_F_In.Count / arf_F_total.Count) * 100, 2);

            allShipOver = Math.Round(((double)all_Over.Count / all_total.Count) * 100, 2);
            euvShipOver = Math.Round(((double)euv_Over.Count / euv_total.Count) * 100, 2);
            arf_I_ShipOver = Math.Round(((double)arf_I_Over.Count / arf_I_total.Count) * 100, 2);
            arf_F_ShipOver = Math.Round(((double)arf_F_Over.Count / arf_F_total.Count) * 100, 2);

            //-----------------------------------------------------------------------------------------------------------------
            //Output
            //-----------------------------------------------------------------------------------------------------------------
            //if(double.IsNaN(euvShipIn))
            //{
            //    lblEuvShipRateIn10.Text = "";
            //}
            //else
            //{
            //    lblEuvShipRateIn10.Text = euvShipIn + "%";
            //}

            //lblEuvShipRateIn10.Text = euvShipIn + "%";
            //lblArf_IShipRateIn10.Text = arf_I_ShipIn + "%";            
            //lblArf_FShipRateIn10.Text = arf_F_ShipIn + "%";

            //lblEuvShipRateOver10.Text = euvShipOver + "%";
            //lblArf_IShipRateOver10.Text = arf_I_ShipOver + "%";
            //lblArf_FShipRateOver10.Text = arf_F_ShipOver + "%";


            lblEuvShipRateIn10.Text = double.IsNaN(euvShipIn) ? "": $"{euvShipIn}%";
            lblArf_IShipRateIn10.Text = double.IsNaN(arf_I_ShipIn) ? "" : $"{arf_I_ShipIn}%";
            lblArf_FShipRateIn10.Text = double.IsNaN(arf_F_ShipIn) ? "": $"{arf_F_ShipIn}%";

            lblEuvShipRateOver10.Text = double.IsNaN(euvShipOver) ? "" : $"{euvShipOver}%";
            lblArf_IShipRateOver10.Text = double.IsNaN(arf_I_ShipOver) ? "": $"{arf_I_ShipOver}%";
            lblArf_FShipRateOver10.Text = double.IsNaN(arf_F_ShipOver) ? "" : $"{arf_F_ShipOver}%";
        }


        //private void MakeDataList(List<LotItem> list)
        private void MakeDataList()
        {
            //================================================================================================================
            //Declare and initialize variables 
            //================================================================================================================            
            //List<SummaryItem> totalSummaryList = new List<SummaryItem>();

            //DateTime today = DateTime.Today;
            //DateTime yesterday = today.AddDays(-1);
            //DateTime thirtyDaysAgoFromYesterday = yesterday.AddDays(-29);

            //DateTime today = DateTime.Today;
            DateTime yesterday = DateTime.ParseExact(_today, "yyyyMMdd", null).AddDays(-1);
            DateTime thirtyDaysAgoFromYesterday = DateTime.ParseExact(_today, "yyyyMMdd", null).AddDays(-29);




            //================================================================================================================
            // 1. 전일
            //================================================================================================================           

            // -----------------------------------------------------------------------------------------------------
            //  (1-1).detail
            // -----------------------------------------------------------------------------------------------------
            _dayDetailList = _lotlist
                            .Where(x => DateTime.ParseExact(x.StdDt, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture) >= thirtyDaysAgoFromYesterday
                                     && DateTime.ParseExact(x.StdDt, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture) <= yesterday)
                            .GroupBy(x => x.StdDt)
                            .Select(g => new DetailItem
                            {
                                kind = g.Key,
                                vPgIn = Math.Round(g.Average(x => x.vPgIn ?? 0.0), 2),
                                vNoGwang = Math.Round(g.Average(x => x.vNoGwang) ?? 0.0, 2),

                                v1stA = Math.Round(g.Average(x => x.v1stA ?? 0.0), 2),
                                v1stA2 = Math.Round(g.Average(x => x.v1stA2 ?? 0.0), 2),
                                v1stB = Math.Round(g.Average(x => x.v1stB ?? 0.0), 2),
                                v1stB2 = Math.Round(g.Average(x => x.v1stB2 ?? 0.0), 2),

                                v2nd = Math.Round(g.Average(x => x.v2nd ?? 0.0), 2),
                                vAdd = Math.Round(g.Average(x => x.vAdd ?? 0.0), 2)
                            })
                            .ToList();

            //var ddd = "333";

            // -----------------------------------------------------------------------------------------------------
            //  (1-2).summary
            // -----------------------------------------------------------------------------------------------------            
            //SummaryItem summaryRow = new SummaryItem
            //{
            //    catagory = "전일",
            //    vPgIn = Math.Round(_dayDetailList.Average(x => x.vPgIn), 2),
            //    vNoGwang = Math.Round(_dayDetailList.Average(x => x.vNoGwang), 2),

            //    v1stA = Math.Round(_dayDetailList.Average(x => x.v1stA), 2),
            //    v1stA2 = Math.Round(_dayDetailList.Average(x => x.v1stA2), 2),
            //    v1stB = Math.Round(_dayDetailList.Average(x => x.v1stB), 2),
            //    v1stB2 = Math.Round(_dayDetailList.Average(x => x.v1stB2), 2),

            //    v2nd = Math.Round(_dayDetailList.Average(x => x.v2nd), 2),
            //    vAdd = Math.Round(_dayDetailList.Average(x => x.vAdd), 2)
            //};

            var summaryRow = _dayDetailList
                             .Where(x => DateTime.ParseExact(x.kind, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture) == yesterday)
                             .GroupBy(x => x.kind)
                             .Select(g => new SummaryItem
                             {
                                 catagory = "전일",
                                 vPgIn = Math.Round(g.Average(x => x.vPgIn), 2),
                                 vNoGwang = Math.Round(g.Average(x => x.vNoGwang), 2),

                                 v1stA = Math.Round(g.Average(x => x.v1stA), 2),
                                 v1stA2 = Math.Round(g.Average(x => x.v1stA2), 2),
                                 v1stB = Math.Round(g.Average(x => x.v1stB), 2),
                                 v1stB2 = Math.Round(g.Average(x => x.v1stB2), 2),

                                 v2nd = Math.Round(g.Average(x => x.v2nd), 2),
                                 vAdd = Math.Round(g.Average(x => x.vAdd), 2)
                             })
                             .FirstOrDefault();

            totalSummaryList.Add(summaryRow);


            //================================================================================================================
            // 2. 금주
            //================================================================================================================           
            string startOfThisYear = DateTime.Today.ToString("yyyy0101");

            Calendar cal = CultureInfo.InvariantCulture.Calendar;
            CalendarWeekRule rule = CalendarWeekRule.FirstFourDayWeek;
            DayOfWeek firstDay = DayOfWeek.Sunday;


            _weekDetailList = _lotlist
                              .Where(x => string.Compare(x.StdDt, startOfThisYear) >= 0)
                              .Select(x =>
                              {

                                  var parsedDate = DateTime.ParseExact(x.StdDt, "yyyyMMdd", CultureInfo.InvariantCulture);
                                  int weekNum = cal.GetWeekOfYear(parsedDate, rule, firstDay);

                                  // [보정] 1월인데 53주차로 계산된다면 올해의 1주차(WW01)로 강제 매핑합니다.
                                  if (weekNum == 53 && parsedDate.Month == 1)
                                  {
                                      weekNum = 1;
                                  }

                                  return new
                                  {
                                      Item = x,
                                      WeekKey = $"WW{weekNum:D2}"
                                  };
                              })
                              .GroupBy(x => x.WeekKey)
                              .Select(g => new DetailItem
                              {
                                  kind = g.Key,
                                  vPgIn = Math.Round(g.Average(x => x.Item.vPgIn ?? 0.0), 2),
                                  vNoGwang = Math.Round(g.Average(x => x.Item.vNoGwang ?? 0.0), 2),
                                  v1stA = Math.Round(g.Average(x => x.Item.v1stA ?? 0.0), 2),
                                  v1stA2 = Math.Round(g.Average(x => x.Item.v1stA2 ?? 0.0), 2),
                                  v1stB = Math.Round(g.Average(x => x.Item.v1stB ?? 0.0), 2),
                                  v1stB2 = Math.Round(g.Average(x => x.Item.v1stB2 ?? 0.0), 2),
                                  v2nd = Math.Round(g.Average(x => x.Item.v2nd ?? 0.0), 2),
                                  vAdd = Math.Round(g.Average(x => x.Item.vAdd ?? 0.0), 2)
                              })
                              .ToList();

            //var dfeg = "333";

            var _weekDetailList2 = _lotlist
                              .Where(x => string.Compare(x.StdDt, startOfThisYear) >= 0)
                              .GroupBy(x => 
                              {

                                  var parsedDate = DateTime.ParseExact(x.StdDt, "yyyyMMdd", CultureInfo.InvariantCulture);
                                  int weekNum = cal.GetWeekOfYear(parsedDate, rule, firstDay);

                                  // [보정] 1월인데 53주차로 계산된다면 올해의 1주차(WW01)로 강제 매핑합니다.
                                  if (weekNum == 53 && parsedDate.Month == 1)
                                  {
                                      weekNum = 1;
                                  }

                                  //return new
                                  //{
                                  //    //weekKey = weekNum,
                                  //    weekKey = $"WW{weekNum:D2}"
                                  //};

                                  //return weekNum;
                                  return $"WW{weekNum:D2}";


                              })
                              .Select(gg => new DetailItem
                              {
                                  //kind = gg.Key.weekKey.ToString(),
                                  kind = gg.Key.ToString(),
                                  vPgIn = Math.Round(gg.Average(x => x.vPgIn ?? 0.0), 2),
                                  vNoGwang = Math.Round(gg.Average(x => x.vNoGwang ?? 0.0), 2),
                                  v1stA = Math.Round(gg.Average(x => x.v1stA ?? 0.0), 2),
                                  v1stA2 = Math.Round(gg.Average(x => x.v1stA2 ?? 0.0), 2),
                                  v1stB = Math.Round(gg.Average(x => x.v1stB ?? 0.0), 2),
                                  v1stB2 = Math.Round(gg.Average(x => x.v1stB2 ?? 0.0), 2),
                                  v2nd = Math.Round(gg.Average(x => x.v2nd ?? 0.0), 2),
                                  vAdd = Math.Round(gg.Average(x => x.vAdd ?? 0.0), 2)
                              })
                              .ToList();


            //var dfeg2 = "333";





            // -----------------------------------------------------------------------------------------------------
            //  summary
            // -----------------------------------------------------------------------------------------------------


            //summaryRow = new SummaryItem
            //{
            //    catagory = "금주",
            //    vPgIn = Math.Round(_weekDetailList.Average(x => x.vPgIn), 2),
            //    vNoGwang = Math.Round(_weekDetailList.Average(x => x.vNoGwang), 2),

            //    v1stA = Math.Round(_weekDetailList.Average(x => x.v1stA), 2),
            //    v1stA2 = Math.Round(_weekDetailList.Average(x => x.v1stA2), 2),
            //    v1stB = Math.Round(_weekDetailList.Average(x => x.v1stB), 2),
            //    v1stB2 = Math.Round(_weekDetailList.Average(x => x.v1stB2), 2),

            //    v2nd = Math.Round(_weekDetailList.Average(x => x.v2nd), 2),
            //    vAdd = Math.Round(_weekDetailList.Average(x => x.vAdd), 2)
            //};

            int weekNumber = cal.GetWeekOfYear(DateTime.ParseExact(_today, "yyyyMMdd", CultureInfo.InvariantCulture), rule, firstDay);
            string currentWW = $"WW{weekNumber:D2}";

            summaryRow = _weekDetailList
                        .Where(x => x.kind == currentWW)
                        .GroupBy(x => x.kind)
                        .Select(g => new SummaryItem
                        {
                            catagory = "금주",
                            vPgIn = Math.Round(g.Average(x => x.vPgIn), 2),
                            vNoGwang = Math.Round(g.Average(x => x.vNoGwang), 2),

                            v1stA = Math.Round(g.Average(x => x.v1stA), 2),
                            v1stA2 = Math.Round(g.Average(x => x.v1stA2), 2),
                            v1stB = Math.Round(g.Average(x => x.v1stB), 2),
                            v1stB2 = Math.Round(g.Average(x => x.v1stB2), 2),

                            v2nd = Math.Round(g.Average(x => x.v2nd), 2),
                            vAdd = Math.Round(g.Average(x => x.vAdd), 2)
                        })
                        .FirstOrDefault();

            totalSummaryList.Add(summaryRow);

            //================================================================================================================
            // 3. 금월
            //================================================================================================================
            _monDetailList = _lotlist
                            .Where(x => string.Compare(x.StdDt, startOfThisYear) >= 0)
                            .Select(x => new
                            {
                                MonthKey = x.StdDt.Substring(4, 2),
                                Item = x
                            })
                            .GroupBy(x => x.MonthKey)
                            .OrderBy(g => g.Key)
                            .Select(g => new DetailItem
                            {
                                kind = g.Key,
                                vPgIn = Math.Round(g.Average(x => x.Item.vPgIn ?? 0.0), 2),
                                vNoGwang = Math.Round(g.Average(x => x.Item.vNoGwang) ?? 0.0, 2),

                                v1stA = Math.Round(g.Average(x => x.Item.v1stA ?? 0.0), 2),
                                v1stA2 = Math.Round(g.Average(x => x.Item.v1stA2 ?? 0.0), 2),
                                v1stB = Math.Round(g.Average(x => x.Item.v1stB ?? 0.0), 2),
                                v1stB2 = Math.Round(g.Average(x => x.Item.v1stB2 ?? 0.0), 2),

                                v2nd = Math.Round(g.Average(x => x.Item.v2nd ?? 0.0), 2),
                                vAdd = Math.Round(g.Average(x => x.Item.vAdd ?? 0.0), 2)
                            })
                            .ToList();


            // -----------------------------------------------------------------------------------------------------
            //  summary
            // -----------------------------------------------------------------------------------------------------
            //summaryRow = new SummaryItem
            //{
            //    catagory = "금월",
            //    vPgIn = Math.Round(_monDetailList.Average(x => x.vPgIn), 2),
            //    vNoGwang = Math.Round(_monDetailList.Average(x => x.vNoGwang), 2),

            //    v1stA = Math.Round(_monDetailList.Average(x => x.v1stA), 2),
            //    v1stA2 = Math.Round(_monDetailList.Average(x => x.v1stA2), 2),
            //    v1stB = Math.Round(_monDetailList.Average(x => x.v1stB), 2),
            //    v1stB2 = Math.Round(_monDetailList.Average(x => x.v1stB2), 2),

            //    v2nd = Math.Round(_monDetailList.Average(x => x.v2nd), 2),
            //    vAdd = Math.Round(_monDetailList.Average(x => x.vAdd), 2)
            //};

            summaryRow = _monDetailList
                        .Where(x => x.kind == _currMon)
                        .GroupBy(x => x.kind)
                        .Select(g => new SummaryItem
                        {
                            catagory = "금월",
                            vPgIn = Math.Round(g.Average(x => x.vPgIn), 2),
                            vNoGwang = Math.Round(g.Average(x => x.vNoGwang), 2),

                            v1stA = Math.Round(g.Average(x => x.v1stA), 2),
                            v1stA2 = Math.Round(g.Average(x => x.v1stA2), 2),
                            v1stB = Math.Round(g.Average(x => x.v1stB), 2),
                            v1stB2 = Math.Round(g.Average(x => x.v1stB2), 2),

                            v2nd = Math.Round(g.Average(x => x.v2nd), 2),
                            vAdd = Math.Round(g.Average(x => x.vAdd), 2)
                        })
                        .FirstOrDefault();

            totalSummaryList.Add(summaryRow);

            var ddd7 = "333";


            //================================================================================================================
            // 4. 연누적
            //================================================================================================================
            _yearDetailList = _lotlist
                            .Where(x => string.Compare(x.StdDt, startOfThisYear) >= 0)
                            .Select(x => new
                            {
                                YearKey = x.StdDt.Substring(0, 4),
                                Item = x
                            })
                            .GroupBy(x => x.YearKey)
                            .Select(g => new DetailItem
                            {
                                kind = g.Key,
                                vPgIn = Math.Round(g.Average(x => x.Item.vPgIn ?? 0.0), 2),
                                vNoGwang = Math.Round(g.Average(x => x.Item.vNoGwang) ?? 0.0, 2),

                                v1stA = Math.Round(g.Average(x => x.Item.v1stA ?? 0.0), 2),
                                v1stA2 = Math.Round(g.Average(x => x.Item.v1stA2 ?? 0.0), 2),
                                v1stB = Math.Round(g.Average(x => x.Item.v1stB ?? 0.0), 2),
                                v1stB2 = Math.Round(g.Average(x => x.Item.v1stB2 ?? 0.0), 2),

                                v2nd = Math.Round(g.Average(x => x.Item.v2nd ?? 0.0), 2),
                                vAdd = Math.Round(g.Average(x => x.Item.vAdd ?? 0.0), 2)
                            })
                            .ToList();

            // -----------------------------------------------------------------------------------------------------
            //  summary
            // -----------------------------------------------------------------------------------------------------
            summaryRow = new SummaryItem
            {
                catagory = "연누적",
                vPgIn = Math.Round(_yearDetailList.Average(x => x.vPgIn), 2),
                vNoGwang = Math.Round(_yearDetailList.Average(x => x.vNoGwang), 2),

                v1stA = Math.Round(_yearDetailList.Average(x => x.v1stA), 2),
                v1stA2 = Math.Round(_yearDetailList.Average(x => x.v1stA2), 2),
                v1stB = Math.Round(_yearDetailList.Average(x => x.v1stB), 2),
                v1stB2 = Math.Round(_yearDetailList.Average(x => x.v1stB2), 2),

                v2nd = Math.Round(_yearDetailList.Average(x => x.v2nd), 2),
                vAdd = Math.Round(_yearDetailList.Average(x => x.vAdd), 2)
            };

            totalSummaryList.Add(summaryRow);

            //var ddd = "333";

            //================================================================================================================
            // 5. 목표
            //================================================================================================================
            Random rand = new Random();

            _targetDetailList = _lotlist
                            .Where(x => string.Compare(x.StdDt, startOfThisYear) >= 0)
                            .Select(x => new
                            {
                                YearKey = x.StdDt.Substring(0, 4),
                                Item = x
                            })
                            .GroupBy(x => x.YearKey)
                            //.Select(g => new DetailItem
                            //{
                            //    kind = g.Key,
                            //    vPgIn = Math.Round(g.Average(x => x.Item.vPgIn ?? 0.0), 2),
                            //    vNoGwang = Math.Round(g.Average(x => x.Item.vNoGwang) ?? 0.0, 2),

                            //    v1stA = Math.Round(g.Average(x => x.Item.v1stA ?? 0.0), 2),
                            //    v1stA2 = Math.Round(g.Average(x => x.Item.v1stA2 ?? 0.0), 2),
                            //    v1stB = Math.Round(g.Average(x => x.Item.v1stB ?? 0.0), 2),
                            //    v1stB2 = Math.Round(g.Average(x => x.Item.v1stB2 ?? 0.0), 2),

                            //    v2nd = Math.Round(g.Average(x => x.Item.v2nd ?? 0.0), 2),
                            //    vAdd = Math.Round(g.Average(x => x.Item.vAdd ?? 0.0), 2)
                            //})
                            .Select(g =>
                            {
                                double GetRandomOffset() => (rand.NextDouble() * 0.1) - 0.05;

                                return new DetailItem
                                {
                                    kind = g.Key,
                                    vPgIn = Math.Round(g.Average(x => x.Item.vPgIn ?? 0.0) + GetRandomOffset(), 2),
                                    vNoGwang = Math.Round(g.Average(x => x.Item.vNoGwang ?? 0.0) + GetRandomOffset(), 2),

                                    v1stA = Math.Round(g.Average(x => x.Item.v1stA ?? 0.0) + GetRandomOffset(), 2),
                                    v1stA2 = Math.Round(g.Average(x => x.Item.v1stA2 ?? 0.0) + GetRandomOffset(), 2),
                                    v1stB = Math.Round(g.Average(x => x.Item.v1stB ?? 0.0) + GetRandomOffset(), 2),
                                    v1stB2 = Math.Round(g.Average(x => x.Item.v1stB2 ?? 0.0) + GetRandomOffset(), 2),

                                    v2nd = Math.Round(g.Average(x => x.Item.v2nd ?? 0.0) + GetRandomOffset(), 2),
                                    vAdd = Math.Round(g.Average(x => x.Item.vAdd ?? 0.0) + GetRandomOffset(), 2)
                                };
                            })
                            .ToList();

            // -----------------------------------------------------------------------------------------------------
            //  summary
            // -----------------------------------------------------------------------------------------------------
            summaryRow = new SummaryItem
            {
                catagory = "목표",
                vPgIn = Math.Round(_targetDetailList.Average(x => x.vPgIn), 2),
                vNoGwang = Math.Round(_targetDetailList.Average(x => x.vNoGwang), 2),

                v1stA = Math.Round(_targetDetailList.Average(x => x.v1stA), 2),
                v1stA2 = Math.Round(_targetDetailList.Average(x => x.v1stA2), 2),
                v1stB = Math.Round(_targetDetailList.Average(x => x.v1stB), 2),
                v1stB2 = Math.Round(_targetDetailList.Average(x => x.v1stB2), 2),

                v2nd = Math.Round(_targetDetailList.Average(x => x.v2nd), 2),
                vAdd = Math.Round(_targetDetailList.Average(x => x.vAdd), 2)
            };

            totalSummaryList.Add(summaryRow);

            var ddd = "333";
        }


        private void MakeSummayList(List<LotItem> list)
        {
            //================================================================================================================
            //Declare and initialize variables 
            //================================================================================================================            
            //List<SummaryItem> totalSummaryList = new List<SummaryItem>();

            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);
            DateTime thirtyDaysAgoFromYesterday = yesterday.AddDays(-29);


            //================================================================================================================
            // 1. 전일
            //================================================================================================================
            _daySummaryList = list
               .Where(item =>
               {
                   if (DateTime.TryParseExact(item.StdDt, "yyyyMMdd",
                                              System.Globalization.CultureInfo.InvariantCulture,
                                              System.Globalization.DateTimeStyles.None,
                                              out DateTime itemDate))
                   {
                       return itemDate >= thirtyDaysAgoFromYesterday && itemDate <= yesterday;
                   }
                   return false;
               })
               .Select(item => new
               {
                   // "20260702" -> "2026-07-02" 형태로 날짜 키 생성
                   DateName = DateTime.ParseExact(item.StdDt, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"),
                   Item = item
               })
               .GroupBy(x => x.DateName) // 날짜별로 그룹 묶기
               .Select(g => new SummaryItem
               {
                   // 세부 리스트의 구분 열에는 실제 날짜가 들어감
                   catagory = g.Key,

                   // 해당 날짜의 공정별 평균값 계산
                   vPgIn = Math.Round(g.Average(x => x.Item.vPgIn ?? 0.0), 2),
                   vNoGwang = Math.Round(g.Average(x => x.Item.vNoGwang ?? 0.0), 2),

                   v1stA = Math.Round(g.Average(x => x.Item.v1stA ?? 0.0), 2),
                   v1stA2 = Math.Round(g.Average(x => x.Item.v1stA2 ?? 0.0), 2),
                   v1stB = Math.Round(g.Average(x => x.Item.v1stB ?? 0.0), 2),
                   v1stB2 = Math.Round(g.Average(x => x.Item.v1stB2 ?? 0.0), 2),

                   v2nd = Math.Round(g.Average(x => x.Item.v2nd ?? 0.0), 2),
                   vAdd = Math.Round(g.Average(x => x.Item.vAdd ?? 0.0), 2)
               })
               .OrderBy(r => r.catagory) // 과거 날짜부터 순서대로 정렬
               .ToList();

            // -----------------------------------------------------------------------------------------------------
            // 2. [요약 리스트 가공] 생성된 전일 세부 리스트(daySummaryRows)를 다시 통째로 평균 내어 1행으로 압축
            // -----------------------------------------------------------------------------------------------------
            if (_daySummaryList.Count > 0)
            {
                SummaryItem summaryRow = new SummaryItem
                {
                    // 요약 뷰 마스터 행 타이틀 지정
                    catagory = "전일",

                    // 일별로 마감된 평균값들을 대상으로 최종 전체 평균 연산 (소수점 2자리)
                    vPgIn = Math.Round(_daySummaryList.Average(x => x.vPgIn), 2),
                    vNoGwang = Math.Round(_daySummaryList.Average(x => x.vNoGwang), 2),

                    v1stA = Math.Round(_daySummaryList.Average(x => x.v1stA), 2),
                    v1stA2 = Math.Round(_daySummaryList.Average(x => x.v1stA2), 2),
                    v1stB = Math.Round(_daySummaryList.Average(x => x.v1stB), 2),
                    v1stB2 = Math.Round(_daySummaryList.Average(x => x.v1stB2), 2),

                    v2nd = Math.Round(_daySummaryList.Average(x => x.v2nd), 2),
                    vAdd = Math.Round(_daySummaryList.Average(x => x.vAdd), 2)
                };

                // 요약 마스터 통합 리스트에 단일 행 추가
                totalSummaryList.Add(summaryRow);
            }
            else
            {
                totalSummaryList.Add(new SummaryItem { catagory = "NoData" });
            }

            //// 3. 최종 요약 리스트를 대시보드 마스터 그리드에 바인딩
            //gridDay.DataSource = totalSummaryList;


            //================================================================================================================
            // 2. 금주
            //================================================================================================================
            Calendar cal = CultureInfo.InvariantCulture.Calendar;
            CalendarWeekRule weekRule = CalendarWeekRule.FirstFourDayWeek; // ISO 8601 기준
            DayOfWeek firstDayOfWeek = DayOfWeek.Sunday;

            _weekSummaryList = list
                .Where(item =>
                {
                    // 8자리 날짜 포맷 파싱 검증
                    return DateTime.TryParseExact(item.StdDt, "yyyyMMdd",
                                                   CultureInfo.InvariantCulture,
                                                   DateTimeStyles.None,
                                                   out _);
                })
                .Select(item =>
                {
                    DateTime itemDate = DateTime.ParseExact(item.StdDt, "yyyyMMdd", CultureInfo.InvariantCulture);
                    int weekNum = cal.GetWeekOfYear(itemDate, weekRule, firstDayOfWeek);

                    return new
                    {
                        // "WW01", "WW02" 형태로 2자리 포맷팅
                        WeekName = $"WW{weekNum.ToString("D2")}",
                        Item = item
                    };
                })
                // 올해 주차 범위인 WW01부터 WW29 사이의 데이터만 필터링
                .Where(x => string.Compare(x.WeekName, "WW01") >= 0 && string.Compare(x.WeekName, "WW29") <= 0)
                .GroupBy(x => x.WeekName) // 주차 이름 기준으로 행 그룹 묶기
                .Select(g => new SummaryItem
                {
                    // 1번 열(kind)에 주차 이름 명시 ("WW01", "WW02" 등이 행으로 생성됨)
                    catagory = g.Key,

                    // 해당 주차 내의 모든 행 데이터를 대상으로 각 공정별 평균값 계산
                    vPgIn = Math.Round(g.Average(x => x.Item.vPgIn ?? 0.0), 2),
                    vNoGwang = Math.Round(g.Average(x => x.Item.vNoGwang ?? 0.0), 2),

                    v1stA = Math.Round(g.Average(x => x.Item.v1stA ?? 0.0), 2),
                    v1stA2 = Math.Round(g.Average(x => x.Item.v1stA2 ?? 0.0), 2),
                    v1stB = Math.Round(g.Average(x => x.Item.v1stB ?? 0.0), 2),
                    v1stB2 = Math.Round(g.Average(x => x.Item.v1stB2 ?? 0.0), 2),

                    v2nd = Math.Round(g.Average(x => x.Item.v2nd ?? 0.0), 2),
                    vAdd = Math.Round(g.Average(x => x.Item.vAdd ?? 0.0), 2)
                })
                .OrderBy(r => r.catagory) // WW01부터 순서대로 정렬
                .ToList();


            //-----------------------------------------------------------------------------------------------------
            // 3. 주차별 세부 리스트(weeklySummaryRows)를 바탕으로 하나의 '금주 전체 평균' 행 생성
            //---------------------------------------------------------------------------------------
            if (_weekSummaryList.Count > 0)
            {
                SummaryItem weeklyTotalRow = new SummaryItem
                {
                    // 1번 구분 열 명칭을 "주별 전체 평균" 또는 원하는 타이틀로 지정
                    catagory = "금주",

                    // 주차별(WW01~WW29)로 계산되어 나온 평균값들을 다시 통째로 평균 계산 (소수점 2자리)
                    vPgIn = Math.Round(_weekSummaryList.Average(x => x.vPgIn), 2),
                    vNoGwang = Math.Round(_weekSummaryList.Average(x => x.vNoGwang), 2),

                    v1stA = Math.Round(_weekSummaryList.Average(x => x.v1stA), 2),
                    v1stA2 = Math.Round(_weekSummaryList.Average(x => x.v1stA2), 2),
                    v1stB = Math.Round(_weekSummaryList.Average(x => x.v1stB), 2),
                    v1stB2 = Math.Round(_weekSummaryList.Average(x => x.v1stB2), 2),

                    v2nd = Math.Round(_weekSummaryList.Average(x => x.v2nd), 2),
                    vAdd = Math.Round(_weekSummaryList.Average(x => x.vAdd), 2)
                };

                // 여러 행(AddRange) 대신, 최종 가공된 단 하나의 행만 추가(Add)
                totalSummaryList.Add(weeklyTotalRow);
            }
            else
            {
                totalSummaryList.Add(new SummaryItem { catagory = "금주 데이터 없음" });
            }

            //================================================================================================================
            // 3. 금월
            //================================================================================================================
            _monSummaryList = list
                .Where(item =>
                {
                    // 8자리 날짜 포맷 파싱 검증
                    return DateTime.TryParseExact(item.StdDt, "yyyyMMdd",
                                                   CultureInfo.InvariantCulture,
                                                   DateTimeStyles.None,
                                                   out _);
                })
                .Select(item =>
                {
                    DateTime itemDate = DateTime.ParseExact(item.StdDt, "yyyyMMdd", CultureInfo.InvariantCulture);

                    return new
                    {
                        // "M01", "M02" 형태로 정렬이 깨지지 않게 2자리 포맷팅("D2") 적용
                        MonthName = $"M{itemDate.Month.ToString("D2")}",
                        Item = item
                    };
                })
                .GroupBy(x => x.MonthName) // 월 이름 기준으로 행 그룹 묶기
                .Select(g => new SummaryItem
                {
                    // 세부 리스트의 구분 열에는 월 명칭이 들어감 ("M01", "M02" 등)
                    catagory = g.Key,

                    // 해당 월 내의 모든 데이터를 대상으로 각 공정별 평균값 계산
                    vPgIn = Math.Round(g.Average(x => x.Item.vPgIn ?? 0.0), 2),
                    vNoGwang = Math.Round(g.Average(x => x.Item.vNoGwang ?? 0.0), 2),

                    v1stA = Math.Round(g.Average(x => x.Item.v1stA ?? 0.0), 2),
                    v1stA2 = Math.Round(g.Average(x => x.Item.v1stA2 ?? 0.0), 2),
                    v1stB = Math.Round(g.Average(x => x.Item.v1stB ?? 0.0), 2),
                    v1stB2 = Math.Round(g.Average(x => x.Item.v1stB2 ?? 0.0), 2),

                    v2nd = Math.Round(g.Average(x => x.Item.v2nd ?? 0.0), 2),
                    vAdd = Math.Round(g.Average(x => x.Item.vAdd ?? 0.0), 2)
                })
                .OrderBy(r => r.catagory) // M01부터 순서대로 정렬
                .ToList();


            // -----------------------------------------------------------------------------------------------------
            // 2. [금월 요약 리스트 가공] 생성된 금월 세부 리스트(monthSummaryRows)를 다시 1행으로 압축하여 추가
            // -----------------------------------------------------------------------------------------------------
            if (_monSummaryList.Count > 0)
            {
                SummaryItem monthlyTotalRow = new SummaryItem
                {
                    // 요약 뷰 마스터 행 타이틀 지정
                    catagory = "금월",

                    // 월별로 마감된 평균값들을 대상으로 최종 전체 평균 연산 (소수점 2자리)
                    vPgIn = Math.Round(_monSummaryList.Average(x => x.vPgIn), 2),
                    vNoGwang = Math.Round(_monSummaryList.Average(x => x.vNoGwang), 2),

                    v1stA = Math.Round(_monSummaryList.Average(x => x.v1stA), 2),
                    v1stA2 = Math.Round(_monSummaryList.Average(x => x.v1stA2), 2),
                    v1stB = Math.Round(_monSummaryList.Average(x => x.v1stB), 2),
                    v1stB2 = Math.Round(_monSummaryList.Average(x => x.v1stB2), 2),

                    v2nd = Math.Round(_monSummaryList.Average(x => x.v2nd), 2),
                    vAdd = Math.Round(_monSummaryList.Average(x => x.vAdd), 2)
                };

                // 요약 마스터 통합 리스트의 맨 마지막 자리에 추가
                totalSummaryList.Add(monthlyTotalRow);
            }
            else
            {
                totalSummaryList.Add(new SummaryItem { catagory = "NoDataMon" });
            }

            var ddd = "333";


        }

        private void MakeDetailList(List<LotItem> pList)
        {
            //-----------------------------------------------------------------------------------------------------
            //(1).전일 ~ 30일 전 데이터 필터링 (StdDt 기준)
            //-----------------------------------------------------------------------------------------------------            
            //DateTime today = DateTime.Today;
            //DateTime yesterday = today.AddDays(-1);            
            //DateTime thirtyDaysAgoFromYesterday = yesterday.AddDays(-29);

            //var daySummaryList = list
            //    .Where(item =>
            //    {
            //        if (DateTime.TryParseExact(item.StdDt, "yyyyMMdd",
            //                                   System.Globalization.CultureInfo.InvariantCulture,
            //                                   System.Globalization.DateTimeStyles.None,
            //                                   out DateTime itemDate))
            //        {
            //            return itemDate >= thirtyDaysAgoFromYesterday && itemDate <= yesterday;
            //        }
            //        return false;
            //    })
            //    .Select(item => new
            //    {
            //        DateName = DateTime.ParseExact(item.StdDt, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"),
            //        VPgIn = item.VPgIn ?? 0.0
            //    })
            //    .GroupBy(x => x.DateName)
            //    .Select(g =>
            //    {
            //        int rowCount = g.Count(); // 해당 날짜의 총 행의 개수
            //        double totalSum = g.Sum(x => x.VPgIn); // 해당 날짜의 VPgIn 합산 값

            //        // 행의 개수가 0개일 경우를 대비한 안전 처리 후 평균 계산
            //        double averageVPgIn = rowCount > 0 ? (totalSum / rowCount) : 0.0;

            //        return new
            //        {
            //            Date = g.Key,
            //            // 소수점 2자리까지 반올림 처리
            //            AvgVPgIn = Math.Round(averageVPgIn, 2)
            //        };
            //    })
            //    .OrderBy(r => r.Date)
            //    .ToList();

            //// 평균 계산된 일별 데이터를 그리드에 바인딩
            //gridDay.DataSource = daySummaryList;




            //-----------------------------------------------------------------------------------------------------
            // 2. 주차별 그룹화 및 VPgIn 합산 연산 진행
            //-----------------------------------------------------------------------------------------------------
            //Calendar cal = CultureInfo.InvariantCulture.Calendar;
            //CalendarWeekRule weekRule = CalendarWeekRule.FirstFourDayWeek; // ISO 8601 기준 주차 계산 방식
            //DayOfWeek firstDayOfWeek = DayOfWeek.Monday;

            //var weeklySummaryList = list
            //    .Where(item =>
            //    {
            //        // 8자리 날짜 포맷 파싱 검증
            //        return DateTime.TryParseExact(item.StdDt, "yyyyMMdd",
            //                                       CultureInfo.InvariantCulture,
            //                                       DateTimeStyles.None,
            //                                       out _);
            //    })
            //    .Select(item =>
            //    {
            //        DateTime itemDate = DateTime.ParseExact(item.StdDt, "yyyyMMdd", CultureInfo.InvariantCulture);
            //        // 날짜를 기반으로 해당 년도의 주차(숫자) 구하기
            //        int weekNum = cal.GetWeekOfYear(itemDate, weekRule, firstDayOfWeek);

            //        return new
            //        {
            //            WeekName = $"WW{weekNum}", // "WW1", "WW2" 형식 문자열 생성
            //                                       // null 값 안전 처리 (null일 경우 0.0으로 대체)
            //            VPgIn = item.VPgIn ?? 0.0
            //        };
            //    })
            //    .GroupBy(x => x.WeekName) // 주차 이름(WW1, WW2...) 기준으로 그룹 묶기
            //    .Select(g => new
            //    {
            //        Week = g.Key,
            //        TotalVPgIn = g.Sum(x => x.VPgIn) // 해당 주차의 VPgIn 값 합산(SUM)
            //    })
            //    .OrderBy(r => r.Week) // 주차 순서대로 정렬
            //    .ToList();

            //// 3. 차트나 그리드뷰(gridDay)에 바인딩하여 결과 확인
            //gridWeek.DataSource = weeklySummaryList;

            //-----------------------------------------------------------------------------------------------------
            // 월별 그룹화 및 VPgIn 합산 연산 진행
            //-----------------------------------------------------------------------------------------------------
            //var monthlySummaryList = list
            //    .Where(item =>
            //    {
            //        // 8자리 날짜 포맷 파싱 검증
            //        return DateTime.TryParseExact(item.StdDt, "yyyyMMdd",
            //                                       CultureInfo.InvariantCulture,
            //                                       DateTimeStyles.None,
            //                                       out _);
            //    })
            //    .Select(item =>
            //    {
            //        DateTime itemDate = DateTime.ParseExact(item.StdDt, "yyyyMMdd", CultureInfo.InvariantCulture);

            //        // 날짜에서 월을 추출하여 "M01", "M02" 형태로 포맷팅 (D2는 2자리 정수 채우기)
            //        string monthName = $"M{itemDate.Month.ToString("D2")}";

            //        return new
            //        {
            //            MonthName = monthName,
            //            VPgIn = item.VPgIn ?? 0.0 // null 값 안전 처리
            //        };
            //    })
            //    .GroupBy(x => x.MonthName) // 월 이름(M01, M02...) 기준으로 그룹 묶기
            //    .Select(g => new
            //    {
            //        Month = g.Key,
            //        TotalVPgIn = g.Sum(x => x.VPgIn) // 해당 월의 VPgIn 값 합산(SUM)
            //    })
            //    .OrderBy(r => r.Month) // 월 순서대로 정렬 (M01 -> M12)
            //    .ToList();

            //// 그리드뷰나 차트에 데이터 바인딩
            //gridMonth.DataSource = monthlySummaryList;

            //var ddd = "333";
        }

        // [수정 및 통합] 기존의 Day, Week, Mon 함수를 하나로 통합합니다.
        private void BindChartDataFromDB()
        {
            //-------------------------------------------------------------------------
            // 1. DB 또는 서비스에서 데이터를 리스트(혹은 DataTable)로 긁어옵니다.
            // (여기서는 예시 데이터를 동적으로 생성하지만, 실제로는 DB 쿼리 결과가 들어옵니다.)
            //-------------------------------------------------------------------------
            List<ChartDataRow> dbResultList = FetchWorkResultFromDB(); // 실제 DB 조회 매서드 매핑

            //-------------------------------------------------------------------------
            // 2. "구분(금일/금주/월별)"을 차트의 X축 숫자 좌표(1, 2, 3)로 매핑하기 위한 매커니즘
            //-------------------------------------------------------------------------
            // 이 딕셔너리가 있으면 새로운 구분("분기별" 등)이 추가되어도 하드코딩 수정 없이 확장 가능합니다.
            Dictionary<string, double> gubunToXAxis = new Dictionary<string, double>()
            {
                { "금일", 1.0 },
                { "금주", 2.0 },
                { "금월", 3.0 }
            };

            //-------------------------------------------------------------------------
            // 3. 루프를 돌며 동적으로 데이터를 Series에 주입
            //-------------------------------------------------------------------------
            foreach (var row in dbResultList)
            {
                // DB에 적힌 공정명(SectNm)에 맞는 Series가 이미 차트에 생성되어 있는지 확인
                Series targetSeries = stackChart.Series.FindByName(row.SectNm);

                // 만약 테이블에는 데이터가 있는데 Form_Load 때 생성 안 된 공정이 있다면 동적 생성
                if (targetSeries == null)
                {
                    targetSeries = new Series(row.SectNm);
                    targetSeries.ChartType = SeriesChartType.StackedBar;
                    stackChart.Series.Add(targetSeries);
                }

                // 구분 값("금일" 등)에 해당하는 X축 숫자 좌표(1, 2, 3)를 가져옴
                if (gubunToXAxis.TryGetValue(row.Gubun, out double xAxisValue))
                {
                    // 찾은 Series의 해당 X좌표에 Y값(수치)을 추가
                    targetSeries.Points.AddXY(xAxisValue, row.Val);
                }
            }
        }

        // 가상의 DB 조회 메서드 (실제 개발 시 Repository 또는 ADO.NET/Dapper 코드가 들어갈 자리)
        private List<ChartDataRow> FetchWorkResultFromDB()
        {
            // 실제 환경에서는 "SELECT GUBUN, SECT_NM, VAL FROM WORK_RESULT" 등의 쿼리 실행 구간
            return new List<ChartDataRow>()
            {
                new ChartDataRow { Gubun = "전일", SectNm = "PG In", Val = 5 },
                new ChartDataRow { Gubun = "전일", SectNm = "노광", Val = 2 },
                new ChartDataRow { Gubun = "전일", SectNm = "1st A", Val = 6 },
                new ChartDataRow { Gubun = "전일", SectNm = "1st B", Val = 3 },
                new ChartDataRow { Gubun = "전일", SectNm = "추가", Val = 1 },

                new ChartDataRow { Gubun = "금주", SectNm = "PG In", Val = 2 },
                new ChartDataRow { Gubun = "금주", SectNm = "노광", Val = 1 },
                new ChartDataRow { Gubun = "금주", SectNm = "1st A", Val = 3 },
                new ChartDataRow { Gubun = "금주", SectNm = "1st B", Val = 6 },
                new ChartDataRow { Gubun = "금주", SectNm = "추가", Val = 2 },

                new ChartDataRow { Gubun = "금월", SectNm = "PG In", Val = 3 },
                new ChartDataRow { Gubun = "금월", SectNm = "노광", Val = 2 },
                new ChartDataRow { Gubun = "금월", SectNm = "1st A", Val = 7 },
                new ChartDataRow { Gubun = "금월", SectNm = "1st B", Val = 3 },
                new ChartDataRow { Gubun = "금월", SectNm = "추가", Val = 1 },

                new ChartDataRow { Gubun = "연누적", SectNm = "PG In", Val = 3 },
                new ChartDataRow { Gubun = "연누적", SectNm = "노광", Val = 2 },
                new ChartDataRow { Gubun = "연누적", SectNm = "1st A", Val = 7 },
                new ChartDataRow { Gubun = "연누적", SectNm = "1st B", Val = 3 },
                new ChartDataRow { Gubun = "연누적", SectNm = "추가", Val = 1 },

                new ChartDataRow { Gubun = "목표", SectNm = "PG In", Val = 3 },
                new ChartDataRow { Gubun = "목표", SectNm = "노광", Val = 2 },
                new ChartDataRow { Gubun = "목표", SectNm = "1st A", Val = 7 },
                new ChartDataRow { Gubun = "목표", SectNm = "1st B", Val = 3 },
                new ChartDataRow { Gubun = "목표", SectNm = "추가", Val = 1 }
            };
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    //public class DetailItemComparer : IEqualityComparer<DetailItem>
    //{
    //    public bool Equals(DetailItem x, DetailItem y) => x.kind == y.kind;
    //    public int GetHashCode(DetailItem obj) => obj.kind == null ? 0 : obj.kind.GetHashCode();
    //}
}
