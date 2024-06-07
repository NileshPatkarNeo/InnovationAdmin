using Innovation_Admin.UI.Models.ResponsesModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.AdminUser
{
    public class CreateAdminUserDto
    {
        [JsonProperty("user_Name")]
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(20, ErrorMessage = "User Name cannot be longer than 20 characters")]
        public string User_Name { get; set; }

        [JsonProperty("role")]
        [Required(ErrorMessage = "Role is required")]
        //[Range(1, int.MaxValue, ErrorMessage = "Role must be a valid number")]
        public Guid Role { get; set; }

        [JsonProperty("roleName")]
        [Required(ErrorMessage = "Role is required")]
        //[Range(1, int.MaxValue, ErrorMessage = "Role must be a valid number")]
        public string RoleName { get; set; }

        [JsonProperty("email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [JsonProperty("password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 40 characters long")]
        public string Password { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

       
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }


    }
}
