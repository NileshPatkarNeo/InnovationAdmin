using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.BillingMethodType
{
    public class CreateBillingMethodTypeDto
    {
        [JsonProperty("Name")]
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name can only contain characters")]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters.")]
        [MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        [Remote(action: "IsBillingMethodTypeUnique", controller: "Common", ErrorMessage = "Name is already in use.")]
        public string Name { get; set; }

        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
