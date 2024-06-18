using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;


namespace InnovationAdmin.Application.Features.ContractTerms.Queries.GetContractTermsList
{
    public class GetContractTermsListQueryHandler : IRequestHandler<GetContractTermsListQuery, Response<IEnumerable<ContractTermListVM>>>
    {
        private readonly IAsyncRepository<Domain.Entities.ContractTerms> _contractTermsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractTermsListQueryHandler> _logger;

        public GetContractTermsListQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.ContractTerms> contractTermsRepository, ILogger<GetContractTermsListQueryHandler> logger)
        {
            _mapper = mapper;
            _contractTermsRepository = contractTermsRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ContractTermListVM>>> Handle(GetContractTermsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allContractTerms = (await _contractTermsRepository.ListAllAsync()).OrderBy(x => x.Name);
            var contractTermsList = _mapper.Map<IEnumerable<ContractTermListVM>>(allContractTerms);
            _logger.LogInformation("Handle Completed");
            return new Response<IEnumerable<ContractTermListVM>>(contractTermsList, "success");
        }
    }
}
