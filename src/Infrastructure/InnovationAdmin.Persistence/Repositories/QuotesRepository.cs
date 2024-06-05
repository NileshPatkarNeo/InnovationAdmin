using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Persistence.Repositories
{
    public class QuotesRepository : BaseRepository<Quotes>, IQuotesRepository
    {
        private readonly ILogger _logger;
        public QuotesRepository(ApplicationDbContext dbContext, ILogger<Quotes> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
