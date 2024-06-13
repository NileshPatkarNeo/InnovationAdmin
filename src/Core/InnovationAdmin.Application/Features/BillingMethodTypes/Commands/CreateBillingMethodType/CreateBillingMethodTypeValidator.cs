using FluentValidation;
using InnovationAdmin.Application.Features.DataSources.Commands.CreateDataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.BillingMethodTypes.Commands.CreateBillingMethodType
{
    public class CreateBillingMethodTypeValidator : AbstractValidator<CreateBillingMethodTypeCommand>
    {
        public CreateBillingMethodTypeValidator()
        {

           RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull().WithMessage("{PropertyName} is required.")
          .MaximumLength(50).WithMessage("Length should be less than 50 characters");
        }
    }
}
