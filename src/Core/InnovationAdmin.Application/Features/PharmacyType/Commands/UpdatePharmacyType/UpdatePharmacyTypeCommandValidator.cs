using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup;
using InnovationAdmin.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Commands.UpdatePharmacyType
{
    public class UpdatePharmacyTypeCommandValidator : AbstractValidator<UpdatePharmacyTypeCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdatePharmacyTypeCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(50).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

            RuleFor(p => p.Code)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .GreaterThan(0).WithMessage("{PropertyName} must not exceed {MaxLength}.");


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
