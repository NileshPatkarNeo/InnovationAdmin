using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Admin_Users.Commands.CreateAdmin_User
{
    public class CreateAdminUserValidator : AbstractValidator<CreateAdminUserCommand>
    {

        public CreateAdminUserValidator()
        {


            RuleFor(p => p.User_Name)
     .NotEmpty().WithMessage("UserName is not valid")
         .NotNull()
     .MaximumLength(50).WithMessage("Length should be less than 50 characters");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is not valid")
                .NotNull()
                .MaximumLength(40).WithMessage("Length should be less than 40 characters");

            RuleFor(p => p.Role)
                .NotEmpty().WithMessage("Role is an int value")
                .GreaterThan(0).WithMessage("Number should be greater than 0");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email is not valid")
                .EmailAddress().WithMessage("Put valid format of Email");

            RuleFor(p => p.Status)
                .NotNull().WithMessage("Boolean value");
        }

    }
}
