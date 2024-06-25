using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.ContractTerms.Queries.GetContractTerm;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ContractTerms.Commands.DeleteContractTerm
{
    public class DeleteContractTermCommandHandler : IRequestHandler<DeleteContractTermCommand>
    {
        private readonly IContractTermsRepository _contractTermsRepository;

        public DeleteContractTermCommandHandler(IContractTermsRepository contractTermsRepository)
        {
            _contractTermsRepository = contractTermsRepository;
        }

        public async Task<Unit> Handle(DeleteContractTermCommand request, CancellationToken cancellationToken)
        {
            var contractTermId = request.ID;
            var contractTermToUpdate = await _contractTermsRepository.GetByIdAsync(contractTermId);

            if (contractTermToUpdate == null)
            {
                throw new NotFoundException(nameof(ContractTerms), contractTermId);
            }

            // Update the status to false instead of deleting the record
            contractTermToUpdate.Status = false;

            // Save the changes to the repository
            await _contractTermsRepository.UpdateAsync(contractTermToUpdate);

            // Return Unit.Value to indicate successful completion
            return Unit.Value;
        }
    }
}
