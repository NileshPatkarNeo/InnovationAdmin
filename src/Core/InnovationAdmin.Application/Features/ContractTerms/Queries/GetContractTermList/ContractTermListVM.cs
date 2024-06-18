using System;

namespace InnovationAdmin.Application.Features.ContractTerms.Queries.GetContractTermsList
{
    public class ContractTermListVM
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ContractType { get; set; }
        public int ContractTypeCode { get; set; }
    }
}
