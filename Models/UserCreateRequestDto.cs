using Newtonsoft.Json;

namespace CeDev.Models
{
    public class UserCreateRequestDto
    {
        //-------------------------------------------------------------------------------------------
        // Declare and initialize variables
        //-------------------------------------------------------------------------------------------
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("userPw")]
        public string UserPw { get; set; }
    }
}