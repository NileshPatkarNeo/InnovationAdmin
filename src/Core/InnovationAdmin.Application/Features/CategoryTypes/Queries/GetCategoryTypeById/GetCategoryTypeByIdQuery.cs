using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.CategoryTypes.Queries.GetCategoryTypeById
{
    public class GetCategoryTypeByIdQuery : IRequest<Response<GetCategoryTypeByIdVm>>
    {
        public String ID { get; set; }

    }
}
