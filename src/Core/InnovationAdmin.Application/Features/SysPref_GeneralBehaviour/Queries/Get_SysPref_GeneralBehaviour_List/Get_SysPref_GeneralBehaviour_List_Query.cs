using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.Get_SysPref_GeneralBehaviour_List
{
    public class Get_SysPref_GeneralBehaviour_List_Query:IRequest<Response<IEnumerable<SysPref_GeneralBehaviour_ListVM>>>
    {
    }
}
