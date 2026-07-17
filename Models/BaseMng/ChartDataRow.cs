namespace CeDev.Models.BaseMng
{
    public class ChartDataRow
    {
        public string Gubun { get; set; }  // "금일", "주별", "월별"
        public string SectNm { get; set; } // "PG In", "노광", "1st A" 등
        public double Val { get; set; }    // 실적 수치

    }
}

