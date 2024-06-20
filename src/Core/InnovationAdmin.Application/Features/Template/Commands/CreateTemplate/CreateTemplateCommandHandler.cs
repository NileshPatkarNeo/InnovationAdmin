
using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;

namespace InnovationAdmin.Application.Features.Template.Commands.CreateTemplate
{
    public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, Response<CreateTemplateDto>>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public CreateTemplateCommandHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateTemplateDto>> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTemplateCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var template = new Templates
            {
                ID = Guid.NewGuid(),
                Name = request.Name,
                PdfTemplateFile = request.PdfTemplateFile,
                Domain = request.Domain,
                Size = request.Size
            };

            template = await _templateRepository.AddAsync(template);

            var response = new Response<CreateTemplateDto>(_mapper.Map<CreateTemplateDto>(template), "success");

            return response;
        }
    }
}
