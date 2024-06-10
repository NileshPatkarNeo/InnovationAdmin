using InnovationAdmin.Application.Features.PharmacyGroup.Commands.CreatePharmacyGroup;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.RemittanceType.Commands.CreateRemittanceType
{
    public class CreateRemittanceTypeCommand : IRequest<Response<CreateRemittanceTypeDto>>
    {
        public string Name { get; set; }
    }
}
