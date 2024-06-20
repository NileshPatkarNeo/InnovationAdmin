using InnovationAdmin.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace InnovationAdmin.Application.Features.ContractTerms.Queries.GetContractTermsList
{
    public class GetContractTermsListQuery : IRequest<Response<IEnumerable<ContractTermListVM>>>
    {
    }
}
