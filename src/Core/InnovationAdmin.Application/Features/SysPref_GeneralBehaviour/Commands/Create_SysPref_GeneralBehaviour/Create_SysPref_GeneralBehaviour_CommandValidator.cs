﻿using FluentValidation;
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


            //RuleFor(p => p.Auto_Change_Claim_Status)
            //    .NotNull().WithMessage("{PropertyName} is required.")
            //    .Must(Boolean).WithMessage("{PropertyName} must be a boolean value (true or false).");

            RuleFor(p => p.Records_Locked_Seconds)
             .NotEmpty().WithMessage("Error")
             .GreaterThan(0).WithMessage("Error");

            RuleFor(p => p.User_Timeout)
             .NotEmpty().WithMessage("Error")
             .GreaterThan(0).WithMessage("Error");
        }

        private bool Boolean(bool arg)
        {
            throw new NotImplementedException();
        }
    }
    }

