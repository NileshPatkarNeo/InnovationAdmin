using Newtonsoft.Json;
using System.ComponentModel;
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
        [Display(Name = "Pdf Template File")]
        public string? PdfTemplateFile { get; set; }

        [JsonProperty("domain")]
        [Required(ErrorMessage = "Domain is required.")]
        [StringLength(50, ErrorMessage = "Domain must be 50 characters or less.")]
        public string Domain { get; set; }

        [JsonProperty("size")]

        public string? Size { get; set; }
        [NotMapped]

        [DisplayName("Pdf File")]
        public IFormFile PdfFile { get; set; }

       
    }
}
