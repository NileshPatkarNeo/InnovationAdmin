using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceList;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;


namespace InnovationAdmin.Application.Features.CategoryTypes.Queries.GetCategoryTypeList
{
    public class GetCategoryTypeListQueryHandler : IRequestHandler<GetCategoryTypeListQuery, Response<IEnumerable<GetCategoryTypeListVm>>>
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetCategoryTypeListQueryHandler(IMapper mapper, ICategoryTypeRepository categoryTypeRepository, ILogger<GetCategoryTypeListQueryHandler> logger)
        {
            _mapper = mapper;
            _categoryTypeRepository = categoryTypeRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetCategoryTypeListVm>>> Handle(GetCategoryTypeListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allcategoryType = (await _categoryTypeRepository.ListAllAsync()).OrderBy(x => x.DocumentName).ToList();
            var categoryType = _mapper.Map<IEnumerable<GetCategoryTypeListVm>>(allcategoryType);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetCategoryTypeListVm>>(categoryType, "success");
        }
    }
}
