using Innovation_Admin.UI.Models.ResponsesModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.Account_Manager
{
    public class AccountManagerDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Remote(action: "IsManagerUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(Id), ErrorMessage = "Name is already in use.")]
      
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
