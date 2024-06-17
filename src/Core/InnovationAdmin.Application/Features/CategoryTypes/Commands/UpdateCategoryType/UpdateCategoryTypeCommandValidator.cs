using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.CategoryTypes.Commands.UpdateCategoryType
{
    public class UpdateCategoryTypeCommandValidator : AbstractValidator<UpdateCategoryTypeCommand>
    {
        public UpdateCategoryTypeCommandValidator()
        {
            RuleFor(p => p.DocumentName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("Length should be less than 50 characters");

            RuleFor(p => p.GroupName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("Length should be less than 50 characters");

            RuleFor(p => p.ClaimName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("Length should be less than 50 characters");

            RuleFor(p => p.AdjustmentName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("Length should be less than 50 characters");
        }
    }
}
