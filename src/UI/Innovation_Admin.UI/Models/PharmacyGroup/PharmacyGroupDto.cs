using Innovation_Admin.UI.Models.ResponsesModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.PharmacyGroup
{
    public class PharmacyGroupDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("pharmacyName")]
        [Required(ErrorMessage = "Pharmacy Name is required")]
        [StringLength(25, ErrorMessage = "Pharmacy Name cannot be longer than 100 characters")]
        public string PharmacyName { get; set; }
    }
}
