using Innovation_Admin.UI.Models.ResponsesModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.Quote
{
    public class QuoteDto
    {
        [JsonProperty("iD")]
        public Guid ID { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Quote is required.")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Name can only contain characters")]
        [MinLength(2, ErrorMessage = "Quote should be at least 2 characters.")]
        [Remote(action: "IsNameUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(ID),
         ErrorMessage = "Quote is already in use.")]
        [StringLength(100, ErrorMessage = "Quote Name cannot exceed 100 characters.")]
        [DisplayName("Quote")]
        public string Name { get; set; }

        [JsonProperty("quoteBy")]
        [Required(ErrorMessage = "Quote By is required.")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Name can only contain characters")]
        [MinLength(2, ErrorMessage = "Quote By should be at least 2 characters.")]
        [StringLength(50, ErrorMessage = "Quote Name cannot exceed 50 characters.")]
        [Display(Name="Quote By")]
        public string QuoteBy { get; set; }

        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
