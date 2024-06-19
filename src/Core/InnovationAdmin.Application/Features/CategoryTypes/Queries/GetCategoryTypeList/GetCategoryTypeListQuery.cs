using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.CategoryTypes.Queries.GetCategoryTypeList
{
    public class GetCategoryTypeListQuery : IRequest<Response<IEnumerable<GetCategoryTypeListVm>>>
    {
    }
}
