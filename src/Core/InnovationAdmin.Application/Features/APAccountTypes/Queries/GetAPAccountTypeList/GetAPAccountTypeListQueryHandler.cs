using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InnovationAdmin.Application.Features.APAccountTypes.Queries.GetAPAccountTypeList
{
    public class GetAPAccountTypeListQueryHandler : IRequestHandler<GetAPAccountTypeListQuery, Response<IEnumerable<GetAPAccountTypeListVm>>>
    {
        private readonly IAPAccountTypeRepository _aPAccountTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetAPAccountTypeListQueryHandler(IMapper mapper, IAPAccountTypeRepository aPAccountTypeRepository, ILogger<GetAPAccountTypeListQueryHandler> logger)
        {
            _mapper = mapper;
            _aPAccountTypeRepository = aPAccountTypeRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetAPAccountTypeListVm>>> Handle(GetAPAccountTypeListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allAccountType = (await _aPAccountTypeRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();
            var accountType = _mapper.Map<IEnumerable<GetAPAccountTypeListVm>>(allAccountType);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetAPAccountTypeListVm>>(accountType, "success");
        }

    }
}
