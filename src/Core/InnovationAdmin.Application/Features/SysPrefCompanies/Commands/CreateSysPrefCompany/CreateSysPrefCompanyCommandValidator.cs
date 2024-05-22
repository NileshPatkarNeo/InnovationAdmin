using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefCompanies.Commands.CreateSysPrefCompany
{
    public class CreateSysPrefCompanyCommandValidator : AbstractValidator<CreateSysPrefCompanyCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public CreateSysPrefCompanyCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(50).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

            RuleFor(p => p.TermForPharmacy)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(50).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }

}
