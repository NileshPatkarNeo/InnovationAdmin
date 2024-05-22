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
                .NotEmpty().WithMessage("Error")
                .NotNull()
                .MaximumLength(50).WithMessage("Error");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Error")
                .NotNull()
                .MinimumLength(8).WithMessage("Error");

            RuleFor(p => p.Role)
                .NotEmpty().WithMessage("Error")
                .GreaterThan(0).WithMessage("Error");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Error")
                .EmailAddress().WithMessage("Error");

            RuleFor(p => p.Status)
                .NotNull().WithMessage("Error");
        }

        //private string GetMessage(string Code, string Lang)
        //{
        //    return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        //}
    }
}
