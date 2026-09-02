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
            InitKpiGridColSetting();

            await GetTargetInfo();                        
            await GetKpiInfo();
        }

        private void InitEvents()
        {
            gridTarget.EditingControlShowing += GridTarget_EditingControlShowing;
            //gridTarget.CellClick += GridTarget_CellClick;

            gridKpi.EditingControlShowing += GridKpi_EditingControlShowing;
        }

        private void GridTarget_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            //// 클릭한 셀이 새로 만든 콤보박스 컬럼이고, 헤더가 아닐 때
            //if (e.RowIndex >= 0 && gridTarget.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            //{
            //    // 편집 모드로 들어가며 자동으로 드롭다운 목록을 엽니다.
            //    gridTarget.BeginEdit(true);
            //    var comboBox = gridTarget.EditingControl as ComboBox;
            //    if (comboBox != null)
            //    {
            //        comboBox.DroppedDown = true;
            //    }
            //}
        }

        private void GridTarget_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // 첫 번째 열(Index 0)을 제외한 나머지 열들 대상
            if (gridTarget.CurrentCell.ColumnIndex > 0)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    // 이벤트 중복 등록 방지
                    txt.KeyPress -= TextBox_Decimal_KeyPress;

                    // 소수점이 들어가므로 MaxLength 제한은 해제합니다 (소수점 포함 길어질 수 있으므로)
                    txt.MaxLength = 32767;

                    txt.KeyPress += TextBox_Decimal_KeyPress;
                }
            }
        }

        private void GridKpi_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            switch (gridKpi.CurrentCell.ColumnIndex)
            {
                case 4:
                    {
                        TextBox txt = e.Control as TextBox;
                        if (txt != null)
                        {
                            // 이벤트 중복 등록 방지
                            txt.KeyPress -= TextBox_Number_KeyPress;

                            // 소수점이 들어가므로 MaxLength 제한은 해제합니다 (소수점 포함 길어질 수 있으므로)
                            txt.MaxLength = 2;

                            txt.KeyPress += TextBox_Number_KeyPress;
                        }
                    }
                    break;

                case 8:
                case 12:
                case 16:
                case 20:
                    {
                        TextBox txt = e.Control as TextBox;
                        if (txt != null)
                        {
                            // 이벤트 중복 등록 방지
                            txt.KeyPress -= TextBox_Decimal_KeyPress;

                            // 소수점이 들어가므로 MaxLength 제한은 해제합니다 (소수점 포함 길어질 수 있으므로)
                            txt.MaxLength = 32767;

                            txt.KeyPress += TextBox_Decimal_KeyPress;
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void TextBox_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자가 아니고, 제어 문자(백스페이스, 복사/붙여넣기 단축키 등)도 아니라면 입력 차단
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TextBox_Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            // 백스페이스 등 제어 문자는 무조건 허용
            if (char.IsControl(e.KeyChar)) return;

            // 숫자와 소수점(.)만 허용
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // 이미 소수점이 찍혀있는데 또 소수점을 누른 경우 차단
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            // 현재 입력하려는 문자를 조합한 예상 텍스트 생성
            string futureText = txt.Text.Substring(0, txt.SelectionStart)
                                + e.KeyChar
                                + txt.Text.Substring(txt.SelectionStart + txt.SelectionLength);

            // 정규식을 통해 소수점 둘째 자리까지만 입력되도록 제한
            // (정수부 제한 없이 소수점 아래만 최대 2자리로 제한하는 패턴입니다)
            if (!Regex.IsMatch(futureText, @"^\d*\.?\d{0,2}$"))
            {
                e.Handled = true;
            }
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
            //(1).조건
            cboYearKpi.Items.Clear();

            cboYearKpi.Items.Add("2026");
            cboYearKpi.Items.Add("2027");
            cboYearKpi.Items.Add("2028");

            cboYearKpi.SelectedIndex = 0;


            //-------------------------------------------------------------------------------
            //(2).결과 그리드
            //-------------------------------------------------------------------------------
            //List<string> monList = new List<string>();

            //for (int i = 1; i <= 12; i++)
            //{
            //    monList.Add(i.ToString());
            //}

            //IntGridControl_Combox(9, monList);

            //InitKpiGridColSetting();
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

            //model.year = "2026";
            model.year = cboYearTarget.Text;

            queryString["year"] = model.year;

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


            //gridTarget.Columns["year"].Visible = false;
            //gridTarget.Columns["waveCd"].Visible = false;

            gridTarget.Columns["year"].ReadOnly = true;
            gridTarget.Columns["waveCd"].ReadOnly = true;

            gridTarget.Columns["waveNm"].HeaderText = "파장";
            gridTarget.Columns["waveNm"].ReadOnly = true;
        }

        //private bool isKpiColSetYn = false;

        private async Task GetKpiInfo()
        {
            //======================================================================================================================
            // Declare and initialize variables
            //======================================================================================================================            
            KpiSearchModel model = new KpiSearchModel();            
            string baseUrl = "http://localhost:9081/api/basemng-kpi-info";            
            var queryString = HttpUtility.ParseQueryString(string.Empty);
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
                gridKpi.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            foreach(var item in list)
            {
                item.gubun = item.gubunVal + "일 " + item.gubunSign;
            }
            
            gridKpi.DataSource = list;
        }

        private void InitKpiGridColSetting()
        {
            //======================================================================================================================================
            //Declare and initialize variables 
            //======================================================================================================================================
            gridKpi.Columns.Clear();
            gridKpi.AutoGenerateColumns = false;

            int colWidth = 50; // 기준 너비 변수

            //-------------------------------------------------------------------------------
            // 콤보박스용 데이터 리스트 미리 생성
            //-------------------------------------------------------------------------------
            // (1) 문자 부등호
            List<string> ynSine_Char = new List<string> { "이내", "초과" };

            // (2) 부등호
            List<string> ynSine = new List<string> { "≥", ">", "<", "≤" };

            // (3) 1~12월
            List<string> monList = new List<string>();
            for (int i = 1; i <= 12; i++)
            {
                monList.Add(i.ToString());
            }

            // (4) 사용여부
            List<string> ynList = new List<string> { "Y", "N" };


            //======================================================================================================================================
            //Processing
            //======================================================================================================================================            
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "year", Name = "year", Visible = false });
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "kpiCd", Name = "kpiCd", Visible = false });            
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "kpiNm", Name = "kpiNm", HeaderText = "KPI명", ReadOnly = true });
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "gubun", Name = "gubun", HeaderText = "구분", ReadOnly = true });            
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "gubunDay", Name = "gubunDay", HeaderText = "", Width = 70 });            
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "gubunSign",
                Name = "gubunSign",
                HeaderText = "",
                Width = 70,
                DataSource = ynSine_Char,
                FlatStyle = FlatStyle.Flat
            });

            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "kpiVal", Name = "kpiVal", HeaderText = "KPI값", Width = 350, ReadOnly = true });

            //1차
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v1stSign",
                Name = "v1stSign",
                HeaderText = "1차",
                Width = colWidth,
                DataSource = ynSine,
                FlatStyle = FlatStyle.Flat
            });
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "v1stVal", Name = "v1stVal", HeaderText = "", Width = colWidth });
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v1stMon",
                Name = "v1stMon",
                HeaderText = "",
                Width = colWidth,
                DataSource = monList,
                FlatStyle = FlatStyle.Flat
            });
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v1stUseYn",
                Name = "v1stUseYn",
                HeaderText = "",
                Width = colWidth,
                DataSource = ynList,
                FlatStyle = FlatStyle.Flat
            });

            //2차
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v2stSign",
                Name = "v2stSign",
                HeaderText = "2차",
                Width = 70,
                DataSource = ynSine,
                FlatStyle = FlatStyle.Flat
            });
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "v2stVal", Name = "v2stVal", HeaderText = "", Width = 70 });
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v2stMon",
                Name = "v2stMon",
                HeaderText = "",
                Width = 70,
                DataSource = monList,
                FlatStyle = FlatStyle.Flat
            });
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v2stUseYn",
                Name = "v2stUseYn",
                HeaderText = "",
                Width = 70,
                DataSource = ynList,
                FlatStyle = FlatStyle.Flat
            });

            //3차
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v3stSign",
                Name = "v3stSign",
                HeaderText = "3차",
                Width = 70,
                DataSource = ynSine,
                FlatStyle = FlatStyle.Flat
            });
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "v3stVal", Name = "v3stVal", HeaderText = "", Width = 70 });
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v3stMon",
                Name = "v3stMon",
                HeaderText = "",
                Width = 70,
                DataSource = monList,
                FlatStyle = FlatStyle.Flat
            });
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v3stUseYn",
                Name = "v3stUseYn",
                HeaderText = "",
                Width = 70,
                DataSource = ynList,
                FlatStyle = FlatStyle.Flat
            });

            //4차
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v4stSign",
                Name = "v4stSign",
                HeaderText = "4차",
                Width = 70,
                DataSource = ynSine,
                FlatStyle = FlatStyle.Flat
            });
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "v4stVal", Name = "v4stVal", HeaderText = "", Width = 70 });
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v4stMon",
                Name = "v4stMon",
                HeaderText = "",
                Width = 70,
                DataSource = monList,
                FlatStyle = FlatStyle.Flat
            });
            gridKpi.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "v4stUseYn",
                Name = "v4stUseYn",
                HeaderText = "",
                Width = 70,
                DataSource = ynList,
                FlatStyle = FlatStyle.Flat
            });
            
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "regId", Name = "regId", Visible = false });
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "regDt", Name = "regDt", Visible = false });
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "modId", Name = "modId", Visible = false });
            gridKpi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "modDt", Name = "modDt", Visible = false });

            //======================================================================================================================================
            //Output
            //====================================================================================================================================== 
            gridKpi.DataSource = new List<KpiItem>();
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

        private void btnSaveTarget_Click(object sender, EventArgs e)
        {
            List<TargetItem> list = (List<TargetItem>)gridTarget.DataSource;

            if (list == null || list.Count == 0)
            {
                MessageBox.Show("저장할 그리드 데이터가 없습니다.");
                return;
            }

            using (SavePop pop = new SavePop(list))
            {
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    gridTarget.Refresh();
                    MessageBox.Show("저장이 완료되었습니다.");

                }
            }
        }

        private async void btnTargetHis_Click(object sender, EventArgs e)
        {
            List<TargetItem> list = (List<TargetItem>)gridTarget.DataSource;

            if (list == null || list.Count == 0)
            {
                MessageBox.Show("이력보기할 그리드 데이터가 없습니다.");
                return;
            }

            using (HisPop pop = new HisPop(list))
            {
                if(pop.ShowDialog() == DialogResult.OK)
                {
                    await GetTargetInfo();
                }
            }
        }



        private async Task SaveTargetInfo()
        {
            //======================================================================================================================
            // Declare and initialize variables
            //======================================================================================================================
            TargetSaveModel saveModel = new TargetSaveModel();

            List<TargetItem> list = (List<TargetItem>)gridTarget.DataSource;

            if (list == null || list.Count == 0)
            {
                MessageBox.Show("저장할 데이터가 그리드에 존재하지 않습니다.");
                return;
            }

            // 2. 전달할 데이터 바인딩
            var strYear = cboYearTarget.Text.Trim();

            //saveModel.year = "2026";     
            saveModel.year = strYear;

            //saveModel.reason = txtReason.Text.Trim();
            saveModel.userId = "ADMIN";
            saveModel.gridData = list;

            //string url = "http://localhost:9081/api/basemng-target-info/save-snapshot";
            string url = "http://localhost:9081/api/basemng-target-info/save";

            string ddd = "ddd";

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
                    //MessageBox.Show("호출성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("저장성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await GetTargetInfo();
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

        private async void btnSaveKpi_Click(object sender, EventArgs e)
        {
            await SaveKpiInfo();
        }

        private async Task SaveKpiInfo()
        {
            //======================================================================================================================
            // Declare and initialize variables
            //======================================================================================================================
            KpiSaveModel saveModel = new KpiSaveModel();

            List<KpiItem> list = (List<KpiItem>)gridKpi.DataSource;

            if (list == null || list.Count == 0)
            {
                MessageBox.Show("저장할 데이터가 그리드에 존재하지 않습니다.");
                return;
            }

            // 2. 전달할 데이터 바인딩
            var strYear = cboYearTarget.Text.Trim();

            //saveModel.year = "2026";     
            saveModel.year = strYear;

            //saveModel.reason = txtReason.Text.Trim();
            saveModel.userId = "ADMIN";
            saveModel.gridData = list;

            
            string url = "http://localhost:9081/api/basemng-kpi-info/save";

            string ddd = "ddd";

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
                    MessageBox.Show("저장성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ////재조회
                    //await GetKpiInfo();
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
    }
}
