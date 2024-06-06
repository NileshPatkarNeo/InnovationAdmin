using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Queries.GetReceiptBatchSourceQuery
{
    public class GetReceiptBatchSourceByIdHandler : IRequestHandler<GetReceiptBatchSourceByIdQuery, Response<ReceiptBatchSourceDto>>
    {
        private readonly IReceiptBatchSourceRepository _receiptBatchSourceRepository;
        private readonly IMapper _mapper;

        public GetReceiptBatchSourceByIdHandler(IReceiptBatchSourceRepository receiptBatchSourceRepository, IMapper mapper)
        {
            _receiptBatchSourceRepository = receiptBatchSourceRepository;
            _mapper = mapper;
        }

        public async Task<Response<ReceiptBatchSourceDto>> Handle(GetReceiptBatchSourceByIdQuery request, CancellationToken cancellationToken)
        {
            var batchSource = await _receiptBatchSourceRepository.GetByIdAsync(request.Id);

            if (batchSource == null)
            {
                return new Response<ReceiptBatchSourceDto>("Batch not found.");
            }

            var batchDto = _mapper.Map<ReceiptBatchSourceDto>(batchSource);
            return new Response<ReceiptBatchSourceDto>(batchDto);
        }
    }
}
