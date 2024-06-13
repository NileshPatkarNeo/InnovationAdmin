using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;


namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetDoNotTakeGroupQuery
{
    public class GetDoNotTakeGroupByIdQuery : IRequest<Response<DoNotTakeGroupDto>>
    {
        public GetDoNotTakeGroupByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

    }
}
