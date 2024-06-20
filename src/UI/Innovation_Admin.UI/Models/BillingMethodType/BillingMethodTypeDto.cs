using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.BillingMethodType
{
    public class BillingMethodTypeDto
    {

        [JsonProperty("ID")]
        public Guid ID { get; set; }

        [JsonProperty("Name")]
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Name should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Name can only contain alphanumeric characters and spaces.")]

        public string Name { get; set; }

        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
