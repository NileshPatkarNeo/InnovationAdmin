using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.SysPrefSecurityEmail
{
    public class CreateSysPrefSecurityEmailDto
    {
        //[JsonProperty("sysPrefSecurityEmailId")]
        //public Guid SysPrefSecurityEmailId { get; set; }

        [JsonProperty("defaultFromName")]
        [Required(ErrorMessage = "Default From Name is required.")]
        [MaxLength(20, ErrorMessage = "Default From Name cannot exceed 20 characters.")]
        [Remote(action: "IsSecurityEmailUnique", controller: "Common", ErrorMessage = "Name is already in use.")]
        public string DefaultFromName { get; set; }

        [JsonProperty("defaultFromAddress")]
        [Required(ErrorMessage = "Default From Address is required.")]
        [MaxLength(100, ErrorMessage = "Default From Address cannot exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string DefaultFromAddress { get; set; }

        [JsonProperty("defaultReplyToAddress")]
        [Required(ErrorMessage = "Default Reply To Address is required.")]
        [MaxLength(100, ErrorMessage = "Default Reply To Address cannot exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string DefaultReplyToAddress { get; set; }

        [JsonProperty("defaultReplyToName")]
        [Required(ErrorMessage = "Default Reply To Name is required.")]
        [MaxLength(20, ErrorMessage = "Default Reply To Name cannot exceed 20 characters.")]
        public string DefaultReplyToName { get; set; }

        [JsonProperty("status")]
        [Required(ErrorMessage = "Status is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Status must be a valid number.")]
        public int Status { get; set; }
    }
}
