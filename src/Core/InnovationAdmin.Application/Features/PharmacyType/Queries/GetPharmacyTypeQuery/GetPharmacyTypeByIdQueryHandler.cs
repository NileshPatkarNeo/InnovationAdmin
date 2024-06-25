using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;

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

            if (pharmacyType.IsDeleted)
            {
                var claimDto = _mapper.Map<PharmacyTypeDto>(pharmacyType);
                return new Response<PharmacyTypeDto>(claimDto);
            }
            else
            {
                return new Response<PharmacyTypeDto>("Pharmacy Type is inactive.");
            }


        }
    }
}
