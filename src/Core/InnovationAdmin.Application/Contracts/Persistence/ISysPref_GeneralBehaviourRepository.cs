using InnovationAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Contracts.Persistence
{
    public interface ISysPref_GeneralBehaviourRepository : IAsyncRepository<SysPref_GeneralBehaviours>
    {
        Task<List<SysPref_GeneralBehaviours>> GetPreferencesWithDetails(bool includeInactivePreferences);
        Task<SysPref_GeneralBehaviours> AddPreference(SysPref_GeneralBehaviours preference);
    }
}


