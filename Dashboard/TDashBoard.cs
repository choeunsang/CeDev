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
using System.Runtime.Intrinsics.X86;
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
        private List<string> daylist = new List<string>();
        private List<string> weeklist = new List<string>();
        private List<string> monlist = new List<string>();

        List<SummaryItem> totalSummaryList = new List<SummaryItem>();

        private List<SummaryItem> _daySummaryRows = new List<SummaryItem>();
        private List<SummaryItem> _weeklySummaryRows = new List<SummaryItem>();
        private List<SummaryItem> _monthSummaryRows = new List<SummaryItem>();

        public TDashBoard()
        {            
            InitializeComponent();
            InitEvents();
            InitControls();            
        }

        private void InitEvents()
        {
            stackChart.MouseClick += StackChart_MouseClick;
        }

        private void InitControls()
        {
            //await GetPuInfo();
            //await GetWaveInfo();
            //await GetSectInfo();
            //SetSeries();


            cboWave.DataSource = null;
            cboWave.Items.Clear();

            //cboWave.Items.Add("전체");
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
                    DayOfWeek.Monday                  // 월요일 시작 기준
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
                        //MessageBox.Show(axisLabel);
                        ShowDetailChart(axisLabel);
                        break;

                    case "주별":
                        //MessageBox.Show(axisLabel);
                        ShowDetailChart(axisLabel);
                        break;

                    case "월별":
                        //MessageBox.Show(axisLabel);
                        ShowDetailChart(axisLabel);
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

                        //DrawDetailChart(pKind);
                    }                    
                    break;

                case "주별":
                    {
                        ShowDetailChart_Week();
                        //DrawDetailChart(pKind);
                    }
                    break;

                case "월별":
                    {
                        ShowDetailChart_Month();
                        //DrawDetailChart(pKind);
                    }
                    break;

                default:
                    MessageBox.Show("상세차트 그릴 수 없다");
                    break;
            }
        }

        private void DrawDetailChart(string pKind)
        {
            //--------------------------------------------------------------------------------------------------------------------------
            //Declare and initialize variables 
            //--------------------------------------------------------------------------------------------------------------------------
            foreach (var series in detailChart.Series)
            {
                series.Points.Clear();
            }

            //SetSeriesDetailChart(pKind);

            //--------------------------------------------------------------------------------------------------------------------------
            //Processing
            //--------------------------------------------------------------------------------------------------------------------------
            //BindChartDataFromDB();

            //foreach (Series series in stackChart.Series)
            //{
            //    // 차트에 바인딩된 데이터 개수가 최소 3개 이상인지 안전하게 체크
            //    if (series.Points.Count >= 3)
            //    {
            //        // 데이터가 들어간 순서대로 "전일", "주별", "월별" 라벨을 매칭합니다.
            //        // (BindChartDataFromDB 내부에서 전일->주별->월별 순으로 AddXY 했다고 가정)
            //        series.Points[0].AxisLabel = "전일";
            //        series.Points[1].AxisLabel = "주별";
            //        series.Points[2].AxisLabel = "월별";
            //    }
            //}

            //--------------------------------------------------------------------------------------------------------------------------
            //Output
            //--------------------------------------------------------------------------------------------------------------------------
            //if (stackChart.ChartAreas.Count > 0)
            //{
            //    var axisX = stackChart.ChartAreas[0].AxisX;

            //    axisX.Interval = 1;
            //    axisX.LabelStyle.Interval = 1;

            //    // 정렬 순서 뒤집기 (금일이 위로 가게 하려면 추가, 필요 없다면 주석 처리 가능)
            //    axisX.IsReversed = true;

            //    // 기존 라벨을 깨끗이 비운 후, 1번방과 2번방에 각각 알맞은 간판을 동시에 달아줍니다.
            //    axisX.CustomLabels.Clear();
            //    axisX.CustomLabels.Add(0.5, 1.5, "전일"); // 1번 좌표 구역 이름
            //    axisX.CustomLabels.Add(1.5, 2.5, "주별"); // 2번 좌표 구역 이름
            //    axisX.CustomLabels.Add(2.5, 3.5, "월별"); // 3번 좌표 구역 이름
            //}
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

            //--------------------------------------------------------------------------------------------------------------------------
            //Processing
            //--------------------------------------------------------------------------------------------------------------------------
            //BindChartDataFromDB();

            //foreach (Series series in stackChart.Series)
            //{
            //    // 차트에 바인딩된 데이터 개수가 최소 3개 이상인지 안전하게 체크
            //    if (series.Points.Count >= 3)
            //    {
            //        // 데이터가 들어간 순서대로 "전일", "주별", "월별" 라벨을 매칭합니다.
            //        // (BindChartDataFromDB 내부에서 전일->주별->월별 순으로 AddXY 했다고 가정)
            //        series.Points[0].AxisLabel = "전일";
            //        series.Points[1].AxisLabel = "주별";
            //        series.Points[2].AxisLabel = "월별";
            //    }
            //}

            List<ChartDataRow> list = FetchWorkResultFromDB(); // 실제 DB 조회 매서드 매핑



            //foreach (var stackItem in stackChart.Series)
            //{
            //    double val = new Random().Next(1, 10);

            //    int index = stackItem.Points.AddXY(0, val);
            //    stackItem.Points[index].AxisLabel = ("전일");

            //    index = stackItem.Points.AddXY(1, val);
            //    stackItem.Points[index].AxisLabel = ("주별");

            //    index = stackItem.Points.AddXY(2, val);
            //    stackItem.Points[index].AxisLabel = ("월별");
            //}

            foreach (var stackItem in stackChart.Series)
            {
                foreach (var item in list)
                {
                    switch (item.Gubun)
                    {
                        case "전일":
                            {        
                                if(stackItem.Name == item.SectNm)
                                {
                                    int index = stackItem.Points.AddXY(0, item.Val);
                                    stackItem.Points[index].AxisLabel = "전일";
                                } 
                            }
                            break;

                        case "주별":
                            {
                                if (stackItem.Name == item.SectNm)
                                {
                                    int index = stackItem.Points.AddXY(1, item.Val);
                                    stackItem.Points[index].AxisLabel = "주별";
                                }
                            }
                            break;


                        case "월별":
                            {
                                if (stackItem.Name == item.SectNm)
                                {
                                    int index = stackItem.Points.AddXY(2, item.Val);
                                    stackItem.Points[index].AxisLabel = "월별";
                                }
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            //stackChart.Series[0].Points[0].AxisLabel = "전일";
            //stackChart.Series[0].Points[1].AxisLabel = "전일";
            //stackChart.Series[0].Points[2].AxisLabel = "전일";

            //stackChart.ChartAreas[0].AxisX.Interval = 1;
            //stackChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            stackChart.ChartAreas[0].AxisX.IsReversed = true;

            //foreach (var item in list)
            //{
            //    switch(item.Gubun)
            //    {
            //        case "전일":
            //            {

            //            }
            //            break;

            //        case "주별":
            //            {

            //            }
            //            break;


            //        case "월별":
            //            {

            //            }
            //            break;

            //        default:
            //            break;
            //    }

            //double val = new Random().Next(1, 10);

            //int index = stackItem.Points.AddXY(0, val);
            //stackItem.Points[index].AxisLabel = ("전일");

            //index = stackItem.Points.AddXY(1, val);
            //stackItem.Points[index].AxisLabel = ("주별");

            //index = stackItem.Points.AddXY(2, val);
            //stackItem.Points[index].AxisLabel = ("월별");
            //}

            //int index = stackChart.Series[0].Points.AddXY(0, "5");
            //stackChart.Series[0].Points[index].AxisLabel = "전일";

            //index = stackChart.Series[0].Points.AddXY(1, "5");
            //stackChart.Series[0].Points[index].AxisLabel = "주별";


            //int index = stackChart.Series[0].Points.AddXY(0, "5");
            //stackChart.Series[0].Points[index].AxisLabel = "전일";

            //index = stackChart.Series[0].Points.AddXY(1, "5");
            //stackChart.Series[0].Points[index].AxisLabel = "주별";

            //index = stackChart.Series[0].Points.AddXY(3, "5");
            //stackChart.Series[0].Points[index].AxisLabel = "주별";

            //--------------------------------------------------------------------------------------------------------------------------
            //Output
            //--------------------------------------------------------------------------------------------------------------------------
            //if (stackChart.ChartAreas.Count > 0)
            //{
            //    var axisX = stackChart.ChartAreas[0].AxisX;

            //    axisX.Interval = 1;
            //    axisX.LabelStyle.Interval = 1;

            //    // 정렬 순서 뒤집기 (금일이 위로 가게 하려면 추가, 필요 없다면 주석 처리 가능)
            //    axisX.IsReversed = true;

            //    // 기존 라벨을 깨끗이 비운 후, 1번방과 2번방에 각각 알맞은 간판을 동시에 달아줍니다.
            //    axisX.CustomLabels.Clear();
            //    axisX.CustomLabels.Add(0.5, 1.5, "전일"); // 1번 좌표 구역 이름
            //    axisX.CustomLabels.Add(1.5, 2.5, "주별"); // 2번 좌표 구역 이름
            //    axisX.CustomLabels.Add(2.5, 3.5, "월별"); // 3번 좌표 구역 이름
            //}
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
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
                stackChart.Series.Add(series);
            }
        }

        private void SetSeriesDetailChart()
        {
            //---------------------------------------------------------------------------------------------------
            //Declare and initialize variables
            //---------------------------------------------------------------------------------------------------
            var list = gridSection.DataSource as List<SectItem>;

            //---------------------------------------------------------------------------------------------------
            //Processing 
            //---------------------------------------------------------------------------------------------------
            detailChart.Series.Clear();
            //detailChart.ChartAreas.Clear();

            //ChartArea chartArea = new ChartArea("DetailArea");
            //detailChart.ChartAreas.Add(chartArea);

            foreach (var item in list)
            {
                Series series = new Series(item.Nm);
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;

                detailChart.Series.Add(series);
            }
        }

        //foreach (var series in detailChart.Series)
        //{
        //    series.Points.Clear();
        //}

        //detailChart.Series[0].Points.AddXY(0, daylist[0]);
        //detailChart.Series[0].Points.AddXY(1, daylist[1]);
        //detailChart.Series[0].Points.AddXY(1, daylist[2]);



        private void ShowDetailChart_Day()
        {
            //int index = detailChart.Series[0].Points.AddXY(0, "5");
            //detailChart.Series[0].Points[index].AxisLabel = daylist[0];

            //index = detailChart.Series[0].Points.AddXY(1, "5");
            //detailChart.Series[0].Points[index].AxisLabel = daylist[1];



            //int i = 0;

            //foreach (var item in daylist)
            //{
            //    int index = detailChart.Series[0].Points.AddXY(i, "5");
            //    detailChart.Series[0].Points[index].AxisLabel = item;

            //    i++;
            //}

            //i = 0;

            //foreach (var item in daylist)
            //{
            //    int index = detailChart.Series[1].Points.AddXY(i, "2");
            //    detailChart.Series[1].Points[index].AxisLabel = item;

            //    i++;
            //}

            foreach(var stackItem in detailChart.Series)
            {
                for (int i = 0; i < daylist.Count; i++)
                {
                    double val = new Random().Next(1, 10);

                    //int index = stackItem.Points.AddXY(i, "2");
                    int index = stackItem.Points.AddXY(i, val);

                    stackItem.Points[index].AxisLabel = daylist[i];
                }
            }


            detailChart.ChartAreas[0].AxisX.Interval = 1;
            detailChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //detailChart.ChartAreas[0].AxisX.IsReversed = true;
        }

        private void ShowDetailChart_Week()
        {
            foreach (var stackItem in detailChart.Series)
            {
                for (int i = 0; i < weeklist.Count; i++)
                {
                    double val = new Random().Next(1, 10);

                    //int index = stackItem.Points.AddXY(i, "2");
                    int index = stackItem.Points.AddXY(i, val);

                    stackItem.Points[index].AxisLabel = weeklist[i];
                }
            }


            detailChart.ChartAreas[0].AxisX.Interval = 1;
            detailChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //detailChart.ChartAreas[0].AxisX.IsReversed = true;
        }

        private void ShowDetailChart_Month()
        {
            foreach (var stackItem in detailChart.Series)
            {
                for (int i = 0; i < monlist.Count; i++)
                {
                    double val = new Random().Next(1, 10);

                    //int index = stackItem.Points.AddXY(i, "2");
                    int index = stackItem.Points.AddXY(i, val);

                    stackItem.Points[index].AxisLabel = monlist[i];
                }
            }


            detailChart.ChartAreas[0].AxisX.Interval = 1;
            detailChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //detailChart.ChartAreas[0].AxisX.IsReversed = true;
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

            MakeSummayList(list);
            //MakeDetailList(list);
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
            _daySummaryRows = list
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
                    kind = g.Key,

                    // 해당 날짜의 공정별 평균값 계산
                    vPgIn = Math.Round(g.Average(x => x.Item.VPgIn ?? 0.0), 2),
                    vNoGwang = Math.Round(g.Average(x => x.Item.VNoGwang ?? 0.0), 2),

                    v1stA = Math.Round(g.Average(x => x.Item.V1stA ?? 0.0), 2),
                    v1stA2 = Math.Round(g.Average(x => x.Item.V1stA2 ?? 0.0), 2),
                    v1stB = Math.Round(g.Average(x => x.Item.V1stB ?? 0.0), 2),
                    v1stB2 = Math.Round(g.Average(x => x.Item.V1stB2 ?? 0.0), 2),

                    v2nd = Math.Round(g.Average(x => x.Item.V2nd ?? 0.0), 2),
                    vAdd = Math.Round(g.Average(x => x.Item.VAdd ?? 0.0), 2)
                })
                .OrderBy(r => r.kind) // 과거 날짜부터 순서대로 정렬
                .ToList();

            // -----------------------------------------------------------------------------------------------------
            // 2. [요약 리스트 가공] 생성된 일별 세부 리스트(daySummaryRows)를 다시 통째로 평균 내어 1행으로 압축
            // -----------------------------------------------------------------------------------------------------
            if (_daySummaryRows.Count > 0)
            {
                SummaryItem summaryRow = new SummaryItem
                {
                    // 요약 뷰 마스터 행 타이틀 지정
                    kind = "전일",

                    // 일별로 마감된 평균값들을 대상으로 최종 전체 평균 연산 (소수점 2자리)
                    vPgIn = Math.Round(_daySummaryRows.Average(x => x.vPgIn), 2),
                    vNoGwang = Math.Round(_daySummaryRows.Average(x => x.vNoGwang), 2),

                    v1stA = Math.Round(_daySummaryRows.Average(x => x.v1stA), 2),
                    v1stA2 = Math.Round(_daySummaryRows.Average(x => x.v1stA2), 2),
                    v1stB = Math.Round(_daySummaryRows.Average(x => x.v1stB), 2),
                    v1stB2 = Math.Round(_daySummaryRows.Average(x => x.v1stB2), 2),

                    v2nd = Math.Round(_daySummaryRows.Average(x => x.v2nd), 2),
                    vAdd = Math.Round(_daySummaryRows.Average(x => x.vAdd), 2)
                };

                // 요약 마스터 통합 리스트에 단일 행 추가
                totalSummaryList.Add(summaryRow);
            }
            else
            {
                totalSummaryList.Add(new SummaryItem { kind = "데이터 없음" });
            }

            //// 3. 최종 요약 리스트를 대시보드 마스터 그리드에 바인딩
            //gridDay.DataSource = totalSummaryList;


            //================================================================================================================
            // 2. 주별
            //================================================================================================================
            Calendar cal = CultureInfo.InvariantCulture.Calendar;
            CalendarWeekRule weekRule = CalendarWeekRule.FirstFourDayWeek; // ISO 8601 기준
            DayOfWeek firstDayOfWeek = DayOfWeek.Monday;

            _weeklySummaryRows = list
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
                    kind = g.Key,

                    // 해당 주차 내의 모든 행 데이터를 대상으로 각 공정별 평균값 계산
                    vPgIn = Math.Round(g.Average(x => x.Item.VPgIn ?? 0.0), 2),
                    vNoGwang = Math.Round(g.Average(x => x.Item.VNoGwang ?? 0.0), 2),

                    v1stA = Math.Round(g.Average(x => x.Item.V1stA ?? 0.0), 2),
                    v1stA2 = Math.Round(g.Average(x => x.Item.V1stA2 ?? 0.0), 2),
                    v1stB = Math.Round(g.Average(x => x.Item.V1stB ?? 0.0), 2),
                    v1stB2 = Math.Round(g.Average(x => x.Item.V1stB2 ?? 0.0), 2),

                    v2nd = Math.Round(g.Average(x => x.Item.V2nd ?? 0.0), 2),
                    vAdd = Math.Round(g.Average(x => x.Item.VAdd ?? 0.0), 2)
                })
                .OrderBy(r => r.kind) // WW01부터 순서대로 정렬
                .ToList();


            //-----------------------------------------------------------------------------------------------------
            // 3. 주차별 세부 리스트(weeklySummaryRows)를 바탕으로 하나의 '주별 전체 평균' 행 생성
            //---------------------------------------------------------------------------------------
            if (_weeklySummaryRows.Count > 0)
            {
                SummaryItem weeklyTotalRow = new SummaryItem
                {
                    // 1번 구분 열 명칭을 "주별 전체 평균" 또는 원하는 타이틀로 지정
                    kind = "주별",

                    // 주차별(WW01~WW29)로 계산되어 나온 평균값들을 다시 통째로 평균 계산 (소수점 2자리)
                    vPgIn = Math.Round(_weeklySummaryRows.Average(x => x.vPgIn), 2),
                    vNoGwang = Math.Round(_weeklySummaryRows.Average(x => x.vNoGwang), 2),

                    v1stA = Math.Round(_weeklySummaryRows.Average(x => x.v1stA), 2),
                    v1stA2 = Math.Round(_weeklySummaryRows.Average(x => x.v1stA2), 2),
                    v1stB = Math.Round(_weeklySummaryRows.Average(x => x.v1stB), 2),
                    v1stB2 = Math.Round(_weeklySummaryRows.Average(x => x.v1stB2), 2),

                    v2nd = Math.Round(_weeklySummaryRows.Average(x => x.v2nd), 2),
                    vAdd = Math.Round(_weeklySummaryRows.Average(x => x.vAdd), 2)
                };

                // 여러 행(AddRange) 대신, 최종 가공된 단 하나의 행만 추가(Add)
                totalSummaryList.Add(weeklyTotalRow);
            }
            else
            {
                totalSummaryList.Add(new SummaryItem { kind = "주별 데이터 없음" });
            }

            //================================================================================================================
            // 3. 월별
            //================================================================================================================
            _monthSummaryRows = list
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
                    kind = g.Key,

                    // 해당 월 내의 모든 데이터를 대상으로 각 공정별 평균값 계산
                    vPgIn = Math.Round(g.Average(x => x.Item.VPgIn ?? 0.0), 2),
                    vNoGwang = Math.Round(g.Average(x => x.Item.VNoGwang ?? 0.0), 2),

                    v1stA = Math.Round(g.Average(x => x.Item.V1stA ?? 0.0), 2),
                    v1stA2 = Math.Round(g.Average(x => x.Item.V1stA2 ?? 0.0), 2),
                    v1stB = Math.Round(g.Average(x => x.Item.V1stB ?? 0.0), 2),
                    v1stB2 = Math.Round(g.Average(x => x.Item.V1stB2 ?? 0.0), 2),

                    v2nd = Math.Round(g.Average(x => x.Item.V2nd ?? 0.0), 2),
                    vAdd = Math.Round(g.Average(x => x.Item.VAdd ?? 0.0), 2)
                })
                .OrderBy(r => r.kind) // M01부터 순서대로 정렬
                .ToList();


            // -----------------------------------------------------------------------------------------------------
            // 2. [월별 요약 리스트 가공] 생성된 월별 세부 리스트(monthSummaryRows)를 다시 1행으로 압축하여 추가
            // -----------------------------------------------------------------------------------------------------
            if (_monthSummaryRows.Count > 0)
            {
                SummaryItem monthlyTotalRow = new SummaryItem
                {
                    // 요약 뷰 마스터 행 타이틀 지정
                    kind = "월별",

                    // 월별로 마감된 평균값들을 대상으로 최종 전체 평균 연산 (소수점 2자리)
                    vPgIn = Math.Round(_monthSummaryRows.Average(x => x.vPgIn), 2),
                    vNoGwang = Math.Round(_monthSummaryRows.Average(x => x.vNoGwang), 2),

                    v1stA = Math.Round(_monthSummaryRows.Average(x => x.v1stA), 2),
                    v1stA2 = Math.Round(_monthSummaryRows.Average(x => x.v1stA2), 2),
                    v1stB = Math.Round(_monthSummaryRows.Average(x => x.v1stB), 2),
                    v1stB2 = Math.Round(_monthSummaryRows.Average(x => x.v1stB2), 2),

                    v2nd = Math.Round(_monthSummaryRows.Average(x => x.v2nd), 2),
                    vAdd = Math.Round(_monthSummaryRows.Average(x => x.vAdd), 2)
                };

                // 요약 마스터 통합 리스트의 맨 마지막 자리에 추가
                totalSummaryList.Add(monthlyTotalRow);
            }
            else
            {
                totalSummaryList.Add(new SummaryItem { kind = "월별 데이터 없음" });
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
            // 2. "구분(금일/주별/월별)"을 차트의 X축 숫자 좌표(1, 2, 3)로 매핑하기 위한 매커니즘
            //-------------------------------------------------------------------------
            // 이 딕셔너리가 있으면 새로운 구분("분기별" 등)이 추가되어도 하드코딩 수정 없이 확장 가능합니다.
            Dictionary<string, double> gubunToXAxis = new Dictionary<string, double>()
            {
                { "금일", 1.0 },
                { "주별", 2.0 },
                { "월별", 3.0 }
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

                new ChartDataRow { Gubun = "주별", SectNm = "PG In", Val = 2 },
                new ChartDataRow { Gubun = "주별", SectNm = "노광", Val = 1 },
                new ChartDataRow { Gubun = "주별", SectNm = "1st A", Val = 3 },
                new ChartDataRow { Gubun = "주별", SectNm = "1st B", Val = 6 },
                new ChartDataRow { Gubun = "주별", SectNm = "추가", Val = 2 },

                new ChartDataRow { Gubun = "월별", SectNm = "PG In", Val = 3 },
                new ChartDataRow { Gubun = "월별", SectNm = "노광", Val = 2 },
                new ChartDataRow { Gubun = "월별", SectNm = "1st A", Val = 7 },
                new ChartDataRow { Gubun = "월별", SectNm = "1st B", Val = 3 },
                new ChartDataRow { Gubun = "월별", SectNm = "추가", Val = 1 }


            };
        }


        
    }


}
