using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.ClaimStatus.Commands.UpdateClaimStatus
{
    public class UpdateClaimStatusCommandHandler : IRequestHandler<UpdateClaimStatusCommand, Response<UpdateClaimStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IClaimStatusRepository _claimStatusRepository;
        private readonly IMessageRepository _messageRepository;

        public UpdateClaimStatusCommandHandler(IMapper mapper, IClaimStatusRepository claimStatusRepository, IMessageRepository messageRepository)
        {
            _claimStatusRepository = claimStatusRepository;
            _messageRepository = messageRepository;
            _mapper = mapper;
           
        }

        public async Task<Response<UpdateClaimStatusDto>> Handle(UpdateClaimStatusCommand request, CancellationToken cancellationToken)
        {
            var claimToUpdate = await _claimStatusRepository.GetByIdAsync(request.Id);

            if (claimToUpdate == null)
            {
                throw new NotFoundException(nameof(ClaimStatus), request.Id);
            }
            var validator = new UpdateClaimStatusCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, claimToUpdate);
            await _claimStatusRepository.UpdateAsync(claimToUpdate);
            var dto = _mapper.Map<UpdateClaimStatusDto>(claimToUpdate);
            return new Response<UpdateClaimStatusDto>(dto, "Claim Status updated successfully");
        }

    }
}
