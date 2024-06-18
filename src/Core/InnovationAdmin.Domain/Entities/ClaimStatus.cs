using InnovationAdmin.Domain.Common;


namespace InnovationAdmin.Domain.Entities
{
    public  class ClaimStatus : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string color { get; set; }   
    }
}
