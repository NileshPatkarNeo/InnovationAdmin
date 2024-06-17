

using FluentValidation;
using InnovationAdmin.Application.Features.DataSources.Commands.CreateDataSource;

namespace InnovationAdmin.Application.Features.CategoryTypes.Commands.CreateCategoryType
{
    public class CreateCategoryTypeValidator : AbstractValidator<CreateCategoryTypeCommand>
    {
        public CreateCategoryTypeValidator()
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
