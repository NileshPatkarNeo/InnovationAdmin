using InnovationAdmin.Application.Features.Quote.Queries.GetQuotesList;
using InnovationAdmin.Application.Features.Template.Queries.GetTemplatesList;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.Template.Queries.GetTemplateList
{
    public class GetTemplatesListQuery : IRequest<Response<IEnumerable<TemplateListVM>>>
    {
    }
}
