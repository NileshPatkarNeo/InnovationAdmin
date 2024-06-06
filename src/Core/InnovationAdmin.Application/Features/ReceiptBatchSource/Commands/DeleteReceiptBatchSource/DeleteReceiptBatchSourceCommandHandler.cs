using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.DeleteSysPrefCommand;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.DeleteReceiptBatchSource
{
    public class DeleteReceiptBatchSourceCommandHandler : IRequestHandler<DeleteReceiptBatchSourceCommand, Response<bool>>
    {
        private readonly IReceiptBatchSourceRepository _receiptBatchSourceRepository;

        public DeleteReceiptBatchSourceCommandHandler(IReceiptBatchSourceRepository receiptBatchSourceRepository)
        {
            _receiptBatchSourceRepository = receiptBatchSourceRepository;
        }

        public async Task<Response<bool>> Handle(DeleteReceiptBatchSourceCommand request, CancellationToken cancellationToken)
        {
            var batchToDelete = await _receiptBatchSourceRepository.GetByIdAsync(request.Id);

            if (batchToDelete == null)
            {
                return new Response<bool>($"ReceiptBatchSource with id {request.Id} not found.");
            }

            await _receiptBatchSourceRepository.DeleteAsync(batchToDelete);

            return new Response<bool>(true, "ReceiptBatchSource deleted successfully.");
        }
    }
}

