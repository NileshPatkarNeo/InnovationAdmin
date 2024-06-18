using InnovationAdmin.Application.Features.ClaimStatus.Queries.GetClaimStatusQuery;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.ClaimStatus.Queries.GetAllListClaimStatusQuery
{
    public class GetAllClaimStatusQuery : IRequest<Response<IEnumerable<ClaimStatusDto>>>
    {

    }
}
