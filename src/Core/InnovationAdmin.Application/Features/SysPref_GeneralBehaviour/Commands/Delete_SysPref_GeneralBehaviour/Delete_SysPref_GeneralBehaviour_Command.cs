using MediatR;

namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Delete_SysPref_GeneralBehaviour
{
    public class Delete_SysPref_GeneralBehaviour_Command : IRequest
    {
        public Guid Preference_ID { get; set; }
    }
}
