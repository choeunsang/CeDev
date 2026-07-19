namespace CeDev.Models.BaseMng
{
    public class LotItem
    {
        // 이미지 내 SQL 컬럼 기반 추가 필드
        public string LotId { get; set; }
        public string StdDt { get; set; }
        public string Oper { get; set; }

        // 공정별 시각 (T_...)
        public string TPgIn { get; set; }
        public string TNoGwang { get; set; }
        public string T1stA { get; set; }
        public string T1stA2 { get; set; }
        public string T1stB { get; set; }
        public string T1stB2 { get; set; }
        public string T2nd { get; set; }
        public string TAdd { get; set; }
        public string End { get; set; }

        // 공정별 시간 계산 값 (V_...)
        public double? VPgIn { get; set; }
        public double? VNoGwang { get; set; }
        public double? V1stA { get; set; }
        public double? V1stA2 { get; set; }
        public double? V1stB { get; set; }
        public double? V1stB2 { get; set; }
        public double? V2nd { get; set; }
        public double? VAdd { get; set; }

        // 생성 및 반출 시각
        public string LotCreateTm { get; set; }
        public string LotOutTm { get; set; }

    }
}

