using CeDev.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Web;

namespace CeDev
{
    public partial class DangiInfo : Form
    {
        public DangiInfo()
        {
            InitializeComponent();
            InitEvent();            
        }

        private void InitEvent()
        {
            this.Load += RentGbunInfo_Load;
        }

        private async void RentGbunInfo_Load(object? sender, EventArgs e)
        {
            await CeDev.Common.AuthManager.CheckAuthAsync(this);
            await InitCont();
            await DoSearch();
        }

        private async Task InitCont()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string url = "http://localhost:9081/api/region/sido";

            progressBar1.Visible = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;

            ////전월세 구분
            //cboGubun.Items.Clear();
            //cboGubun.Items.Add("전체");
            //cboGubun.Items.Add("전세");
            //cboGubun.Items.Add("월세");
            //cboGubun.SelectedIndex = 0;

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);

                var sidoList = JsonConvert.DeserializeObject<List<string>>(json);

                cboSido.Items.Clear();
                cboSido.Items.Add("전체");
                cboSido.SelectedIndex = 0;

                foreach (string sido in sidoList)
                {
                    cboSido.Items.Add(sido);
                }

                if (cboSido.Items.Contains("서울특별시"))
                {
                    cboSido.SelectedItem = "서울특별시";
                }

                txtYear.Text = DateTime.Now.Year.ToString();
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
                await GetRentInfoList();
            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.MarqueeAnimationSpeed = 0;
                btnSearch.Enabled = true;
            }
        }

        private async Task GetRentInfoList()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            RentInfoSearchModel model = new RentInfoSearchModel();

            model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();
            //model.Year = txtYear.Text.Trim();

            string baseUrl = "http://localhost:9081/api/common/dangi-info";
            string queryString = BuildQueryString(model);
            string url = $"{baseUrl}?{queryString}";
            
            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------            
            Stopwatch stopwatch = Stopwatch.StartNew();

            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            List<DangiItem> list = JsonConvert.DeserializeObject<List<DangiItem>>(json);

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
            //dataGridView1.DataSource = new System.ComponentModel.BindingList<RentGbunItem>(list);

            lblCnt.Text = $"{list.Count:N0} 건({seconds:0.0}초)";

            SetGridHeader();
        }

        private string BuildQueryString(RentInfoSearchModel model)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            var query = HttpUtility.ParseQueryString(string.Empty);

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            query["sido"] = model.Sido;
            //query["sigungu"] = model.Sigungu;
            //query["dong"] = model.Dong;
            //query["year"] = model.Year;
            //query["gubun"] = model.Gubun;

            return query.ToString();
        }

        private void SetGridHeader()
        {
            //컬럼명 변경            
            if (dataGridView1.Columns["Sido"] != null) dataGridView1.Columns["Sido"].HeaderText = "시도코드";
            if (dataGridView1.Columns["Sigungu"] != null) dataGridView1.Columns["Sigungu"].HeaderText = "시군구코드";
            if (dataGridView1.Columns["Dong"] != null) dataGridView1.Columns["Dong"].HeaderText = "법정동코드";
            if (dataGridView1.Columns["Dangi"] != null) dataGridView1.Columns["Dangi"].HeaderText = "단지명";

            //데이터 바인딩 또는 조회 완료 후 실행            
            dataGridView1.Columns["Dangi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}