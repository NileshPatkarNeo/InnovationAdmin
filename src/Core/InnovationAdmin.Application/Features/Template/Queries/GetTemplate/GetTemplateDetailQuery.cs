using InnovationAdmin.Application.Features.Quote.Queries.GetQuote;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Template.Queries.GetTemplate
{
    public class GetTemplateDetailQuery : IRequest<Response<TemplateVM>>
    {
        public Guid ID { get; set; }
    }
  
}
