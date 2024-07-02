using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.CategoryType
{
    public class CreateCategoryTypeDto
    {

        [JsonProperty("id")]
        public Guid ID { get; set; }

        [JsonProperty("documentName")]
        [Required(ErrorMessage = "Document Name is required.")]
        [MaxLength(50, ErrorMessage = "Document Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Document Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Document Name can only contain alphanumeric characters and spaces.")]
        [Remote(action: "IsDocumentNameUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(ID), ErrorMessage = "Document Type is already in use.")]

        public string DocumentName { get; set; }

        [JsonProperty("groupName")]
        [Required(ErrorMessage = "Group Name is required.")]
        [MaxLength(50, ErrorMessage = "Group Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Group Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Group Name can only contain alphanumeric characters and spaces.")]
        [Remote(action: "IsGroupNameUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(ID), ErrorMessage = "Group Name is already in use.")]
        public string GroupName { get; set; }

        [JsonProperty("claimName")]
        [Required(ErrorMessage = "Claim Name is required.")]
        [MaxLength(50, ErrorMessage = "Claim Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Claim Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Claim Name can only contain alphanumeric characters and spaces.")]
        [Remote(action: "IsClaimNameUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(ID), ErrorMessage = "Claim Name is already in use.")]
        public string ClaimName { get; set; }

        [JsonProperty("adjustmentName")]
        [Required(ErrorMessage = "Adjustment Name is required.")]
        [MaxLength(50, ErrorMessage = "Adjustment Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Adjustment Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Adjustment Name can only contain alphanumeric characters and spaces.")]
        [Remote(action: "IsAdjustmentNameUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(ID), ErrorMessage = "Adjustment Name is already in use.")]
        public string AdjustmentName { get; set; }

        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
