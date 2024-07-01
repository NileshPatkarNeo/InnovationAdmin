using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.CategoryType
{
    public class CategoryTypeDto
    {
        [JsonProperty("ID")]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Document Name is required.")]
        [MaxLength(50, ErrorMessage = "Document Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Document Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Document Name can only contain alphanumeric characters and spaces.")]
        public string DocumentName { get; set; }

        [Required(ErrorMessage = "Group Name is required.")]
        [MaxLength(50, ErrorMessage = "Group Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Group Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Group Name can only contain alphanumeric characters and spaces.")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Claim Name is required.")]
        [MaxLength(50, ErrorMessage = "Claim Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Claim Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Claim Name can only contain alphanumeric characters and spaces.")]
        public string ClaimName { get; set; }

        [Required(ErrorMessage = "Adjustment Name is required.")]
        [MaxLength(50, ErrorMessage = "Adjustment Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Adjustment Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Adjustment Name can only contain alphanumeric characters and spaces.")]
        public string AdjustmentName { get; set; }

        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
