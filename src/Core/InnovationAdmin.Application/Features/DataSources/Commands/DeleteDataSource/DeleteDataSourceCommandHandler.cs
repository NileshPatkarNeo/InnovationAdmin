using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using MediatR;


namespace InnovationAdmin.Application.Features.DataSources.Commands.DeleteDataSource
{
    public class DeleteDataSourceCommandHandler : IRequestHandler<DeleteDataSourceCommand>
    {
        private readonly IDataSourceRepository _dataSourceRepository;

        public DeleteDataSourceCommandHandler(IDataSourceRepository dataSourceRepository)
        {
            _dataSourceRepository = dataSourceRepository;
        }

        public async Task<Unit> Handle(DeleteDataSourceCommand request, CancellationToken cancellationToken)
        {
            var dataSourceId = request.ID;
            var dataSourceIdToDelete = await _dataSourceRepository.GetByIdAsync(dataSourceId);
            if (dataSourceIdToDelete == null)
            {
                throw new NotFoundException(nameof(DataSources), dataSourceId);
            }
            await _dataSourceRepository.DeleteAsync(dataSourceIdToDelete);
            return Unit.Value;
            //throw new NotImplementedException();
        }
    }
}
