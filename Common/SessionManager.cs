using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CeDev.Common
{
    public static class SessionManager
    {
        // 프로젝트 전체에서 단 하나만 존재하며 쿠키를 유지하는 HttpClient
        public static readonly CookieContainer CookieContainer = new CookieContainer();
        private static readonly HttpClientHandler Handler = new HttpClientHandler() { CookieContainer = CookieContainer };

        public static readonly HttpClient Client = new HttpClient(Handler);

        // 기본 서버 주소를 고정해두면 나중에 URL 관리하기도 편합니다.
        public static readonly string BaseUrl = "http://localhost:9081";
    }
}
