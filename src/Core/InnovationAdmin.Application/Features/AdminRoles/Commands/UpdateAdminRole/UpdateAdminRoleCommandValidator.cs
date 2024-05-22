using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Commands.UpdateAdminRole
{
    public class UpdateAdminRoleCommandValidator : AbstractValidator<UpdateAdminRoleCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public UpdateAdminRoleCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Role_Name)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(50).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

            //RuleFor(p => p.Price)
            //    .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
            //    .GreaterThan(0);
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
