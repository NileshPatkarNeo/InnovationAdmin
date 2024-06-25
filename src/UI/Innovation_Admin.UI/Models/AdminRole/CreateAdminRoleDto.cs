using Innovation_Admin.UI.Models.ResponsesModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.AdminRole
{
    public class CreateAdminRoleDto
    {
        [JsonProperty("role_Name")]
        [Required(ErrorMessage = "Role Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Name can only contain characters")]
        [MinLength(2, ErrorMessage = "Role Name should be at least 2 characters.")]
        [Remote(action: "IsRoleNameUnique", controller: "Common", ErrorMessage = "Role Name is already in use.")]
        [StringLength(50, ErrorMessage = "Role Name cannot exceed 50 characters.")]
        public string Role_Name{ get; set; }

        [JsonProperty("description")]
        [Required(ErrorMessage = "Description is required.")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Description can only contain characters")]
        [MinLength(2, ErrorMessage = "Description should be at least 2 characters.")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
