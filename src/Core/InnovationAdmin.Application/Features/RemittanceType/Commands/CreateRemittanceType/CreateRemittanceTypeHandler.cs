using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using InnovationAdmin.Application.Exceptions;


namespace InnovationAdmin.Application.Features.RemittanceType.Commands.CreateRemittanceType
{
    public class CreateRemittanceTypeHandler: IRequestHandler<CreateRemittanceTypeCommand, Response<CreateRemittanceTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRemittanceTypeRepository _remittanceTypeRepository;
        private readonly IMessageRepository _messageRepository;

        public CreateRemittanceTypeHandler(IMapper mapper, IRemittanceTypeRepository remittanceTypeRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _remittanceTypeRepository = remittanceTypeRepository;
            _messageRepository = messageRepository;
        }
        public async Task<Response<CreateRemittanceTypeDto>> Handle(CreateRemittanceTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRemittanceTypeValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var remittanceType = new Domain.Entities.RemittanceType
            {
                Name = request.Name
            };

            remittanceType = await _remittanceTypeRepository.AddAsync(remittanceType);

            var remittanceTypeDto = _mapper.Map<CreateRemittanceTypeDto>(remittanceType);

            return new Response<CreateRemittanceTypeDto>(remittanceTypeDto, "Remittance Type created successfully");
        }
    }
}
    