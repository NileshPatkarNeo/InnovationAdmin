using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.ResponsesModel.Login
{
    public class AuthenticationRequest
    {
        [JsonProperty("email")]
        [Required]
        public string Email { get; set; }

        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }
    }
}
