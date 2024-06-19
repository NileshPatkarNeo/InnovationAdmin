using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Commands.CreatePharmacyType
{
    public class CreatePharmacyTypeCommand : IRequest<Response<CreatePharmacyTypeDto>>
    {
        public string Description { get; set; }
        public int Code { get; set; }
    }
}
