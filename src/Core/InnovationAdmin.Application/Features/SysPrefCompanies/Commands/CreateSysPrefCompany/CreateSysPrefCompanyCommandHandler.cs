
using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;

using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;

namespace InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany
{
    public class CreateSysPrefCompanyCommandHandler : IRequestHandler<CreateSysPrefCompanyCommand, Response<CreateSysPrefCompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISysPrefCompanyRepository _sysPrefCompanyRepository;
        private readonly IMessageRepository _messageRepository;

        public CreateSysPrefCompanyCommandHandler(IMapper mapper, ISysPrefCompanyRepository sysPrefCompanyRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _sysPrefCompanyRepository = sysPrefCompanyRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CreateSysPrefCompanyDto>> Handle(CreateSysPrefCompanyCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSysPrefCompanyCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

             if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var company = new SysPrefCompany
            {
                CompanyName = request.CompanyName,
                TermForPharmacy = request.TermForPharmacy
            };

            
            Console.WriteLine($"CreatedBy: {company.CreatedBy}");

            company = await _sysPrefCompanyRepository.AddAsync(company);


            var companyDto = _mapper.Map<CreateSysPrefCompanyDto>(company);

            return new Response<CreateSysPrefCompanyDto>(companyDto, "success");
        }
    }
}
