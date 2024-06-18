using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ContractTerms.Commands.UpdateContractTerm
{
    public class UpdateContractTermCommandHandler : IRequestHandler<UpdateContractTermCommand, Response<UpdateContractTermDto>>
    {
        private readonly IContractTermsRepository _contractTermsRepository;
        private readonly IMapper _mapper;
       

        public UpdateContractTermCommandHandler(IMapper mapper, IContractTermsRepository contractTermsRepository)
        {
            _mapper = mapper;
            _contractTermsRepository = contractTermsRepository;
           
        }

        public async Task<Response<UpdateContractTermDto>> Handle(UpdateContractTermCommand request, CancellationToken cancellationToken)
        {
            var contractTermToUpdate = await _contractTermsRepository.GetByIdAsync(request.ID);

            if (contractTermToUpdate == null)
            {
                throw new NotFoundException(nameof(UpdateContractTermDto), request.ID);
            }

            var validator = new UpdateContractTermCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, contractTermToUpdate);

            await _contractTermsRepository.UpdateAsync(contractTermToUpdate);
            var dto = new UpdateContractTermDto
            {
                ID = request.ID,
                Name = request.Name,
                ContractType = request.ContractType,
                ContractTypeCode = request.ContractTypeCode
            };
            return new Response<UpdateContractTermDto>(dto, "Updated successfully");
        }
    }
}
