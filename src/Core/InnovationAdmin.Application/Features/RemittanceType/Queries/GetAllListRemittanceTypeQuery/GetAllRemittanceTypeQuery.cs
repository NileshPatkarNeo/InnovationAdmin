using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetPharmacyGroupQuery;
using InnovationAdmin.Application.Features.RemittanceType.Queries.GetRemittanceTypeQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.RemittanceType.Queries.GetAllListRemittanceTypeQuery
{
    public class GetAllRemittanceTypeQuery : IRequest<Response<IEnumerable<RemittanceTypeDto>>>
    {

    }
}
