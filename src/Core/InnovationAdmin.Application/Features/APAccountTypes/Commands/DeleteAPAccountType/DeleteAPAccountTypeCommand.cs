using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.APAccountTypes.Commands.DeleteAPAccountType
{
    public class DeleteAPAccountTypeCommand : IRequest
    {
        public Guid ID { get; set; }

    }
}
