    using AutoMapper;
    using InnovationAdmin.Application.Contracts.Persistence;
    using InnovationAdmin.Application.Exceptions;
    using InnovationAdmin.Application.Responses;
    using MediatR;


    namespace InnovationAdmin.Application.Features.AccountManager.Queries.GetAccountManagerById
    {
        public class GetAccountManagerByIdQueryHandler : IRequestHandler<GetAccountManagerByIdQuery, Response<AccountManagerDto>>
        {
            private readonly IMapper _mapper;
            private readonly IAccountManagerRepository _accountManagerRepository;

            public GetAccountManagerByIdQueryHandler(IMapper mapper, IAccountManagerRepository accountManagerRepository)
            {
                _mapper = mapper;
                _accountManagerRepository = accountManagerRepository;
            }

            public async Task<Response<AccountManagerDto>> Handle(GetAccountManagerByIdQuery request, CancellationToken cancellationToken)
            {
                var accountManager = await _accountManagerRepository.GetByIdAsync(request.Id);
                if (accountManager == null)
                {
                    throw new NotFoundException(nameof(AccountManager), request.Id);
                }

                var accountManagerDto = _mapper.Map<AccountManagerDto>(accountManager);

                return new Response<AccountManagerDto>(accountManagerDto, "Account manager retrieved successfully");
            }
        }
        }
