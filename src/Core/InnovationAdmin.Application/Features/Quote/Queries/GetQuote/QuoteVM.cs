using System;

namespace InnovationAdmin.Application.Features.Quote.Queries.GetQuote
{
    public class QuoteVM
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string QuoteBy { get; set; }
    }
}
