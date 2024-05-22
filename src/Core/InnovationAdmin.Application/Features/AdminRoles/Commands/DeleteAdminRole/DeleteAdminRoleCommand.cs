using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Commands.DeleteAdminRole
{
    public class DeleteAdminRoleCommand : IRequest
    {
        public Guid Role_ID { get; set; }
    }
}
