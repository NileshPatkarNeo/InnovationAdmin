using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.DoNotTakeGroup.Queries.GetDoNotTakeGroupQuery
{
    public class DoNotTakeGroupDto
    {
        public Guid Id { get; set; }
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
    }
}
