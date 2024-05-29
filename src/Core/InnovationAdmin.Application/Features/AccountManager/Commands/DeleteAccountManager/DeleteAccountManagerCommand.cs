using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AccountManager.Commands.DeleteAccountManager
{
    public class DeleteAccountManagerCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
}
