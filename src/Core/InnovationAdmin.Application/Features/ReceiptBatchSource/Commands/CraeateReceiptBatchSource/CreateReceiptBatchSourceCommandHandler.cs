

using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.CraeateReceiptBatchSource
{
    public class CreateReceiptBatchSourceCommandHandler : IRequestHandler<CreateReceiptBatchSourceCommand, Response<CreateReceiptBatchDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReceiptBatchSourceRepository _receiptBatchSourceRepository;
        private readonly IMessageRepository _messageRepository;

        public CreateReceiptBatchSourceCommandHandler(IMapper mapper, IReceiptBatchSourceRepository receiptBatchSourceRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _receiptBatchSourceRepository = receiptBatchSourceRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CreateReceiptBatchDto>> Handle(CreateReceiptBatchSourceCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateReceiptBatchSourceCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var batch = new Domain.Entities.ReceiptBatchSource
            {
                Name = request.Name,
                Type = request.Type
            };

            batch = await _receiptBatchSourceRepository.AddAsync(batch);

            var companyDto = _mapper.Map<CreateReceiptBatchDto>(batch);

            return new Response<CreateReceiptBatchDto>(companyDto, "success");
        }
    }
}
