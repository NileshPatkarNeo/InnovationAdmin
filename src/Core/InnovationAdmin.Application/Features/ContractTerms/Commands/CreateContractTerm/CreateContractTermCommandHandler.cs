using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ContractTerms.Commands.CreateContractTerm
{
    public class CreateContractTermCommandHandler : IRequestHandler<CreateContractTermCommand, Response<CreateContractTermDto>>
    {
        private readonly IContractTermsRepository _contractTermsRepository;
        private readonly IMapper _mapper;

        public CreateContractTermCommandHandler(IContractTermsRepository contractTermsRepository, IMapper mapper)
        {
            _contractTermsRepository = contractTermsRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateContractTermDto>> Handle(CreateContractTermCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateContractTermCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var contractTerm = new Domain.Entities.ContractTerms

            {
                Name = request.Name,
                ContractType = request.ContractType,
                ContractTypeCode = request.ContractTypeCode
            };

            contractTerm = await _contractTermsRepository.AddAsync(contractTerm);

            var response = new Response<CreateContractTermDto>(_mapper.Map<CreateContractTermDto>(contractTerm), "success");

            return response;
        }
    }
}
