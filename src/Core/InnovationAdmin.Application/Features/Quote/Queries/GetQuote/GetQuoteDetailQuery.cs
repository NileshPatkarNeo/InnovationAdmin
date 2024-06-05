using InnovationAdmin.Application.Responses;
using MediatR;
using System;

namespace InnovationAdmin.Application.Features.Quote.Queries.GetQuote
{
    public class GetQuoteDetailQuery : IRequest<Response<QuoteVM>>
    {
        public Guid ID { get; set; }
    }
}
