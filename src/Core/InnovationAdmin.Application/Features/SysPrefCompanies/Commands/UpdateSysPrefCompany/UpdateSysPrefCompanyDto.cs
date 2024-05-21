

namespace InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany
{
    public class UpdateSysPrefCompanyDto
    {
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string TermForPharmacy { get; set; }
    }
}
