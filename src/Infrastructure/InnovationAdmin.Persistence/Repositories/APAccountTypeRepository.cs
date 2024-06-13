using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;


namespace InnovationAdmin.Persistence.Repositories
{
    public class APAccountTypeRepository : BaseRepository<APAccountType>, IAPAccountTypeRepository
    {
        private readonly ILogger _logger;


        public APAccountTypeRepository(ILogger<APAccountType> logger, ApplicationDbContext dbContext) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
