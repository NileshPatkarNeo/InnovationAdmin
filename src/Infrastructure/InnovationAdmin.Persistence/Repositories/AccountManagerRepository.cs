using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;


namespace InnovationAdmin.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class AccountManagerRepository : BaseRepository<AccountManager>, IAccountManagerRepository
    {

        private readonly ILogger _logger;
        public AccountManagerRepository(ApplicationDbContext dbContext, ILogger<AccountManager> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
