using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetPharmacyGroupQuery
{
    public class GetPharmacyGroupByIdQuery : IRequest<Response<PharmacyGroupDto>>
    {
        public Guid Id { get; set; }

    }
}
