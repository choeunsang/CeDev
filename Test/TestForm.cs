using CeDev.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net; // 👈 CookieContainer 사용을 위해 추가
using System.Net.Http; // 👈 HttpClient 사용을 위해 추가
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CeDev.Test
{
    public partial class TestForm : Form
    {
        // -------------------------------------------------------------------------------------------
        // 공통 쿠키 컨테이너 및 HttpClient 설정 (프로그램 실행 동안 쿠키를 유지하기 위함)
        // -------------------------------------------------------------------------------------------
        private static readonly CookieContainer cookieContainer = new CookieContainer();
        private static readonly HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer };
        public static readonly HttpClient client = new HttpClient(handler); // 👈 싱글톤 형태로 유지하여 쿠키 자동 관리

        public TestForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------	
            string userId = "escho";
            string userPw = "1234";

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

            //string url = "http://localhost:9081/api/auth/dologin";

            //var param = new { userId = userId, userPw = userPw };
            //string json = JsonConvert.SerializeObject(param);

            ////-------------------------------------------------------------------------------------------
            //// Processing
            ////-------------------------------------------------------------------------------------------
            //try
            //{
            //    // [수정] 매번 HttpClient를 using으로 생성하면 쿠키가 유실되므로, 외부 static 변수를 사용합니다.
            //    using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            //    {
            //        //HttpResponseMessage response = await client.PostAsync(url, content);
            //        //string result = await response.Content.ReadAsStringAsync();

            //        HttpResponseMessage response = await CeDev.Common.SessionManager.Client.PostAsync(url, content);
            //        string result = await response.Content.ReadAsStringAsync();

            //        if (!response.IsSuccessStatusCode)
            //        {
            //            MessageBox.Show("로그인 요청 실패: " + result);
            //            return;
            //        }

            //        var resultMap = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            //        bool success = Convert.ToBoolean(resultMap["success"]);
            //        string message = resultMap["message"].ToString();

            //        if (success)
            //        {
            //            // -------------------------------------------------------------------------------------------
            //            // [쿠키 확인 디버깅 코드] 서버에서 쿠키가 잘 넘어왔는지 개발자가 확인하는 용도
            //            // -------------------------------------------------------------------------------------------
            //            Uri uri = new Uri(url);
            //            CookieCollection cookies = cookieContainer.GetCookies(uri);
            //            foreach (Cookie cookie in cookies)
            //            {
            //                Console.WriteLine($"쿠키 이름: {cookie.Name}, 값: {cookie.Value}");
            //            }
            //            // -------------------------------------------------------------------------------------------

            //            // 로그인 성공 시 다음 폼으로 이동하며, 생성한 cookieContainer나 client를 넘겨주면 유지가 쉽습니다.
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
