using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Update_SysPref_GeneralBehaviour
{
    public class Update_SysPref_GeneralBehaviour_CommandValidator : AbstractValidator<Update_SysPref_GeneralBehaviour_Command>
    {
        private readonly IMessageRepository _messageRepository;
        public Update_SysPref_GeneralBehaviour_CommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
            //    .NotNull()
            //    .MaximumLength(50).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

            //RuleFor(p => p.Price)
            //    .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
            //    .GreaterThan(0);
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
        
}
