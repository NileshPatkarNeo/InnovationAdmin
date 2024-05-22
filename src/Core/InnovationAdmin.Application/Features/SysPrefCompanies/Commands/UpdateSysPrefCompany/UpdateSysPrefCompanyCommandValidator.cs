using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Helper;
using System;

namespace InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany
{
    public class UpdateSysPrefCompanyCommandValidator : AbstractValidator<UpdateSysPrefCompanyCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateSysPrefCompanyCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));

            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(50).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

            RuleFor(p => p.TermForPharmacy)
                .NotEmpty().WithMessage(GetMessage("3", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(50).WithMessage(GetMessage("4", ApplicationConstants.LANG_ENG));
        }

        private string GetMessage(string code, string lang)
        {
            try
            {
                var result = _messageRepository.GetMessage(code, lang).Result;
                if (result != null && result.MessageContent != null)
                {
                    return result.MessageContent.ToString();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Exception occurred in GetMessage: {ex.Message}");
            }

            // Return a default message if unable to fetch from _messageRepository
            return "Default message"; // Or any default message you want to return
        }
    }
}
