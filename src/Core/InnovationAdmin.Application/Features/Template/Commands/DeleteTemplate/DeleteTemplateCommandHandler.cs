using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Template.Commands.DeleteTemplate
{
    public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand>
    {
        private readonly ITemplateRepository _templateRepository;

        public DeleteTemplateCommandHandler(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task<Unit> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            var templateId = request.ID;
            var templateToDelete = await _templateRepository.GetByIdAsync(templateId);
            if (templateToDelete == null)
            {
                throw new NotFoundException(nameof(Template), templateId);
            }
            await _templateRepository.DeleteAsync(templateToDelete);
            return Unit.Value;
        }
    }
}
