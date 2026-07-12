namespace CeDev.Models.BaseMng
{
    public class TargetSaveModel
    {
        public string year { get; set; }       
        public string reason { get; set; }     
        public string userId { get; set; }     
        public List<TargetItem> gridData { get; set; } 
    }
}

