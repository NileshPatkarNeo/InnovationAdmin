using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.DataSources.Commands.DeleteDataSource;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.APAccountTypes.Commands.DeleteAPAccountType
{
    public class DeleteAPAccountTypeCommandHandler : IRequestHandler<DeleteAPAccountTypeCommand>
    {
        private readonly IAPAccountTypeRepository _aPAccountTypeRepository;

        public DeleteAPAccountTypeCommandHandler(IAPAccountTypeRepository aPAccountTypeRepository)
        {
            _aPAccountTypeRepository = aPAccountTypeRepository;
        }


        public async Task<Unit> Handle(DeleteAPAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var aPAccountId = request.ID;
            var aPAccountIdToDelete = await _aPAccountTypeRepository.GetByIdAsync(aPAccountId);
            if (aPAccountIdToDelete == null)
            {
                throw new NotFoundException(nameof(APAccountTypes), aPAccountId);
            }
            await _aPAccountTypeRepository.DeleteAsync(aPAccountIdToDelete);
            return Unit.Value;
            //throw new NotImplementedException();
        }
    }
}
