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
        private readonly IAdminRoleRepository _adminRoleRepository;
        public CreateAdminRoleCommandValidator(IAdminRoleRepository adminRoleRepository)
        {
            _adminRoleRepository = adminRoleRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .NotNull().WithMessage("Name should not be empty")
                .MaximumLength(10).WithMessage("Max Length of Name is 10");
        }

       
    }
}
