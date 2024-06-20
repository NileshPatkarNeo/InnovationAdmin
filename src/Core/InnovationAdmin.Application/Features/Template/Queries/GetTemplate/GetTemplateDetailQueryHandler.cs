using AutoMapper;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Exceptions;
using InnovationAdmin.Application.Responses;
using InnovationAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Template.Queries.GetTemplate
{
    public class GetTemplateDetailQueryHandler : IRequestHandler<GetTemplateDetailQuery, Response<TemplateVM>>
    {
        private readonly IAsyncRepository<Templates> _templateRepository;
        private readonly IMapper _mapper;

        public GetTemplateDetailQueryHandler(IMapper mapper, IAsyncRepository<Templates> templateRepository)
        {
            _mapper = mapper;
            _templateRepository = templateRepository;
        }

        public async Task<Response<TemplateVM>> Handle(GetTemplateDetailQuery request, CancellationToken cancellationToken)
        {
            var template = await _templateRepository.GetByIdAsync(request.ID);

            if (template == null)
            {
                throw new NotFoundException(nameof(TemplateVM), request.ID);
            }

            var templateDetailDto = _mapper.Map<TemplateVM>(template);
            var response = new Response<TemplateVM>(templateDetailDto);
            return response;
        }
    }
}
