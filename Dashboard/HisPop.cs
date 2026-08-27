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
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;


namespace CeDev.DataMng
{
    public partial class HisPop : Form
    {
        private List<TargetItem> _list;

        public HisPop()
        {
            InitializeComponent();
            InitEvent();
        }

        public HisPop(List<TargetItem> pList): this()
        {
            //_list = pList;
        }

        private async void HisPop_Load(object sender, EventArgs e)
        {
            //if (_list != null)
            //{
            //    gridHisMaster.DataSource = _list;
            //}

            await GetHisMaster();
            //await GetHisDetail();
        }

        private void InitEvent()
        {
            //gridHisMaster.CellClick += GridHisMaster_CellClick;
            gridHisMaster.SelectionChanged += GridHisMaster_SelectionChanged;
        }

        private async void GridHisMaster_SelectionChanged(object? sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            if (gridHisMaster.CurrentRow == null)
            {
                return;
            }

            TargetHisMasterItem item = gridHisMaster.CurrentRow.DataBoundItem as TargetHisMasterItem;

            if (item == null)
            {
                return;
            }

            txtChgReason.Text = item.chgReason;
            await GetHisDetail(item);
        }

        private async void GridHisMaster_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            if (gridHisMaster.CurrentRow == null)
            {
                return;
            }

            TargetHisMasterItem item = gridHisMaster.CurrentRow.DataBoundItem as TargetHisMasterItem;

            if (item == null)
            {
                return;
            }

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            await GetHisDetail(item);
        }

        private async Task GetHisMaster()
        {
            //======================================================================================================================
            // Declare and initialize variables
            //======================================================================================================================
            TargetSearchModel model = new TargetSearchModel();

            //string year = txtYear.Text.Trim();
            //model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();

            string baseUrl = "http://localhost:9081/api/basemng-target-his-master";


            var queryString = HttpUtility.ParseQueryString(string.Empty);

            ////model.year = "2026";
            //model.year = cboYearTarget.Text;

            //queryString["year"] = model.year;

            //query["sido"] = model.Sido;
            //query["sigungu"] = model.Sigungu;



            string url = $"{baseUrl}?{queryString}";

            //======================================================================================================================
            // Processing
            //======================================================================================================================
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            List<TargetHisMasterItem> list = JsonConvert.DeserializeObject<List<TargetHisMasterItem>>(json);

            //======================================================================================================================
            // Output
            //======================================================================================================================
            if (list == null || list.Count == 0)
            {
                gridHisMaster.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridHisMaster.DataSource = list;

            txtChgReason.Text = list[0].chgReason;


            //gridTarget.Columns["year"].Visible = false;
            //gridTarget.Columns["waveCd"].Visible = false;

            //gridTarget.Columns["year"].ReadOnly = true;
            //gridTarget.Columns["waveCd"].ReadOnly = true;

            //gridTarget.Columns["waveNm"].HeaderText = "파장";
            //gridTarget.Columns["waveNm"].ReadOnly = true;
        }

        private async Task GetHisDetail(TargetHisMasterItem pItem)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            TargetSearchModel model = new TargetSearchModel();

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            


            queryString["histId"] = pItem.histId;

            string baseUrl = "http://localhost:9081/api/basemng-target-his-detail";
                        

            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                string json = await client.GetStringAsync(url);
                List<TargetHisDetailItem> list = JsonConvert.DeserializeObject<List<TargetHisDetailItem>>(json);

                stopwatch.Stop();

                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("조회된 데이터가 없습니다.");
                    gridHisDetail.DataSource = null;
                    //chart1.Series.Clear();
                    return;
                }

                long elapsedMs = stopwatch.ElapsedMilliseconds;
                double seconds = elapsedMs / 1000.0; // 초 단위 변환 (0.8초)

                gridHisDetail.DataSource = list;
                gridHisDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //lblCnt2.Text = $"{list.Count:N0} 건({seconds:0.0}초)";

                //SetGridHeader();
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
