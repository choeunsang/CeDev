using System.Text.Json.Serialization;

namespace CeDev.Models.BaseMng
{
    public class PuItem
    {

        //[JsonPropertyName("puCd")]
        //public string PuCd { get; set; }

        //[JsonPropertyName("puNm")]
        //public string PuNm { get; set; }

        //[JsonPropertyName("parentCd")]
        //public string ParentCd { get; set; }

        //[JsonPropertyName("parentNm")]
        //public string ParentNm { get; set; }


        
        public string puCd { get; set; }

        
        public string puNm { get; set; }

        
        public string parentCd { get; set; }

        public string parentNm { get; set; }
    }
}

