using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetDoNotTakeGroupQuery;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetAllListSysPrefCompnayQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetAllListDoNoTakeGroupQuery
{
    public class GetAllDoNotTakeGroupQueryHandler : IRequestHandler<GetAllDoNotTakeGroupQuery, Response<IEnumerable<DoNotTakeGroupDto>>>
    {
        private readonly IDoNotTakeGroup _doNotTakeGroup;
        private readonly IMapper _mapper;

        public GetAllDoNotTakeGroupQueryHandler(IDoNotTakeGroup doNotTakeGroup, IMapper mapper)
        {
         _doNotTakeGroup = doNotTakeGroup;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<DoNotTakeGroupDto>>> Handle(GetAllDoNotTakeGroupQuery request, CancellationToken cancellationToken)
        {
            var groups = await _doNotTakeGroup.ListAllAsync();
            var groupDto = _mapper.Map<IEnumerable<DoNotTakeGroupDto>>(groups);
            return new Response<IEnumerable<DoNotTakeGroupDto>>(groupDto);
        }
    }
}
