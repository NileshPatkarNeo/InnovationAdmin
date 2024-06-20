namespace InnovationAdmin.Application.Features.ContractTerms.Commands.CreateContractTerm
{
    public class CreateContractTermDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ContractType { get; set; }
        public int ContractTypeCode { get; set; }
    }
}
 