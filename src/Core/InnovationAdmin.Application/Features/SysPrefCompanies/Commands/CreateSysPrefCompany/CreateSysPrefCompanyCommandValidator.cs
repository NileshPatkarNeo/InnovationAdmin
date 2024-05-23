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
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");



            RuleFor(p => p.TermForPharmacy)
               .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");



        }

    }
}
