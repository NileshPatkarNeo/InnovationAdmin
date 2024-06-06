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

namespace InnovationAdmin.Application.Features.RemittanceType.Queries.GetRemittanceTypeQuery
{
    public class GetRemittanceTypeByIdQueryHandler : IRequestHandler<GetRemittanceTypeByIdQuery, Response<RemittanceTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRemittanceTypeRepository _remittanceTypeRepository;

        public GetRemittanceTypeByIdQueryHandler(IRemittanceTypeRepository remittanceTypeRepository, IMapper mapper)
        {
            _remittanceTypeRepository = remittanceTypeRepository;
            _mapper = mapper;
        }
        public async Task<Response<RemittanceTypeDto>> Handle(GetRemittanceTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var remittanceType = await _remittanceTypeRepository.GetByIdAsync(request.Id);

            if (remittanceType == null)
            {
                return new Response<RemittanceTypeDto>("Type not found.");
            }

            var Dto = _mapper.Map<RemittanceTypeDto>(remittanceType);
            return new Response<RemittanceTypeDto>(Dto);
        }
    }
}
