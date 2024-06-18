using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ClaimStatus.Commands.CreateClaimStatus
{
    public class CreateClaimStatusDto
    {
       public Guid ID { get; set; }
        public string Name { get; set; }    
        public string Color { get; set; } 
    }
}
