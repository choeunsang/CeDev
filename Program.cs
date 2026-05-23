using CeDev.DataMng;
using CeDev.Login;
using CeDev.Test;

namespace CeDev.Login
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            ////테스트
            //Application.Run(new TestForm());

            ////사용자 정보
            //Application.Run(new UserInfo());

            ////부동산 자료 업데이트
            //Application.Run(new DataUpdate());

            ////전월세 정보
            //Application.Run(new RentInfo());


            ////(0).로그인
            //Application.Run(new Login());

            //(1).메인화면
            Application.Run(new MainForm());

            ////(2).주택 거래량
            ////Application.Run(new HousTradVolume());            
            //Application.Run(new HousTradDetailVolume());

            //////(3).주택 거래량 시별 통계
            //Application.Run(new HousTradSigunguDetailVolume());

            ////(4).주택가격 변동상세
            ////Application.Run(new ReceTran());
            //Application.Run(new TotalTran());
        }
    }
}