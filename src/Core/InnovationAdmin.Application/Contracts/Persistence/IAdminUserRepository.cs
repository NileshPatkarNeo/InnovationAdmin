using InnovationAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Contracts.Persistence
{
    public interface IAdminUserRepository : IAsyncRepository<Admin_User>
    {
        Task<List<Admin_User>> GetActiveAdminUsers();

        Task<Admin_User> AddAdminUser(Admin_User adminUser);

    }
}
