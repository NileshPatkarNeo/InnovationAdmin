using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
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
            var contractTermToDelete = await _contractTermsRepository.GetByIdAsync(contractTermId);
            if (contractTermToDelete == null)
            {
                throw new NotFoundException(nameof(ContractTerms), contractTermId);
            }
            await _contractTermsRepository.DeleteAsync(contractTermToDelete);
            return Unit.Value;
        }
    }
}
