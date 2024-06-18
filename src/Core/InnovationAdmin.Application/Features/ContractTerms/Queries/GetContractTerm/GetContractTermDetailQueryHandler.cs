using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ContractTerms.Queries.GetContractTerm
{
    public class GetContractTermDetailQueryHandler : IRequestHandler<GetContractTermDetailQuery, Response<ContractTermVM>>
    {
        private readonly IAsyncRepository<Domain.Entities.ContractTerms> _contractTermsRepository;
        private readonly IMapper _mapper;

        public GetContractTermDetailQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.ContractTerms> contractTermsRepository)
        {
            _mapper = mapper;
            _contractTermsRepository = contractTermsRepository;
        }

        public async Task<Response<ContractTermVM>> Handle(GetContractTermDetailQuery request, CancellationToken cancellationToken)
        {
            var contractTerm = await _contractTermsRepository.GetByIdAsync(request.ID);

            if (contractTerm == null)
            {
                throw new NotFoundException(nameof(ContractTermVM), request.ID);
            }

            var contractTermDetailDto = _mapper.Map<ContractTermVM>(contractTerm);
            var response = new Response<ContractTermVM>(contractTermDetailDto);
            return response;
        }
    }
}
