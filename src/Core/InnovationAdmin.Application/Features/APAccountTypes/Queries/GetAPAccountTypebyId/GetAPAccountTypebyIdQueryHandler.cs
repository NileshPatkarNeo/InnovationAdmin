using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceById;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.APAccountTypes.Queries.GetAPAccountTypebyId
{
    public class GetAPAccountTypebyIdQueryHandler : IRequestHandler<GetAPAccountTypebyIdQuery, Response<GetAPAccountTypebyIdVm>>
    {
        private readonly IAsyncRepository<APAccountType> _accountType;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;
        public GetAPAccountTypebyIdQueryHandler(IMapper mapper, IAsyncRepository<APAccountType> accountType, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _accountType = accountType;
            _protector = provider.CreateProtector("");
        }

        public async Task<Response<GetAPAccountTypebyIdVm>> Handle(GetAPAccountTypebyIdQuery request, CancellationToken cancellationToken)
        {
            var @system = await _accountType.GetByIdAsync(new Guid(request.ID));
            var systemDto = _mapper.Map<GetAPAccountTypebyIdVm>(system);

            if (@system == null)
            {
                throw new NotFoundException(nameof(GetAPAccountTypebyIdVm), @system.ID);
            }

            var response = new Response<GetAPAccountTypebyIdVm>(systemDto);
            return response;
        }

    }
}
