using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.CraeateReceiptBatchSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ClaimStatus.Commands.CreateClaimStatus
{
    public class CreateClaimStatusCommandValidator : AbstractValidator<CreateClaimStatusCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public CreateClaimStatusCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
     .NotEmpty().WithMessage("{PropertyName} is required.")
     .NotNull().WithMessage("{PropertyName} cannot be null.")
     .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(p => p.Color)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");


        }

    }
}
