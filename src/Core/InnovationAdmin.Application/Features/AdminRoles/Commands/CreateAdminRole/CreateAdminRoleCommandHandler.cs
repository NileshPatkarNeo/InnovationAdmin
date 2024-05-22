using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole
{
    public class CreateAdminRoleCommandHandler : IRequestHandler<CreateAdminRoleCommand, Response<CreateAdminRoleDto>>
    {
        private readonly IAdminRoleRepository _adminRoleService;

        public CreateAdminRoleCommandHandler(IAdminRoleRepository adminRoleService)
        {
            _adminRoleService = adminRoleService;
        }

        public async Task <Response<CreateAdminRoleDto>> Handle(CreateAdminRoleCommand request, CancellationToken cancellationToken)
        {
            Response<CreateAdminRoleDto> response = new Response<CreateAdminRoleDto>();


            // Perform validation, authorization, etc.
            var adminRole = await _adminRoleService.CreateAdminRoleAsync(request);
            response.Succeeded = true;
            response.Data = adminRole;

            return response;
        }

    }
}
