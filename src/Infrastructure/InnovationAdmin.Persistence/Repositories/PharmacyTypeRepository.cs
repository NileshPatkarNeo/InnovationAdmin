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
    public class PharmacyTypeRepository : BaseRepository<PharmacyType>,IPharmacyTypeRepository
    {
        private readonly ILogger _logger;

    public PharmacyTypeRepository(ILogger<PharmacyType> logger, ApplicationDbContext dbContext) : base(dbContext, logger)
    {
        _logger = logger;
    }
}
}
