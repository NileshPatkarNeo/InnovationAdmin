using FluentValidation;

namespace InnovationAdmin.Application.Features.Quote.Commands.CreateQuote
{
    public class CreateQuoteCommandValidator : AbstractValidator<CreateQuoteCommand>
    {
        public CreateQuoteCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
                .MinimumLength(2).WithMessage("{PropertyName} should have at least {MinLength} characters.");
                

            RuleFor(p => p.QuoteBy)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
                .MinimumLength(2).WithMessage("{PropertyName} should have at least {MinLength} characters.");
               
        }
    }
}
