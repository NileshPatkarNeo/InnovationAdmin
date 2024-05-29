using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AccountManager.Queries.GetAccountManagerById
{
    public class GetAccountManagerByIdQuery : IRequest<Response<AccountManagerDto>>
    {
        public Guid Id { get; }

        public GetAccountManagerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
