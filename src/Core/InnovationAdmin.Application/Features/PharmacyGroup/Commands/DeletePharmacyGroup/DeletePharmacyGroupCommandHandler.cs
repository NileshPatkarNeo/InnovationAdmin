using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.DeleteSysPrefCommand;
using InnovationAdmin.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Commands.DeletePharmacyGroup
{
    public class DeletePharmacyGroupCommandHandler : IRequestHandler<DeletePharmacyGroupCommand, Response<bool>>
    {
        private readonly IPharmacyGroupRepository _pharmacyGroupRepository;


        public DeletePharmacyGroupCommandHandler(IPharmacyGroupRepository pharmacyGroupRepository)
    {
            _pharmacyGroupRepository = pharmacyGroupRepository;
    }

    public async Task<Response<bool>> Handle(DeletePharmacyGroupCommand request, CancellationToken cancellationToken)
    {
        var pharmacyGroupToDelete = await _pharmacyGroupRepository.GetByIdAsync(request.Id);

        if (pharmacyGroupToDelete == null)
        {
            return new Response<bool>($"PharmacyGroup with id {request.Id} not found.");
        }

        await _pharmacyGroupRepository.DeleteAsync(pharmacyGroupToDelete);

        return new Response<bool>(true, "PharmacyGroup deleted successfully.");
    }
}
}
