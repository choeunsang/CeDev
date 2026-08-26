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
using System.Windows.Forms;


namespace CeDev.DataMng
{
    public partial class SavePop : Form
    {
        private List<TargetItem> _list;


        public SavePop()
        {
            InitializeComponent();
        }

        public SavePop(List<TargetItem> plist) :this()
        {
            _list = plist;            
        }

        private void SavePop_Load(object sender, EventArgs e)
        {            
            if (_list != null)
            {                
                gridTarget.DataSource = _list;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //Declare and initialize variables 
            if(string.IsNullOrEmpty(txtChgReason.Text.Trim()))
            {
                MessageBox.Show("변경사유를 먼저 입력 해 주세요.");
                return;
            }


            //Processing 
            await SaveTargetInfo();
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
            //var strYear = cboYearTarget.Text.Trim();
            var strYear = "dfd";

            //saveModel.year = "2026";     
            saveModel.year = list[0].year;
            
            saveModel.reason = txtChgReason.Text.Trim();
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

                    //await GetTargetInfo();
                    this.DialogResult = DialogResult.OK;
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
    }
}
