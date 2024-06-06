using InnovationAdmin.Application.Features.ReceiptBatchSource.Queries.GetReceiptBatchSourceQuery;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Queries.GetAllListReceipyBatchSourceQuery
{
    public class GetAllReceiptBatchSourceQuery : IRequest<Response<IEnumerable<ReceiptBatchSourceDto>>>
    {

    }
}
