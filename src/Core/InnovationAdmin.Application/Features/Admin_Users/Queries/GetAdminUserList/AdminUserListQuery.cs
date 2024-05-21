using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Admin_Users.Queries.GetAdminUserList
{
    public class AdminUserListQuery :  IRequest<Response<IEnumerable<AdminUserListVm>>>
    {
    }
}
