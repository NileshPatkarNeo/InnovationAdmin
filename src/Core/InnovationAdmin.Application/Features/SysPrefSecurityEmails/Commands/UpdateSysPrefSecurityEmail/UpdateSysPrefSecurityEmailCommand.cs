using InnovationAdmin.Application.Features.Admin_Users.Commands.UpdateAdminUser;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.UpdateSysPrefSecurityEmail
{
    public class UpdateSysPrefSecurityEmailCommand : IRequest<Response<UpdateSysPrefSecurityEmailCommandDto>>
    {

        public Guid SysPrefSecurityEmailId { get; set; }


        public string DefaultFromName { get; set; }


        public string DefaultFromAddress { get; set; }

        public string DefaultReplyToAddress { get; set; }


        public string DefaultReplyToName { get; set; }

        public int Status { get; set; }
    }
}
