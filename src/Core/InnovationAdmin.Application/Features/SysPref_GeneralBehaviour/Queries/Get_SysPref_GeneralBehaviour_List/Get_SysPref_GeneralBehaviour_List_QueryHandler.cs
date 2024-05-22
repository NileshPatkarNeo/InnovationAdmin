using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.Get_SysPref_GeneralBehaviour_List
{
    public class Get_SysPref_GeneralBehaviour_List_QueryHandler : IRequestHandler<Get_SysPref_GeneralBehaviour_List_Query, Response<IEnumerable<SysPref_GeneralBehaviour_ListVM>>>
    {
        private readonly IMapper _mapper;
        private readonly ISysPref_GeneralBehaviourRepository _sysPref_generalbehaviourRepository;

        private readonly ILogger _logger;
        public Get_SysPref_GeneralBehaviour_List_QueryHandler(IMapper mapper, ISysPref_GeneralBehaviourRepository sysPref_generalbehaviourRepository, ILogger<Get_SysPref_GeneralBehaviour_List_QueryHandler> logger)
        {
            _mapper = mapper;
            _sysPref_generalbehaviourRepository = sysPref_generalbehaviourRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<SysPref_GeneralBehaviour_ListVM>>> Handle(Get_SysPref_GeneralBehaviour_List_Query request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allSystem = (await _sysPref_generalbehaviourRepository.ListAllAsync());
            var system = _mapper.Map<IEnumerable<SysPref_GeneralBehaviour_ListVM>>(allSystem);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<SysPref_GeneralBehaviour_ListVM>>(system, "success");
        }

    }
}
