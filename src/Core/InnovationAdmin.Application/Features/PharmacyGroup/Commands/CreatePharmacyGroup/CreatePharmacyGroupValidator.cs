using InnovationAdmin.Application.Contracts.Persistence;
using FluentValidation;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Commands.CreatePharmacyGroup
{
    public class CreatePharmacyGroupValidator : AbstractValidator<CreatePharmacyGroupCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public CreatePharmacyGroupValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.PharmacyName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
        }
    }
}
