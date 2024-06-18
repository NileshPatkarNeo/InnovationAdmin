using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using MediatR;


namespace InnovationAdmin.Application.Features.CategoryTypes.Commands.UpdateCategoryType
{
    public class UpdateCategoryTypeCommandHandler : IRequestHandler<UpdateCategoryTypeCommand, Response<UpdateCategoryTypeCommandDto>>
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryTypeCommandHandler(IMapper mapper, ICategoryTypeRepository categoryTypeRepository)
        {
            _mapper = mapper;
            _categoryTypeRepository = categoryTypeRepository;

        }

        public async Task<Response<UpdateCategoryTypeCommandDto>> Handle(UpdateCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            var categoryTypeToUpdate = await _categoryTypeRepository.GetByIdAsync(request.ID);

            if (categoryTypeToUpdate == null)
            {
                throw new NotFoundException(nameof(CategoryTypes), request.ID);
            }

            var validator = new UpdateCategoryTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, categoryTypeToUpdate);

            await _categoryTypeRepository.UpdateAsync(categoryTypeToUpdate);


            return new Response<UpdateCategoryTypeCommandDto>(_mapper.Map<UpdateCategoryTypeCommandDto>(categoryTypeToUpdate), "Updated successfully ");

        }

    }
}
