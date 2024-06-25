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
            
            var claimToUpdate = await _pharmacyTypeRepository.GetByIdAsync(request.Id);

            if (claimToUpdate == null)
            {
                return new Response<bool>($"Pharmacy Type with id {request.Id} not found.");
            }


            claimToUpdate.IsDeleted = false;


            await _pharmacyTypeRepository.UpdateAsync(claimToUpdate);

            return new Response<bool>(true, "Pharmacy Type Deleted successfully.");



        }



    }
}
