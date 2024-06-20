using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.RemittanceType
{
    public class RemittanceTypeDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name can only contain alphabetic characters and spaces")]
        public string Name { get; set; }

        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
