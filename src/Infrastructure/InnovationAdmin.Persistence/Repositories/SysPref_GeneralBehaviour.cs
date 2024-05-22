using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InnovationAdmin.Persistence.Repositories
{

    [ExcludeFromCodeCoverage]
    public class SysPref_GeneralBehaviourRepository : BaseRepository<SysPref_GeneralBehaviours>, ISysPref_GeneralBehaviourRepository
        {

        private readonly ILogger _logger;
        public SysPref_GeneralBehaviourRepository(ApplicationDbContext dbContext, ILogger<SysPref_GeneralBehaviours> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<SysPref_GeneralBehaviours>> GetPreferencesWithDetails(bool includeInactivePreferences)
        {
            _logger.LogInformation(" Initiated");
            var allSysPref_GeneralBehaviour = await _dbContext.SysPref_GeneralBehaviour.ToListAsync();
           
            _logger.LogInformation("GetPreferencesWithDetails( Completed");
            return allSysPref_GeneralBehaviour;
        }

        public async Task<SysPref_GeneralBehaviours> AddPreference(SysPref_GeneralBehaviours sysPref_generalBehaviour)
        {
            //var categoryId = Guid.NewGuid();
            //List<SqlParameter> parms = new List<SqlParameter>
            //    {
            //        // Create parameter(s)
            //        new SqlParameter { ParameterName = "@CategoryId", Value = categoryId },
            //        new SqlParameter { ParameterName = "@Name", Value = category.Name },
            //    };
            //await StoredProcedureCommandAsync("CreateCategory", parms.ToArray());
            //category = await GetByIdAsync(categoryId);
            return sysPref_generalBehaviour;
        }
    }

}
