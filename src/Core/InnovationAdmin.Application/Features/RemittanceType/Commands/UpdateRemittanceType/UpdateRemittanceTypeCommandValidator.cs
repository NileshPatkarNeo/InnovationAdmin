using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Helper;

namespace InnovationAdmin.Application.Features.RemittanceType.Commands.UpdateRemittanceType
{
    public class UpdateRemittanceTypeCommandValidator : AbstractValidator<UpdateRemittanceTypeCommand>
    {

        private readonly IMessageRepository _messageRepository;

        public UpdateRemittanceTypeCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(50).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

        }

        private string GetMessage(string code, string lang)
        {
            try
            {
                var result = _messageRepository.GetMessage(code, lang).Result;
                if (result != null && result.MessageContent != null)
                {
                    return result.MessageContent.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred in GetMessage: {ex.Message}");
            }

            return "Default message"; 
        }


    }
}
