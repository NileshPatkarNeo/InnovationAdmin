using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.ClaimStatus.Commands.UpdateClaimStatus
{
    public class UpdateClaimStatusCommand : IRequest<Response<UpdateClaimStatusDto>>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }
    }
}
