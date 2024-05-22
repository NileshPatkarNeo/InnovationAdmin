using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Create_SysPref_GeneralBehaviour
{
    public class Create_SysPref_GeneralBehaviour_CommandValidator : AbstractValidator<Create_SysPref_GeneralBehaviour_Command>
    {
        private readonly IMessageRepository _messageRepository;
        public Create_SysPref_GeneralBehaviour_CommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
            //    .NotNull()
            //    .MaximumLength(10).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
