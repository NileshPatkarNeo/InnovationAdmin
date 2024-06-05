using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;


namespace InnovationAdmin.Persistence.Repositories
{
    public class DataSourceRepository : BaseRepository<DataSource>, IDataSourceRepository
    {
        private readonly ILogger _logger;


        public DataSourceRepository(ILogger<DataSource> logger, ApplicationDbContext dbContext) : base(dbContext, logger)
        {
            _logger = logger;
        }

    }
}
