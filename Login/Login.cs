using CeDev.Common;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            //temp
            txtId.Text = "escho";
            txtPw.Text = "1234";
        }

        private void lblJoin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            SignUp signUp = new SignUp();

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            this.Hide();

            signUp.ShowDialog();

            this.Show();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string userId = txtId.Text.Trim();
            string userPw = txtPw.Text.Trim();

            //string url = "http://localhost:9081/api/auth/login";
            string url = "http://localhost:9081/api/auth/dologin";

            var param = new
            {
                userId = userId,
                userPw = userPw
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

            //-------------------------------------------------------------------------------------------
            // 2. 비즈니스 로직 및 서버 통신을 AuthManager에 위임
            //-------------------------------------------------------------------------------------------
            bool isLoginSuccess = await AuthManager.LoginAsync(userId, userPw);

            //-------------------------------------------------------------------------------------------
            // 3. 로그인 결과에 따른 화면 제어 전환
            //-------------------------------------------------------------------------------------------
            if (isLoginSuccess)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }

            //try
            //{
            //    using (HttpClient client = new HttpClient())
            //    using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            //    {
            //        HttpResponseMessage response = await client.PostAsync(url, content);
            //        string result = await response.Content.ReadAsStringAsync();

            //        if (!response.IsSuccessStatusCode)
            //        {
            //            MessageBox.Show("로그인 요청 실패: " + result);
            //            return;
            //        }

            //        //var userList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(result);

            //        //if (userList != null && userList.Count > 0)
            //        //{
            //        //    MainForm mainForm = new MainForm();
            //        //    mainForm.Show();

            //        //    this.Hide();
            //        //}
            //        //else
            //        //{
            //        //    MessageBox.Show("ID 또는 PW가 일치하지 않습니다.");
            //        //}

            //        var resultMap = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);

            //        bool success = Convert.ToBoolean(resultMap["success"]);
            //        string message = resultMap["message"].ToString();

            //        if (success)
            //        {
            //            MainForm mainForm = new MainForm();
            //            mainForm.Show();

            //            this.Hide();
            //        }
            //        else
            //        {
            //            MessageBox.Show(message);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("서버 연결 실패: " + ex.Message);
            //}
        }
    }
}
