using CeDev.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace CeDev.Login
{
    public partial class UserInfoNew : Form
    {
        public UserInfoNew()
        {
            InitializeComponent();
        }

        private async void btnNew_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string userId = txtId.Text.Trim();
            string userPw = txtPw.Text.Trim();

            string url = "http://localhost:9081/api/user/signup";

            UserCreateRequestDto param = new UserCreateRequestDto
            {
                UserId = userId,
                UserPw = userPw
            };

            string json = JsonConvert.SerializeObject(param);

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            if (string.IsNullOrWhiteSpace(userId))
            {
                MessageBox.Show("ID를 입력하세요.");
                return;
            }

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
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("사용자가 생성되었습니다.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("사용자 생성 실패: " + result);
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