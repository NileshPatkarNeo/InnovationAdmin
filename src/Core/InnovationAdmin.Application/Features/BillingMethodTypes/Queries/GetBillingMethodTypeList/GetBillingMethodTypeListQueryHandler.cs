using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceList;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;


namespace InnovationAdmin.Application.Features.BillingMethodTypes.Queries.GetBillingMethodTypeList
{
    public class GetBillingMethodTypeListQueryHandler : IRequestHandler<GetBillingMethodTypeListQuery, Response<IEnumerable<GetBillingMethodTypeListVm
        >>>
    {
        private readonly IBillingMethodTypeRepository _billingMethodTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetBillingMethodTypeListQueryHandler(IMapper mapper, IBillingMethodTypeRepository billingMethodTypeRepository, ILogger<GetDataSourceListQueryHandler> logger)
        {
            _mapper = mapper;
            _billingMethodTypeRepository = billingMethodTypeRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetBillingMethodTypeListVm>>> Handle(GetBillingMethodTypeListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allBillingMethod = (await _billingMethodTypeRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();
            var billingMethod = _mapper.Map<IEnumerable<GetBillingMethodTypeListVm>>(allBillingMethod);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetBillingMethodTypeListVm>>(billingMethod, "success");
        }
    }
}
