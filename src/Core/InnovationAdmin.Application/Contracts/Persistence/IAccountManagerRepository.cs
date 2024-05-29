using InnovationAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Contracts.Persistence
{
    public interface IAccountManagerRepository : IAsyncRepository<AccountManager>
    {
    }
}
