using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.PharmacyGroup.Commands.CreatePharmacyGroup
{
    public class CreatePharmacyGroupHandler : IRequestHandler<CreatePharmacyGroupCommand, Response<CreatePharmacyGroupDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPharmacyGroupRepository _pharmacyGroupRepository;
        private readonly IMessageRepository _messageRepository;

        public CreatePharmacyGroupHandler(IMapper mapper, IPharmacyGroupRepository pharmacyGroupRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _pharmacyGroupRepository = pharmacyGroupRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CreatePharmacyGroupDto>> Handle(CreatePharmacyGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePharmacyGroupValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var pharmacygroup = new Domain.Entities.PharmacyGroup
            {
                PharmacyName = request.PharmacyName
            };

            pharmacygroup = await _pharmacyGroupRepository.AddAsync(pharmacygroup);

            var pharmacygroupDto = _mapper.Map<CreatePharmacyGroupDto>(pharmacygroup);

            return new Response<CreatePharmacyGroupDto>(pharmacygroupDto, "Pharmacy Group created successfully");
        }
    }
}
