using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AccountManager.Commands.DeleteAccountManager
{
    public class DeleteAccountManagerCommandHandler : IRequestHandler<DeleteAccountManagerCommand, Response<Guid>>
    {
        private readonly IAccountManagerRepository _accountManagerRepository;

        public DeleteAccountManagerCommandHandler(IAccountManagerRepository accountManagerRepository)
        {
            _accountManagerRepository = accountManagerRepository;
        }

        public async Task<Response<Guid>> Handle(DeleteAccountManagerCommand request, CancellationToken cancellationToken)
        {
            var accountManagerToDelete = await _accountManagerRepository.GetByIdAsync(request.Id);
            if (accountManagerToDelete == null)
            {
                throw new NotFoundException(nameof(AccountManager), request.Id);
            }

            await _accountManagerRepository.DeleteAsync(accountManagerToDelete);
            return new Response<Guid>(request.Id, "Account manager deleted successfully");
        }
    }
}