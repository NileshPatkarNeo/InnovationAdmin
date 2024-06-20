using Microsoft.AspNetCore.Mvc;
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
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters.")]
        [Remote(action: "IsTemplateNameUnique", controller: "Common", ErrorMessage = "Name is already in use.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters..")]
        public string Name { get; set; }

        [Display(Name = "Pdf Template File")]
        public string? PdfTemplateFile { get; set; }

        [JsonProperty("domain")]
        [Required(ErrorMessage = "Domain is required.")]
        [StringLength(50, ErrorMessage = "Domain cannot exceed 50 characters..")]
        public string Domain { get; set; }

        [JsonProperty("size")]

        public string? Size { get; set; }
        [NotMapped]

        [DisplayName("Pdf File")]
        public IFormFile PdfFile { get; set; }

       
    }
}
