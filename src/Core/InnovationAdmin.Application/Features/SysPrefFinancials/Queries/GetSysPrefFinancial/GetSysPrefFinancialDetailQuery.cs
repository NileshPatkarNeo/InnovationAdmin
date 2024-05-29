using InnovationAdmin.Application.Features.AdminRoles.Queries.GetAdminRole;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Queries.GetSysPrefFinancial
{
    public class GetSysPrefFinancialDetailQuery : IRequest<Response<SysPrefFinancialVM>>
    {
        public Guid FinancialID { get; set; }

    }
}
