using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.DeletePharmacyGroup;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Commands.DeletePharmacyType
{
    public class DeletePharmacyTypeCommandHandler : IRequestHandler<DeletePharmacyTypeCommand, Response<bool>>
    {
        private readonly IPharmacyTypeRepository _pharmacyTypeRepository;

        public DeletePharmacyTypeCommandHandler(IPharmacyTypeRepository pharmacyTypeRepository)
        {
            _pharmacyTypeRepository = pharmacyTypeRepository;
        }

        public async Task<Response<bool>> Handle(DeletePharmacyTypeCommand request, CancellationToken cancellationToken)
        {
            var pharmacyTypeToDelete = await _pharmacyTypeRepository.GetByIdAsync(request.Id);

            if (pharmacyTypeToDelete == null)
            {
                return new Response<bool>($"PharmacyType with id {request.Id} not found.");
            }

            await _pharmacyTypeRepository.DeleteAsync(pharmacyTypeToDelete);

            return new Response<bool>(true, "PharmacyType deleted successfully.");
        }



    }
}
