using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.CorrespondenceNote
{
    public class CorrespondenceNoteDto
    {
  

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("note")]
        [Required(ErrorMessage = "Note is required")]
        [MinLength(2, ErrorMessage = "Note should have at least 2 characters.")]
        [StringLength(50, ErrorMessage = "Note cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name can only contain alphanumeric characters and spaces.")]
        [Remote(action: "IsNoteUnique", controller: "Common", ErrorMessage = "Note is already in use.")]
        public string Note { get; set; }

        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }

}
