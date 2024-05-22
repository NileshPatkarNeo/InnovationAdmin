using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefCompanies.Commands.DeleteSysPrefCommand
{
    public class DeleteSysPrefCompanyCommand : IRequest<Response<bool>>
    {
        public Guid CompanyId { get; set; }
    }
}
