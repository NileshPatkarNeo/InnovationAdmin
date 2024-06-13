using FluentValidation;
using InnovationAdmin.Application.Features.DataSources.Commands.UpdateDataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.APAccountTypes.Commands.UpdateAPAccountType
{
    public class UpdateAPAccountTypeCommandValidator : AbstractValidator<UpdateAPAccountTypeCommand>
    {
        public UpdateAPAccountTypeCommandValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("Length should be less than 50 characters");
        }

    }
}
