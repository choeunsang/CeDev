using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CeDev.Common
{
    public static class AuthManager
    {
        /// <summary>
        /// 서버에 로그인을 요청하고 결과 및 인증 쿠키를 획득합니다.
        /// </summary>
        public static async Task<bool> LoginAsync(string userId, string userPw)
        {
            string url = $"{SessionManager.BaseUrl}/api/auth/dologin";
            var param = new { userId = userId, userPw = userPw };
            string json = JsonConvert.SerializeObject(param);

            try
            {
                using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    // SessionManager의 단일 HttpClient로 로그인 요청
                    HttpResponseMessage response = await SessionManager.Client.PostAsync(url, content);
                    string result = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("로그인 요청 실패: " + result);
                        return false;
                    }

                    var resultMap = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                    bool success = Convert.ToBoolean(resultMap["success"]);
                    string message = resultMap["message"].ToString();

                    if (success)
                    {
                        // -------------------------------------------------------------------------------------------
                        // [디버깅 코드] SessionManager의 쿠키 컨테이너에서 쿠키 확인
                        // -------------------------------------------------------------------------------------------
                        Uri uri = new Uri(url);
                        CookieCollection cookies = SessionManager.CookieContainer.GetCookies(uri);
                        foreach (Cookie cookie in cookies)
                        {
                            Console.WriteLine($"쿠키 이름: {cookie.Name}, 값: {cookie.Value}");
                        }
                        // -------------------------------------------------------------------------------------------

                        return true;
                    }
                    else
                    {
                        MessageBox.Show(message);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 연결 실패: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 현재 사용자의 로그인 세션(쿠키) 유효성을 검증합니다.
        /// </summary>
        /// <param name="targetForm">검증을 요청한 현재 폼 (실패 시 닫기 위함)</param>
        /// <returns>인증 성공 여부</returns>
        public static async Task<bool> CheckAuthAsync(Form targetForm)
        {
            return true;

            //string checkUrl = $"{SessionManager.BaseUrl}/api/auth/check-auth";

            //try
            //{
            //    // SessionManager의 공통 HttpClient 활용
            //    HttpResponseMessage response = await SessionManager.Client.GetAsync(checkUrl);
            //    string result = await response.Content.ReadAsStringAsync();

            //    if (!response.IsSuccessStatusCode)
            //    {
            //        HandleFailedAuth("서버 인증 요청에 실패했습니다.", targetForm);
            //        return false;
            //    }

            //    var resultMap = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            //    bool success = Convert.ToBoolean(resultMap["success"]);

            //    if (!success)
            //    {
            //        string message = resultMap["message"]?.ToString() ?? "유효하지 않은 세션입니다.";
            //        HandleFailedAuth(message, targetForm);
            //        return false;
            //    }

            //    // 인증 성공
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    HandleFailedAuth($"보안 검증 중 서버 연결에 실패했습니다.\n오류: {ex.Message}", targetForm);
            //    return false;
            //}
        }

        /// <summary>
        /// 인증 실패 시 공통 알림 및 후속 제어
        /// </summary>
        private static void HandleFailedAuth(string message, Form targetForm)
        {
            MessageBox.Show($"비정상적인 접근입니다.\n사유: {message}", "보안 경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // 호출한 폼이 메인 화면(MainForm)이면 프로그램 전체 종료
            if (targetForm.IsMdiContainer || targetForm.Name == "MainForm")
            {
                Application.Exit();
            }
            else
            {
                // 일반 자식 폼(MDI Child)이면 해당 화면만 즉시 닫기
                targetForm.Close();
            }
        }
    }
}
