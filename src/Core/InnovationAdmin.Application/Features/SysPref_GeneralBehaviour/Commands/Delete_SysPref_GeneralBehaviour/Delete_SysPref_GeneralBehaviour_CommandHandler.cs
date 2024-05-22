using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.DataProtection;



namespace InnovationAdmin.Application.Features.SysPref_GeneralBehaviour.Commands.Delete_SysPref_GeneralBehaviour
{
    public class Delete_SysPref_GeneralBehaviour_CommandHandler :IRequestHandler<Delete_SysPref_GeneralBehaviour_Command>
    {
        private readonly ISysPref_GeneralBehaviourRepository _sysPref_generalbehaviourRepository;
        public Delete_SysPref_GeneralBehaviour_CommandHandler(ISysPref_GeneralBehaviourRepository sysPref_generalbehaviourRepository, IDataProtectionProvider provider)
        {
            _sysPref_generalbehaviourRepository = sysPref_generalbehaviourRepository;
            //_protector = provider.CreateProtector("");
        }

        public async Task<Unit> Handle(Delete_SysPref_GeneralBehaviour_Command request, CancellationToken cancellationToken)
        {
            var preferenceId = request.Preference_ID;
            var sysToDelete = await _sysPref_generalbehaviourRepository.GetByIdAsync(preferenceId);

            if (sysToDelete == null)
            {
                throw new NotFoundException(nameof(SysPref_GeneralBehaviour), preferenceId);
            }

            await _sysPref_generalbehaviourRepository.DeleteAsync(sysToDelete);
            return Unit.Value;
        }
    }
}
