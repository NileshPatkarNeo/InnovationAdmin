using InnovationAdmin.Application.Responses;
using MediatR;

namespace InnovationAdmin.Application.Features.ContractTerms.Commands.UpdateContractTerm
{
    public class UpdateContractTermCommand : IRequest<Response<UpdateContractTermDto>>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ContractType { get; set; }
        public int ContractTypeCode { get; set; }
    }
}
