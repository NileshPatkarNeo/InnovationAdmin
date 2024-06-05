using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.RemittanceType.Commands.CreateRemittanceType
{
    public class CreateRemittanceTypeDto
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
