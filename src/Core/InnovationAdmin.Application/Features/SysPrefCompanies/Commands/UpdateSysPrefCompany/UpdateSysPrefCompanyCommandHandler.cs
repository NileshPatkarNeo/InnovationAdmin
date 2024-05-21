using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Helper;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;


namespace InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany
{
    
    public class UpdateSysPrefCompanyCommandHandler : IRequestHandler<UpdateSysPrefCompanyCommand, Response<UpdateSysPrefCompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISysPrefCompanyRepository _sysPrefCompanyRepository;

        public UpdateSysPrefCompanyCommandHandler(IMapper mapper, ISysPrefCompanyRepository sysPrefCompanyRepository)
        {
            _mapper = mapper;
            _sysPrefCompanyRepository = sysPrefCompanyRepository;
        }

        public async Task<Response<UpdateSysPrefCompanyDto>> Handle(UpdateSysPrefCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToUpdate = await _sysPrefCompanyRepository.GetByIdAsync(request.CompanyID);

            if (companyToUpdate == null)
            {
                throw new NotFoundException(nameof(SysPrefCompany), request.CompanyID);
            }

            companyToUpdate.CompanyName = request.CompanyName;
            companyToUpdate.TermForPharmacy = request.TermForPharmacy;
            companyToUpdate.LastModifiedDate = DateTime.Now; 

            await _sysPrefCompanyRepository.UpdateAsync(companyToUpdate);

            var companyDto = _mapper.Map<UpdateSysPrefCompanyDto>(companyToUpdate);

            return new Response<UpdateSysPrefCompanyDto>(companyDto, "SysPrefCompany updated successfully");
        }
    }

}
