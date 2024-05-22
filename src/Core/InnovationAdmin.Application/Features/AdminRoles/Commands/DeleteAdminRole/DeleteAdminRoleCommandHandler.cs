using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole
{
    public class DeleteAdminRoleCommandHandler : IRequestHandler<DeleteAdminRoleCommand>
    {
        private readonly IAdminRoleRepository _adminRoleRepository;

        public DeleteAdminRoleCommandHandler(IAdminRoleRepository adminRoleRepository)
        {
            _adminRoleRepository = adminRoleRepository;
        }

        public async Task<Unit> Handle(DeleteAdminRoleCommand request, CancellationToken cancellationToken)
        {
            var adminRoleId = request.Role_ID;
            var adminRoleToDelete = await _adminRoleRepository.GetByIdAsync(adminRoleId);
            if (adminRoleToDelete == null)
            {
                throw new NotFoundException(nameof(AdminRoles), adminRoleId);
            }
            await _adminRoleRepository.DeleteAsync (adminRoleToDelete);
            return Unit.Value;
            //throw new NotImplementedException();
        }
    }
}
