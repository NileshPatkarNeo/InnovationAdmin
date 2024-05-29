using InnovationAdmin.Application.Features.SysPrefFinancials.Queries.GetSysPrefFinancialList;
using InnovationAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Contracts.Persistence
{
    public interface ISysPrefFinancialRepository : IAsyncRepository<SysPrefFinancial>
    {
        Task<List<SysPrefFinancialListVM>> GetAllSysPrefFinancialWithCompanyDetails();
    }
}
