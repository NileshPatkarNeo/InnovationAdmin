using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Features.DataSources.Commands.DeleteDataSource;
using MediatR;


namespace InnovationAdmin.Application.Features.CategoryTypes.Commands.DeleteCategoryType
{
    public class DeleteCategoryTypeCommandHandler : IRequestHandler<DeleteCategoryTypeCommand>
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;

        public DeleteCategoryTypeCommandHandler(ICategoryTypeRepository categoryTypeRepository)
        {
            _categoryTypeRepository = categoryTypeRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            var categoryTypeId = request.ID;
            var categoryTypeIdToDelete = await _categoryTypeRepository.GetByIdAsync(categoryTypeId);
            if (categoryTypeIdToDelete == null)
            {
                throw new NotFoundException(nameof(CategoryTypes), categoryTypeId);
            }
            await _categoryTypeRepository.DeleteAsync(categoryTypeIdToDelete);
            return Unit.Value;
            //throw new NotImplementedException();
        }


    }
}
