using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Application.Features.SysPrefFinancials.Queries.GetSysPrefFinancialList;
using InnovationAdmin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Persistence.Repositories
{
    public class SysPrefFinancialRepository : BaseRepository<SysPrefFinancial>, ISysPrefFinancialRepository
    {
        private readonly ILogger _logger;
        public SysPrefFinancialRepository(ApplicationDbContext dbContext, ILogger<SysPrefFinancial> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<SysPrefFinancialListVM>> GetAllSysPrefFinancialWithCompanyDetails()
        {
            var data = await this._dbContext.SysPrefFinancials.Include(x => x.Company).Select(x => new SysPrefFinancialListVM() { CompanyID = x.CompanyID, CompanyName = x.Company.CompanyName, ClaimAgeCollectionEnd = x.ClaimAgeCollectionEnd, ClaimAgeCollectionStart = x.ClaimAgeCollectionEnd, ClaimPaidThreshold = x.ClaimPaidThreshold, ClaimStatusWriteOff = x.ClaimStatusWriteOff, DaysToBlock = x.DaysToBlock, DefaultPaymentMethod = x.DefaultPaymentMethod, DefaultReceiptBatchDescription = x.DefaultReceiptBatchDescription, FinancialID = x.FinancialID, LastCheckNo = x.LastCheckNo }).ToListAsync();
            return data;
        }

    }
}
