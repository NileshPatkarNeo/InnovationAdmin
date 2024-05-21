using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Admin_Users.Commands.DeleteAdminUser
{
    public class DeleteAdminUserCommandHandler : IRequestHandler<DeleteAdminUserCommand>
    {
        private readonly IAdminUserRepository _adminuserRepository;

        public DeleteAdminUserCommandHandler(IAdminUserRepository adminuserRepository)
        {
            _adminuserRepository = adminuserRepository;
        }

        public async Task<Unit> Handle(DeleteAdminUserCommand request, CancellationToken cancellationToken)
        {
            var adminuserId = new Guid(request.User_ID);
            var adminToDelete = await _adminuserRepository.GetByIdAsync(adminuserId);
            if (adminToDelete == null)
            {
                throw new NotFoundException(nameof(Admin_User), adminuserId);
            }
            await _adminuserRepository.DeleteAsync(adminToDelete);
            return Unit.Value;
            //throw new NotImplementedException();
        }

    }
}
