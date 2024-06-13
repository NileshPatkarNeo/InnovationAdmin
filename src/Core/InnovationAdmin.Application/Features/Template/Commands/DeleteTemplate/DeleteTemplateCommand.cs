using MediatR;
using System;

namespace InnovationAdmin.Application.Features.Template.Commands.DeleteTemplate
{
    public class DeleteTemplateCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
