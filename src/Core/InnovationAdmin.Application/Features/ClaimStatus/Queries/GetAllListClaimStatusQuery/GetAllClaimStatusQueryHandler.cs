using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.ClaimStatus.Queries.GetClaimStatusQuery;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.ClaimStatus.Queries.GetAllListClaimStatusQuery
{
    public class GetAllClaimStatusQueryHandler : IRequestHandler<GetAllClaimStatusQuery, Response<IEnumerable<ClaimStatusDto>>>
    {
        private readonly IClaimStatusRepository _claimStatusRepository;
        private readonly IMapper _mapper;
        public GetAllClaimStatusQueryHandler(IClaimStatusRepository claimStatusRepository, IMapper mapper)
        {
           _claimStatusRepository = claimStatusRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ClaimStatusDto>>> Handle(GetAllClaimStatusQuery request, CancellationToken cancellationToken)
        {
            var claim = (await _claimStatusRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
            var claimDto = _mapper.Map<IEnumerable<ClaimStatusDto>>(claim);
            return new Response<IEnumerable<ClaimStatusDto>>(claimDto);
        }
    }
}
