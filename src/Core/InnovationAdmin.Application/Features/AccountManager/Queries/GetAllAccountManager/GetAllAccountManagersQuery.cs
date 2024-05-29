using InnovationAdmin.Application.Features.AccountManager.Queries.GetAccountManagerById;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AccountManager.Queries.GetAllAccountManager
{
    public class GetAllAccountManagersQuery : IRequest<Response<IEnumerable<AccountManagerDto>>>
    {
        // You can add any necessary properties or parameters here
    }
}
