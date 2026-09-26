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
    public partial class CoinInfo : Form
    {
        private List<CoinItem> _coinlist = new List<CoinItem>();


        public CoinInfo()
        {
            InitializeComponent();
            InitEvents();
            //InitControls();
        }

        private void InitEvents()
        {
            //gridPu.CellValueChanged += GridPu_CellValueChanged;
            //gridPu.CurrentCellDirtyStateChanged += GridPu_CurrentCellDirtyStateChanged;


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

            txtLaunchDt.Text = item.launchDt;

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
            string oneYearsAgo = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            string threeMonthAgo = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");

            var volaList = list.Where(x => string.Compare(x.priceDt, threeMonthAgo) <= 0).ToList();
            //var volaList = list.Where(x => string.Compare(x.priceDt, oneYearsAgo) <= 0).ToList();

            volaList = volaList
                     .Where(x => (Convert.ToDecimal(x.highPrice) - Convert.ToDecimal(x.lowPrice)) / Convert.ToDecimal(x.lowPrice) >= 0.1m)
                     .ToList();

            txtShotCnt.Text = volaList.Count.ToString();

            var lastItem = volaList.OrderByDescending(x => x.priceDt).FirstOrDefault();
            txtShotLastDt.Text = lastItem?.priceDt?.ToString() ?? "데이터 없음";

            var maxPriceItem = list.OrderByDescending(x => x.price).FirstOrDefault();
            var minPriceItem = list.OrderBy(x => x.price).FirstOrDefault();

            if (maxPriceItem != null)
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

            SetGridHeader2();
        }

        private void InitControls()
        {
            ////Tat시작점 설정정보 - 하드코딩
            //_tatlist.Add(new TatItem() { TatStart = "B1ST" });
            //_tatlist.Add(new TatItem() { TatStart = "B2ST" });
            //_tatlist.Add(new TatItem() { TatStart = "B3ST" });
            //_tatlist.Add(new TatItem() { TatStart = "B4ST" });
            //_tatlist.Add(new TatItem() { TatStart = "B5ST" });
            //_tatlist.Add(new TatItem() { TatStart = "PG_IN" });
        }

        private void GridPu_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            //if (gridPu.Columns[e.ColumnIndex].Name == "ParentCd")
            //{
            //    var selCd = gridPu.Rows[e.RowIndex].Cells["ParentCd"].Value?.ToString();

            //    if (!string.IsNullOrEmpty(selCd))
            //    {
            //        var matchSect = _sectlist.FirstOrDefault(x => x.Cd == selCd);

            //        if (matchSect != null)
            //        {
            //            gridPu.Rows[e.RowIndex].Cells["ParentNm"].Value = matchSect.Nm;
            //        }
            //    }
            //}
            //else
            //{
            //    //gridPu.Rows[e.RowIndex].Cells["ParentNm"].Value = string.Empty;
            //}
        }


        private void GridPu_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            //if (gridPu.IsCurrentCellDirty && gridPu.CurrentCell is DataGridViewComboBoxCell)
            //{
            //    gridPu.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
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
            PuSearchModel model = new PuSearchModel();
            string baseUrl = "http://localhost:9081/api/basemng-coin-info";
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["krNm"] = txtSearchCoinNm.Text;

            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------            
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            _coinlist = JsonConvert.DeserializeObject<List<CoinItem>>(json);

            _coinlist = _coinlist.Where(x => x.useYn == "Y").ToList();


            _coinlist.ForEach(x => x.price = Math.Round(Convert.ToDecimal(x.price), 2).ToString());

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------                        
            if (_coinlist == null || _coinlist.Count == 0)
            {
                lblCnt.Text = "0 건";
                gridCoin.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridCoin.DataSource = _coinlist;
            lblCnt.Text = $"{_coinlist.Count:N0} 건";

            SetGridHeader();
        }

        private void SetGridHeader()
        {
            gridCoin.Columns["cd"].HeaderText = "코드";
            gridCoin.Columns["krNm"].HeaderText = "코인명";
            gridCoin.Columns["enNm"].HeaderText = "코인명(영문)";
            gridCoin.Columns["description"].HeaderText = "설명";
            gridCoin.Columns["issueCntryNm"].HeaderText = "발행국";
            gridCoin.Columns["price"].HeaderText = "가격";
            gridCoin.Columns["priceDt"].HeaderText = "가격일자";
            gridCoin.Columns["marketCap"].HeaderText = "시총";
            gridCoin.Columns["useYn"].HeaderText = "사용여부";
            gridCoin.Columns["launchDt"].HeaderText = "상장일";

            gridCoin.Columns["cd"].Visible = true;
            gridCoin.Columns["krNm"].Visible = true;
            gridCoin.Columns["enNm"].Visible = false;
            gridCoin.Columns["description"].Visible = false;
            gridCoin.Columns["issueCntryNm"].Visible = false;
            gridCoin.Columns["price"].Visible = true;
            gridCoin.Columns["priceDt"].Visible = true;
            gridCoin.Columns["marketCap"].Visible = false;
            gridCoin.Columns["useYn"].Visible = false;
            gridCoin.Columns["launchDt"].Visible = false;


            gridCoin.Columns["cd"].DisplayIndex = 0;
            gridCoin.Columns["krNm"].DisplayIndex = 1;
            gridCoin.Columns["enNm"].DisplayIndex = 2;
            gridCoin.Columns["description"].DisplayIndex = 3;
            gridCoin.Columns["issueCntryNm"].DisplayIndex = 4;
            gridCoin.Columns["price"].DisplayIndex = 5;
            gridCoin.Columns["priceDt"].DisplayIndex = 6;
            gridCoin.Columns["marketCap"].DisplayIndex = 7;
            gridCoin.Columns["useYn"].DisplayIndex = 8;
            gridCoin.Columns["launchDt"].DisplayIndex = 9;

            //gridCoin.Columns["dailyRange"].Width = 70;
            //gridCoin.Columns["changeRate"].Width = 70;
        }

        private void SetGridHeader2()
        {
            gridPrice.Columns["cd"].HeaderText = "코드";
            gridPrice.Columns["priceDt"].HeaderText = "가격일자";
            gridPrice.Columns["price"].HeaderText = "가격";            
            gridPrice.Columns["openingPrice"].HeaderText = "시초가";
            gridPrice.Columns["highPrice"].HeaderText = "최고가";
            gridPrice.Columns["lowPrice"].HeaderText = "최저가";
            gridPrice.Columns["volume"].HeaderText = "거래량";
            gridPrice.Columns["marketCap"].HeaderText = "시총";
            gridPrice.Columns["etc"].HeaderText = "etc";

            gridPrice.Columns["cd"].Visible = false;
            gridPrice.Columns["priceDt"].Visible = true;
            gridPrice.Columns["price"].Visible = true;
            gridPrice.Columns["openingPrice"].Visible = true;
            gridPrice.Columns["highPrice"].Visible = true;
            gridPrice.Columns["lowPrice"].Visible = true;
            gridPrice.Columns["volume"].Visible = true;
            gridPrice.Columns["marketCap"].Visible = false;
            gridPrice.Columns["etc"].Visible = false;

            //gridPrice.Columns["cd"].Width = 70;
            //gridPrice.Columns["krNm"].Width = 70;
        }
    }
}
