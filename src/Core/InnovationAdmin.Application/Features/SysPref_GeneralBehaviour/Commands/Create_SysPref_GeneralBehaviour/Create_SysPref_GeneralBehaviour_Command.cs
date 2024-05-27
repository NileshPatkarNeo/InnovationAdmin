using InnovationAdmin.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Create_SysPref_GeneralBehaviour
{
    public class Create_SysPref_GeneralBehaviour_Command :IRequest<Response<Create_SysPref_GeneralBehaviour_Dto>>
    {
        //public Guid Preference_ID { get; set; }
        public bool Auto_Change_Claim_Status { get; set; }
        public bool Claim_Status_Receipting { get; set; }
        public bool Claim_Status_Payment { get; set; }
        public bool Claim_Status_Zero_Paid { get; set; }
        public bool Claim_Status_Procare_Claim_Load { get; set; }
        public bool Logout_Redirect { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Records_Locked_Seconds must be greater than 0")]

        public int Records_Locked_Seconds { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Records_Locked_Seconds must be greater than 0")]

        public int User_Timeout { get; set; }
    }
}
