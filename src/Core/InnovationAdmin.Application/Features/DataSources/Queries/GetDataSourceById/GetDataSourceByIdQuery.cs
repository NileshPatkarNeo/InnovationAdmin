using InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailById;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceById
{
    public class GetDataSourceByIdQuery : IRequest<Response<GetDataSourceByIdVm>>
    {
        public String ID { get; set; }
    }
}
