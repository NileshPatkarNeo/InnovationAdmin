using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Create_SysPref_GeneralBehaviour
{
    public class Create_SysPref_GeneralBehaviour_CommandHandler : IRequestHandler<Create_SysPref_GeneralBehaviour_Command, Response<Create_SysPref_GeneralBehaviour_Dto>>
    {
        private readonly IMapper _mapper;
        private readonly ISysPref_GeneralBehaviourRepository _sysPref_generalbehaviourRepository;
        private readonly IMessageRepository _messageRepository;

        public Create_SysPref_GeneralBehaviour_CommandHandler(IMapper mapper, ISysPref_GeneralBehaviourRepository sysPref_generalbehaviourRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _sysPref_generalbehaviourRepository = sysPref_generalbehaviourRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<Create_SysPref_GeneralBehaviour_Dto>> Handle(Create_SysPref_GeneralBehaviour_Command request, CancellationToken cancellationToken)
        {
            Response<Create_SysPref_GeneralBehaviour_Dto> createSysPref_GeneralBehaviourCommandResponse = null;

            var validator = new Create_SysPref_GeneralBehaviour_CommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationException(string.Join(", ", errors));
            }
            else
            {
                var sysPref_generalBehaviour = new SysPref_GeneralBehaviours()
                {
                    Auto_Change_Claim_Status = request.Auto_Change_Claim_Status,
                    Claim_Status_Receipting = request.Claim_Status_Receipting,
                    Claim_Status_Payment = request.Claim_Status_Payment,
                    Claim_Status_Zero_Paid = request.Claim_Status_Zero_Paid,
                    Claim_Status_Procare_Claim_Load = request.Claim_Status_Procare_Claim_Load,
                    Logout_Redirect = request.Logout_Redirect,
                    Records_Locked_Seconds = request.Records_Locked_Seconds,
                    User_Timeout = request.User_Timeout
                };

                sysPref_generalBehaviour = await _sysPref_generalbehaviourRepository.AddAsync(sysPref_generalBehaviour);
                createSysPref_GeneralBehaviourCommandResponse = new Response<Create_SysPref_GeneralBehaviour_Dto>(_mapper.Map<Create_SysPref_GeneralBehaviour_Dto>(sysPref_generalBehaviour), "success");
            }

            return createSysPref_GeneralBehaviourCommandResponse;
        }
    }
}
