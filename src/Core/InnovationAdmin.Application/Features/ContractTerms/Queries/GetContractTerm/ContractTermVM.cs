using System;

namespace InnovationAdmin.Application.Features.ContractTerms.Queries.GetContractTerm
{
    public class ContractTermVM
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ContractType { get; set; }
        public int ContractTypeCode { get; set; }
    }
}
