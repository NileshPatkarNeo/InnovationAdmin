using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.CreateDoNotTakeGroup
{
    public class CreateDoNotTakeGroupCommand : IRequest<Response<CreateDoNoTakeGroupDto>>
    {
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
    }
}
