using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Template.Commands.UpdateTemplate
{
    public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateCommand, Response<UpdateTemplateDto>>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;
      

        public UpdateTemplateCommandHandler(IMapper mapper, ITemplateRepository templateRepository)
        {
            _mapper = mapper;
            _templateRepository = templateRepository;
            
        }

        public async Task<Response<UpdateTemplateDto>> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
        {
            var templateToUpdate = await _templateRepository.GetByIdAsync(request.ID);

            if (templateToUpdate == null)
            {
                throw new NotFoundException(nameof(UpdateTemplateDto), request.ID);
            }

            var validator = new UpdateTemplateCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, templateToUpdate);

            await _templateRepository.UpdateAsync(templateToUpdate);
            var dto = new UpdateTemplateDto
            {
                ID = request.ID,
                Name = request.Name,
                PdfTemplateFile = request.PdfTemplateFile,
                Domain = request.Domain,
                Size = request.Size
            };
            return new Response<UpdateTemplateDto>(dto, "Updated successfully");
        }
    }
}
