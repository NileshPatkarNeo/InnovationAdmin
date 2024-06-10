using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.RemittanceType.Commands.UpdateRemittanceType
{
    public class UpdateRemittanceTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
