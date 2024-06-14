using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.DeleteDoNotGroup
{
    public class DeleteDoNotTakeGroupCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}
