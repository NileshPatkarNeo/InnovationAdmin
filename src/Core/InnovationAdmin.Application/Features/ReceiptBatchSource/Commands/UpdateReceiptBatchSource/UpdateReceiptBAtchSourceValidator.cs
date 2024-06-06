using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ReceiptBatchSource.Commands.UpdateReceiptBatchSource
{
    public class UpdateReceiptBAtchSourceValidator : AbstractValidator<UpdateReceiptBAtchSourceCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateReceiptBAtchSourceValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
      .NotEmpty().WithMessage("{PropertyName} is required.")
      .NotNull().WithMessage("{PropertyName} cannot be null.")
      .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");


        }
    }
}
