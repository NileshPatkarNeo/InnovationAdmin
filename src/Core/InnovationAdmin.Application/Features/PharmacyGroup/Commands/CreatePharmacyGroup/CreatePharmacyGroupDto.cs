using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Commands.CreatePharmacyGroup
{
    public class CreatePharmacyGroupDto
    {
        public Guid Id { get; set; }

        public string PharmacyName { get; set; }
    }
}
