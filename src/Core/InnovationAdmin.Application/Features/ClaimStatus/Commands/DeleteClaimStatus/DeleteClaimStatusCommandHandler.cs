using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
            var claimToUpdate = await _claimStatusRepository.GetByIdAsync(request.Id);

            if (claimToUpdate == null)
            {
                return new Response<bool>($"Claim Status with id {request.Id} not found.");
            }

           
            claimToUpdate.IsDeleted = true;

          
            await _claimStatusRepository.UpdateAsync(claimToUpdate);

            return new Response<bool>(true, "Claim Status Deleted successfully.");
        }
    }
}
