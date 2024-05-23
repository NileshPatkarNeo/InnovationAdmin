using FluentValidation;
using InnovationAdmin.Application.Contracts.Persistence;
using System;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Create_SysPref_GeneralBehaviour
{
    public class Create_SysPref_GeneralBehaviour_CommandValidator : AbstractValidator<Create_SysPref_GeneralBehaviour_Command>
    {
        private readonly IMessageRepository _messageRepository;
        public Create_SysPref_GeneralBehaviour_CommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
                       
        }

        private bool Boolean(bool arg)
        {
            throw new NotImplementedException();
        }
    }
    }

