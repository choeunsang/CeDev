using CeDev.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace CeDev.Login
{
    public partial class UserInfoDetail : Form
    {
        //-------------------------------------------------------------------------------------------
        // Declare and initialize variables
        //-------------------------------------------------------------------------------------------
        private int _userSeq;

        public UserInfoDetail()
        {
            InitializeComponent();
        }

        public UserInfoDetail(int userSeq, string userId, string userPw)
        {
            InitializeComponent();

            _userSeq = userSeq;
            txtId.Text = userId;
            txtPw.Text = userPw;
            txtId.ReadOnly = true;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string userPw = txtPw.Text.Trim();
            string url = $"http://localhost:9081/api/user/{_userSeq}/password";

            UserUpdateRequestDto param = new UserUpdateRequestDto
            {
                userPw = userPw
            };

            string json = JsonConvert.SerializeObject(param);

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            if (string.IsNullOrWhiteSpace(userPw))
            {
                MessageBox.Show("PW를 입력하세요.");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await client.PutAsync(url, content);
                    string result = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("수정 실패: " + result);
                        return;
                    }

                    int updateCnt = Convert.ToInt32(result);

                    if (updateCnt > 0)
                    {
                        MessageBox.Show("수정되었습니다.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("수정 대상이 없습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 연결 실패: " + ex.Message);
            }
        }
    }
}