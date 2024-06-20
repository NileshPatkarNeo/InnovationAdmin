using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;


namespace InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceList
{
    public class GetDataSourceListQueryHandler : IRequestHandler<GetDataSourceListQuery, Response<IEnumerable<GetDataSourceListVm>>>
    {
        private readonly IDataSourceRepository _dataSourceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetDataSourceListQueryHandler(IMapper mapper, IDataSourceRepository dataSourceRepository, ILogger<GetDataSourceListQueryHandler> logger)
        {
            _mapper = mapper;
            _dataSourceRepository = dataSourceRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetDataSourceListVm>>> Handle(GetDataSourceListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allDataSource = (await _dataSourceRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();
            var dataSource = _mapper.Map<IEnumerable<GetDataSourceListVm>>(allDataSource);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetDataSourceListVm>>(dataSource, "success");
        }

    }
}
