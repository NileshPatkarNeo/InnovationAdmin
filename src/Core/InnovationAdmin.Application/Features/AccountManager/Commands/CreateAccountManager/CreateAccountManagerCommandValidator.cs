using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AccountManager.Commands.CreateAccountManager
{
    public class CreateAccountManagerCommandValidator : AbstractValidator<CreateAccountManagerCommand>
    {

        public CreateAccountManagerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Write Name")
                .NotNull().WithMessage("Name must not be null.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
                //.Matches(@"^\S+$").WithMessage("Name must not contain only whitespace.");
        }
    }
}
