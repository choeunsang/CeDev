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
        }



        //private void InitializeGridComboBox()
        private void IntGridControl_Combox(int pColNum, List<string> pList, string pHeaderTxt)
        {
            // 1. 기존 '3'이 들어있는 컬럼 인덱스 지정 (예: 6번째 컬럼이면 Index 5)
            //int targetColumnIndex = 9;
            int targetColumnIndex = pColNum;

            // 2. 기존 행들의 데이터 값(예: "3")을 미리 배열이나 리스트에 백업
            string[] originalValues = new string[gridKpi.Rows.Count];
            for (int i = 0; i < gridKpi.Rows.Count; i++)
            {
                if (gridKpi.Rows[i].Cells[targetColumnIndex].Value != null)
                {
                    originalValues[i] = gridKpi.Rows[i].Cells[targetColumnIndex].Value.ToString().Trim();
                }
            }

            // 3. 기존의 텍스트박스 컬럼 제거
            gridKpi.Columns.RemoveAt(targetColumnIndex);

            // 4. 새로운 콤보박스 컬럼 생성
            DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
            //cmbCol.Name = "MonthSelectColumn";
            //cmbCol.HeaderText = "3차"; // 기존 헤더 이름에 맞게 지정하세요
            cmbCol.HeaderText = pHeaderTxt;

            // ⚠️ 중요: 만약 DataTable을 DataSource로 바인딩 중이라면 아래 속성을 바인딩 필드명과 맞춰야 합니다.
            // cmbCol.DataPropertyName = "해당필드명"; 

            // 5. 콤보박스에 1~12 아이템 추가 (안전하게 문자열 .ToString()으로 추가)
            //for (int i = 1; i <= 12; i++)
            //{
            //    cmbCol.Items.Add(i.ToString());
            //}

            foreach (var item in pList)
            {
                cmbCol.Items.Add(item.ToString());
            }


            // 6. 원래 위치에 콤보박스 컬럼 삽입
            gridKpi.Columns.Insert(targetColumnIndex, cmbCol);

            // 7. 백업해 두었던 기존 값을 각 셀에 다시 대입하여 기본 선택 상태로 만들기
            for (int i = 0; i < gridKpi.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(originalValues[i]))
                {
                    // 콤보박스 아이템 목록에 백업된 값("3")이 존재하는지 확인 후 세팅
                    if (cmbCol.Items.Contains(originalValues[i]))
                    {
                        gridKpi.Rows[i].Cells[targetColumnIndex].Value = originalValues[i];
                    }
                }
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

            model.year = "2026";
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


            //gridTarget.Columns["waveCd"].Visible = false;
            gridTarget.Columns["waveNm"].HeaderText = "파장";
            gridTarget.Columns["waveNm"].ReadOnly = true;
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

            gridKpi.Columns["kpiNm"].ReadOnly = true;
            gridKpi.Columns["gubun"].ReadOnly = true;

            gridKpi.Columns["gubunDay"].HeaderText = "";
            gridKpi.Columns["gubunDay"].Width = 70;

            gridKpi.Columns["gubunSign"].HeaderText = "";
            gridKpi.Columns["gubunSign"].Width = 70;

            gridKpi.Columns["kpiVal"].Width = 350;
            gridKpi.Columns["kpiVal"].ReadOnly = true;

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


            //-------------------------------------------------------------------------------
            //(2).결과 그리드 - 컨트롤
            //-------------------------------------------------------------------------------
            //(1).문자 부등호()
            List<string> ynSine_Char = new List<string>();

            ynSine_Char.Add("이내");
            ynSine_Char.Add("초과");

            IntGridControl_Combox(5, ynSine_Char, "");

            //(2).부등호()
            List<string> ynSine = new List<string>();

            ynSine.Add("≥");
            ynSine.Add(">");
            ynSine.Add("<");
            ynSine.Add("≤");

            IntGridControl_Combox(7, ynSine, "1차");
            IntGridControl_Combox(11, ynSine, "2차");
            IntGridControl_Combox(15, ynSine, "3차");
            IntGridControl_Combox(19, ynSine, "4차");

            //(3).1~12월
            List<string> monList = new List<string>();

            for (int i = 1; i <= 12; i++)
            {
                monList.Add(i.ToString());
            }

            IntGridControl_Combox(9, monList, "");
            IntGridControl_Combox(13, monList, "");
            IntGridControl_Combox(17, monList, "");
            IntGridControl_Combox(20, monList, "");

            //(4).사용여부(Y/N)
            List<string> ynList = new List<string>();

            ynList.Add("Y");
            ynList.Add("N");

            IntGridControl_Combox(10, ynList, "");
            IntGridControl_Combox(14, ynList, "");
            IntGridControl_Combox(18, ynList, "");
            IntGridControl_Combox(22, ynList, "");
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

        }
    }
}
