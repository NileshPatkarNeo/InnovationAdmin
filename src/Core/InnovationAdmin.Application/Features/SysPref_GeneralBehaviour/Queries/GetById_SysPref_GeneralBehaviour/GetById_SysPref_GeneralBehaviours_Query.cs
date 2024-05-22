using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Queries.GetById_SysPref_GeneralBehaviour
{
    public class GetById_SysPref_GeneralBehaviours_Query : IRequest<Response<GetById_SysPref_GeneralBehaviours_VM>>
    {
        public Guid Preference_ID { get; set; }
    }
}
