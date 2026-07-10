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
        }

        private void TargetMng_Load(object sender, EventArgs e)
        {

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
            //gridTarget.Columns["waveNm"].HeaderText = "파장";
        }
    }
}
