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
        [StringLength(100, ErrorMessage = "Note cannot be longer than 100 characters")]
        public string Note { get; set; }

        [StringLength(1000)]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }

}
