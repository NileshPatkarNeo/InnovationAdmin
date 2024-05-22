using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery
{
    public class GetSysPrefCompanyByIdQuery : IRequest<Response<SysPrefCompanyDto>>
    {
        public Guid CompanyID { get; set; }

        public GetSysPrefCompanyByIdQuery(Guid companyId)
        {
            CompanyID = companyId;
        }
    }
}
