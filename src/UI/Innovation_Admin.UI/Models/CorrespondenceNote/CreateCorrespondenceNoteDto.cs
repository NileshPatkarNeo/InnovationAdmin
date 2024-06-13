using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.CorrespondenceNote
{
    public class CreateCorrespondenceNoteDto
    {
        [JsonProperty("note")]
        [Required(ErrorMessage = "Note is required.")]
        [MaxLength(50, ErrorMessage = "Note cannot exceed 50 characters.")]
        //[MinLength(2, ErrorMessage = "Note should have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Name can only contain alphanumeric characters and spaces.")]

        public string Note { get; set; }

        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
