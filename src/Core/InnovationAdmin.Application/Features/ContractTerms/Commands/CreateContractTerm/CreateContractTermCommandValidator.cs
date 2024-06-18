using FluentValidation;

namespace InnovationAdmin.Application.Features.ContractTerms.Commands.CreateContractTerm
{
    public class CreateContractTermCommandValidator : AbstractValidator<CreateContractTermCommand>
    {
        public CreateContractTermCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
                .MinimumLength(2).WithMessage("{PropertyName} should have at least {MinLength} characters.");

            RuleFor(p => p.ContractType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
                .MinimumLength(2).WithMessage("{PropertyName} should have at least {MinLength} characters.");

            RuleFor(p => p.ContractTypeCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be a positive integer.");
        }
    }
}
