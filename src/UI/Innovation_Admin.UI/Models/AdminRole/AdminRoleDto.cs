using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace Innovation_Admin.UI.Models.AdminRole
{
    public class AdminRoleDto
    {
        [JsonProperty("role_ID")]
        public Guid Role_ID { get; set; }
    
        [JsonProperty("role_Name")]
        [Required(ErrorMessage = "Role Name is required.")]
        [MinLength(2, ErrorMessage = "Role Name should be at least 2 characters.")]
        [Remote(action: "IsRoleNameUnique", controller: "Common", ErrorMessage = "Role Name is already in use.")]
        [StringLength(100, ErrorMessage = "Role Name cannot exceed 21 characters.")]
        public string Role_Name { get; set; }

        [JsonProperty("description")]
        [Required(ErrorMessage = "Description is required.")]
        [MinLength(2, ErrorMessage = "Description should be at least 2 characters.")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 61 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
