using FluentValidation;
using InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.UpdateSysPrefSecurityEmail
{
    public class UpdateSysPrefSecurityEmailCommandValidator : AbstractValidator<UpdateSysPrefSecurityEmailCommand>
    {
        public UpdateSysPrefSecurityEmailCommandValidator()
        {
            RuleFor(p => p.DefaultFromName)
            .NotEmpty().WithMessage("Error")
            .NotNull().WithErrorCode("Name is Requied")
            .MaximumLength(50).WithMessage("Error");

            RuleFor(p => p.DefaultFromAddress)
                .NotEmpty().WithMessage("Error")
                .NotNull().WithErrorCode("Name is Requied")
                .MinimumLength(8).WithMessage("Error");

            RuleFor(p => p.DefaultReplyToAddress)
                .NotEmpty().WithMessage("Error")
                .MinimumLength(0).WithMessage("Error");

            RuleFor(p => p.DefaultReplyToName)
                .NotEmpty().WithMessage("Error")
                .EmailAddress().WithMessage("Error");

            RuleFor(p => p.Status)
             .NotNull().WithMessage("Error");
        }
    }
}
