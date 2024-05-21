using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany
{
    public class UpdateSysPrefCompanyCommand : IRequest<Response<UpdateSysPrefCompanyDto>>
    {
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string TermForPharmacy { get; set; }
    }
}
