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
        }

        private async void btnPuSearch_Click(object sender, EventArgs e)
        {
            try
            {
                await GetPuInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

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

        private async Task GetPuInfo()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            PuSearchModel model = new PuSearchModel();

            //string year = txtYear.Text.Trim();
            //model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();

            string baseUrl = "http://localhost:9081/api/basemng-pu-info";

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
            List<PuItem> list = JsonConvert.DeserializeObject<List<PuItem>>(json);
            
            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------            
            if (list == null || list.Count == 0)
            {                
                gridPu.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridPu.DataSource = list;
        }

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


    }
}
