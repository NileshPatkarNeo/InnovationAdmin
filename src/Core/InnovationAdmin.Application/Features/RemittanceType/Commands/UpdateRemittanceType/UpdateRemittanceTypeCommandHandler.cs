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

namespace InnovationAdmin.Application.Features.RemittanceType.Commands.UpdateRemittanceType
{
    public class UpdateRemittanceTypeCommandHandler : IRequestHandler<UpdateRemittanceTypeCommand, Response<UpdateRemittanceTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRemittanceTypeRepository _remittanceTypeRepository;

        public UpdateRemittanceTypeCommandHandler(IMapper mapper, IRemittanceTypeRepository remittanceTypeRepository)
        {
            _mapper = mapper;
            _remittanceTypeRepository = remittanceTypeRepository;
        }

        public async Task<Response<UpdateRemittanceTypeDto>> Handle(UpdateRemittanceTypeCommand request, CancellationToken cancellationToken)
        {
            var remittanceTypeToUpdate = await _remittanceTypeRepository.GetByIdAsync(request.Id);

            if (remittanceTypeToUpdate == null)
            {
                throw new NotFoundException(nameof(RemittanceType), request.Id);
            }

            remittanceTypeToUpdate.Name = request.Name;

            remittanceTypeToUpdate.LastModifiedDate = DateTime.Now;

            await _remittanceTypeRepository.UpdateAsync(remittanceTypeToUpdate);

            var Dto = _mapper.Map<UpdateRemittanceTypeDto>(remittanceTypeToUpdate);

            return new Response<UpdateRemittanceTypeDto>(Dto, "Remittance Type updated successfully");
        }

    }
}
