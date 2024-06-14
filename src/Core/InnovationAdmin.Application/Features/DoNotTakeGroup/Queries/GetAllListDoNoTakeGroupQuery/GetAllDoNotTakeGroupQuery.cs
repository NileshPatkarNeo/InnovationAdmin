
using InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetDoNotTakeGroupQuery;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetAllListDoNoTakeGroupQuery
{
    public class GetAllDoNotTakeGroupQuery : IRequest<Response<IEnumerable<DoNotTakeGroupDto>>>
    {
    }
}
