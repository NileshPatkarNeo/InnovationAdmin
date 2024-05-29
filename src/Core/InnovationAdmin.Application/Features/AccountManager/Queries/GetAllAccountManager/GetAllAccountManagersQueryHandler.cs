using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.AccountManager.Queries.GetAccountManagerById;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AccountManager.Queries.GetAllAccountManager
{
    public class GetAllAccountManagersQueryHandler : IRequestHandler<GetAllAccountManagersQuery, Response<IEnumerable<AccountManagerDto>>>
    {
        private readonly IAccountManagerRepository _accountManagerRepository;
        private readonly IMapper _mapper;

        public GetAllAccountManagersQueryHandler(IAccountManagerRepository accountManagerRepository, IMapper mapper)
        {
            _accountManagerRepository = accountManagerRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<AccountManagerDto>>> Handle(GetAllAccountManagersQuery request, CancellationToken cancellationToken)
        {
            var accountManagers = await _accountManagerRepository.ListAllAsync();
            var accountManagerDtos = _mapper.Map<IEnumerable<AccountManagerDto>>(accountManagers);
            return new Response<IEnumerable<AccountManagerDto>>(accountManagerDtos, "Account managers retrieved successfully");
        }
    }

}
