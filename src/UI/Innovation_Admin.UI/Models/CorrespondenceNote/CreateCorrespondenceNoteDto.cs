using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.CorrespondenceNote
{
    public class CreateCorrespondenceNoteDto
    {
        [JsonProperty("note")]
        [Required(ErrorMessage = "Note is required.")]
        [MaxLength(50, ErrorMessage = "Note cannot exceed 50 characters.")]
        [MinLength(2, ErrorMessage = "Note should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Note can only contain alphanumeric characters and spaces.")]
        [Remote(action: "IsNoteUnique", controller: "Common", ErrorMessage = "Note is already in use.")]
        public string Note { get; set; }

        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
