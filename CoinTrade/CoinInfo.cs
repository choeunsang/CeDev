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


            var volaList = list
                     .Where(x => (Convert.ToDecimal(x.highPrice) - Convert.ToDecimal(x.lowPrice)) / Convert.ToDecimal(x.lowPrice) >= 0.1m)
                     .ToList();

            txtShotCnt.Text  = volaList.Count.ToString();

            var lastItem = volaList.OrderByDescending(x => x.priceDt).FirstOrDefault();
            txtShotLastDt.Text = lastItem?.priceDt?.ToString() ?? "데이터 없음";


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

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------                        
            if (_coinlist == null || _coinlist.Count == 0)
            {
                gridCoin.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridCoin.DataSource = _coinlist;
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
