using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany
{
    public class CreateSysPrefCompanyCommand : IRequest<Response<CreateSysPrefCompanyDto>>
    {
        public string CompanyName { get; set; }
        public string TermForPharmacy { get; set; }
    }
}
