using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Helper;

namespace InnovationAdmin.Application.Features.Quote.Commands.UpdateQuote
{
    public class UpdateQuoteCommandValidator : AbstractValidator<UpdateQuoteCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateQuoteCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(100).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG))
                .MinimumLength(2).WithMessage(GetMessage("3", ApplicationConstants.LANG_ENG));
                

            RuleFor(p => p.QuoteBy)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(25).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG))
                .MinimumLength(2).WithMessage(GetMessage("3", ApplicationConstants.LANG_ENG));
               
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
