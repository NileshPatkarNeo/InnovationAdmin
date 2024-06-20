using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.UpdateReceiptBatchSource
{
    public class UpdateReceiptBAtchSourceCommand : IRequest<Response<UpdateReceiptBAtchSourceDto>>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
