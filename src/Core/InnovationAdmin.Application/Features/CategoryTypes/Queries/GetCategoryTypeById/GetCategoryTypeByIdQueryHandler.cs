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

namespace InnovationAdmin.Application.Features.CategoryTypes.Queries.GetCategoryTypeById
{
    public class GetCategoryTypeByIdQueryHandler : IRequestHandler<GetCategoryTypeByIdQuery, Response<GetCategoryTypeByIdVm>>
    {
        private readonly IAsyncRepository<CategoryType> _categoryType;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;
        public GetCategoryTypeByIdQueryHandler(IMapper mapper, IAsyncRepository<CategoryType> categoryType, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _categoryType = categoryType;
            _protector = provider.CreateProtector("");
        }

        public async Task<Response<GetCategoryTypeByIdVm>> Handle(GetCategoryTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var @system = await _categoryType.GetByIdAsync(new Guid(request.ID));
            var systemDto = _mapper.Map<GetCategoryTypeByIdVm>(system);

            if (@system == null)
            {
                throw new NotFoundException(nameof(GetCategoryTypeByIdVm), @system.ID);
            }

            var response = new Response<GetCategoryTypeByIdVm>(systemDto);
            return response;
        }
    }
}
