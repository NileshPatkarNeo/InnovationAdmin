

using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.ClaimStatus.Commands.DeleteClaimStatus
{
    public class DeleteClaimStatusCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}
