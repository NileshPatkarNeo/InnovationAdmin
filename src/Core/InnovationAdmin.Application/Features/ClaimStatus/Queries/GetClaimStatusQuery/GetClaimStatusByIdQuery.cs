using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.ClaimStatus.Queries.GetClaimStatusQuery
{
    public class GetClaimStatusByIdQuery : IRequest<Response<ClaimStatusDto>>
    {
        public GetClaimStatusByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
