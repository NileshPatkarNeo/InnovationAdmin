using InnovationAdmin.Application.Responses;
using MediatR;
using System;

namespace InnovationAdmin.Application.Features.Quote.Commands.UpdateQuote
{
    public class UpdateQuoteCommand : IRequest<Response<UpdateQuoteDto>>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string QuoteBy { get; set; }
    }
}
