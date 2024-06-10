using MediatR;
using System;

namespace InnovationAdmin.Application.Features.Quote.Commands.DeleteQuote
{
    public class DeleteQuoteCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
