using InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.RemittanceType.Commands.UpdateRemittanceType
{
    public class UpdateRemittanceTypeCommand : IRequest<Response<UpdateRemittanceTypeDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
