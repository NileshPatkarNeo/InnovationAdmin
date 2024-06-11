using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.DataSources.Commands.UpdateDataSource
{
    public class UpdateDataSourceCommandHandler : IRequestHandler<UpdateDataSourceCommand, Response<UpdateDataSourceCommandDto>>
    {
        private readonly IDataSourceRepository _dataSourceRepository;
        private readonly IMapper _mapper;

        public UpdateDataSourceCommandHandler(IMapper mapper, IDataSourceRepository dataSourceRepository)
        {
            _mapper = mapper;
            _dataSourceRepository = dataSourceRepository;

        }

        public async Task<Response<UpdateDataSourceCommandDto>> Handle(UpdateDataSourceCommand request, CancellationToken cancellationToken)
        {
            var dataSourceToUpdate = await _dataSourceRepository.GetByIdAsync(request.ID);

            if (dataSourceToUpdate == null)
            {
                throw new NotFoundException(nameof(DataSources), request.ID);
            }

            var validator = new UpdateDataSourceCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, dataSourceToUpdate);

            await _dataSourceRepository.UpdateAsync(dataSourceToUpdate);


            return new Response<UpdateDataSourceCommandDto>(_mapper.Map<UpdateDataSourceCommandDto>(dataSourceToUpdate), "Updated successfully ");

        }
    }
}
