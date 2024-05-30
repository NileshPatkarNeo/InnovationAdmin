using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefSecurityEmails.Commands.DeleteSysPrefSecurityEmail
{
    public class DeleteSysPrefSecurityEmailCommand : IRequest
    {
        public Guid SysPrefSecurityEmailId { get; set; }
    
    }
}
