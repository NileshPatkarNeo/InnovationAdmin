using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailList
{
    public class GetSysPrefSecurityEmailListQuery : IRequest<Response<IEnumerable<GetSysPrefSecurityEmailListVm>>>
    {
    }
}
