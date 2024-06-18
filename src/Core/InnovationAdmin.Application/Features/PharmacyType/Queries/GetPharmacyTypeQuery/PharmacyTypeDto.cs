using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Queries.GetPharmacyTypeQuery
{
    public class PharmacyTypeDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
    }
}
