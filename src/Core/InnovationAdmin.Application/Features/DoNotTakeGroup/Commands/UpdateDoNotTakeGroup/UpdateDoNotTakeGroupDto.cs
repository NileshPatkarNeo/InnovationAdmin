using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Commands.UpdateDoNotTakeGroup
{
    public class UpdateDoNotTakeGroupDto
    {
        public Guid Id { get; set; }
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
    }
}
