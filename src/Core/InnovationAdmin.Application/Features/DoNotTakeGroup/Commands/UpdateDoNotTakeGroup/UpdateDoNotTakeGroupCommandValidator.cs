using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.CreateDoNotTakeGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.UpdateDoNotTakeGroup
{
    public class UpdateDoNotTakeGroupCommandValidator : AbstractValidator<UpdateDoNotTakeGroupCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateDoNotTakeGroupCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.GroupCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.GroupName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");


        }
    }
}
