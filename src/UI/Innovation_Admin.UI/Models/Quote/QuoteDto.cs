using Innovation_Admin.UI.Models.ResponsesModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.Quote
{
    public class QuoteDto
    {
        [JsonProperty("iD")]
        public Guid ID { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(25, ErrorMessage = "Name must be 25 characters or less.")]
        public string Name { get; set; }

        [JsonProperty("quoteBy")]
        [Required(ErrorMessage = "Quote By is required.")]
        [StringLength(100, ErrorMessage = "Quote By must be 100 characters or less.")]
        [Display(Name="Quote By")]
        public string QuoteBy { get; set; }

        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
