using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup
{
    public class UpdatePharmacyGroupDto
    {
        public Guid Id { get; set; }
        public string PharmacyName { get; set; }
    }
}
