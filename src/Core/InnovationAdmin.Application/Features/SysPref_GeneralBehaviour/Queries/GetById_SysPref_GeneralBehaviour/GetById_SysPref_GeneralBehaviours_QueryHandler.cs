using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.GetById_SysPref_GeneralBehaviour
{
    public class GetById_SysPref_GeneralBehaviours_QueryHandler : IRequestHandler<GetById_SysPref_GeneralBehaviours_Query, Response<GetById_SysPref_GeneralBehaviours_VM>>
    {
        private readonly ISysPref_GeneralBehaviourRepository _sysPref_generalbehaviourRepository;

        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetById_SysPref_GeneralBehaviours_QueryHandler(IMapper mapper, ISysPref_GeneralBehaviourRepository sysPref_generalbehaviourRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _sysPref_generalbehaviourRepository = sysPref_generalbehaviourRepository;
           
        }
        public async Task<Response<GetById_SysPref_GeneralBehaviours_VM>> Handle(GetById_SysPref_GeneralBehaviours_Query request, CancellationToken cancellationToken)
        {


            var @system = await _sysPref_generalbehaviourRepository.GetByIdAsync(request.Preference_ID);
            var systemDto = _mapper.Map<GetById_SysPref_GeneralBehaviours_VM>(system);


            if (@system == null)
            {
                throw new NotFoundException(nameof(GetById_SysPref_GeneralBehaviours_VM), @system.Preference_ID);
            }

            var response = new Response<GetById_SysPref_GeneralBehaviours_VM>(systemDto);
            return response;
        }

    }
}
