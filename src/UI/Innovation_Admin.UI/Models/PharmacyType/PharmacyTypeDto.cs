using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.PharmacyType
{
    public class PharmacyTypeDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, ErrorMessage = "Description cannot be longer than 50 characters")]
        [MinLength(2, ErrorMessage = "Description should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Description can only contain alphabetic characters and spaces")]
        [Remote(action: "IsPharmacyTypeUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(Id), ErrorMessage = "Pharmacy Type is already in use.")]
        public string Description { get; set; }

        [JsonProperty("code")]
        [Required(ErrorMessage = "Code is required")]
        [Range(1, 100, ErrorMessage = "code must be between 1-100")]
        [Remote(action: "IsPharmacyCodeUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(Id), ErrorMessage = "Code is already in use.")]
        public int Code { get; set; }

        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }

    }
}
