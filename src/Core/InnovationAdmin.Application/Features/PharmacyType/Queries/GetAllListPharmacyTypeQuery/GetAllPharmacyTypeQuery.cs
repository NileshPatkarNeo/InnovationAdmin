using InnovationAdmin.Application.Features.PharmacyType.Queries.GetPharmacyTypeQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Queries.GetAllListPharmacyTypeQuery
{
    public class GetAllPharmacyTypeQuery : IRequest<Response<IEnumerable<PharmacyTypeDto>>>
    {

    }
}
