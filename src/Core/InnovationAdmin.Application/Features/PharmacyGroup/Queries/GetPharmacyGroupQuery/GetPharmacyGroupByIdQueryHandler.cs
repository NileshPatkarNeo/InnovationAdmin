using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetPharmacyGroupQuery
{
    public class GetPharmacyGroupByIdQueryHandler : IRequestHandler<GetPharmacyGroupByIdQuery, Response<PharmacyGroupDto>>
    {
        private readonly IPharmacyGroupRepository _pharmacyGroupRepository;
        private readonly IMapper _mapper;

        public GetPharmacyGroupByIdQueryHandler(IPharmacyGroupRepository pharmacyGroupRepository, IMapper mapper)
        {
            _pharmacyGroupRepository = pharmacyGroupRepository;
            _mapper = mapper;
        }

        public async Task<Response<PharmacyGroupDto>> Handle(GetPharmacyGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var pharmacyGroup = await _pharmacyGroupRepository.GetByIdAsync(request.Id);

            if (pharmacyGroup == null)
            {
                return new Response<PharmacyGroupDto>("Company not found.");
            }

            var Dto = _mapper.Map<PharmacyGroupDto>(pharmacyGroup);
            return new Response<PharmacyGroupDto>(Dto);
        }
    }
}
