using CeDev.Models;
using CeDev.Models.BaseMng;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
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
        private List<TargetHisDetailItem> _templist;
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
            TargetHisMasterItem preItem = new TargetHisMasterItem();

            if (item == null)
            {
                return;
            }

            _templist = new List<TargetHisDetailItem>();

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            var idx = gridHisMaster.CurrentRow.Index;
            var preIdx = 0;

            if(idx > 0)
            {
                preIdx = idx - 1;
                preItem = gridHisMaster.Rows[preIdx].DataBoundItem as TargetHisMasterItem;
                
                _templist = await GetHisDetailList(preItem);                
            }            

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------
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

            string baseUrl = "http://localhost:9081/api/basemng-target-his-master";
            var queryString = HttpUtility.ParseQueryString(string.Empty);
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

        private async Task<List<TargetHisDetailItem>> GetHisDetailList(TargetHisMasterItem pItem)
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
        
                if (list == null || list.Count == 0)
                {
                    return null;
                }
                else
                {
                    return list; 
                }                
            }
        }

        private async Task GetHisDetail(TargetHisMasterItem pItem)
        {
            //=================================================================================================================
            // Declare and initialize variables
            //=================================================================================================================
            TargetSearchModel model = new TargetSearchModel();
            var queryString = HttpUtility.ParseQueryString(string.Empty);            
            queryString["histId"] = pItem.histId;

            string baseUrl = "http://localhost:9081/api/basemng-target-his-detail";                        
            string url = $"{baseUrl}?{queryString}";

            //=================================================================================================================
            // Processing
            //=================================================================================================================
            HttpClient client = new HttpClient();
            
            string json = await client.GetStringAsync(url);
            List<TargetHisDetailItem> list = JsonConvert.DeserializeObject<List<TargetHisDetailItem>>(json);
            
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("조회된 데이터가 없습니다.");
                gridHisDetail.DataSource = null;
                //chart1.Series.Clear();
                return;
            }

            gridHisDetail.DataSource = list;
            gridHisDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Color chgColorY = Color.MistyRose;
            Color chgColorN = Color.White;

            //=================================================================================================================
            // Output 
            //=================================================================================================================
            if ((_templist == null) || (_templist.Count == 0))
            {
                return;
            }

            foreach (DataGridViewRow row in gridHisDetail.Rows )
            {
                if(row.DataBoundItem is TargetHisDetailItem item)
                {
                    var subItem = _templist.FirstOrDefault( x=> x.waveCd == item.waveCd);                    

                    //01.fabIn
                    if (item.fabIn != subItem.fabIn)
                    {
                        row.Cells["fabIn"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["fabIn"].Style.BackColor = chgColorN;
                    }

                    //02.b1st
                    if (item.b1st != subItem.b1st)
                    {
                        row.Cells["b1st"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["b1st"].Style.BackColor = chgColorN;
                    }

                    //03.b2st
                    if (item.b2st != subItem.b2st)
                    {
                        row.Cells["b2st"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["b2st"].Style.BackColor = chgColorN;
                    }

                    //04.b3st
                    if (item.b3st != subItem.b3st)
                    {
                        row.Cells["b3st"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["b3st"].Style.BackColor = chgColorN;
                    }

                    //05.b4st
                    if (item.b4st != subItem.b4st)
                    {
                        row.Cells["b4st"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["b4st"].Style.BackColor = chgColorN;
                    }

                    //06.b5st
                    if (item.b5st != subItem.b5st)
                    {
                        row.Cells["b5st"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["b5st"].Style.BackColor = chgColorN;
                    }

                    //07.pgin
                    if (item.pgin != subItem.pgin)
                    {
                        row.Cells["pgin"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["pgin"].Style.BackColor = chgColorN;
                    }

                    //08.a1st
                    if (item.a1st != subItem.a1st)
                    {
                        row.Cells["a1st"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["a1st"].Style.BackColor = chgColorN;
                    }

                    //09.a2st
                    if (item.a2st != subItem.a2st)
                    {
                        row.Cells["a2st"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["a2st"].Style.BackColor = chgColorN;
                    }

                    //10.a3st
                    if (item.a3st != subItem.a3st)
                    {
                        row.Cells["a3st"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["a3st"].Style.BackColor = chgColorN;
                    }

                    //11.a4st
                    if (item.a4st != subItem.a4st)
                    {
                        row.Cells["a4st"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["a4st"].Style.BackColor = chgColorN;
                    }

                    //12.a5st
                    if (item.a5st != subItem.a5st)
                    {
                        row.Cells["a5st"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["a5st"].Style.BackColor = chgColorN;
                    }

                    //13.fabOut
                    if (item.fabOut != subItem.fabOut)
                    {
                        row.Cells["fabOut"].Style.BackColor = chgColorY;
                    }
                    else
                    {
                        row.Cells["fabOut"].Style.BackColor = chgColorN;
                    }
                }
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
