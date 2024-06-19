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
        [StringLength(25, ErrorMessage = "Description cannot be longer than 100 characters")]
        public string Description { get; set; }

        [JsonProperty("code")]
        [Required(ErrorMessage = "Code is required")]
        [Range(1, 100, ErrorMessage = "code must be between 1-100")]
        public int Code { get; set; }
    }
}
