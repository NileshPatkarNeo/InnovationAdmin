using Innovation_Admin.UI.Models.ResponsesModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.AdminUser
{
    public class CreateAdminUserDto
    {
        [JsonProperty("user_Name")]
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(100, ErrorMessage = "User Name cannot be longer than 100 characters")]
        public string User_Name { get; set; }

        [JsonProperty("role")]
        [Required(ErrorMessage = "Role is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Role must be a valid number")]
        public int Role { get; set; }

        [JsonProperty("email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [JsonProperty("password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters long")]
        public string Password { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

    }
}
