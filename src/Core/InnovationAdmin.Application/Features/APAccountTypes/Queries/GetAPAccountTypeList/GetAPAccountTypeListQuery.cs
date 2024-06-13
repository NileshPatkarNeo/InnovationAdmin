using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.APAccountTypes.Queries.GetAPAccountTypeList
{
    public class GetAPAccountTypeListQuery : IRequest<Response<IEnumerable<GetAPAccountTypeListVm>>>
    {
    }
}
