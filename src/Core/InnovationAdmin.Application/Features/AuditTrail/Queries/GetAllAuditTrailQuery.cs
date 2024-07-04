using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AuditTrail.Queries
{
    public class GetAllAuditTrailQuery : IRequest<Response<IEnumerable<AuditTrailDto>>>
    {
    }
}
