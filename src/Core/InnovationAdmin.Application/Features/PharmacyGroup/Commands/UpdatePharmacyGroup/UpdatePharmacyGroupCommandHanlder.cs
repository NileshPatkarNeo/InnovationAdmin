using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.SysPrefCompanies.Commands.UpdateSysPrefCompany;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup
{
    public class UpdatePharmacyGroupCommandHanlder : IRequestHandler<UpdatePharmacyGroupCommand, Response<UpdatePharmacyGroupDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPharmacyGroupRepository _pharmacyGroupRepository;

        public UpdatePharmacyGroupCommandHanlder(IMapper mapper, IPharmacyGroupRepository pharmacyGroupRepository)
        {
            _mapper = mapper;
            _pharmacyGroupRepository = pharmacyGroupRepository;
        }

        public async Task<Response<UpdatePharmacyGroupDto>> Handle(UpdatePharmacyGroupCommand request, CancellationToken cancellationToken)
        {
            var pharmacyGroupToUpdate = await _pharmacyGroupRepository.GetByIdAsync(request.Id);

            if (pharmacyGroupToUpdate == null)
            {
                throw new NotFoundException(nameof(PharmacyGroup), request.Id);
            }

            pharmacyGroupToUpdate.PharmacyName = request.PharmacyName;

            pharmacyGroupToUpdate.LastModifiedDate = DateTime.Now;

            await _pharmacyGroupRepository.UpdateAsync(pharmacyGroupToUpdate);

            var Dto = _mapper.Map<UpdatePharmacyGroupDto>(pharmacyGroupToUpdate);

            return new Response<UpdatePharmacyGroupDto>(Dto, "SysPrefCompany updated successfully");
        }
    }
}
