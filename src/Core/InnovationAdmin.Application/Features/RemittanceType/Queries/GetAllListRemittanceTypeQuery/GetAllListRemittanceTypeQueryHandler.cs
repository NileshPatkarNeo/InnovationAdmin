using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetAllListPharmacyGroupQuery;
using InnovationAdmin.Application.Features.PharmacyGroup.Queries.GetPharmacyGroupQuery;
using InnovationAdmin.Application.Features.RemittanceType.Queries.GetRemittanceTypeQuery;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.RemittanceType.Queries.GetAllListRemittanceTypeQuery
{
    public class GetAllListRemittanceTypeQueryHandler : IRequestHandler<GetAllRemittanceTypeQuery, Response<IEnumerable<RemittanceTypeDto>>>
    {
        private readonly IRemittanceTypeRepository _remittanceTypeRepository;
        private readonly IMapper _mapper;

        public GetAllListRemittanceTypeQueryHandler(IRemittanceTypeRepository remittanceTypeRepository, IMapper mapper)
        {
            _remittanceTypeRepository = remittanceTypeRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<RemittanceTypeDto>>> Handle(GetAllRemittanceTypeQuery request, CancellationToken cancellationToken)
        {
            var remittanceType = await _remittanceTypeRepository.ListAllAsync();
            var remittanceTypeDto = _mapper.Map<IEnumerable<RemittanceTypeDto>>(remittanceType);
            return new Response<IEnumerable<RemittanceTypeDto>>(remittanceTypeDto);
        }
    }
}
