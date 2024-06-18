using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Helper;

namespace InnovationAdmin.Application.Features.ContractTerms.Commands.UpdateContractTerm
{
    public class UpdateContractTermCommandValidator : AbstractValidator<UpdateContractTermCommand>
    {
       

        public UpdateContractTermCommandValidator( )
        {
            

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is Required")
                .NotNull()
                .MaximumLength(100).WithMessage("Name should be less than 100 characters")
                .MinimumLength(2).WithMessage("Name should be greater than 2 characters");

            RuleFor(p => p.ContractType)
                .NotEmpty().WithMessage("ContractType is Required")
                .NotNull()
                .MaximumLength(50).WithMessage("ContractType should be less than 50 characters")
                .MinimumLength(2).WithMessage("ContractType should be greater than 2 characters");

            RuleFor(p => p.ContractTypeCode)
                .NotEmpty().WithMessage("ContractTypeCode is Required")
                .GreaterThan(0).WithMessage("ContractTypeCode should be greater than 0");
        }

    }
}
