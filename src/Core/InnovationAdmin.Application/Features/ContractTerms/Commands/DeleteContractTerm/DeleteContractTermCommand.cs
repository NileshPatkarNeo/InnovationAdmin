using MediatR;
using System;

namespace InnovationAdmin.Application.Features.ContractTerms.Commands.DeleteContractTerm
{
    public class DeleteContractTermCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
