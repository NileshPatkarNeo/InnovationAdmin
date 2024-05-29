using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRoleList;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Queries.GetSysPrefFinancialList
{
    public class GetSysPrefFinancialsListQuery : IRequest<Response<IEnumerable<SysPrefFinancialListVM>>>
    {
    }
}
