using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.UpdateDoNotTakeGroup
{
    public class UpdateDoNotTakeGroupCommand : IRequest<Response<UpdateDoNotTakeGroupDto>>
    {
        public Guid Id { get; set; }        
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
    }
}
