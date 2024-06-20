

using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.Template.Queries.GetTemplateList;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InnovationAdmin.Application.Features.Template.Queries.GetTemplatesList
{
    public class GetTemplatesListQueryHandler : IRequestHandler<GetTemplatesListQuery, Response<IEnumerable<TemplateListVM>>>
    {
        private readonly IAsyncRepository<Templates> _templateRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTemplatesListQueryHandler> _logger;

        public GetTemplatesListQueryHandler(IMapper mapper, IAsyncRepository<Templates> templateRepository, ILogger<GetTemplatesListQueryHandler> logger)
        {
            _mapper = mapper;
            _templateRepository = templateRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<TemplateListVM>>> Handle(GetTemplatesListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allTemplates = (await _templateRepository.ListAllAsync()).OrderBy(x => x.Name);
            var templatesList = _mapper.Map<IEnumerable<TemplateListVM>>(allTemplates);
            _logger.LogInformation("Handle Completed");
            return new Response<IEnumerable<TemplateListVM>>(templatesList, "success");
        }
    }
}
