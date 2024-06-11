using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;


namespace InnovationAdmin.Application.Features.DataSources.Commands.CreateDataSource
{
    public class CreateDataSourceCommandHandler : IRequestHandler<CreateDataSourceCommand, Response<CreateDataSourceDto>>
    {

        private readonly IMapper _mapper;
        private readonly IDataSourceRepository  _dataSourceRepository;
        public CreateDataSourceCommandHandler(IMapper mapper, IDataSourceRepository dataSourceRepository)
        {
            _mapper = mapper;
            _dataSourceRepository = dataSourceRepository;
        }

        public async Task<Response<CreateDataSourceDto>> Handle(CreateDataSourceCommand request, CancellationToken cancellationToken)
        {
            Response<CreateDataSourceDto> createDataSourceCommandResponse = null;

            var validator = new CreateDataSourceValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var dataSource = _mapper.Map<DataSource>(request);


                dataSource = await _dataSourceRepository.AddAsync(dataSource);
                createDataSourceCommandResponse = new Response<CreateDataSourceDto>(_mapper.Map<CreateDataSourceDto>(dataSource), "success");
            }

            return createDataSourceCommandResponse;
        }
    }
}
