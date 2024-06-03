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
.NotEmpty().WithMessage("{PropertyName} is required.")
.NotNull().WithErrorCode("Name is Requied")
.MaximumLength(50).WithMessage("Length should be less than 50 characters");

            RuleFor(p => p.DefaultFromAddress)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithErrorCode("{PropertyName} is required.")
                .EmailAddress().WithMessage("Invalid Email Format");


            RuleFor(p => p.DefaultReplyToAddress)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithErrorCode("ReplyToAddress is Requied")
                .EmailAddress().WithMessage("Invalid Email Format");


            RuleFor(p => p.DefaultReplyToName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithErrorCode("ReplyToName is Requied")
                .MaximumLength(50).WithMessage("Length should be less than 50 characters");

            RuleFor(p => p.Status)
             .NotNull().WithMessage("Error");
        }
    }
}
