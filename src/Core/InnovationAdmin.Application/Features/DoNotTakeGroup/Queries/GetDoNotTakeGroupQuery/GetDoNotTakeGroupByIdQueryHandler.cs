using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetDoNotTakeGroupQuery
{
    public class GetDoNotTakeGroupByIdQueryHandler : IRequestHandler<GetDoNotTakeGroupByIdQuery, Response<DoNotTakeGroupDto>>
    {
        private readonly IDoNotTakeGroup _doNotTakeGroup;
        private readonly IMapper _mapper;

        public GetDoNotTakeGroupByIdQueryHandler(IDoNotTakeGroup doNotTakeGroup, IMapper mapper)
        {
         _doNotTakeGroup = doNotTakeGroup;
            _mapper = mapper;
        }

        public async Task<Response<DoNotTakeGroupDto>> Handle(GetDoNotTakeGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var DoNotTakeGroup = await _doNotTakeGroup.GetByIdAsync(request.Id);

            if (DoNotTakeGroup == null)
            {
                return new Response<DoNotTakeGroupDto>("Group not found.");
            }

            var dngDto = _mapper.Map<DoNotTakeGroupDto>(DoNotTakeGroup);
            return new Response<DoNotTakeGroupDto>(dngDto);
        }
    }
}
