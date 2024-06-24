using Innovation_Admin.UI.Models.ResponsesModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.ReceiptBatchSource
{
    public class ReceiptBatchSourceDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Receipt Batch should be at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Receipt Batch cannot exceed 50 characters")]
        [Remote(action: "IsBatchUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(Id), ErrorMessage = "Receipt Batch Source is already in use.")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [JsonProperty("type")]
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
    }
}
