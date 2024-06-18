using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.ClaimStatus.Commands.DeleteClaimStatus
{
    public class DeleteClaimStatusCommandHandler : IRequestHandler<DeleteClaimStatusCommand, Response<bool>>
    {
        private readonly IClaimStatusRepository _claimStatusRepository;

        public DeleteClaimStatusCommandHandler(IClaimStatusRepository claimStatusRepository)
        {
           _claimStatusRepository = claimStatusRepository;
        }

        public async Task<Response<bool>> Handle(DeleteClaimStatusCommand request, CancellationToken cancellationToken)
        {
            var claimToDelete = await _claimStatusRepository.GetByIdAsync(request.Id);

            if (claimToDelete == null)
            {
                return new Response<bool>($"Claim Status with id {request.Id} not found.");
            }

            await _claimStatusRepository.DeleteAsync(claimToDelete);

            return new Response<bool>(true, "Claim Status deleted successfully.");
        }
    }
}

