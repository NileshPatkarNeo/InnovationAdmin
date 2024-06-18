using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.ClaimStatus.Commands.CreateClaimStatus
{
    public class CreateClaimStatusCommandHandler : IRequestHandler<CreateClaimStatusCommand, Response<CreateClaimStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IClaimStatusRepository _claimStatusRepository;
        private readonly IMessageRepository _messageRepository;

        public CreateClaimStatusCommandHandler(IMapper mapper, IMessageRepository messageRepository, IClaimStatusRepository claimStatusRepository)
        {
            _mapper = mapper;
            _claimStatusRepository = claimStatusRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CreateClaimStatusDto>> Handle(CreateClaimStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateClaimStatusCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var claim = new Domain.Entities.ClaimStatus
            {
                Name = request.Name,
                color = request.Color

            };
            claim = await _claimStatusRepository.AddAsync(claim);


            var claimDto = _mapper.Map<CreateClaimStatusDto>(claim);

            return new Response<CreateClaimStatusDto>(claimDto, "success");
        }
    }
}
