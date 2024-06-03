using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup
{
    public class UpdatePharmacyGroupCommandValidator : AbstractValidator<UpdatePharmacyGroupCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdatePharmacyGroupCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));

            RuleFor(p => p.PharmacyName)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(50).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

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
