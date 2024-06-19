using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.CreatePharmacyGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Commands.CreatePharmacyType
{
    public class CreatePharmacyTypeValidator : AbstractValidator<CreatePharmacyTypeCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public CreatePharmacyTypeValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(p => p.Code)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .GreaterThan(0).WithMessage("{PropertyName} must not exceed {MaxLength}.");

        }
    }
}
