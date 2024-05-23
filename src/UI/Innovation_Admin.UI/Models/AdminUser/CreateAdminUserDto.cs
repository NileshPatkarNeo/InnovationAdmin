using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.AdminUser
{
    public class CreateAdminUserDto
    {
        [JsonProperty("user_Name")]
        public string User_Name { get; set; }

        [JsonProperty("role")]
        public int Role { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
