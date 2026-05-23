using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CeDev.Login
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void btnJoin_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string userId = txtId.Text.Trim();
            string userPw = txtPw.Text.Trim();

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



            string url = "http://localhost:9081/api/user/signup";

            var param = new
            {
                userId = userId,
                userPw = userPw
            };

            string json = JsonConvert.SerializeObject(param);

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------


            try
            {
                using (HttpClient client = new HttpClient())
                using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("회원가입이 완료되었습니다.");
                        this.Close();
                    }
                    else
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("회원가입 실패: " + result);
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
