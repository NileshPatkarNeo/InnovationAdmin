using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetAllListPharmacyGroupQuery;
using InnovationAdmin.Application.Features.PharmacyType.Queries.GetPharmacyTypeQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Queries.GetAllListPharmacyTypeQuery
{
    public class GetAllListPharmacyTypeQueryHandler : IRequestHandler<GetAllPharmacyTypeQuery, Response<IEnumerable<PharmacyTypeDto>>>
    {
        private readonly IPharmacyTypeRepository _pharmacyTypeRepository;
        private readonly IMapper _mapper;

        public GetAllListPharmacyTypeQueryHandler(IPharmacyTypeRepository pharmacyTypeRepository, IMapper mapper)
        {
            _pharmacyTypeRepository = pharmacyTypeRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<PharmacyTypeDto>>> Handle(GetAllPharmacyTypeQuery request, CancellationToken cancellationToken)
        {
            var type = await _pharmacyTypeRepository.ListAllAsync();
            var typeDto = _mapper.Map<IEnumerable<PharmacyTypeDto>>(type);
            return new Response<IEnumerable<PharmacyTypeDto>>(typeDto);
        }

    }
}
