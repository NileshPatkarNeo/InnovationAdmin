using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Commands.CreatePharmacyType
{
    public class CreatePharmacyTypeDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
    }
}
