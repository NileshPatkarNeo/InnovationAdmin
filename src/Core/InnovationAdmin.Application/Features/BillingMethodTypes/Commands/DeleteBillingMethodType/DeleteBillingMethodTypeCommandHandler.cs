using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.DataSources.Commands.DeleteDataSource;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.BillingMethodTypes.Commands.DeleteBillingMethodType
{
    public class DeleteBillingMethodTypeCommandHandler : IRequestHandler<DeleteBillingMethodTypeCommand>
    {
        private readonly IBillingMethodTypeRepository _billingMethodTypeRepository;

        public DeleteBillingMethodTypeCommandHandler(IBillingMethodTypeRepository billingMethodTypeRepository)
        {
            _billingMethodTypeRepository = billingMethodTypeRepository;
        }

        public async Task<Unit> Handle(DeleteBillingMethodTypeCommand request, CancellationToken cancellationToken)
        {
            var billingMethodId = request.ID;
            var billingMethodIdToDelete = await _billingMethodTypeRepository.GetByIdAsync(billingMethodId);
            if (billingMethodIdToDelete == null)
            {
                throw new NotFoundException(nameof(BillingMethodTypes), billingMethodId);
            }
            await _billingMethodTypeRepository.DeleteAsync(billingMethodIdToDelete);
            return Unit.Value;
            //throw new NotImplementedException();
        }
    }
}
