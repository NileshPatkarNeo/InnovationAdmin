using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.SysPrefCompany
{
    public class SysPrefCompanyDto
    {
        [JsonProperty("companyID")]
        public Guid CompanyID { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("termForPharmacy")]
        public string TermForPharmacy { get; set; }
    }

}
