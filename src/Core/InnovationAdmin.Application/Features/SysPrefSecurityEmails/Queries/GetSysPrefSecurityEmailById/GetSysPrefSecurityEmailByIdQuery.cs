using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Queries.GetSysPrefSecurityEmailById
{
    public class GetSysPrefSecurityEmailByIdQuery : IRequest<Response<GetSysPrefSecurityEmailByIdVm>>
    {
        public String SysPrefSecurityEmailId { get; set; }


    }
}
