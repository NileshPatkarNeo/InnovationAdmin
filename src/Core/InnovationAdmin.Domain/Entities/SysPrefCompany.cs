using InnovationAdmin.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Domain.Entities
{
    public class SysPrefCompany : AuditableEntity
    {
        [Key]
        public Guid CompanyID { get; set; }  
        public string CompanyName { get; set; }
        public string TermForPharmacy { get; set; }
    }
}
