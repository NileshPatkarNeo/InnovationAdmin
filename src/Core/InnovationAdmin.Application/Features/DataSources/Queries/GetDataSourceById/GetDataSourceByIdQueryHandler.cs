using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;


namespace InnovationAdmin.Application.Features.DataSources.Queries.GetDataSourceById
{
    public class GetDataSourceByIdQueryHandler : IRequestHandler<GetDataSourceByIdQuery, Response<GetDataSourceByIdVm>>
    {
        private readonly IAsyncRepository<DataSource> _dataSource;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;
        public GetDataSourceByIdQueryHandler(IMapper mapper, IAsyncRepository<DataSource> dataSource, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _dataSource = dataSource;
            _protector = provider.CreateProtector("");
        }

        public async Task<Response<GetDataSourceByIdVm>> Handle(GetDataSourceByIdQuery request, CancellationToken cancellationToken)
        {
            var @system = await _dataSource.GetByIdAsync(new Guid(request.ID));
            var systemDto = _mapper.Map<GetDataSourceByIdVm>(system);

            if (@system == null)
            {
                throw new NotFoundException(nameof(GetDataSourceByIdVm), @system.ID);
            }

            var response = new Response<GetDataSourceByIdVm>(systemDto);
            return response;
        }
    }
}
