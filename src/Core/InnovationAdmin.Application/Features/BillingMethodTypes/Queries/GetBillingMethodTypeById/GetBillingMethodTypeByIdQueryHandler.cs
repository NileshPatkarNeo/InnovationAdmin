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

namespace InnovationAdmin.Application.Features.BillingMethodTypes.Queries.GetBillingMethodTypeById
{
    public class GetBillingMethodTypeByIdQueryHandler : IRequestHandler<GetBillingMethodTypeByIdQuery, Response<GetBillingMethodTypeByIdVm>>
    {
        private readonly IAsyncRepository<BillingMethodType> _billingMethod;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;
        public GetBillingMethodTypeByIdQueryHandler(IMapper mapper, IAsyncRepository<BillingMethodType> billingMethod, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _billingMethod = billingMethod;
            _protector = provider.CreateProtector("");
        }


        public async Task<Response<GetBillingMethodTypeByIdVm>> Handle(GetBillingMethodTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var @system = await _billingMethod.GetByIdAsync(new Guid(request.ID));
            var systemDto = _mapper.Map<GetBillingMethodTypeByIdVm>(system);

            if (@system == null)
            {
                throw new NotFoundException(nameof(GetBillingMethodTypeByIdVm), @system.ID);
            }

            var response = new Response<GetBillingMethodTypeByIdVm>(systemDto);
            return response;
        }
    }
}
