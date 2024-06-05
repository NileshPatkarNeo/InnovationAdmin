using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.AccountManager.Commands.CreateAccountManager
{
    public class CreateAccountManagerCommand : IRequest<Response<CreateAccountManagerDto>>
    {
        
        public string Name { get; set; }
    }
}
