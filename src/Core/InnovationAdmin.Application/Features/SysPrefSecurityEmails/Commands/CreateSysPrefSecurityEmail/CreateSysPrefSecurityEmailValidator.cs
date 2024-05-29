using FluentValidation;
using InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.CreateSysPrefSecurityEmail
{
    public class CreateSysPrefSecurityEmailValidator : AbstractValidator<CreateSysPrefSecurityEmailCommand>
    {

        public CreateSysPrefSecurityEmailValidator()
        {


            RuleFor(p => p.DefaultFromName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("Error");

            RuleFor(p => p.DefaultFromAddress)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .MinimumLength(8).WithMessage("Error in DefaultFromAddress");

            RuleFor(p => p.DefaultReplyToAddress)
                .NotEmpty().WithMessage("{PropertyName} is required")
                         .NotNull().WithMessage("{PropertyName} is required")
                .MinimumLength(8).WithMessage("Error in DefaultReplyToAddress");

            RuleFor(p => p.DefaultReplyToName)
                .NotEmpty().WithMessage("Error")
                         .NotNull().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("Error in DefaultReplyToName");

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("Error")
                     .NotNull().WithMessage("{PropertyName} is required");


        }





    }
    }

