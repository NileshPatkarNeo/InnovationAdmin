using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Commands.UpdatePharmacyType
{
    public class UpdatePharmacyTypeCommandHanlder : IRequestHandler<UpdatePharmacyTypeCommand, Response<UpdatePharmacyTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPharmacyTypeRepository _pharmacyTypeRepository;

        public UpdatePharmacyTypeCommandHanlder(IMapper mapper, IPharmacyTypeRepository pharmacyTypeRepository)
        {
            _mapper = mapper;
            _pharmacyTypeRepository = pharmacyTypeRepository;
        }

        public async Task<Response<UpdatePharmacyTypeDto>> Handle(UpdatePharmacyTypeCommand request, CancellationToken cancellationToken)
        {
            var pharmacyTypeToUpdate = await _pharmacyTypeRepository.GetByIdAsync(request.Id);

            if (pharmacyTypeToUpdate == null)
            {
                throw new NotFoundException(nameof(PharmacyType), request.Id);
            }

            pharmacyTypeToUpdate.Description = request.Description;

            pharmacyTypeToUpdate.Code = request.Code;

            pharmacyTypeToUpdate.LastModifiedDate = DateTime.Now;

            await _pharmacyTypeRepository.UpdateAsync(pharmacyTypeToUpdate);

            var Dto = _mapper.Map<UpdatePharmacyTypeDto>(pharmacyTypeToUpdate);

            return new Response<UpdatePharmacyTypeDto>(Dto, "PharmacyType updated successfully");
        }
    }
}
