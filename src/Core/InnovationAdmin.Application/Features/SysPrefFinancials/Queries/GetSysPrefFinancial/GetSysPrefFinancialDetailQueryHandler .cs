using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.SysPrefFinancials.Queries.GetSysPrefFinancial
{
    public class GetSysPrefFinancialDetailQueryHandler : IRequestHandler<GetSysPrefFinancialDetailQuery, Response<SysPrefFinancialVM>>
    {
        private readonly IAsyncRepository<SysPrefFinancial> _sysPrefFinancialRepository;
        private readonly IMapper _mapper;

        public GetSysPrefFinancialDetailQueryHandler(
            IMapper mapper,
            IAsyncRepository<SysPrefFinancial> sysPrefFinancialRepository)
        {
            _mapper = mapper;
            _sysPrefFinancialRepository = sysPrefFinancialRepository;
        }

        public async Task<Response<SysPrefFinancialVM>> Handle(GetSysPrefFinancialDetailQuery request, CancellationToken cancellationToken)
        {
            var sysPrefFinancial = await _sysPrefFinancialRepository.GetByIdAsync(request.FinancialID);
            if (sysPrefFinancial == null)
            {
                throw new NotFoundException(nameof(SysPrefFinancial), request.FinancialID);
            }

            var sysPrefFinancialDetailDto = _mapper.Map<SysPrefFinancialVM>(sysPrefFinancial);
            var response = new Response<SysPrefFinancialVM>(sysPrefFinancialDetailDto);
            return response;
        }
    }
}
