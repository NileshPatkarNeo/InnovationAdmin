using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Persistence.Repositories
{
    public class ContractTermsRepository  : BaseRepository<ContractTerms>, IContractTermsRepository
    {
        private readonly ILogger _logger;
        public ContractTermsRepository(ApplicationDbContext dbContext, ILogger<ContractTerms> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
  
}
