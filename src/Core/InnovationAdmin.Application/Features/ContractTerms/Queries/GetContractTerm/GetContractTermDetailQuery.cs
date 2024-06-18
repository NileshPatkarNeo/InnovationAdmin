using InnovationAdmin.Application.Responses;
using MediatR;
using System;

namespace InnovationAdmin.Application.Features.ContractTerms.Queries.GetContractTerm
{
    public class GetContractTermDetailQuery : IRequest<Response<ContractTermVM>>
    {
        public Guid ID { get; set; }
    }
}
