using Innovation_Admin.UI.Models.ResponsesModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.PharmacyGroup
{
    public class PharmacyGroupDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("pharmacyName")]
        [Required(ErrorMessage = "Pharmacy Name is required")]
        [StringLength(25, ErrorMessage = "Pharmacy Name cannot be longer than 25 characters")]
        [MinLength(2, ErrorMessage = "Pharmacy Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Pharmacy Name can only contain alphabetic characters and spaces")]
        [Remote(action: "IsPharmacyNameUnique", controller: "Common", ErrorMessage = "Pharmacy Name is already in use.")]
        public string PharmacyName { get; set; }

        
        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
