using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetSysPrefCompanyQuery
{
    public class GetSysPrefCompanyByIdQueryHandler : IRequestHandler<GetSysPrefCompanyByIdQuery, Response<SysPrefCompanyDto>>
    {
        private readonly ISysPrefCompanyRepository _sysPrefCompanyRepository;
        private readonly IMapper _mapper;

        public GetSysPrefCompanyByIdQueryHandler(ISysPrefCompanyRepository sysPrefCompanyRepository, IMapper mapper)
        {
            _sysPrefCompanyRepository = sysPrefCompanyRepository;
            _mapper = mapper;
        }

        public async Task<Response<SysPrefCompanyDto>> Handle(GetSysPrefCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var sysPrefCompany = await _sysPrefCompanyRepository.GetByIdAsync(request.CompanyID);

            if (sysPrefCompany == null)
            {
                return new Response<SysPrefCompanyDto>("Company not found.");
            }

            var sysPrefCompanyDto = _mapper.Map<SysPrefCompanyDto>(sysPrefCompany);
            return new Response<SysPrefCompanyDto>(sysPrefCompanyDto);
        }
    }
}
