using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AccountManager.Queries.GetAccountManagerById
{
    public class AccountManagerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Add other properties of the account manager as needed
    }
}
