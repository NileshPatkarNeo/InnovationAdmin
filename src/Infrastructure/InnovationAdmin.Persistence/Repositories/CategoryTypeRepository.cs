using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;


namespace InnovationAdmin.Persistence.Repositories
{
    public class CategoryTypeRepository : BaseRepository<CategoryType>, ICategoryTypeRepository
    {
        private readonly ILogger _logger;


        public CategoryTypeRepository(ILogger<CategoryType> logger, ApplicationDbContext dbContext) : base(dbContext, logger)
        {
            _logger = logger;
        }
    
    }
}
