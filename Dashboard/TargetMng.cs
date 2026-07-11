using CeDev.Models;
using CeDev.Models.BaseMng;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;


namespace CeDev.DataMng
{
    public partial class TargetMng : Form
    {
        public TargetMng()
        {
            InitializeComponent();
            InitEvents();
            InitControls();
        }

        private async void TargetMng_Load(object sender, EventArgs e)
        {
            await GetTargetInfo();
            await GetKpiInfo();
        }

        private void InitEvents()
        {

        }

        private void InitControls()
        {
            //===============================================================================================
            //가. 목표관리
            //===============================================================================================            
            cboYearTarget.Items.Clear();

            cboYearTarget.Items.Add("2026");
            cboYearTarget.Items.Add("2027");
            cboYearTarget.Items.Add("2028");

            cboYearTarget.SelectedIndex = 0;

            //===============================================================================================
            //나. Kpi
            //===============================================================================================
            cboYearKpi.Items.Clear();

            cboYearKpi.Items.Add("2026");
            cboYearKpi.Items.Add("2027");
            cboYearKpi.Items.Add("2028");

            cboYearKpi.SelectedIndex = 0;
        }



        private async Task GetTargetInfo()
        {
            //======================================================================================================================
            // Declare and initialize variables
            //======================================================================================================================
            TargetSearchModel model = new TargetSearchModel();

            //string year = txtYear.Text.Trim();
            //model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();

            string baseUrl = "http://localhost:9081/api/basemng-target-info";

            //string queryString = BuildQueryString(model);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            //query["sido"] = model.Sido;
            //query["sigungu"] = model.Sigungu;

            string url = $"{baseUrl}?{queryString}";

            //======================================================================================================================
            // Processing
            //======================================================================================================================
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            List<TargetItem> list = JsonConvert.DeserializeObject<List<TargetItem>>(json);

            //======================================================================================================================
            // Output
            //======================================================================================================================
            if (list == null || list.Count == 0)
            {
                gridTarget.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridTarget.DataSource = list;


            //gridTarget.Columns["waveCd"].Visible = false;
            gridTarget.Columns["waveNm"].HeaderText = "파장";
        }

        private async Task GetKpiInfo()
        {
            //======================================================================================================================
            // Declare and initialize variables
            //======================================================================================================================
            KpiSearchModel model = new KpiSearchModel();

            //string year = txtYear.Text.Trim();
            //model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();

            string baseUrl = "http://localhost:9081/api/basemng-kpi-info";

            //string queryString = BuildQueryString(model);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            //query["sido"] = model.Sido;
            //query["sigungu"] = model.Sigungu;

            string url = $"{baseUrl}?{queryString}";

            //======================================================================================================================
            // Processing
            //======================================================================================================================
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            List<KpiItem> list = JsonConvert.DeserializeObject<List<KpiItem>>(json);

            //======================================================================================================================
            // Output
            //======================================================================================================================
            if (list == null || list.Count == 0)
            {
                gridTarget.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridKpi.DataSource = list;


            gridKpi.Columns["year"].Visible = false;
            gridKpi.Columns["kpiCd"].Visible = false;

            gridKpi.Columns["gubunDay"].HeaderText = "";
            gridKpi.Columns["gubunDay"].Width = 70;

            gridKpi.Columns["gubunSign"].HeaderText = "";
            gridKpi.Columns["gubunSign"].Width = 70;


            gridKpi.Columns["kpiVal"].Width = 350;

            gridKpi.Columns["v1stSign"].HeaderText = "1차";
            gridKpi.Columns["v1stSign"].Width = 70;
            gridKpi.Columns["v1stVal"].HeaderText = "";
            gridKpi.Columns["v1stVal"].Width = 70;
            gridKpi.Columns["v1stMon"].HeaderText = "";
            gridKpi.Columns["v1stMon"].Width = 70;
            gridKpi.Columns["v1stUseYn"].HeaderText = "";
            gridKpi.Columns["v1stUseYn"].Width = 70;

            gridKpi.Columns["v2stSign"].HeaderText = "2차";
            gridKpi.Columns["v2stSign"].Width = 70;
            gridKpi.Columns["v2stVal"].HeaderText = "";
            gridKpi.Columns["v2stVal"].Width = 70;
            gridKpi.Columns["v2stMon"].HeaderText = "";
            gridKpi.Columns["v2stMon"].Width = 70;
            gridKpi.Columns["v2stUseYn"].HeaderText = "";
            gridKpi.Columns["v2stUseYn"].Width = 70;

            gridKpi.Columns["v3stSign"].HeaderText = "3차";
            gridKpi.Columns["v3stSign"].Width = 70;
            gridKpi.Columns["v3stVal"].HeaderText = "";
            gridKpi.Columns["v3stVal"].Width = 70;
            gridKpi.Columns["v3stMon"].HeaderText = "";
            gridKpi.Columns["v3stMon"].Width = 70;
            gridKpi.Columns["v3stUseYn"].HeaderText = "";
            gridKpi.Columns["v3stUseYn"].Width = 70;

            gridKpi.Columns["v4stSign"].HeaderText = "4차";
            gridKpi.Columns["v4stSign"].Width = 70;
            gridKpi.Columns["v4stVal"].HeaderText = "";
            gridKpi.Columns["v4stVal"].Width = 70;
            gridKpi.Columns["v4stMon"].HeaderText = "";
            gridKpi.Columns["v4stMon"].Width = 70;
            gridKpi.Columns["v4stUseYn"].HeaderText = "";
            gridKpi.Columns["v4stUseYn"].Width = 70;

            gridKpi.Columns["regId"].Visible = false;
            gridKpi.Columns["regDt"].Visible = false;
            gridKpi.Columns["modId"].Visible = false;
            gridKpi.Columns["modDt"].Visible = false;


            
        }

        private async void btnSearchTarget_Click(object sender, EventArgs e)
        {
            try
            {
                await GetTargetInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void btnSearchKpi_Click(object sender, EventArgs e)
        {
            try
            {
                await GetKpiInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
