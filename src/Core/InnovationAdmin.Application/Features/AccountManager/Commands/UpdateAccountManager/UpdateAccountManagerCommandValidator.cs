using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;

namespace InnovationAdmin.Application.Features.AccountManager.Commands.UpdateAccountManager
{
    public class UpdateAccountManagerCommandValidator : AbstractValidator<UpdateAccountManagerCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public UpdateAccountManagerCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Write Name plz ")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
        }
    }
}
