namespace CeDev.Models
{
    public class UserDto
    {
        //-------------------------------------------------------------------------------------------
        // Declare and initialize variables
        //-------------------------------------------------------------------------------------------
        public int UserSeq { get; set; }

        public string UserId { get; set; }

        public string UserPw { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string DeptCd { get; set; }

        public string RoleCd { get; set; }

        public string UseYn { get; set; }

        public DateTime? RegDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}