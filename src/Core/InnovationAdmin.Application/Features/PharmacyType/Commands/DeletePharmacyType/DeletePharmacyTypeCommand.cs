using InnovationAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovationAdmin.Application.Features.PharmacyType.Commands.DeletePharmacyType
{
    public class DeletePharmacyTypeCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}
