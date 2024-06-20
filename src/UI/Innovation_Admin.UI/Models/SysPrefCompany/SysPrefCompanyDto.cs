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
        public string CompanyName { get; set; }

        [JsonProperty("termForPharmacy")]
        [Display(Name = "Term For Pharmacy")]
        public string TermForPharmacy { get; set; }

        
        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }

}
