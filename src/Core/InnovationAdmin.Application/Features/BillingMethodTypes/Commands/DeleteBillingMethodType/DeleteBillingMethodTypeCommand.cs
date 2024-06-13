using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.BillingMethodTypes.Commands.DeleteBillingMethodType
{
    public class DeleteBillingMethodTypeCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
