using FluentValidation;
using InnovationAdmin.Application.Features.DataSources.Commands.UpdateDataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.BillingMethodTypes.Commands.UpdateBillingMethodType
{
    public class UpdateBillingMethodTypeCommandValidator : AbstractValidator<UpdateBillingMethodTypeCommand>
    {
        public UpdateBillingMethodTypeCommandValidator()
        {
            RuleFor(p => p.Name)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull().WithMessage("{PropertyName} is required.")
           .MaximumLength(50).WithMessage("Length should be less than 50 characters");
        }
    }
}
