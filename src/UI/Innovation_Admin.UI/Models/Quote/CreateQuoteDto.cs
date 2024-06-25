using Innovation_Admin.UI.Models.ResponsesModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.Quote
{
    public class CreateQuoteDto
    {
        [JsonProperty("name")]
        [DisplayName("Quote")]
        [Required(ErrorMessage = "Quote is required.")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Quote can only contain characters")]
        [MinLength(2, ErrorMessage = "Quote should be at least 2 characters.")]
        [Remote(action: "IsNameUnique", controller: "Common", ErrorMessage = "Quote is already in use.")]
        [StringLength(100, ErrorMessage = "Quote cannot exceed 100 characters.")]
        public string Name { get; set; }

        [JsonProperty("quoteBy")]
        [Required(ErrorMessage = "Quote By is required.")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Quote By can only contain characters")]
        [MinLength(2, ErrorMessage = "Quote By should be at least 2 characters.")]
        [StringLength(25, ErrorMessage = "Quote By cannot exceed 25 characters")]
        [DisplayName("Quote By")]

        public string QuoteBy { get; set; }
    }
}
