using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Helper;

namespace InnovationAdmin.Application.Features.Template.Commands.UpdateTemplate
{
    public class UpdateTemplateCommandValidator : AbstractValidator<UpdateTemplateCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateTemplateCommandValidator( )
        {
            

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull()
                .MaximumLength(50).WithMessage("Name Should be less than 50 characters");

            RuleFor(p => p.PdfTemplateFile)
                .NotEmpty().WithMessage("PdfTemplateFile is required")
                .NotNull()
                .MaximumLength(200).WithMessage("PdfTemplateFile Size should be 200");

            RuleFor(p => p.Domain)
                .NotEmpty().WithMessage("Domain is required")
                .NotNull()
                .MaximumLength(50).WithMessage("Domain should be 50 characters");

            RuleFor(p => p.Size)
                .NotEmpty().WithMessage("Size is required")
                .NotNull()
                .MaximumLength(50).WithMessage("Size should be 50 characters");
        }

        //private string GetMessage(string Code, string Lang)
        //{
        //    return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        //}
    }
}
