using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Innovation_Admin.UI.Models.SysPrefCompany
{
    public class SysPrefCompanyDto
    {
        [JsonProperty("companyID")]
        public Guid CompanyID { get; set; }

        [JsonProperty("companyName")]
        [Display(Name = "Company Name")]

    
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Remote(action: "IsCompanyUnique", controller: "Common", AdditionalFields = "__RequestVerificationToken," + nameof(CompanyID), ErrorMessage = "Name is already in use.")]
        public string CompanyName { get; set; }

        [JsonProperty("termForPharmacy")]
        [Display(Name = "Term For Pharmacy")]
        [Required(ErrorMessage = "Term For Pharmacy is required")]
        [MinLength(2, ErrorMessage = "Term For Pharmacy be at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Term For Pharmacy cannot exceed 100 characters")]
        public string TermForPharmacy { get; set; }

        
        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }

}
