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
    public partial class SeriesMng : Form
    {
        private List<SectItem> _sectlist = new List<SectItem>();
        private List<PuItem> _pulist = new List<PuItem>();
        private List<WaveItem> _wavelist = new List<WaveItem>();

        public SeriesMng()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            gridPu.CellValueChanged += GridPu_CellValueChanged;
            gridPu.CurrentCellDirtyStateChanged += GridPu_CurrentCellDirtyStateChanged;
        }

        private void GridPu_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (gridPu.Columns[e.ColumnIndex].Name == "ParentCd")
            {
                var selCd = gridPu.Rows[e.RowIndex].Cells["ParentCd"].Value?.ToString();

                if (!string.IsNullOrEmpty(selCd))
                {
                    var matchSect = _sectlist.FirstOrDefault(x => x.Cd == selCd);

                    if (matchSect != null)
                    {
                        gridPu.Rows[e.RowIndex].Cells["ParentNm"].Value = matchSect.Nm;
                    }
                }
            }
            else
            {
                //gridPu.Rows[e.RowIndex].Cells["ParentNm"].Value = string.Empty;
            }
        }


        private void GridPu_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (gridPu.IsCurrentCellDirty && gridPu.CurrentCell is DataGridViewComboBoxCell)
            {
                gridPu.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        private async void SeriesMng_Load(object sender, EventArgs e)
        {
            await GetSectInfo();
            await GetPuInfo();
            await GetWaveInfo();
        }

        private async void btnSectSearch_Click(object sender, EventArgs e)
        {
            try
            {
                await GetSectInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private async Task GetSectInfo()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            PuSearchModel model = new PuSearchModel();

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

            //List<SectItem> list = JsonConvert.DeserializeObject<List<SectItem>>(json);
            _sectlist = JsonConvert.DeserializeObject<List<SectItem>>(json);

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------            
            //if (list == null || list.Count == 0)
            if (_sectlist == null || _sectlist.Count == 0)
            {
                gridSect.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridSect.DataSource = _sectlist;
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

            //List<PuItem> list = JsonConvert.DeserializeObject<List<PuItem>>(json);
            _pulist = JsonConvert.DeserializeObject<List<PuItem>>(json);

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------            
            //if (list == null || list.Count == 0)
            if (_pulist == null || _pulist.Count == 0)
            {
                gridPu.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridPu.DataSource = _pulist;

            DataGridViewComboBoxColumn cboCol = new DataGridViewComboBoxColumn();

            cboCol.Name = "ParentCd";
            cboCol.HeaderText = "ParentCd";
            cboCol.DataPropertyName = "ParentCd";

            cboCol.DataSource = _sectlist.ToList();
            cboCol.ValueMember = "cd";
            cboCol.DisplayMember = "cd";

            if (gridPu.Columns.Contains("ParentCd"))
            {
                int idx = gridPu.Columns["ParentCd"].Index;

                gridPu.Columns.RemoveAt(idx);
                gridPu.Columns.Insert(idx, cboCol);
            }
            else
            {
                gridPu.Columns.Add(cboCol);
            }

            //gridPu.DataSource = _pulist;
        }

        private async Task GetWaveInfo()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            WaveSearchModel model = new WaveSearchModel();

            //string year = txtYear.Text.Trim();
            //model.Sido = cboSido.Text == "전체" ? "" : cboSido.Text.Trim();

            string baseUrl = "http://localhost:9081/api/basemng-wave-info";

            //string queryString = BuildQueryString(model);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            //query["sido"] = model.Sido;
            //query["sigungu"] = model.Sigungu;

            string url = $"{baseUrl}?{queryString}";

            //-------------------------------------------------------------------------------------------
            // Processing^
            //-------------------------------------------------------------------------------------------            
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);

            //List<WaveItem> list = JsonConvert.DeserializeObject<List<WaveItem>>(json);
            _wavelist = JsonConvert.DeserializeObject<List<WaveItem>>(json);

            //-------------------------------------------------------------------------------------------
            // Output
            //-------------------------------------------------------------------------------------------            
            //if (list == null || list.Count == 0)
            if (_wavelist == null || _wavelist.Count == 0)
            {
                gridWave.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            gridWave.DataSource = _wavelist;
        }

        private async void btnPuSave_Click(object sender, EventArgs e)
        {
            //======================================================================================================================
            // Declare and initialize variables
            //======================================================================================================================
            PuSaveModel saveModel = new PuSaveModel();
            List<PuItem> list = (List<PuItem>)gridPu.DataSource;

            if(list == null || list.Count == 0) 
            {
                MessageBox.Show("저장할 데이타가 없습니다.");
                return; 
            }

            List<PuSaveItem> savelist = new List<PuSaveItem>();

            foreach(var item in list)
            {
                PuSaveItem saveItem = new PuSaveItem();
                saveItem.puCd = item.PuCd;
                saveItem.puNm = item.PuNm;
                saveItem.parentCd = item.ParentCd;
                saveItem.parentNm = item.ParentNm;

                savelist.Add(saveItem);
            }

            //saveModel.gridData = list;
            saveModel.gridData = savelist;

            string url = "http://localhost:9081/api/basemng-pu-info/save";


            //======================================================================================================================
            // Processing
            //======================================================================================================================
            HttpClient client = new HttpClient();

            // 객체를 JSON 문자열로 직렬화
            string jsonPayload = JsonConvert.SerializeObject(saveModel);

            // POST 전송을 위한 HttpContent 생성 (Encoding 및 미디어 타입 지정)
            HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // 비동기 POST 호출
            HttpResponseMessage response = await client.PostAsync(url, content);

            //======================================================================================================================
            // Output
            //======================================================================================================================
            if (response.IsSuccessStatusCode)
            {
                // 1. 자바 서버가 리턴한 JSON 텍스트를 읽어옵니다.
                string jsonResult = await response.Content.ReadAsStringAsync();

                // 2. JSON 문자열을 dynamic 객체로 변환합니다.
                dynamic result = JsonConvert.DeserializeObject(jsonResult);

                // 3. 자바 DTO의 필드명과 정확히 대소문자를 맞춰서 데이터를 꺼냅니다.
                string status = result.status;          // "SUCCESS"
                string message = result.message;        // "저장이 완료되었습니다."
                //string histId = result.data.ToString(); // 20260712081020 (Long 타입 처리)

                // 4. 비즈니스 조건 검증
                if (status == "SUCCESS")
                {
                    MessageBox.Show("호출성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //MessageBox.Show("정상적으로 저장 및 이력 등록이 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show($"{message}\n(생성된 이력 번호: {histId})", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //this.DialogResult = DialogResult.OK;
                    //this.Close();
                }
                else
                {
                    MessageBox.Show($"서버에서 처리에 실패했습니다.\n사유: {message}", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                string errorMsg = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"저장 처리 중 오류가 발생했습니다.\n오류 내용: {errorMsg}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
