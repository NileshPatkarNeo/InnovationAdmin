using InnovationAdmin.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany
{
    public class CreateSysPrefCompanyCommand : IRequest<Response<CreateSysPrefCompanyDto>>
    {
        [Required]
        public string CompanyName { get; set; }
        
        public string TermForPharmacy { get; set; }
    }
}
