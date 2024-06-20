using Innovation_Admin.UI.Models.ResponsesModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.AdminUser
{
    public class AdminUserDto
    {

        [JsonProperty("user_ID")]
        public Guid User_ID { get; set; }

        [JsonProperty("user_Name")]
        [Required(ErrorMessage = "User Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name can only contain characters")]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters.")]
        [StringLength(30, ErrorMessage = "User Name cannot be longer than 30 characters")]
        [Remote(action: "IsAdminUserUnique", controller: "Common", ErrorMessage = "Name is already in use.")]
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
