using InnovationAdmin.Application.Features.PharmacyGroup.Commands.UpdatePharmacyGroup;
using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Commands.UpdatePharmacyType
{
    public class UpdatePharmacyTypeCommand : IRequest<Response<UpdatePharmacyTypeDto>>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
    }
}
