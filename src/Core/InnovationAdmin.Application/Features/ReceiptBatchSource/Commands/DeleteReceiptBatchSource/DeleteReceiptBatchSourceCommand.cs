using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.DeleteReceiptBatchSource
{
    public class DeleteReceiptBatchSourceCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}
