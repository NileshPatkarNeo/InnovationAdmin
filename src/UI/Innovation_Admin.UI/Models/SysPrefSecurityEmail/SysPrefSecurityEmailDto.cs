using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.SysPrefSecurityEmail
{
    public class SysPrefSecurityEmailDto
    {
        [JsonProperty("sysPrefSecurityEmailId")]
        public Guid SysPrefSecurityEmailId { get; set; }

        [JsonProperty("defaultFromName")]
        [Required(ErrorMessage = "Default From Name is required.")]
        [StringLength(20, ErrorMessage = "Default From Name cannot exceed 50 characters.")]
        [Remote(action: "IsSecurityEmailUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(SysPrefSecurityEmailId), ErrorMessage = "Name is already in use.")]
        public string DefaultFromName { get; set; }

        [JsonProperty("defaultFromAddress")]
        [Required(ErrorMessage = "Default From Address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100, ErrorMessage = "Default From Address cannot exceed 100 characters.")]
        public string DefaultFromAddress { get; set; }

        [JsonProperty("defaultReplyToAddress")]
        [Required(ErrorMessage = "Default Reply To Address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100, ErrorMessage = "Default Reply To Address cannot exceed 100 characters.")]
        public string DefaultReplyToAddress { get; set; }

        [JsonProperty("defaultReplyToName")]
        [Required(ErrorMessage = "Default Reply To Name is required.")]
        [StringLength(20, ErrorMessage = "Default Reply To Name cannot exceed 50 characters.")]
        public string DefaultReplyToName { get; set; }

        [JsonProperty("status")]
        [Required(ErrorMessage = "Status is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Status must be a valid number.")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
