using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetPharmacyGroupQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Queries.GetPharmacyTypeQuery
{
    public class GetPharmacyTypeByIdQueryHandler : IRequestHandler<GetPharmacyTypeByIdQuery, Response<PharmacyTypeDto>>
    {
        private readonly IPharmacyTypeRepository _pharmacyTypeRepository;
        private readonly IMapper _mapper;

        public GetPharmacyTypeByIdQueryHandler(IPharmacyTypeRepository pharmacyTypeRepository, IMapper mapper)
        {
            _pharmacyTypeRepository = pharmacyTypeRepository;
            _mapper = mapper;
        }

        public async Task<Response<PharmacyTypeDto>> Handle(GetPharmacyTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var pharmacyType = await _pharmacyTypeRepository.GetByIdAsync(request.Id);

            if (pharmacyType == null)
            {
                return new Response<PharmacyTypeDto>("Type not found.");
            }

            var Dto = _mapper.Map<PharmacyTypeDto>(pharmacyType);
            return new Response<PharmacyTypeDto>(Dto);
        }
    }
}
