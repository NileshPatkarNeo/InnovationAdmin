using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Queries.GetReceiptBatchSourceQuery;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetAllListSysPrefCompnayQuery;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Queries.GetAllListReceipyBatchSourceQuery
{
    public class GetAllReceiptBatchSourceQueryHandler : IRequestHandler<GetAllReceiptBatchSourceQuery, Response<IEnumerable<ReceiptBatchSourceDto>>>
    {
        private readonly IReceiptBatchSourceRepository _receiptBatchSourceRepository;
        private readonly IMapper _mapper;

        public GetAllReceiptBatchSourceQueryHandler(IReceiptBatchSourceRepository receiptBatchSourceRepository, IMapper mapper)
        {
            _receiptBatchSourceRepository = receiptBatchSourceRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ReceiptBatchSourceDto>>> Handle(GetAllReceiptBatchSourceQuery request, CancellationToken cancellationToken)
        {
            var batch = await _receiptBatchSourceRepository.ListAllAsync();
            var batchDto = _mapper.Map<IEnumerable<ReceiptBatchSourceDto>>(batch);
            return new Response<IEnumerable<ReceiptBatchSourceDto>>(batchDto);
        }
    }
}
