using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovation_Admin.UI.Models.Template
{
    public class CreateTemplateDto
    {
        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less.")]
        public string Name { get; set; }

        //[JsonProperty("pdfTemplateFile")]
        
        public string? PdfTemplateFile { get; set; }

        [JsonProperty("domain")]
        [Required(ErrorMessage = "Domain is required.")]
        [StringLength(50, ErrorMessage = "Domain must be 50 characters or less.")]
        public string Domain { get; set; }

        [JsonProperty("size")]

        public string? Size { get; set; }
        [NotMapped]
        public IFormFile PdfFile { get; set; }

       
    }
}
