namespace CeDev.Models.BaseMng
{
    public class PuSaveModel
    {
        //public string year { get; set; }       
        //public string reason { get; set; }     
        public string userId { get; set; }     
        public List<PuSaveItem> gridData { get; set; } 
    }

    public class PuSaveItem
    {
        public string puCd { get; set; }
        public string puNm { get; set; }
        public string parentCd { get; set; }

        public string parentNm { get; set; }
    }
}

