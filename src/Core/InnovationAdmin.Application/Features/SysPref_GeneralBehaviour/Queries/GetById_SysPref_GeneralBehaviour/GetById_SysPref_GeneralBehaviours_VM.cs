namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.GetById_SysPref_GeneralBehaviour
{
    public class GetById_SysPref_GeneralBehaviours_VM
    {
        public Guid Preference_ID { get; set; }
        public bool Auto_Change_Claim_Status { get; set; }
        public bool Claim_Status_Receipting { get; set; }
        public bool Claim_Status_Payment { get; set; }
        public bool Claim_Status_Zero_Paid { get; set; }
        public bool Claim_Status_Procare_Claim_Load { get; set; }
        public bool Logout_Redirect { get; set; }
        public int Records_Locked_Seconds { get; set; }
        public int User_Timeout { get; set; }
    }
}
