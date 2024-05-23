using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Update_SysPref_GeneralBehaviour
{
    public class Update_SysPref_GeneralBehaviour_CommandHandler : IRequestHandler<Update_SysPref_GeneralBehaviour_Command, Response<Update_SysPref_GeneralBehaviour_Dto>>
    {
        private readonly IMapper _mapper;
        private readonly ISysPref_GeneralBehaviourRepository _sysPref_generalbehaviourRepository;
        private readonly IMessageRepository _messageRepository;

        public Update_SysPref_GeneralBehaviour_CommandHandler(IMapper mapper, ISysPref_GeneralBehaviourRepository sysPref_generalbehaviourRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _sysPref_generalbehaviourRepository = sysPref_generalbehaviourRepository;
            _messageRepository = messageRepository;
        }
        public async Task<Response<Update_SysPref_GeneralBehaviour_Dto>> Handle(Update_SysPref_GeneralBehaviour_Command request, CancellationToken cancellationToken)
        {
            var SysToUpdate = await _sysPref_generalbehaviourRepository.GetByIdAsync(request.Preference_ID);

            if (SysToUpdate == null)
            {
                throw new NotFoundException(nameof(SysPref_GeneralBehaviour), request.Preference_ID);
            }

            // Validate the request
            var validator = new Update_SysPref_GeneralBehaviour_CommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            // Map the update request to the  entity
            _mapper.Map(request, SysToUpdate);

            // Update in the repository
            await _sysPref_generalbehaviourRepository.UpdateAsync(SysToUpdate);

            // Prepare the response DTO
            var dto = new Update_SysPref_GeneralBehaviour_Dto
            {
                Preference_ID = request.Preference_ID,
                Auto_Change_Claim_Status = request.Auto_Change_Claim_Status,
                Claim_Status_Receipting = request.Claim_Status_Receipting,
                Claim_Status_Payment = request.Claim_Status_Payment,
                Claim_Status_Zero_Paid = request.Claim_Status_Zero_Paid,
                Claim_Status_Procare_Claim_Load = request.Claim_Status_Procare_Claim_Load,
                Logout_Redirect = request.Logout_Redirect,
                Records_Locked_Seconds = request.Records_Locked_Seconds,
                User_Timeout = request.User_Timeout
            };

            // Return a successful response
            return new Response<Update_SysPref_GeneralBehaviour_Dto>(dto, "Updated successfully");
        }

    }
}
