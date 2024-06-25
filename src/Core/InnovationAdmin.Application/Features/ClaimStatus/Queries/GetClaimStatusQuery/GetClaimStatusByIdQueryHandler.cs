using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.ClaimStatus.Queries.GetClaimStatusQuery
{
    public class GetClaimStatusByIdQueryHandler : IRequestHandler<GetClaimStatusByIdQuery, Response<ClaimStatusDto>>
    {
        private readonly IClaimStatusRepository _claimStatusRepository;
        private readonly IMapper _mapper;

        public GetClaimStatusByIdQueryHandler(IClaimStatusRepository claimStatusRepository, IMapper mapper)
        {
            _claimStatusRepository = claimStatusRepository;
            _mapper = mapper;
        }

        public async Task<Response<ClaimStatusDto>> Handle(GetClaimStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var claimStatus = await _claimStatusRepository.GetByIdAsync(request.Id);

            if (claimStatus == null)
            {
                return new Response<ClaimStatusDto>("Claim not found.");
            }

            if (claimStatus.Status)
            {
                var claimDto = _mapper.Map<ClaimStatusDto>(claimStatus);
                return new Response<ClaimStatusDto>(claimDto);
            }
            else
            {
                return new Response<ClaimStatusDto>("Claim status is inactive.");
            }
        }
    }
}
