

using InnovationAdmin.Application.Contracts.Infrastructure;
using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InnovationAdmin.Persistence.Repositories
{
   
    public class SysPrefCompanyRepository : BaseRepository<SysPrefCompany>, ISysPrefCompanyRepository
    {
        private readonly ILogger _logger;
      
        public SysPrefCompanyRepository(ILogger<SysPrefCompany> logger, ApplicationDbContext dbContext ) : base(dbContext, logger)
        {
            _logger = logger;
        }

    }
}
