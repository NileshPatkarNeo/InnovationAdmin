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

namespace InnovationAdmin.Application.Features.SysPrefCompanies.Queries.GetAllListSysPrefCompnayQuery
{
    class GetAllSysPrefCompaniesQueryHandler : IRequestHandler<GetAllSysPrefCompaniesQuery, Response<IEnumerable<SysPrefCompanyDto>>>
    {
        private readonly ISysPrefCompanyRepository _sysPrefCompanyRepository;
        private readonly IMapper _mapper;

        public GetAllSysPrefCompaniesQueryHandler(ISysPrefCompanyRepository sysPrefCompanyRepository, IMapper mapper)
        {
            _sysPrefCompanyRepository = sysPrefCompanyRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<SysPrefCompanyDto>>> Handle(GetAllSysPrefCompaniesQuery request, CancellationToken cancellationToken)
        {
            var sysPrefCompanies = await _sysPrefCompanyRepository.ListAllAsync();
            var sysPrefCompaniesDto = _mapper.Map<IEnumerable<SysPrefCompanyDto>>(sysPrefCompanies);
            return new Response<IEnumerable<SysPrefCompanyDto>>(sysPrefCompaniesDto);
        }
    }
}
