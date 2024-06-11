using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using ReceiptBatchSourceEntity = InnovationAdmin.Domain.Entities.ReceiptBatchSource;
using MediatR;

namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.UpdateReceiptBatchSource
{
    public class UpdateReceiptBAtchSourceHandler : IRequestHandler<UpdateReceiptBAtchSourceCommand, Response<UpdateReceiptBAtchSourceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReceiptBatchSourceRepository _receiptBatchSourceRepository;
        private readonly IMessageRepository _messageRepository;

        public UpdateReceiptBAtchSourceHandler(IMapper mapper, IReceiptBatchSourceRepository receiptBatchSourceRepository, IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _receiptBatchSourceRepository = receiptBatchSourceRepository;
        }

        public async Task<Response<UpdateReceiptBAtchSourceDto>> Handle(UpdateReceiptBAtchSourceCommand request, CancellationToken cancellationToken)
        {
            var batchToUpdate = await _receiptBatchSourceRepository.GetByIdAsync(request.Id);

            if (batchToUpdate == null)
            {
                throw new NotFoundException(nameof(ReceiptBatchSource), request.Id);
            }
            var validator = new UpdateReceiptBAtchSourceValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

             _mapper.Map(request,batchToUpdate);
            await _receiptBatchSourceRepository.UpdateAsync(batchToUpdate);
            var dto = _mapper.Map<UpdateReceiptBAtchSourceDto>(batchToUpdate);
            return new Response<UpdateReceiptBAtchSourceDto>(dto, "Receipt batch updated successfully");
        }

    }
}
