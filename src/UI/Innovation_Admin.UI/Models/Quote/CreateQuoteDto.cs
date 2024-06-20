using Innovation_Admin.UI.Models.ResponsesModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.Quote
{
    public class CreateQuoteDto
    {
        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(25, ErrorMessage = "Name must be 25 characters or less.")]
        public string Name { get; set; }

        [JsonProperty("quoteBy")]
        [Required(ErrorMessage = "Quote By is required.")]
        [StringLength(100, ErrorMessage = "Quote By must be 100 characters or less.")]

        public string QuoteBy { get; set; }
    }
}
