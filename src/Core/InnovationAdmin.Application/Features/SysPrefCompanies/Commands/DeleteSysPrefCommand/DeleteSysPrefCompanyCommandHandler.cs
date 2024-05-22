using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefCompanies.Commands.DeleteSysPrefCommand
{
    public class DeleteSysPrefCompanyCommandHandler : IRequestHandler<DeleteSysPrefCompanyCommand, Response<bool>>
    {
        private readonly ISysPrefCompanyRepository _sysPrefCompanyRepository;

        public DeleteSysPrefCompanyCommandHandler(ISysPrefCompanyRepository sysPrefCompanyRepository)
        {
            _sysPrefCompanyRepository = sysPrefCompanyRepository;
        }

        public async Task<Response<bool>> Handle(DeleteSysPrefCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToDelete = await _sysPrefCompanyRepository.GetByIdAsync(request.CompanyId);

            if (companyToDelete == null)
            {
                return new Response<bool>($"SysPrefCompany with id {request.CompanyId} not found.");
            }

            await _sysPrefCompanyRepository.DeleteAsync(companyToDelete);

            return new Response<bool>(true, "SysPrefCompany deleted successfully.");
        }
    }

}
