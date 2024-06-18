﻿using InnovationAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Contracts.Persistence
{
    public interface IClaimStatusRepository : IAsyncRepository<ClaimStatus>
    {

    }
}
