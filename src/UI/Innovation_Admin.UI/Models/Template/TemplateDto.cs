using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.Template
{
    public class TemplateDto
    {
        [JsonProperty("id")]
        public Guid ID { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less.")]
        public string Name { get; set; }

        [JsonProperty("pdfTemplateFile")]
        [Required(ErrorMessage = "PDF Template File is required.")]
        [StringLength(200, ErrorMessage = "Domain must be 200 characters or less.")]

        public string PdfTemplateFile { get; set; }

        [JsonProperty("domain")]
        [Required(ErrorMessage = "Domain is required.")]
        [StringLength(50, ErrorMessage = "Domain must be 50 characters or less.")]
        public string Domain { get; set; }

        [JsonProperty("size")]
        [Required(ErrorMessage = "Size is required.")]
        [StringLength(50, ErrorMessage = "Domain must be 50 characters or less.")]

        public string Size { get; set; }
    }
}
