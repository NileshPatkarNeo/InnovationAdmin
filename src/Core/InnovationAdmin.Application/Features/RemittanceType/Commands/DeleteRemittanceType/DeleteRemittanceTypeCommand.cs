using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.RemittanceType.Commands.DeleteRemittanceType
{
    public class DeleteRemittanceTypeCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }

    }
}
