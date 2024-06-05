using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Queries.GetSysPrefFinancialList
{
    public class GetSysPrefFinancialsListQueryHandler : IRequestHandler<GetSysPrefFinancialsListQuery, Response<IEnumerable<SysPrefFinancialListVM>>>
    {
        private readonly ISysPrefFinancialRepository _sysPrefFinancialRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetSysPrefFinancialsListQueryHandler> _logger;
        

        public GetSysPrefFinancialsListQueryHandler(
            IMapper mapper,
            ISysPrefFinancialRepository sysPrefFinancialRepository,
            ILogger<GetSysPrefFinancialsListQueryHandler> logger)
        {
            _mapper = mapper;
            _sysPrefFinancialRepository = sysPrefFinancialRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<SysPrefFinancialListVM>>> Handle(GetSysPrefFinancialsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allSysPrefFinancials = (await _sysPrefFinancialRepository.GetAllSysPrefFinancialWithCompanyDetails()).OrderBy(x => x.ClaimAgeCollectionStart);
            _logger.LogInformation("Handle Completed");
            return new Response<IEnumerable<SysPrefFinancialListVM>>(allSysPrefFinancials, "success");
        }
    }
}
