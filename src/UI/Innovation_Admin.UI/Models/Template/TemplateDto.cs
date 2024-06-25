using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.Template
{
    public class TemplateDto
    {
        [JsonProperty("id")]
        public Guid ID { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Name can only contain characters")]
        [Remote(action: "IsTemplateNameUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(ID), ErrorMessage = "Name is already in use.")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less.")]
        public string Name { get; set; }

        [JsonProperty("pdfTemplateFile")]
        [DisplayName("pdf Template File")]
        public string? PdfTemplateFile { get; set; }

        [JsonProperty("domain")]
        [Required(ErrorMessage = "Domain is required.")]
        [StringLength(50, ErrorMessage = "Domain must be 50 characters or less.")]
        public string Domain { get; set; }



        public string? Size { get; set; }

        [DisplayName("Pdf File")]
        public IFormFile? PdfFile { get; set; }


    }
}
