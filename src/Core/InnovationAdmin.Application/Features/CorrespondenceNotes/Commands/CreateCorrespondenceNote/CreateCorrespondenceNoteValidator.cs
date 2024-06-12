using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.RemittanceType.Commands.CreateRemittanceType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CorrespondenceNotes.Commands.CreateCorrespondenceNote
{
    public class CreateCorrespondenceNoteValidator : AbstractValidator<CreateCorrespondenceNoteCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public CreateCorrespondenceNoteValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Note)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        }
    }
}

