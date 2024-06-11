using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailList;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceList
{
    public class GetDataSourceListQuery : IRequest<Response<IEnumerable<GetDataSourceListVm>>>
    {
    }
}
