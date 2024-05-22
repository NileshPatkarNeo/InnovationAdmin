using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRole
{
    public class GetAdminRoleDetailQuery : IRequest<Response<AdminRoleVM>>
    {
        public Guid Role_ID { get; set; }
    }
}
