using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.PharmacyType.Commands.CreatePharmacyType
{


    public class CreatePharmacyTypeHandler : IRequestHandler<CreatePharmacyTypeCommand, Response<CreatePharmacyTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPharmacyTypeRepository _pharmacyGroupRepository;
        private readonly IMessageRepository _messageRepository;

        public CreatePharmacyTypeHandler(IMapper mapper, IPharmacyTypeRepository pharmacyGroupRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _pharmacyGroupRepository = pharmacyGroupRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CreatePharmacyTypeDto>> Handle(CreatePharmacyTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePharmacyTypeValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var batch = new Domain.Entities.PharmacyType
            {
                Description = request.Description,
                Code = request.Code
            };

            batch = await _pharmacyGroupRepository.AddAsync(batch);

            var companyDto = _mapper.Map<CreatePharmacyTypeDto>(batch);

            return new Response<CreatePharmacyTypeDto>(companyDto, "success");
        }
    }
}
