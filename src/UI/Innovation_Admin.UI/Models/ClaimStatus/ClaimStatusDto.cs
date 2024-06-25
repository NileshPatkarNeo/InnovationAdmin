using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.ClaimStatus
{
    public class ClaimStatusDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Remote(action: "IsStatusUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(Id), ErrorMessage = "Name is already in use.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [Remote(action: "IsColorUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(Id), ErrorMessage = "Color is already in use.")]
        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
