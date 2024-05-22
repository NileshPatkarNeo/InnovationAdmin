using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery
{
    public class SysPrefCompanyDto
    {
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string TermForPharmacy { get; set; }
    }
}
