namespace CeDev.Models.BaseMng
{
    public class KpiSaveModel
    {
        public string year { get; set; }       
        public string reason { get; set; }     
        public string userId { get; set; }     
        public List<KpiItem> gridData { get; set; } 
    }
}

