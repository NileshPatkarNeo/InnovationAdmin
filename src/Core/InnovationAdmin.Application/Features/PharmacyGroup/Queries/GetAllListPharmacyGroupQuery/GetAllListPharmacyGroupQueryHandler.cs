using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetPharmacyGroupQuery;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetAllListSysPrefCompnayQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetAllListPharmacyGroupQuery
{
    public class GetAllListPharmacyGroupQueryHandler : IRequestHandler<GetAllPharmacyGroupQuery, Response<IEnumerable<PharmacyGroupDto>>>
    {
        private readonly IPharmacyGroupRepository _pharmacyGroupRepository;
        private readonly IMapper _mapper;

        public GetAllListPharmacyGroupQueryHandler(IPharmacyGroupRepository pharmacyGroupRepository, IMapper mapper)
        {
            _pharmacyGroupRepository = pharmacyGroupRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<PharmacyGroupDto>>> Handle(GetAllPharmacyGroupQuery request, CancellationToken cancellationToken)
        {
            var sysPrefCompanies = await _pharmacyGroupRepository.ListAllAsync();
            var sysPrefCompaniesDto = _mapper.Map<IEnumerable<PharmacyGroupDto>>(sysPrefCompanies);
            return new Response<IEnumerable<PharmacyGroupDto>>(sysPrefCompaniesDto);
        }

    }
}
