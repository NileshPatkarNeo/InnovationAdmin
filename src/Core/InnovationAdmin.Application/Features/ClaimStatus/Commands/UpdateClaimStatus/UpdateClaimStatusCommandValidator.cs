using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.UpdateReceiptBatchSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ClaimStatus.Commands.UpdateClaimStatus
{
    internal class UpdateClaimStatusCommandValidator : AbstractValidator<UpdateClaimStatusCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateClaimStatusCommandValidator(IMessageRepository messageRepository)
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
