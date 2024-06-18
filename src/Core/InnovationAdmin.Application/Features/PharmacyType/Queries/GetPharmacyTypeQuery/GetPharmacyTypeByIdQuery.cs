using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Queries.GetPharmacyTypeQuery
{
    public class GetPharmacyTypeByIdQuery : IRequest<Response<PharmacyTypeDto>>
    {
        public Guid Id { get; set; }
    }
}
