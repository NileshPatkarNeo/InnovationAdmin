using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Create_SysPref_GeneralBehaviour
{
    public class Create_SysPref_GeneralBehaviour_CommandValidator : AbstractValidator<Create_SysPref_GeneralBehaviour_Command>
    {
        private readonly IMessageRepository _messageRepository;
        public Create_SysPref_GeneralBehaviour_CommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
                       
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
