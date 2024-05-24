using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole
{
    public class CreateAdminRoleCommandValidator : AbstractValidator<CreateAdminRoleCommand>
    {
        public CreateAdminRoleCommandValidator() {
       

        

           
            RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(p => p.Name)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        }

    }
}
