using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InnovationAdmin.Persistence.Repositories
{
    public class ClaimStatusRepository: BaseRepository<ClaimStatus>, IClaimStatusRepository
    {
        private readonly ILogger _logger;

        public ClaimStatusRepository(ILogger<ClaimStatus> logger, ApplicationDbContext dbContext) : base(dbContext, logger)
        {
            _logger = logger;
        }

    }
}
