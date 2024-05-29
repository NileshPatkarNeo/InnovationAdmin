using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.AccountManager.Commands.CreateAccountManager;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AccountManager.Commands.UpdateAccountManager
{
    public class UpdateAccountManagerCommandHandler : IRequestHandler<UpdateAccountManagerCommand, Response<Guid>>
    {
        private readonly IAccountManagerRepository _accountManagerRepository;
        private readonly IMessageRepository _messageRepository;

        public UpdateAccountManagerCommandHandler(IAccountManagerRepository accountManagerRepository, IMessageRepository messageRepository)
        {
            _accountManagerRepository = accountManagerRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateAccountManagerCommand request, CancellationToken cancellationToken)
        {
            var accountManagerToUpdate = await _accountManagerRepository.GetByIdAsync(request.Id);
            if (accountManagerToUpdate == null)
            {
                throw new NotFoundException(nameof(AccountManager), request.Id);
            }

            var validator = new UpdateAccountManagerCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }


            accountManagerToUpdate.Name = request.Name;

            await _accountManagerRepository.UpdateAsync(accountManagerToUpdate);
            return new Response<Guid>(request.Id, "Account manager updated successfully");
        }
    }
}
