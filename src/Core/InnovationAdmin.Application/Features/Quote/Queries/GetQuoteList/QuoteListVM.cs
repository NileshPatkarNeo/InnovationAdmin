using System;

namespace InnovationAdmin.Application.Features.Quote.Queries.GetQuotesList
{
    public class QuoteListVM
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string QuoteBy { get; set; }
    }
}
