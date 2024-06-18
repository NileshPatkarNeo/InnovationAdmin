using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;

namespace InnovationAdmin.Application.Features.CategoryTypes.Commands.CreateCategoryType
{
    public class CreateCategoryTypeCommandHandler : IRequestHandler<CreateCategoryTypeCommand, Response<CreateCategoryTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        public CreateCategoryTypeCommandHandler(IMapper mapper, ICategoryTypeRepository categoryTypeRepository)
        {
            _mapper = mapper;
            _categoryTypeRepository = categoryTypeRepository;
        }

        public async Task<Response<CreateCategoryTypeDto>> Handle(CreateCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            Response<CreateCategoryTypeDto> createCategoryTypeCommandResponse = null;

            var validator = new CreateCategoryTypeValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var categoryType = _mapper.Map<CategoryType>(request);


                categoryType = await _categoryTypeRepository.AddAsync(categoryType);
                createCategoryTypeCommandResponse = new Response<CreateCategoryTypeDto>(_mapper.Map<CreateCategoryTypeDto>(categoryType), "success");
            }

            return createCategoryTypeCommandResponse;
        }
    }
}
