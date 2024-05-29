using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Domain.Entities;
using System;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Commands.CreateSysPrefFinancial
{
    public class CreateSysPrefFinancialCommandValidator : AbstractValidator<CreateSysPrefFinancialCommand>
    {
        private readonly IAsyncRepository<SysPrefCompany> _companyRepository;

        public CreateSysPrefFinancialCommandValidator(IAsyncRepository<SysPrefCompany> companyRepository)
        {
            _companyRepository = companyRepository;

            RuleFor(p => p.CompanyID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (id, cancellation) => await CompanyExists(id)).WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.DefaultPaymentMethod)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(p => p.LastCheckNo)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");

            RuleFor(p => p.ClaimAgeCollectionStart)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.ClaimAgeCollectionEnd)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(p => p.ClaimAgeCollectionStart).WithMessage("{PropertyName} must be after {ComparisonValue}.");

            RuleFor(p => p.DefaultReceiptBatchDescription)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(p => p.ClaimPaidThreshold)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");

            RuleFor(p => p.ClaimStatusWriteOff)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(p => p.DaysToBlock)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");
        }

        private async Task<bool> CompanyExists(Guid companyId)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);
            return company != null;
        }
    }
}
