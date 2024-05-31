using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Commands.DeleteSysPrefFinancial
{
    public class DeleteSysPrefFinancialCommand : IRequest
    {
        public Guid FinancialID { get; set; }
    }
}
