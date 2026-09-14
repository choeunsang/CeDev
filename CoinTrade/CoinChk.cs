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
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace CeDev.DataMng
{
    public partial class CoinChk : Form
    {
        private List<CoinItem> _coinlist = new List<CoinItem>();
        private List<CoinChkItem> _coinChklist = new List<CoinChkItem>();


        public CoinChk()
        {
            InitializeComponent();
            InitControls();
            //InitEvents();            
        }

        private void InitControls()
        {
            txtDt.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        }

        private void InitEvents()
        {
            gridCoin.SelectionChanged += GridCoin_SelectionChanged;
        }

        private void GridCoin_SelectionChanged(object? sender, EventArgs e)
        {
            GetCoinDetailInfo();
        }

        private async void GetCoinDetailInfo()
        {
            //-------------------------------------------------------------------------------------------
            //Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            if (gridCoin.CurrentRow == null)
            {
                return;
            }

            CoinItem item = gridCoin.CurrentRow.DataBoundItem as CoinItem;

            if (item == null)
            {
                return;
            }

            //-------------------------------------------------------------------------------------------
            //Processing
            //-------------------------------------------------------------------------------------------
            txtCoinCd.Text = item.cd;
            txtCoinKrNm.Text = item.krNm;
            txtCoinEnNm.Text = item.enNm;
            txtDesc.Text = item.description;

            txtPrice.Text = Math.Round(Convert.ToDecimal(item.price), 2).ToString();
            txtPriceDt.Text = item.priceDt;
            txtCntry.Text = item.issueCntryNm;

            //-------------------------------------------------------------------------------------------
            //Output
            //-------------------------------------------------------------------------------------------
            string imgPathStr = string.Empty;
            imgPathStr = @"C:\dev\WinformDev\CeDev\Img\simbol\" + item.cd + ".png";

            if (System.IO.File.Exists(imgPathStr))
            {
                coinPicture.Image?.Dispose();

                using (var stream = new System.IO.FileStream(imgPathStr, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    coinPicture.Image = Image.FromStream(stream);
                }

                //coinPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                coinPicture.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                coinPicture.Image = null;
            }

            await GetCoinDetail(item);
        }

        private async Task GetCoinDetail(CoinItem pItem)
        {
            //=================================================================================================================
            // Declare and initialize variables
            //=================================================================================================================
            //CoinSearchModel model = new CoinSearchModel();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["cd"] = pItem.cd;
            
            string baseUrl = "http://localhost:9081/api/basemng-coin-detail-info";
            string url = $"{baseUrl}?{queryString}";

            //=================================================================================================================
            // Processing
            //=================================================================================================================
            HttpClient client = new HttpClient();

            string json = await client.GetStringAsync(url);
            List<CoinDetailItem> list = JsonConvert.DeserializeObject<List<CoinDetailItem>>(json);

            //txtPrice.Text = Math.Round(Convert.ToDecimal(item.price), 2).ToString();
            list.ForEach(x => x.price = Math.Round(Convert.ToDecimal(x.price), 2).ToString());

            list.ForEach(x => x.openingPrice = Math.Round(Convert.ToDecimal(x.openingPrice), 2).ToString());
            list.ForEach(x => x.highPrice = Math.Round(Convert.ToDecimal(x.highPrice), 2).ToString());
            list.ForEach(x => x.lowPrice = Math.Round(Convert.ToDecimal(x.lowPrice), 2).ToString());
            list.ForEach(x => x.volume = Math.Round(Convert.ToDecimal(x.volume), 2).ToString());

            if (list == null || list.Count == 0)
            {
                MessageBox.Show("조회된 데이터가 없습니다.");
                gridPrice.DataSource = null;
                //chart1.Series.Clear();
                return;
            }

            //=================================================================================================================
            // Output 
            //=================================================================================================================
            //txtMaxPrice.Text = list.Max(x => x.price).ToString();
            //txtMinPrice.Text = list.Min(x => x.price).ToString();


            //var ddd = list
            //         .Where(x => Convert.ToDecimal(x.highPrice) - Convert.ToDecimal(x.lowPrice) >= 10)
            //         .ToList();
                     

            var maxPriceItem = list.OrderByDescending(x => x.price).FirstOrDefault();
            var minPriceItem = list.OrderBy(x => x.price).FirstOrDefault();

            if(maxPriceItem != null)
            {
                txtMaxPrice.Text = maxPriceItem.price.ToString();
                txtMaxPriceDt.Text = maxPriceItem.priceDt.ToString();
            }

            if (minPriceItem != null)
            {
                txtMinPrice.Text = minPriceItem.price.ToString();
                txtMinPriceDt.Text = minPriceItem.priceDt.ToString();
            }


            gridPrice.DataSource = list;
            gridPrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }



        private async void CoinInfo_Load(object sender, EventArgs e)
        {
            await GetCoinInfo();
        }

        private async void btnSectSearch_Click(object sender, EventArgs e)
        {
            try
            {
                await GetCoinInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private async Task GetCoinInfo()
        {            
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------            
            string baseUrl = "http://localhost:9081/api/basemng-coin-chk-info";            
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["priceDt"] = txtDt.Text;
            string url = $"{baseUrl}?{queryString}";



            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------            
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);            
            _coinChklist = JsonConvert.DeserializeObject<List<CoinChkItem>>(json);


            //_coinChklist = _coinChklist.Where(x => x.useYn == "Y").ToList();

            _coinChklist.ForEach(x => x.price = Math.Round(Convert.ToDecimal(x.price), 2).ToString());

            _coinChklist.ForEach(x => x.openingPrice = Math.Round(Convert.ToDecimal(x.openingPrice), 2).ToString());
            _coinChklist.ForEach(x => x.highPrice = Math.Round(Convert.ToDecimal(x.highPrice), 2).ToString());
            _coinChklist.ForEach(x => x.lowPrice = Math.Round(Convert.ToDecimal(x.lowPrice), 2).ToString());
            _coinChklist.ForEach(x => x.volume = Math.Round(Convert.ToDecimal(x.volume), 2).ToString());
            _coinChklist.ForEach(x => x.dailyRange = Math.Round(Convert.ToDecimal(x.dailyRange), 2).ToString());

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------                        
            if (_coinChklist == null || _coinChklist.Count == 0)
            {
                gridCoin.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridCoin.DataSource = _coinChklist;
        }




    }
}
