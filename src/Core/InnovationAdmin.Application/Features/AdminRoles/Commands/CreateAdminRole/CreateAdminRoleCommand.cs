using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Commands.CreateAdminRole
{
    public class CreateAdminRoleCommand : IRequest<Response<CreateAdminRoleDto>>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
