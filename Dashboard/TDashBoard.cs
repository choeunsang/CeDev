using CeDev.Models;
using CeDev.Models.BaseMng;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace CeDev.DataMng
{
    public partial class TDashBoard : Form
    {
        public TDashBoard()
        {
            InitializeComponent();
        }

        private async void SeriesMng_Load(object sender, EventArgs e)
        {
            //await GetPuInfo();
            //await GetWaveInfo();
            await GetSectInfo();
            SetSeries();
        }

        private void SetSeries()
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

        private void GetChartData_Day()
        {
            // [수정] 아래 축 설정(CustomLabels) 블록을 완전히 지우고, 순수 데이터 입력만 남깁니다.
            if (stackChart.Series.FindByName("PG In") != null) stackChart.Series["PG In"].Points.AddXY(1, 10);
            if (stackChart.Series.FindByName("노광") != null) stackChart.Series["노광"].Points.AddXY(1, 2);
            if (stackChart.Series.FindByName("1st A") != null) stackChart.Series["1st A"].Points.AddXY(1, 3);
            if (stackChart.Series.FindByName("1st B") != null) stackChart.Series["1st B"].Points.AddXY(1, 4);
            if (stackChart.Series.FindByName("추가") != null) stackChart.Series["추가"].Points.AddXY(1, 7);
        }

        private void GetChartData_Week()
        {
            // [수정] 마찬가지로 아래 축 설정 블록을 완전히 지우고, 2번 좌표에 데이터 입력만 남깁니다.
            if (stackChart.Series.FindByName("PG In") != null) stackChart.Series["PG In"].Points.AddXY(2, 2);
            if (stackChart.Series.FindByName("노광") != null) stackChart.Series["노광"].Points.AddXY(2, 3);
            if (stackChart.Series.FindByName("1st A") != null) stackChart.Series["1st A"].Points.AddXY(2, 4);
            if (stackChart.Series.FindByName("1st B") != null) stackChart.Series["1st B"].Points.AddXY(2, 7);
            if (stackChart.Series.FindByName("추가") != null) stackChart.Series["추가"].Points.AddXY(2, 2);
        }

        private void GetChartData_Mon()
        {
            // [수정] 마찬가지로 아래 축 설정 블록을 완전히 지우고, 2번 좌표에 데이터 입력만 남깁니다.
            if (stackChart.Series.FindByName("PG In") != null) stackChart.Series["PG In"].Points.AddXY(3, 8);
            if (stackChart.Series.FindByName("노광") != null) stackChart.Series["노광"].Points.AddXY(3, 2);
            if (stackChart.Series.FindByName("1st A") != null) stackChart.Series["1st A"].Points.AddXY(3, 7);
            if (stackChart.Series.FindByName("1st B") != null) stackChart.Series["1st B"].Points.AddXY(3, 3);
            if (stackChart.Series.FindByName("추가") != null) stackChart.Series["추가"].Points.AddXY(3, 2);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowStackChart();
        }

        private void ShowStackChart()
        {
            //--------------------------------------------------------------------------------------------------------------------------
            //Declare and initialize variables 
            //--------------------------------------------------------------------------------------------------------------------------
            foreach (var series in stackChart.Series)
            {
                series.Points.Clear();
            }

            //SetSeries();

            //--------------------------------------------------------------------------------------------------------------------------
            //Processing
            //--------------------------------------------------------------------------------------------------------------------------
            //GetChartData_Day();
            //GetChartData_Week();
            //GetChartData_Mon();

            BindChartDataFromDB();

            //--------------------------------------------------------------------------------------------------------------------------
            //Output
            //--------------------------------------------------------------------------------------------------------------------------
            if (stackChart.ChartAreas.Count > 0)
            {
                var axisX = stackChart.ChartAreas[0].AxisX;

                axisX.Interval = 1;
                axisX.LabelStyle.Interval = 1;

                // 정렬 순서 뒤집기 (금일이 위로 가게 하려면 추가, 필요 없다면 주석 처리 가능)
                axisX.IsReversed = true;

                // 기존 라벨을 깨끗이 비운 후, 1번방과 2번방에 각각 알맞은 간판을 동시에 달아줍니다.
                axisX.CustomLabels.Clear();
                axisX.CustomLabels.Add(0.5, 1.5, "전일"); // 1번 좌표 구역 이름
                axisX.CustomLabels.Add(1.5, 2.5, "주별"); // 2번 좌표 구역 이름
                axisX.CustomLabels.Add(2.5, 3.5, "월별"); // 3번 좌표 구역 이름
            }
        }

        //private async void btnPuSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        await GetPuInfo();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }            
        //}

        private async void btnWaveSearch_Click(object sender, EventArgs e)
        {
            try
            {
                await GetWaveInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        //private async Task GetPuInfo()
        //{
        //    //-------------------------------------------------------------------------------------------
        //    // Declare and initialize variables
        //    //-------------------------------------------------------------------------------------------
        //    PuSearchModel model = new PuSearchModel();

        //    //string year = txtYear.Text.Trim();
        //    //model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();

        //    string baseUrl = "http://localhost:9081/api/basemng-pu-info";

        //    //string queryString = BuildQueryString(model);
        //    var queryString = HttpUtility.ParseQueryString(string.Empty);

        //    //query["sido"] = model.Sido;
        //    //query["sigungu"] = model.Sigungu;

        //    string url = $"{baseUrl}?{queryString}";

        //    //-------------------------------------------------------------------------------------------
        //    // Processing
        //    //-------------------------------------------------------------------------------------------            
        //    HttpClient client = new HttpClient();
        //    string json = await client.GetStringAsync(url);
        //    List<PuItem> list = JsonConvert.DeserializeObject<List<PuItem>>(json);

        //    //-------------------------------------------------------------------------------------------
        //    // Output
        //    //-------------------------------------------------------------------------------------------            
        //    if (list == null || list.Count == 0)
        //    {
        //        gridPu.DataSource = null;
        //        MessageBox.Show("조회된 데이터가 없습니다.");
        //        return;
        //    }

        //    gridPu.DataSource = list;
        //}

        private async Task GetWaveInfo()
        {
            ////-------------------------------------------------------------------------------------------
            //// Declare and initialize variables
            ////-------------------------------------------------------------------------------------------
            //WaveSearchModel model = new WaveSearchModel();

            ////string year = txtYear.Text.Trim();
            ////model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();

            //string baseUrl = "http://localhost:9081/api/basemng-wave-info";

            ////string queryString = BuildQueryString(model);
            //var queryString = HttpUtility.ParseQueryString(string.Empty);

            ////query["sido"] = model.Sido;
            ////query["sigungu"] = model.Sigungu;

            //string url = $"{baseUrl}?{queryString}";

            ////-------------------------------------------------------------------------------------------
            //// Processing^
            ////-------------------------------------------------------------------------------------------            
            //HttpClient client = new HttpClient();
            //string json = await client.GetStringAsync(url);
            //List<WaveItem> list = JsonConvert.DeserializeObject<List<WaveItem>>(json);

            ////-------------------------------------------------------------------------------------------
            //// Output
            ////-------------------------------------------------------------------------------------------            
            //if (list == null || list.Count == 0)
            //{
            //    gridWave.DataSource = null;
            //    MessageBox.Show("조회된 데이터가 없습니다.");
            //    return;
            //}

            //gridWave.DataSource = list;
        }



        //private string BuildQueryString(PuSearchModel model)
        //{
        //    //-------------------------------------------------------------------------------------------
        //    // Declare and initialize variables
        //    //-------------------------------------------------------------------------------------------
        //    var query = HttpUtility.ParseQueryString(string.Empty);

        //    //-------------------------------------------------------------------------------------------
        //    // Processing
        //    //-------------------------------------------------------------------------------------------
        //    //query["sido"] = model.Sido;
        //    //query["sigungu"] = model.Sigungu;


        //    return query.ToString();
        //}


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
                new ChartDataRow { Gubun = "금일", SectNm = "PG In", Val = 5 },
                new ChartDataRow { Gubun = "금일", SectNm = "노광", Val = 2 },
                new ChartDataRow { Gubun = "금일", SectNm = "1st A", Val = 6 },
                new ChartDataRow { Gubun = "금일", SectNm = "1st B", Val = 3 },
                new ChartDataRow { Gubun = "금일", SectNm = "추가", Val = 1 },

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
